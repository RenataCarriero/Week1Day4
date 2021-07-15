using System;

namespace Week1Day4.Esercizio5
{
    class Program
    {
        //Scrivere un programma che permetta all'utente di creare la sua lista della spesa.

        //Si chiede all'utente quanti prodotti vuole inserire nell'elenco. (numero intero valido e positivo).
        //Quindi si chiede all'utete di inserire i prodotti (esempio "uova", "pasta"..).
        //Non si possono inserire 2 prodotti uguali.
        //(Opzionale: "uova", "UOVA", "Uova" sono da intendersi uguali, quindi no-case-sensitive)

        //Se l'utente inserisce un prodotto già presente, gli si mostra un messaggio del tipo "prodotto già inserito".
        //Completato l'elenco della spesa, stampare un riepilogo con tutti i prodotti che ha inserito l'utente.

        //Requisiti: utilizzare un array (non una lista). Utilizzare le routine (es. ScriviListaSpesa e StampaListaSpesa)

        //Opzionale. Stampare la lista della spesa su un file "listaSpesa.txt" invece che a video.
        static void Main(string[] args)
        {
            Console.WriteLine("Quanti prodotti vuoi inserire nella tua lista della spesa?");
            int n = 0;
            while (!int.TryParse(Console.ReadLine(), out n) || n < 0)
            {
                Console.WriteLine("Inserisci un numero positivo. Riprova.");
            }
            string[] listaSpesa = ScriviListaDellaSpesa(n);

            StampaListaSpesa(listaSpesa);
        }

        private static void StampaListaSpesa(string[] listaSpesa)
        {
            Console.WriteLine("Ecco il riepilogo della tua lista della spesa");
            for (int i = 0; i < listaSpesa.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {listaSpesa[i]}");
            }
        }

        private static string[] ScriviListaDellaSpesa(int n)
        {
            string[] products = new string[n];


            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine($"Inserisci il {i + 1}° prodotto");
                string product = Console.ReadLine().ToUpper();

                int found = Array.IndexOf(products, product);

                if (found > -1) //se c'è già il prodotto
                {
                    Console.WriteLine($"Hai già inserito {product}!");
                    i--; //torno indietro e scrivo un altro prodotto
                }
                else
                {
                    products[i] = product; //lo assegna all'array 
                }
            }
            return products;
        }
    }
}
