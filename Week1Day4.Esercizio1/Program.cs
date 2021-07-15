using System;
using System.Threading;

namespace Week1Day4.Esercizio1
{
    class Program
    {
        /*Gioco del lancio dei Dadi

        Si chiede all'utente quanti dadi vuole lanciare.
        L'utente inserisce un numero per provare ad indovinare 
        la somma dei valori usciti dal lancio dei dadi.

        Il computer lancia i dadi, quindi sorteggia i numeri (random tra 1 e 6).

        Se la somma dei numeri random è uguale al numero scelto dall'utente, l'utente vince
        Se l'utente vince, stampare 'hai vinto', altrimenti 'hai perso'.

        Finita la partita, l'utente deve poter rigiocare.

        Requisiti:
        Verificare che l'utente inserisca un intero e che sia compreso tra i valori possibili/accettabili.
        Se la verifica non va a buon fine, l'utente deve potere inserire nuovamente qualcosa. 

        Opzionale-> Creare un metodo per l'inserimento dei numeri e la verifica, 
        uno per il controllo della vittoria (da chiamare nel main).*/
        static void Main(string[] args)
        {

            Console.WriteLine("*****************************");
            Console.WriteLine("*        Gioco Dadi         *");
            Console.WriteLine("*****************************");
            do
            {
                Console.WriteLine("\nQuanti dadi vuoi lanciare?");
                //int numeroDadi = int.Parse(Console.ReadLine()); //non ci sono controlli
                //Controllo se la stringa che ha inserito l'utente è "trasformabile" in un intero e che questo intero sia positivo
                int numeroDadi;
                while(!int.TryParse(Console.ReadLine(), out numeroDadi) || numeroDadi < 0) 
                {
                    Console.WriteLine("Devi inserire un numero positivo. Riprova:");
                }

                int min = numeroDadi;
                int max = numeroDadi * 6;

                Console.Write($"\nTenta la fortuna!\nProva ad indovinare la somma dei dadi!\n\nInserisci un numero tra {min} e {max}: ");

                int numero;
                while (!int.TryParse(Console.ReadLine(), out numero) || numero < min || numero > max)
                {
                    Console.WriteLine($"\nScelta errata. Inserisci un numero tra {min} e {max}: ");
                }

                Console.WriteLine("\nLancio i dadi...");
                Thread.Sleep(2000); //attesa di 2 secondi. Per usarlo bisogna aggiungere in alto using System.Threading;
                int[] numeriUsciti = new int[numeroDadi];
                int somma = 0;
                for (int i = 0; i < numeroDadi; i++)
                {
                    numeriUsciti[i] = new Random().Next(1, 7);
                    Console.WriteLine($"Il valore del {i + 1}° dado lanciato è: {numeriUsciti[i]}");
                    somma = somma + numeriUsciti[i];
                }
                Console.WriteLine($"\n\nLa loro somma è: {somma}.\nTu avevi inserito il numero {numero} quindi\n");

                if (numero == somma)
                {
                    Console.WriteLine("************************");
                    Console.WriteLine("*      HAI VINTO!      *");
                    Console.WriteLine("************************");
                }
                else
                {
                    Console.WriteLine("************************");
                    Console.WriteLine("*      HAI PERSO..     *");
                    Console.WriteLine("************************");
                }
                Console.WriteLine("\n\nVuoi rigiocare? s/n");
            } while (Console.ReadLine().ToLower() == "s");

            Console.WriteLine("Ciao! Torna presto a giocare!");
        }
    }
}

