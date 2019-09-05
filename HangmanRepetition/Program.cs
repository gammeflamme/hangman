using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanRepetition
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Exempel på förbättringar:
             * - Använd char istället för string.
             * - Bygg om metoderna så att man inte kan gissa på en bokstav man redan gissat på.
             * - Felsäkra metoderna. Utgå från att andra människor kommer att mata in nonsens som parametrar och 
             *   se till att koden inte krashar.
             * - Bygg en klass att spara ordet i. Klassen innehåller både det rätta ordet och hur långt spelaren kommit.
             * - Hämta ordlistan från en textfil eller en databas.
             * - Definitivt överkurs: Hitta ett sätt att hämta ett slumpat ord från en hemsida.
             */

            
            HangmanGame();
            

        }

        static void HangmanGame()
        {
            // FÖRBEREDELSER
            string word = RandomWord();

            string[] visibleWord = GenerateUnderscores(word);

            List<string> erroneousGuesses = new List<string>();

            int maxErroneousGuesses = 7;

            // SPELET
            while (!IsComplete(visibleWord) && erroneousGuesses.Count < maxErroneousGuesses)
            {
                DrawHangedMan(erroneousGuesses.Count);
                PrettyPrint(visibleWord);

                string guess = GetGuess();

                if (IsIn(guess, word))
                {
                    visibleWord = ReplaceFilter(guess, word, visibleWord);

                }
                else
                {
                    erroneousGuesses.Add(guess);
                }
            }

            if (IsComplete(visibleWord))
            {
                DisplayWin();
            }
            else
            {
                DisplayLoss();
            }
        }

        static string[] GenerateUnderscores(string word)
        {
            // Skapa en array med lika många _ som det finns bokstäver/tecken i word
            string[] blank = new string[word.Length];

            for(int i = 0; i < word.Length; i++)
            {
                blank[i] = "_";
            }


            return blank;
        }

        static string RandomWord()
        {
            // Slumpa ett ord från en lista, bara små bokstäver
            List<string> words = new List<string>()
            {
            "buss",
            "toilet",
            "racoon"
            };
            Random rand = new Random();



            return words[rand.Next(words.Count-1)];
        }

        static string PrettyPrint(string[] visibleWord)
        {
            // Returnera en snygg string som genererats utifrån visibleWord.
            // T.ex. om visibleWord är ["a", "p", "a"] så kan man returnera "a p a".
            string word = "";

            for(int i = 0; i < visibleWord.Length; i++)
            {
                word += visibleWord[i];

            }




            return word;
        }

        static bool IsComplete(string[] visibleWord)
        {

            bool check = false;
            // Returnera true ifall alla _ har bytts ut mot tecken, annars false
            for (int i = 0; i < visibleWord.Length; i++)
            {
                
                if (visibleWord[i] != "_")
                {
                    check = true;
                    i = visibleWord.Length;
                }

            }


            return check;
        }

        static string GetGuess()
        {
            // Returnera en 1 bokstavs gissning. Returnera alltid en liten bokstav (a istället för A t.ex.)
            string letter = Console.ReadKey().KeyChar.ToString();
            return letter;
        }

        static bool IsIn(string s, string word)
        {
            // Returnera true om s finns i word, annars false.
            bool check = false;
            string[] wordarr = word.Split();
            for (int i = 0; i < word.Length; i++)
            {

                if (wordarr[i] != s)
                {
                    check = true;
                    i = word.Length;
                }

            }



            return check;
        }

        static string[] ReplaceFilter(string s, string word, string[] visibleWord)
        {
            // Skapa och returnera en kopia av visibleWord där alla positioner där 
            // s finns i word bytts ut mot s.
            // T.ex. om s är "m", word är ["m", "a", "m", "m", "a"] och visibleWord är
            // ["_", "_", "_", "_", "_"] så ska metoden returnera ["m", "_", "m", "m", "_"]
            string[] wordarr = word.Split();


            for (int i = 0; i < word.Length; i++)
            {
                if (visibleWord[i] == s)
                {
                    visibleWord[i] = wordarr[i];
                }



            }




            return visibleWord;
        }

        static string DrawHangedMan(int step)
        {
            string state = step.ToString();

            return state;
        }

        static void DisplayWin()
        {
            // Visa någon form av vinst-meddelande
        }

        static void DisplayLoss()
        {
            // Visa någon form av förlust-meddelande
        }

    }
}
