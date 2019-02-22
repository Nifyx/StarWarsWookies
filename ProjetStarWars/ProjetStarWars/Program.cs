using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using StarWarsLibrary;

namespace ProjetStarWars
{
    class Program
    {
        static void Main(string[] args)
        {
            WookieDataLayer wookieDataLayer = new WookieDataLayer();
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (Wookie w in wookieDataLayer.Select())
            {
                Console.WriteLine(w.ToString());
            }
            Console.WriteLine("Appuyer sur entrée pour sortir de la console");
            Console.ReadLine();
        }
    }
}
