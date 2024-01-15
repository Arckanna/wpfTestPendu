using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfTest

{   
    internal class To_guess
    {
        public static string[] words = { "aquarium", "archipel", "banquise", "batterie", "brocante", "brouhaha","objectif","scorpion", "toujours","hautbois" };
        private string wordToGuess;
        private char letterProposed;
        private string wordAdvance;
        private int nbTry;

        public string InitializeWordToGuess()
        {
            this.wordAdvance = "";
            int len = this.WordLenght;
            for (int i = 0; i < len; i++)
            {
                this.wordAdvance += "_";
            }
            return this.wordAdvance;
        }   

        public bool IsWordFound()
        {
            if (this.wordAdvance == this.wordToGuess)
            {
                return true;
            }               
            else
            {
                return false;
            }
        }

        public To_guess(string value)
        {
            this.wordToGuess = value;
            InitializeWordToGuess();
            this.nbTry = 0;
        }

        public To_guess()
        {           
            Random random = new Random();
            int index = random.Next(words.Length);
            this.wordToGuess = words[index];
            InitializeWordToGuess();
            this.nbTry = 0;
        }

        public int NbTry {
            get { return this.nbTry; }
            set { this.nbTry = value; }
        }

        public string WordToGuess
        {
            get { return this.wordToGuess; }
            set { this.wordToGuess = value; }
        }

        public string WordAdvance
        {
            get { return this.wordAdvance; }
            set { this.wordAdvance = value; }
        }

        public int WordLenght
        {
            get { return WordToGuess.Length; }
        }

        public char LetterProposed
        {
            get { return this.letterProposed; }
            set { this.letterProposed = value; }
        }

    }
}
