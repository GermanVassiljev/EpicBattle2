using System;
using System.IO;

namespace EpicBattle2
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootPath = @"C:\Users\opilane\Samples\";
            string[] heroes = GetDataFromFile(rootPath + "heroes.txt");
            string[] Enemies = GetDataFromFile(rootPath + "enemies.txt");
            string[] Weapon = GetDataFromFile(rootPath + "weapon.txt");
            string RandomHero = GetRandomCharacter(heroes);
            string RandomEnemy = GetRandomCharacter(Enemies);
            string HeroWeapon = GetWeapon(Weapon);
            string EnemyWeapon = GetWeapon(Weapon);
            Console.WriteLine($"Your hero is {RandomHero}");
            Console.WriteLine($"He have {HeroWeapon}");
            Console.WriteLine($"Your enemy is {RandomEnemy}");
            Console.WriteLine($"He have {EnemyWeapon}");
        }
        public static string GetRandomCharacter(string[] someArray)
        {
            return someArray[GetRandomIndex(someArray)];
        }
        public static string GetWeapon(string[] someArray)
        {
            return someArray[GetRandomIndex(someArray)];
        }
        public static int GetRandomIndex(string[] someArray)
        {
            Random rnd = new Random();
            return rnd.Next(0, someArray.Length);
        }

        public static string[] GetDataFromFile(string filePatch)
        {
            string[] dataFromFile = File.ReadAllLines(filePatch);
            return dataFromFile;
        }

    }
}