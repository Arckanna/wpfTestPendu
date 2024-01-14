using System.Diagnostics.Metrics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpfTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        To_guess toGuess;

        public MainWindow()
        {
            InitializeComponent();

            toGuess = new To_guess();
            wordToGuess.Content = toGuess.InitializeWordToGuess();
            nbTry.Content = (10-toGuess.NbTry).ToString();
        }

        public string changeAdvanceWord(string newChange)
        {
            string newAdvanceWord = "";
            for (int i = 0; i < toGuess.WordLenght; i++)
            {
                if (toGuess.WordAdvance[i] != '_')
                {
                    newAdvanceWord += toGuess.WordAdvance[i];
                }
                else if (newChange[i] != '_')
                {
                    newAdvanceWord += newChange[i];
                }
                else
                {
                    newAdvanceWord += '-';
                }
                
            }
            return newAdvanceWord;
        }

        public List<int> All_Indexes_Of()
        {
            List<int> allIndexes = new List<int>();
            for (int i = 0; i < toGuess.WordLenght; i++)
            {
                if (toGuess.WordToGuess[i] == toGuess.LetterProposed)
                {
                    
                    allIndexes.Add(i);
                }
                Console.WriteLine("Letter found at index " + i);
                Console.WriteLine("Letter to find : " + toGuess.WordToGuess[i]);
                Console.WriteLine("Letter proposed : " + toGuess.LetterProposed);
            }
            return allIndexes;
        }

        public bool ProposeLetter()
        {
            bool result = false;

            string letterProposed = proposeLetter.Text;

            if (letterProposed.Length > 1)
            {
                MessageBox.Show("Please enter only one letter");
                result = false;
                return result;
            }
            else if (letterProposed.Length == 0)
            {
                MessageBox.Show("Please enter a letter");
                result = false;
                return result;
            }
            else 
            {
                List<int> allIndexes = All_Indexes_Of();

                if (allIndexes.Count > 0)
                {
                    result = true;
                    string new_str = "";
                    for (int i = 0; i < toGuess.WordLenght; i++)
                    {
                        if (allIndexes.Contains(i))
                        {
                            new_str += toGuess.WordToGuess[i];
                        }
                        else
                        {
                            new_str += '-';
                        }
                    }

                    toGuess.WordAdvance = changeAdvanceWord(new_str);
                    wordToGuess.Content = toGuess.WordAdvance;

                }
                else
                {
                    toGuess.NbTry += 1;
                }

                

                nbTry.Content = (10 - toGuess.NbTry).ToString();

                proposeLetter.Text = "";
            }            

            Check_Victory_Defeat();
            return result;
        }

        

        public void Check_Victory_Defeat()
        {
            if (toGuess.IsWordFound())
            {
                MessageBox.Show("You won !");
                this.Close();
            }
            else if (toGuess.NbTry == 10)
            {
                MessageBox.Show("You lost !");
                this.Close();
            }
        }

        private void ButtonTryClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Button clicked");
            bool letter_is_in = ProposeLetter();
            if (letter_is_in)
            {
                proposeLetter.Background = Brushes.Green;

            }
            else
            {
                proposeLetter.Background = Brushes.Red;
            }
        }
    }
}