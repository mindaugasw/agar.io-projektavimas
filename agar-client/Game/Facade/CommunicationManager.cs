﻿using agar_client.Game;
using agar_client.Game.Objects;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static agar_client.Game.Utils;

namespace agar_client
{
	public class CommunicationManager
	{
        // FIELDS
        public readonly string SERVER_URL;

		public event BasicDelegate ConnectedSuccessfully;
        public event BasicDelegate ConnectionLost;

        static CommunicationManager instance;
        static object threadLock = new object();

        HubConnection connection;
        bool connected = false;

        ConnectionMessage connectionMessage;

        // PROPERTIES
        public static CommunicationManager Instance // Design pattern #1.2 Singleton
		{
            get
			{
                lock(threadLock)
				{
                    if (instance == null)
                    {
                        instance = new CommunicationManager();
                        Logger.Log("CommunicationManager successfully created using Singleton.");
                    }
				}
                return instance;
			}
		}

        public CommunicationManager()
		{
            /*if (Instance == null)
				Instance = this;
			else
				throw new Exception();*/
            SERVER_URL = ConfigManager.Get<string>("serverUrl");

			connection = new HubConnectionBuilder()
				.WithUrl(SERVER_URL+"/gamehub")
				.Build();

            connectionMessage = new ConnectionMessage(connection);

            connection.Closed += async (error) =>
            {
                connected = false;
                if (ConnectionLost != null)
                    ConnectionLost.Invoke();
                Logger.Log("CONNECTION LOST");
                await Task.Delay(new Random().Next(0, 5) * 1000);
	            await connection.StartAsync();
            };
            connection.Reconnected += async (connectionId) =>
            {
                connected = true;
                Logger.Log("RECONNECTED");
            };
        }

        // --- RECEIVING METHODS ---

        private async Task connect()
        {
            connection.On("ReceiveMessage", (string message) =>
            {
                MainWindow.Instance.Dispatcher.Invoke(() =>
                {
                    Logger.Log("Received message: " + message);
				});
            });

            connection.On("AnnounceNewPlayer", (string id, Point position) =>
            {
                MainWindow.Instance.Dispatcher.Invoke(() =>
                {
                    Logger.Log($"New player joined, Id: {id}");
                    GameManager.Instance.CreatePlayer(id, position);
                });
            });

            connection.On("GetGameState", (string[] ids, Point[] positions) =>
            {
                MainWindow.Instance.Dispatcher.Invoke(() =>
                {
                    Logger.Log($"Received game state: {ids.Length} other players currently in-game");
                    for (int i = 0; i < ids.Length; i++)
                        GameManager.Instance.CreatePlayer(ids[i], positions[i]);
                    if (ids.Length == 0)
                    {
                        GameManager.Instance.CreateFoodObjects();
                        GameManager.Instance.CreateVirusObjects();
                        GameManager.Instance.CreatePoisonObjects();
                        GameManager.Instance.SendMapObjects();
                    }

                });
            });

            connection.On("MoveObject", (string id, Point position) =>
            {
                MainWindow.Instance.Dispatcher.Invoke(() =>
                {
                    Debug.WriteLine($"Move receive. ID: {id}, {position}");
                    GameManager.Instance.MovePlayer(id, position);
                });
            });

            connection.On("ReceiveMapObjects", (string[] ids, string[] mapObjectNames, Point[] positions) =>
            {
                MainWindow.Instance.Dispatcher.Invoke(() =>
                {
                    Debug.WriteLine("Received map objects.");
                    GameManager.Instance.ReceiveMapObjects(ids, mapObjectNames, positions);
                });
            });

            // --- CONNECTING ---

            try
            {
                await connection.StartAsync();
                connected = true;

                Logger.Log("CONNECTION ESTABLISHED to " + SERVER_URL);
                if (ConnectedSuccessfully != null)
                    ConnectedSuccessfully.Invoke();
			}
			catch (Exception ex)
			{
                connected = false;
                Debug.WriteLine($"CONNECTION FAILED: {ex.Message}");
			}
		}

        // --- SENDING METHODS ---

        public async void AnnounceNewPlayer(string id, Point position)
        {
            await connect();
            connectionMessage.SendMessage("AnnounceNewPlayer", id, position);
        }

        public async void GetGameState(string localPlayerId)
		{
            connectionMessage.SendMessage("GetGameState", localPlayerId);
        }

        public async void MoveObject(string id, Point position)
        {
            connectionMessage.SendMessage("MoveObject", id, position);
        }

        public async void CreateMapObjects(string[] ids, string[] mapObjectNames, Point[] positions) 
        {
            connectionMessage.SendMessage("CreateMapObjects", ids, mapObjectNames, positions);
        }
    }
}
