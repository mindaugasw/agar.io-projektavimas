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

        private async Task connect(/*object sender, RoutedEventArgs e*/)
        {
            connection.On("ReceiveMessage", (string message) =>
            {
                GameManager.MainWindow.Dispatcher.Invoke(() =>
                {
                    //var newMessage = $"Received: user: {user}, msg: {message}";
                    //var newMessage = message;
                    //messagesList.Items.Add(newMessage);
                    //Debug.WriteLine(newMessage);
                    
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
                    Debug.WriteLine("sda");
					//Debug.WriteLine($"New player receive. ID: {id}, {position}");
					//GameManager.Instance.CreatePlayer(id, position);
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

            /*connection.On("AnnounceNewPlayer", (MapObject obj) =>
            {
                GameManager.MainWindow.Dispatcher.Invoke(() =>
                {
                    //Logger.Log("New player receive: " + id);
                    GameManager.Instance.CreatePlayer(obj.Id, obj.Position);
                });
            });

            connection.On("MoveObject", (MapObject obj) =>
            {
                GameManager.MainWindow.Dispatcher.Invoke(() =>
                {
                    //Logger.Log($"Move receive: {id} @ {position}");
                    GameManager.Instance.MovePlayer(obj.Id, obj.Position);
                });
            });*/


            try
			{
				await connection.StartAsync();
                //messagesList.Items.Add("Connection started");
                //connectButton.IsEnabled = false;
                //sendButton.IsEnabled = true;

                //Debug.WriteLine("SUCCESSFULLY CONNECTED");
                //MainWindow.Log()
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


        /*public async void AnnounceNewPlayer(MapObject newPlayer)
        {
            await connect();

            if (connected)
            {
                Debug.WriteLine($"New player send. ID: {newPlayer.Id}, X: {newPlayer.Position.X}, Y: {newPlayer.Position.Y}");
                connection.InvokeAsync("AnnounceNewPlayer", newPlayer);
            }
            else
                throw new Exception();
        }

        public async void MoveObject(MapObject obj)
        {
            if (connected)
            {
                Debug.WriteLine($"Move send. ID: {obj.Id}, {obj.Position}");
                connection.InvokeAsync("MoveObject", obj);
            }
            else
                throw new Exception();
        }*/

        /*private async void sendButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await connection.InvokeAsync("SendMessage",
                    userTextBox.Text, messageTextBox.Text);
            }
            catch (Exception ex)
            {
                messagesList.Items.Add(ex.Message);
            }
        }*/

        /*public async void sendMessage(string message)
		{
            Debug.WriteLine($"Sending: {message}");
            await connection.InvokeAsync("SendMessage", message);
		}*/
    }
}
