using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfTest

{   public class ToFind
    {
        public static string[] words = { "aquarium", "archipel", "banquise", "batterie", "brocante", "brouhaha","objectif","scorpion", "toujours","hautbois" };
        private string wordToFind;
        private string letterProposed;
        private string wordAdvance;
        private int nbTry;

        public string InitializeWordToFind()
        {
            this.wordAdvance = "";
            int len = this.WordLenght;
            for (int i = 0; i < len; i++)
            {
                this.wordAdvance += "_ ";
            }
            return this.wordAdvance;
        }   

        public bool IsWordFound()
        {
            if (this.wordAdvance == this.wordToFind)
            {
                return true;
            }               
            else
            {
                return false;
            }
        }

        public ToFind(string value)
        {
            this.wordToFind = value;
            InitializeWordToFind();
            this.nbTry = 0;
        }

        public ToFind()
        {           
            Random random = new Random();
            int index = random.Next(words.Length);
            this.wordToFind = words[index];
            InitializeWordToFind();
            this.nbTry = 0;
        }

        public int NbTry {
            get { return nbTry; }
            set { nbTry = value; }
        }

        public string WordToFind
        {
            get { return wordToFind; }
            set { wordToFind = value; }
        }

        public string WordAdvance
        {
            get { return wordAdvance; }
            set { wordAdvance = value; }
        }

        public int WordLenght
        {
            get { return WordToFind.Length; }
        }

        public string LetterProposed
        {
            get { return letterProposed; }
            set { letterProposed = value; }
        }

    }
}
