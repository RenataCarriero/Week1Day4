using System;

namespace Week1Day4.Esercizio4
{
    class Program
    {

        static void Main(string[] args)
        {
            //Esercizio 1: Trovare quante volte un certo carattere è contenuto in una stringa
            Esercizio1();


            //Esercizio 2: Data una stringa, scrivere un programma che trova il primo carattere non ripetuto.
            //es. mozzarella -> output m
            //es. sottilissimo -> output l
            Esercizio2();
            
        }

        private static void Esercizio1()
        {
            //Interazione con utente. E' l'utente che inserisce una parola.
            //Console.WriteLine("Inserisci una parola/frase: ");
            //string s = Console.ReadLine();
            //In alternativa, assegno la parola direttamente a codice.
            string s = "banana";

            //interazione con utente
            //Console.WriteLine("Scegli una lettera e ti dirò quante volte è contenuta nella parola/frase che hai inserito!");
            //char toFind = Console.ReadKey().KeyChar;
            //In alternativa, "setto" il carattere da ricercare direttamente da codice. 
            char toFind = 'n';

            int total = 0;
            for (int i = 0; i <= s.Length-1; i++)
            {
                if (toFind == s[i])
                {
                    total++;
                }
            }
            Console.WriteLine($"\n\nLa lettera {toFind} è contenuta {total} volte nella parola/frase '{s}'");
        }

        private static void Esercizio2() 
        {
            string word = "ekelk";

            //bool isRepeated; //default = false;

            //creo un array di caratteri della stessa lunghezza della stringa "word"
            char[] chars = new char[word.Length];

            //metto nell'array i caratteri della stringa word.
            for (int i = 0; i < word.Length; i++)
            {
                chars[i] = word[i];
            }

            //Esiste un metodo per le stringhe che permette di fare "in automatico"
            //questa operazione di trasformazione della stringa in array di caratteri ed è il ToCharArray()
            //char[] chars = word.ToCharArray();  

            
            for (int i = 0; i < chars.Length; i++)
            {
                int conta = ContaOccorrenze(word, chars[i]);
                if (conta == 1)
                {
                    Console.WriteLine($"Il primo carattere non ripetuto è {chars[i]}");
                    break;
                }
            }

            //Vi ricordate che avevo detto che le stringhe sono già array di caratteri?
            //Il codice scritto sopra può quindi essere scritto senza l'utilizzo dell'array di appoggio chars.
            //Di seguito la soluzione più pulita:
            //
            //string word="ekelk";
            //for (int i = 0; i < word.Length; i++)
            //{
            //    int conta = ContaOccorrenze(word, word[i]);
            //    if (conta == 1)
            //    {
            //        Console.WriteLine($"Il primo carattere non ripetuto è {word[i]}");
            //        break;
            //    }
            //}


        }
        
        //Ho scritto questa funzione che praticamente fa la stessa cosa dell'esercizio 1
        //ma prende in input la parola e il carattere
        //e restituisce quante volte il carattere è ripetuto nella parola.
        private static int ContaOccorrenze(string s, char toFind)
        {
            int total = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (toFind == s[i])
                {
                    total++;
                }
            }
            return total;
        }
    }
}

