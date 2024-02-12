using System;

namespace Diner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======================\n");
            Console.WriteLine("Benvenuti al Ristorante");
            bool isDone = false;
            List<int> OrderNumbers = new List<int>();
            double TotaleOrdine = 0;

            while (!isDone)
            {
                Console.WriteLine("");
                Console.WriteLine("Il nostro menù:\n");
                // Mostrare il menu
                for (int i = 0; i < ListaMenu.Menu.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {ListaMenu.Menu[i]}: € {ListaMenu.Prezzi[i]}");
                }
                try
                {
                    Console.Write("\nSelezionare il numero corrispondente all'ordine: ");
                    int CiboOrdinato = int.Parse(Console.ReadLine());
                    if (CiboOrdinato > 0 && CiboOrdinato < 11)
                    {
                        OrderNumbers.Add(CiboOrdinato);
                        bool isCorrect = false;
                        while (!isCorrect)
                        {
                            // Riassunto ordine
                            Console.Clear();
                            Console.WriteLine("Il tuo ordine: \n");
                            foreach (int orderNumber in OrderNumbers)
                            {
                                Console.WriteLine($"- {ListaMenu.Menu[orderNumber - 1]}: € {ListaMenu.Prezzi[orderNumber - 1]}");
                            }
                            Console.WriteLine();
                            Console.Write("Desideri ordinare qualcosa d'altro? Y/N: ");
                            string answer = Console.ReadLine().ToLower();
                            try
                            {
                                switch (answer)
                                {
                                    case "y":
                                        isCorrect = true;
                                        Console.Clear();
                                        Console.WriteLine("Scegli cos'altro desideri ordinare");
                                        break;
                                    case "n":
                                        isCorrect = true;
                                        isDone = true;
                                        break;
                                    default:
                                        Console.Clear();
                                        throw new Exception("Seleziona un valore valido. Devi digitare 'Y' o 'N'.\n");
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                        throw new Exception("Inserimento non valido. Devi selezionare un numero tra 1 e 10");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.Clear();
            Console.WriteLine("Il conto: ");
            Console.WriteLine("\n-----------------------\n");

            // Conteggio dovuto
            foreach (int orderNumber in OrderNumbers)
            {
                Console.WriteLine($"- {ListaMenu.Menu[orderNumber - 1]}: € {ListaMenu.Prezzi[orderNumber - 1]}");
                TotaleOrdine += ListaMenu.Prezzi[orderNumber - 1];
            }
            TotaleOrdine += ListaMenu.Coperto;


            Console.WriteLine($"- Servizio a tavola: € {ListaMenu.Coperto}");
            Console.WriteLine("\n-----------------------\n");
            Console.WriteLine($"TOTALE: € {TotaleOrdine}");


            // Prendere l'ordine
            // Aggiungere alla lista
            // Chiedere se l'utente vuole altro
            // Se no, presentare il conto
        }
    }
    public class ListaMenu
    {
        private static double _coperto = 3.00;
        private static string[] _menu =
        {
            "Coca Cola 150ml",
            "Insalata di pollo",
            "Pizza Margherita",
            "Pizza 4 Formaggi",
            "Pz Patatine Fritte",
            "Insalata di riso",
            "Frutta di stagione",
            "Pizza fritta",
            "Piadina vegetariana",
            "Panino Hamburger"
        };
        private static double[] _prezzi =
        {
            2.50,
            5.20,
            10.00,
            12.50,
            3.50,
            8.00,
            5.00,
            5.00,
            6.00,
            7.90
        };
        public static double Coperto
        {
            get
            {
                return _coperto;
            }
        }
        public static string[] Menu
        {
            get
            {
                return _menu;
            }
        }
        public static double[] Prezzi
        {
            get
            {
                return _prezzi;
            }
        }

    }
}