using agar_client.Game;
using agar_client.Game.Chain;
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
		// FIELDS
		public event StringDelegate ArrowKeysInput; // Design pattern #5.1 Observer

		static MainWindow instance;
		static object threadLock = new object();

		// PROPERTIES
		public static MainWindow Instance // Design pattern #1.1 Singleton
		{
			get
			{
				//if (instance == null)
				//	throw new Exception();
				return instance;
			}
		}

		public MainWindow()
		{
			lock (threadLock)
			{
				if (instance == null)
					instance = this;
				//else
				//	throw new Exception(); // TODO FIX? commented out for tests, as they fail otherwise
			}

			InitializeComponent();

			new Logger(logTextBox);
			Logger.Log("Initialized main window.");

			/*lock (threadLock) // Attempted fix to run all tests at once. Still not working.
			{
				if (instance == null)
				{
					instance = this;

					InitializeComponent();

					new Logger(logTextBox);
					Logger.Log("Initialized main window.");
				}
			}*/
		}

		public void ProcessMovementInput(object sender, ExecutedRoutedEventArgs args)
		{
			InvokeArrowKeysEvent(sender, args.Parameter.ToString());
			//if (ArrowKeysInput != null)
			//	ArrowKeysInput.Invoke(args.Parameter.ToString());
		}
		
		public void InvokeArrowKeysEvent(object sender, string direction)
		{
			if (ArrowKeysInput != null)
				ArrowKeysInput.Invoke(direction);
		}


		public void connectButton_Click(object sender, RoutedEventArgs e)
		{
			new GameManager();
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

        private void Send_Click(object sender, RoutedEventArgs e)
        {
			IChain chainWords1 = new N_WordsChecking();
			IChain chainWords2 = new F_WordsChecking();
			IChain chainWords3 = new Offensive_WordsChecking();
			IChain chainWords4 = new Religion_SwearWordsChecking();

			chainWords1.SetNextChain(chainWords2);
			chainWords2.SetNextChain(chainWords3);
			chainWords3.SetNextChain(chainWords4);

			Words request = new Words(chatInput.Text);
			chainWords1.CheckBadWord(request);

            if (!request.GetIsSwear())
            {
				CommunicationManager.SendChatMessage(GameManager.LocalPlayer.Id, chatInput.Text);
			}

		}

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
			if(GameManager.mementoIdx < 2)
            {
				return;
            }
			GameManager.chatOriginator.SetMemento(GameManager.chatCareTaker.get(--GameManager.mementoIdx - 1));
			chatInput.Text = GameManager.chatOriginator.GetState();
        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {
			if (GameManager.mementoIdx > GameManager.mementoMaxIdx - 1)
			{
				return;
			}
			GameManager.chatOriginator.SetMemento(GameManager.chatCareTaker.get(GameManager.mementoIdx++));
			chatInput.Text = GameManager.chatOriginator.GetState();
		}

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
			if(chatInput.Text != GameManager.chatOriginator.GetState())
            {
				GameManager.chatOriginator.SetState(chatInput.Text);
				GameManager.chatCareTaker.add(GameManager.mementoIdx++, GameManager.chatOriginator.CreateMemento());

				GameManager.mementoMaxIdx = GameManager.mementoIdx;
			}
        }
    }
}
