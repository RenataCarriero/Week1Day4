using System;
using System.IO;

namespace Week1Day4.Esercizio3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continua = true;
            while (continua)
            {
                Console.WriteLine("\n-----------------------------------");
                Console.WriteLine("Benvenuto!");
                Console.WriteLine("-----------------------------------\n");
                Console.Write("Inserisci il tuo nome: --> ");
                string nome = Console.ReadLine();
                Console.WriteLine($"Ciao {nome}!");

                do
                {
                    char scelta = SceltaMenu();
                    if (scelta == 's')
                    {
                        SchermoNuovaPartita();
                    }
                    else
                    {
                        SchermoUscita();
                        continua = false;
                    }
                } while (continua == true);
            }
        }

        public static void SchermoUscita()
        {
            Console.WriteLine("\nArrivederci");
            Console.WriteLine("Torna presto a giocare!\n\n");
        }

        public static void SchermoNuovaPartita()
        {
            int numeroSegreto = new Random().Next(1, 101);
            
            //Scrittura su File
            StreamWriter sw = new StreamWriter(@"C:\Users\RenataCarriero\source\repos\Week1Day4\Week1Day4.Esercizio3\NumeroDaIndovinare.txt");
            sw.WriteLine("Numero da indovinare: " + numeroSegreto);
            sw.Close();
            //Fine scrittura su File

            Console.WriteLine("\nHo scelto un numero tra 1 e 100. Prova a indovinarlo.");
            bool trovato = false;
            int numeroDiTentativi = 0;
            int tentativo;
            string suggerimento=null;

            do
            {
                Console.WriteLine($"Finora hai effettuato {numeroDiTentativi} tentativi.");
                numeroDiTentativi++;
                Console.Write($"Fai il {numeroDiTentativi}° tentativo (0 se vuoi interrompere il gioco): ");
                while (!int.TryParse(Console.ReadLine(), out tentativo))
                {
                    Console.WriteLine("Devi inserire un numero. Riprova.");
                    Console.Write($"Fai il {numeroDiTentativi}° tentativo (0 se vuoi interrompere il gioco): ");
                }
                while ((tentativo < 0) || (tentativo > 100))
                {
                    Console.WriteLine("Il valore deve essere compreso tra 1 e 100. (0 se vuoi interrompere il gioco)");
                    Console.Write($"Fai il {numeroDiTentativi}° tentativo (0 se vuoi interrompere il gioco): ");
                    tentativo = int.Parse(Console.ReadLine()); //TODO mancano i controlli.
                }

                if (tentativo == 0)
                {
                    Console.WriteLine("\nPartita Interrotta");
                    Console.WriteLine("Il numero da indovinare era: " + numeroSegreto);
                    return;
                }
                else if (tentativo == numeroSegreto)
                {
                    trovato = true;
                    Console.WriteLine("\n****** Bravo, hai indovinato! ******");
                    Console.WriteLine("\nHai effettuato in totale " + numeroDiTentativi + " tentativi");
                    return;
                }
                else
                {
                    if (tentativo < numeroSegreto)
                    {
                        suggerimento = "Prova con un numero piu' alto";
                    }
                    else if (tentativo > numeroSegreto)
                    {
                        suggerimento = "Prova con un numero piu' basso";
                    }
                    Console.WriteLine("Suggerimento: " + suggerimento);
                }
            } while (trovato == false);
        }

        public static char SceltaMenu()
        {
            Console.WriteLine("\n-----------Menu---------- ");
            Console.WriteLine("\nVuoi fare una nuova partita? s/n");

            char risposta = Console.ReadKey().KeyChar;
            while ((risposta != 's') && (risposta != 'n'))
            {
                Console.WriteLine("Errore: devi scegliere s/n. Vuoi fare una nuova partita?");
                risposta = char.Parse(Console.ReadLine());
            }
            return risposta;
        }
    }
}
