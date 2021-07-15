using System;
using System.IO;

namespace Week1Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Esempio1();

            ////scrittura su file con chiusura manuale
            //StreamWriter sw = new StreamWriter(@"fileProva.txt"); //va di default nella cartella bin 
            //sw.WriteLine("Ciao a tutte!");
            //sw.Close();

            //string path = @"C:\Users\RenataCarriero\source\repos\Week1Day4\Week1Day4\fileProva.txt";

            //StreamWriter sw1 = new StreamWriter(path);
            //sw1.WriteLine("Ciao a tutte!!!!");
            //sw1.Close();



            //// scrittura su file con chiusura automatica -> using
            string path1 = @"C:\Users\RenataCarriero\source\repos\Week1Day4\Week1Day4\fileProva1.txt";
            //using (StreamWriter sw2= new StreamWriter(path1))
            //{
            //    sw2.WriteLine("buongiono!");
            //}

            ////Scrittura su file sovrascrivendo il contenuto precedente
            //using(StreamWriter sw2=new StreamWriter(path1))
            //{
            //    sw2.WriteLine("come state?");
            //}

            ////Scrittura su file mantenendo il contenuto precedente
            //using(StreamWriter sw2=new StreamWriter(path1, true))
            //{
            //    sw2.WriteLine("Bene, grazie!");
            //}


            //Lettura di tutto il file
            using(StreamReader sw2= new StreamReader(path1))
            {
                string contenutoFile = sw2.ReadToEnd();
            }

            //Lettura di una riga del file
            using (StreamReader sw2 = new StreamReader(path1))
            {
                string contenutoRiga = sw2.ReadLine();
            }

            //Lettura di tutto il file e divisione del file in righe

            using(StreamReader sw2= new StreamReader(path1))
            {
                string contenutoFile = sw2.ReadToEnd();

                string[] arrayDiRighe = contenutoFile.Split("\r\n");
            }


            







        }

        private static void Esempio1()
        {
            //Operatore ternario
            int a = 1;
            int b = 2;

            string c;

            if (a < b)
            {
                c = "a è più piccolo di b";
            }
            else
            {
                c = "a è più grande di b";
            }

            c = (a < b) ? "a è più piccolo di b" : "a è più grande di b";

            int pari = 0;
            int dispari = 0;

            int n = 10;

            ((n % 2 == 0) ? ref pari : ref dispari)++;


            //Resize array

            int[] mioArray = new int[10];
            mioArray[0] = 1;
            mioArray[1] = 2;
            mioArray[2] = 3;

            for (int i = 0; i < mioArray.Length; i++)
            {
                Console.Write($"{mioArray[i]} \t");
            }

            Array.Resize(ref mioArray, 3);
            Console.WriteLine("\nStampa del mio array dopo il resize");

            for (int i = 0; i < mioArray.Length; i++)
            {
                Console.Write($"{mioArray[i]} \t");
            }
            Console.WriteLine("\n");


            //foreach
            foreach (var item in mioArray)
            {
                Console.Write(item + "\t");
            }
        }
    }
}
