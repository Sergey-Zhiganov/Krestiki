using System;
using System.Collections.Generic;
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

namespace Крестики
{
    public partial class MainWindow : Window
    {
        string player = "O";
        string bot = "X";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            button.Content = player;
            button.IsEnabled = false;
            int check = Win_Check(player);
            if (check == 0)
            {
                Move(check);
            }
        }
        private void Move(int check)
        {
            Button[] buttons = { _1, _2, _3, _4, _5, _6, _7, _8, _9 };
            Random random = new Random();
            while (check == 0)
            {
                int move = random.Next(0, 9);
                Button current_button = buttons[move];
                if (current_button.IsEnabled == true)
                {
                    current_button.Content = bot;
                    current_button.IsEnabled = false;
                    Win_Check(bot);
                    break;
                }
            }
        }
        private int Win_Check(string step)
        {
            int check = 0;
            string[] positions = { (string)_1.Content, (string)_2.Content, (string)_3.Content,
            (string)_4.Content, (string)_5.Content, (string)_6.Content, (string)_7.Content,
            (string)_8.Content, (string)_9.Content,};
            if ((positions[0] == step && positions[1] == step && positions[2] == step) ||
                (positions[3] == step && positions[4] == step && positions[5] == step) ||
                (positions[6] == step && positions[7] == step && positions[8] == step) ||
                (positions[0] == step && positions[3] == step && positions[6] == step) ||
                (positions[1] == step && positions[4] == step && positions[7] == step) ||
                (positions[2] == step && positions[5] == step && positions[8] == step) ||
                (positions[0] == step && positions[4] == step && positions[8] == step) ||
                (positions[6] == step && positions[4] == step && positions[2] == step))
            {
                check = 1;
            }
            else if (positions[0] != "" && positions[1] != "" && positions[2] != "" &&
                positions[3] != "" && positions[4] != "" && positions[5] != "" &&
                positions[6] != "" && positions[7] != "" && positions[8] != "")
            {
                check = 2;
            }
            if (check > 0)
            {
                if (check == 1)
                {
                    Message.Content = $"Победил {step}";
                }
                else
                {
                    Message.Content = "Ничья";
                }
                _1.IsEnabled = false;
                _2.IsEnabled = false;
                _3.IsEnabled = false;
                _4.IsEnabled = false;
                _5.IsEnabled = false;
                _6.IsEnabled = false;
                _7.IsEnabled = false;
                _8.IsEnabled = false;
                _9.IsEnabled = false;
            }
            return check;
        }

        private void newgame_Click(object sender, RoutedEventArgs e)
        {
            _1.Content = "";
            _2.Content = "";
            _3.Content = "";
            _4.Content = "";
            _5.Content = "";
            _6.Content = "";
            _7.Content = "";
            _8.Content = "";
            _9.Content = "";
            _1.IsEnabled = true;
            _2.IsEnabled = true;
            _3.IsEnabled = true;
            _4.IsEnabled = true;
            _5.IsEnabled = true;
            _6.IsEnabled = true;
            _7.IsEnabled = true;
            _8.IsEnabled = true;
            _9.IsEnabled = true;
            Message.Content = null;
            if (player == "X")
            {
                player = "O";
                bot = "X";
                Move(0);
            }
            else
            {
                player = "X";
                bot = "O";
            }
        }
    }
}
