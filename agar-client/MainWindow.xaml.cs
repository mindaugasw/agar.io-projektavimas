using agar_client.Game;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

public delegate void BasicDelegate();
public delegate void StringDelegate(string str);

namespace agar_client
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public static MainWindow Instance;

		public event StringDelegate ArrowKeysInput;

		public MainWindow()
		{
			if (Instance == null)
				Instance = this;
			else
				throw new Exception();

			InitializeComponent();

			new Logger(logTextBox);
			Logger.Log("Initialized main window.");
		}

		void ProcessMovementInput(object sender, ExecutedRoutedEventArgs args)
		{
			if (ArrowKeysInput != null)
				ArrowKeysInput.Invoke(args.Parameter.ToString());
		}

		private void connectButton_Click(object sender, RoutedEventArgs e)
		{
			new GameManager(this);
			CommunicationManager.Instance.ConnectedSuccessfully += OnConnectionEstablished;
			CommunicationManager.Instance.ConnectionLost += OnConnectionLost;

			connectButton.Content = "Starting...";
			connectButton.IsEnabled = false;
		}

		private void OnConnectionEstablished()
		{
			connectButton.Content = "Game in progress";
			connectButton.IsEnabled = false;
		}

		private void OnConnectionLost()
		{
			//connectButton.Content = "";
			//connectButton.IsEnabled = true;
		}
	}
}
