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

        ToFind toFind;

        public MainWindow()
        {
            InitializeComponent();

            toFind = new ToFind();
            wordToFind.Content = toFind.InitializeWordToFind();
            nbTry.Content = (10-toFind.NbTry).ToString();
        }

        public string changeAdvanceWord(string newChange)
        {
            string newAdvanceWord = "";
            for (int i = 0; i < toFind.WordLenght; i++)
            {
                if (toFind.WordAdvance[i] != '_')
                {
                    newAdvanceWord += toFind.WordAdvance[i];
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
            for (int i = 0; i < toFind.WordLenght; i++)
            {   
                string bouh = toFind.WordToFind[i].ToString();
                string bouh2 = toFind.LetterProposed.ToString();

                if (bouh == bouh2)
                {                 
                }
                else
                {
                    allIndexes.Add(i);
                }
                Console.WriteLine("Letter found at index " + i);
                Console.WriteLine("Letter to find : " + toFind.WordToFind[i]);
                Console.WriteLine("Letter proposed : " + toFind.LetterProposed);
            }
            return allIndexes;
        }

        public bool ProposeLetter()
        {
            bool result = false;

           toFind.LetterProposed = proposeLetter.Text;

            if (toFind.LetterProposed.Length > 1)
            {
                MessageBox.Show("Please enter only one letter");
                result = false;
                return result;
            }
            else if (toFind.LetterProposed.Length == 0)
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
                    for (int i = 0; i < toFind.WordLenght; i++)
                    {
                        if (allIndexes.Contains(i))
                        {
                            new_str += toFind.WordToFind[i];
                        }
                        else
                        {
                            new_str += '-';
                        }
                    }

                    toFind.WordAdvance = changeAdvanceWord(new_str);
                    wordToFind.Content = toFind.WordAdvance;

                }
                else
                {
                    toFind.NbTry += 1;
                }

                

                nbTry.Content = (10 - toFind.NbTry).ToString();

                proposeLetter.Text = "";
            }            

            Check_Victory_Defeat();
            return result;
        }

        

        public void Check_Victory_Defeat()
        {
            if (toFind.IsWordFound())
            {
                MessageBox.Show("You won !");
                this.Close();
            }
            else if (toFind.NbTry == 10)
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