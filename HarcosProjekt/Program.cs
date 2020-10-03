﻿using System;
using System.Collections.Generic;
using System.IO;

namespace HarcosProjekt
{
    class Program
    {
        static List<Harcos> tagok;
        static void Beolvas(string file)
        {
            StreamReader sr = new StreamReader(file);
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(';');
                tagok.Add(new Harcos(sor[0], Convert.ToInt32(sor[1])));
            }
            sr.Close();
        }
        static Harcos userCreat()
        {
            int szam = 0;
            string nev = "";
            bool exit = false;
            Console.WriteLine("\nSTATUSZ SABLONOK:\n\t[1] HP:18/18 - DMG: 4\n\t[2] HP:15/15 - DMG: 5\n\t[3] HP:11/11 - DMG: 6");
            do
            {
                Console.Write("\nAdja meg a harcos nevét: ");
                nev = Console.ReadLine();
                Console.Write("\nAdja meg a harcos sablonját: ");
                string beSzam = Console.ReadLine();
                exit = nev != "";
                exit = exit && Int32.TryParse(beSzam, out szam);
                exit = exit && (szam > 0 && szam < 4);

            } while (!exit);
            return new Harcos(nev, szam);
        }
        static void Kiir()
        {
            for (int i = 0; i < tagok.Count; i++)
            {
                Console.WriteLine("[" + (i + 1) + ".]...." + tagok[i]);
            }
        }
        static void Menu() {
            ConsoleKeyInfo billentyu;
            do
            {
                Console.WriteLine("Menu\n".ToUpper());
                Console.WriteLine("a.) Megküzdeni egy harcossal\nb.) Gyógyulni\nc.) Kilépni");
                Console.Write("\nMit szeretne tenni?\nÜsse le a megfelelő billentyűt: ");
                billentyu = Console.ReadKey();
                if (billentyu.Key == ConsoleKey.A)
                {
                    Console.Clear();
                    Kiir();
                    int szam = -1;
                    do
                    {
                        Console.Write("Kivel akarsz megmérkőzni?\nAdd meg a sorszámát: ");
                        bool next = Int32.TryParse(Console.ReadLine(), out szam);
                        if (szam < 1 || szam > tagok.Count + 1 && next)
                        {
                            Console.WriteLine("Nincs ilyen sorszám.\n");
                        }
                    } while (!(szam > 0 && szam<tagok.Count+1));
                    Console.ReadKey();
                    tagok[tagok.Count - 1].Megkuzd(tagok[szam-1]);
                    Kiir();
                }
                else if (billentyu.Key == ConsoleKey.B)
                {
                    Console.Clear();
                }
                else if(billentyu.Key != ConsoleKey.C)
                {
                    Console.WriteLine("\nNem megfelelő billentyút ütötte le!!\n");
                }
            } while (billentyu.Key != ConsoleKey.C);

        }
        static void Main(string[] args)
        {
            tagok = new List<Harcos>() { new Harcos("ZOLTÁÁN", 2), new Harcos("OSzabolcs", 1), new Harcos("Zsombor", 3) };
            Beolvas("harcosok.csv");
            Kiir();
            tagok.Add(userCreat());
            Console.Clear();
            Kiir();
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
    }
}
