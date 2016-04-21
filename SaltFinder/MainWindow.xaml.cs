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

namespace SaltFinder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static char[] Match = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 
                               'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x',
                               'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
                               'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V',
                               'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7',
                               '8', '9', '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*',
                               '+', ',', '-', '.', '/', ':', ';', '<', '=', '>', '?', '@', 
                               '[', '\\', ']', '^', '_', '`', '{', '|', '}', '~'};

        static string FindPassword;
        static int Combi;
        static string space;
        string targetHash;
        string targetPassword;
        string result;
        bool done = false;



        private void Button_Go_Click(object sender, RoutedEventArgs e)
        {
            targetHash = TextBox_Hash.Text;
            targetPassword = TextBox_Password.Text;
            int Count;


            FindPassword = TextBox_Hash.Text;

            for (Count = 0; Count <= 4; Count++)
            {
                Recurse(Count, 0, "");
            }

            TextBox_Salt.Text = result;
            
            //TextBox_Hash.Text = HashWorksHelper.CalculateMD5Hash(TextBox_Password.Text);
        }

        void Recurse(int Lenght, int Position, string BaseString)
        {
            int Count = 0;


            for (Count = 0; (Count < Match.Length) && (!done); Count++)
            {
                if (Position < Lenght - 1)
                {
                    Recurse(Lenght, Position + 1, BaseString + Match[Count]);
                }
                if (HashWorksHelper.CalculateMD5Hash(targetPassword + BaseString + Match[Count].ToString()) == targetHash)
                {
                    result = BaseString + Match[Count].ToString();
                    done = true;
                }
            }
        }
    }
}
