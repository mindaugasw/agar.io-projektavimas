using agar_client.Game;
using agar_client.Game.Objects;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using static agar_client.Game.Utils;

namespace agar_client
{
	class CommunicationManager
	{
        public const string SERVER_URL = "https://localhost:44372";

		public static CommunicationManager Instance;

        public event BasicDelegate ConnectedSuccessfully;
        public event BasicDelegate ConnectionLost;

        HubConnection connection;
        bool connected = false;

        public CommunicationManager()
		{
			if (Instance == null)
				Instance = this;
			else
				throw new Exception();

			connection = new HubConnectionBuilder()
				.WithUrl(SERVER_URL+"/gamehub")
				.Build();

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
                GameManager.MainWindow.Dispatcher.Invoke(() =>
                {
                    Logger.Log("Received message: " + message);
				});
            });

            connection.On("AnnounceNewPlayer", (string id, Point position) =>
            {
                GameManager.MainWindow.Dispatcher.Invoke(() =>
                {
                    Debug.WriteLine($"New player receive. ID: {id}, {position}");
                    GameManager.Instance.CreatePlayer(id, position);
                });
            });

            connection.On("GetGameState", (int[] x) =>
            {
                GameManager.MainWindow.Dispatcher.Invoke(() =>
                {
                    //Debug.WriteLine("get game state");
                });
            });

            connection.On("MoveObject", (string id, Point position) =>
            {
                GameManager.MainWindow.Dispatcher.Invoke(() =>
                {
                    Debug.WriteLine($"Move receive. ID: {id}, {position}");
                    GameManager.Instance.MovePlayer(id, position);
                });
            });

            // --- CONNECTING ---

            try
            {
				await connection.StartAsync();
                connected = true;
                //GetGameState(LocalPlayer.Instance.Id);

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

            if (connected)
            {
                Debug.WriteLine($"New player send. ID: {id}, {position}");
                connection.InvokeAsync("AnnounceNewPlayer", id, position);
            }
            else
                throw new Exception();
        }

        public async void GetGameState(string localPlayerId)
		{
            if (connected)
            {
                Debug.WriteLine($"Getting game state");
                connection.InvokeAsync("GetGameState", localPlayerId);
            }
            else
                throw new Exception();
        }

        public async void MoveObject(string id, Point position)
        {
            if (connected)
            {
                Debug.WriteLine($"Move send. ID: {id}, {position}");
                connection.InvokeAsync("MoveObject", id, position);
            }
            else
                throw new Exception();
        }
    }
}
