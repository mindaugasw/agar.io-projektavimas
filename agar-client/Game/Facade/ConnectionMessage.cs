using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.SignalR.Client;

namespace agar_client.Game.Objects
{
	class ConnectionMessage
	{
        HubConnection connection;

        CheckConnection checkConnection;
		public ConnectionMessage(HubConnection connection) 
		{
            this.connection = connection;
            this.checkConnection = new CheckConnection(connection);
		}

        public async void SendMessage(string methodName, object arg1)
        {

            if (checkConnection.IsConnected())
            {
                Debug.WriteLine($"{methodName}: {arg1}");
                await connection.InvokeAsync(methodName, arg1);
            }
            else
                throw new Exception();
        }

        public async void SendMessage(string methodName, object arg1, object arg2)
        {

            if (checkConnection.IsConnected())
            {
                Debug.WriteLine($"{methodName}: {arg1}, {arg2}");
                await connection.InvokeAsync(methodName, arg1, arg2);
            }
            else
                throw new Exception();
        }

        public async void SendMessage(string methodName, object arg1, object arg2, object arg3)
        {

            if (checkConnection.IsConnected())
            {
                Debug.WriteLine($"{methodName}: {arg1}, {arg2}, {arg3}");
                await connection.InvokeAsync(methodName, arg1, arg2, arg3);
            }
            else
                throw new Exception();
        }

        public async void SendMessage(string methodName, object arg1, object arg2, object arg3, object arg4)
        {

            if (checkConnection.IsConnected())
            {
                Debug.WriteLine($"{methodName}: {arg1}, {arg2}, {arg3}, {arg4}");
                await connection.InvokeAsync(methodName, arg1, arg2, arg3, arg4);
            }
            else
                throw new Exception();
        }

        public async void SendMessage(string methodName, object arg1, object arg2, object arg3, object arg4, object arg5)
        {

            if (checkConnection.IsConnected())
            {
                Debug.WriteLine($"{methodName}: {arg1}, {arg2}, {arg3}, {arg4}, {arg5}");
                await connection.InvokeAsync(methodName, arg1, arg2, arg3, arg4, arg5);
            }
            else
                throw new Exception();
        }

        public async void SendMessage(string methodName, object arg1, object arg2, object arg3, object arg4, object arg5, object arg6)
        {

            if (checkConnection.IsConnected())
            {
                Debug.WriteLine($"{methodName}: {arg1}, {arg2}, {arg3}, {arg4}, {arg5}, {arg6}");
                await connection.InvokeAsync(methodName, arg1, arg2, arg3, arg4, arg5, arg6);
            }
            else
                throw new Exception();
        }
	}
}