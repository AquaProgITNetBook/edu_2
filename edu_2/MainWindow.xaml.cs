using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HelpfulMethods.Extentions;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace edu_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Label[] players_Labels = new Label[4];
        public static List<Player> players = new List<Player>();
        public MainWindow()
        {
            InitializeComponent();
            players_Labels.InitializeArray(player1_Label, player2_Label, player3_Label, player4_Label);
            players.AddElemsCollection(new Player("Max"), new Player("Vlad"));
            players[0].Move("asfsdgsdgsdgasgsssssssssssssssssssssssssssssssssssssssssss");
            players[0].Move("fdsffffffffffffffffffffffffffffffffffff");
            MessageBox.Show(players[0].wordsFromPlayer.Count.ToString());
            MessageBox.Show(players[0].BigestWord());
        }
        private void NewUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && NewUserName.Text != "")
            {
                players.Add(new Player(NewUserName.Text));
            }
        }
    }
    public class Player    
    {
        private static byte players_count = 0;
        public int Score;
        public string Name { get; }
        private Label myLabel;
        public List<string> wordsFromPlayer;
        public Player(string name)
        {
            Name = name[0].ToString().ToUpper() + name.Remove(0,1);
            Score = 0;
            wordsFromPlayer = new List<string>();
            myLabel = MainWindow.players_Labels[players_count++];
        }
        public void Move (string word)
        {
            wordsFromPlayer.Add(word);
        }
        public string BigestWord()
        {
            wordsFromPlayer.OrderByDescending(x => x.Length);
            return wordsFromPlayer.Last();
        }
    }
}
