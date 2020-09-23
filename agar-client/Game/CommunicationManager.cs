using agar_client.Game;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace agar_client
{
	class CommunicationManager
	{
        public const string SERVER_URL = "https://localhost:44372";

		public static CommunicationManager Instance;

        public event BasicDelegate ConnectedSuccessfully;
        public event BasicDelegate ConnectionLost;

        HubConnection connection;


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
                if (ConnectionLost != null)
                    ConnectionLost.Invoke();
                Logger.Log("CONNECTION LOST");
                await Task.Delay(new Random().Next(0, 5) * 1000);
				await connection.StartAsync();
            };
            connection.Reconnected += async (connectionId) =>
            {
                Logger.Log("RECONNECTED");
            };

            //connect(); // TODO
		}

        private async void connect(/*object sender, RoutedEventArgs e*/)
        {
            connection.On<string>("ReceiveMessage", message =>
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

			try
			{
				await connection.StartAsync();
                //messagesList.Items.Add("Connection started");
                //connectButton.IsEnabled = false;
                //sendButton.IsEnabled = true;

                //Debug.WriteLine("SUCCESSFULLY CONNECTED");
                //MainWindow.Log()
                Logger.Log("CONNECTION ESTABLISHED to " + SERVER_URL);
                if (ConnectedSuccessfully != null)
					ConnectedSuccessfully.Invoke();
			}
			catch (Exception ex)
			{
                //messagesList.Items.Add(ex.Message);
                Debug.WriteLine($"CONNECTION FAILED: {ex.Message}");
			}
		}

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

        public async void sendMessage(string message)
		{
            Debug.WriteLine($"Sending: {message}");
            await connection.InvokeAsync("SendMessage", message);
		}
    }
}
