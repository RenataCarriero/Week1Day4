using System;

namespace Week1Day4.Esercizio2
{
    class Program
    {
        //Morra Cinese (carta forbice sasso)

        //Stampare un messaggio di benvenuto al gioco Morra Cinese.
        //Chiedere il NOME dell'utente quindi stampare un messaggio del tipo "Ok NOME, iniziamo a giocare".
        //Il computer sceglie (in modo random) una tra le possibili opzioni tra carta, sasso o forbice.
        //Avvisa l'utente che ha effettuato la sua scelta quindi invita l'utente a fare lo stesso cioè 
        //a scegliere una delle 3 opzioni tra quelle disponibili per poter giocare contro di lui.

        //Dopo la scelta dell'utente sarà quindi "calcolato" il vincitore in base al confronto tra le opzioni scelte.
        //Stampare a video un messaggio all'utente che dica se ha vinto, ha perso oppure c'è stato un pareggio.

        //Ricordiamo che:
        //Sasso vince su Forbice
        //Carta vince su Sasso
        //Forbice vince su Carta

        //Al termine del gioco si richiede all'utente se desidera giocare ancora contro il computer.
        //In caso affermativo si ricomincia a giocare, 
        //altrimenti si esce dal gioco e deve essere mostrato un messaggio di arrivederci.

        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto a Morra Cinese!");
            Console.WriteLine("Come ti chiami?");
            string nome = Console.ReadLine();
            Console.WriteLine($"Ciao {nome}, iniziamo a giocare!");
            bool continua = true;
            while (continua) //while(contiuna==true)
            {
                figura giocataPC = sceltaComputer();
                Console.WriteLine("Io ho già fatto la mia scelta, ora tocca a te!");

                mostraScelte();
                figura giocataUtente = faiScelta();
                //Riepilogo scelte effettuate
                Console.WriteLine($"\nHai scelto {giocataUtente}.\n");
                Console.WriteLine($"La mia scelta invece era {giocataPC}.\n");
                //Verifico se l'utente ha pareggiato
                if (giocataUtente == giocataPC)
                {
                    Console.WriteLine("Abbiamo fatto la stessa scelta quindi PAREGGIO!");
                }
                else //altrimenti verifico se ha vinto o perso
                {
                    bool esitoVittoriaUtente = verificaVittoriaUtente(giocataUtente, giocataPC);

                    if (esitoVittoriaUtente == true)
                    {
                        Console.WriteLine("BRAVO! Hai vinto tu!");
                    }
                    else
                    {
                        Console.WriteLine("Peccato hai perso...");
                    }
                }
                Console.WriteLine("Vuoi continuare a giocare? s/n");
                if (Console.ReadLine().ToUpper() != "S")
                {
                    continua = false;
                }
            }

            Console.WriteLine("Ciao! Alla prossima!");

        }

        private static bool verificaVittoriaUtente(figura giocataUtente, figura giocataPC)
        {
            bool vittoria = false;

            if (giocataUtente == figura.carta && giocataPC == figura.sasso)
            {
                vittoria = true;
            }
            else if (giocataUtente == figura.sasso && giocataPC == figura.forbice)
            {
                vittoria = true;
            }
            else if (giocataUtente == figura.forbice && giocataPC == figura.carta)
            {
                vittoria = true;
            }

            return vittoria;

        }

        private static figura sceltaComputer()
        {
            Random x = new Random();
            figura scelta = (figura)x.Next(1, 4);
            return scelta;
        }

        private static figura faiScelta()
        {
            int scelta;
            while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 3)
            {
                Console.WriteLine("Scelta non consentita. Riprova: ");
            }
            return (figura)scelta;
        }

        private static void mostraScelte()
        {
            Console.WriteLine("\nFai la tua scelta tra:");
            Console.WriteLine($"1 per {figura.sasso}");
            Console.WriteLine($"2 per {figura.forbice}");
            Console.WriteLine($"3 per {figura.carta}\n");
        }

        public enum figura
        {
            sasso = 1,
            forbice = 2,
            carta = 3
        }
    }
}
