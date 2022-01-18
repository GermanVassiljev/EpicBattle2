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
            string[] Armor = GetDataFromFile(rootPath + "armor.txt");
            string RandomHero = GetRandomCharacter(heroes);
            string RandomEnemy = GetRandomCharacter(Enemies);
            string HeroWeapon = GetWeapon(Weapon);
            string EnemyWeapon = GetWeapon(Weapon);
            string HeroArmor = GetRandomCharacter(Armor);
            string EnemyArmor = GetRandomCharacter(Armor);
            int HeroHP = GenerateHP(HeroArmor);
            int EnemyHP = GenerateHP(EnemyArmor);


            Console.WriteLine($"Your hero is {RandomHero} in {HeroArmor} {HeroHP} HP");
            Console.WriteLine($"He have {HeroWeapon}");
            Console.WriteLine($"Your enemy is {RandomEnemy} in {EnemyArmor} {EnemyHP} HP");
            Console.WriteLine($"He have {EnemyWeapon}");
            while (HeroHP >= 0 && EnemyHP >= 0)
            {
                HeroHP = HeroHP - Hit(RandomEnemy, EnemyWeapon);
                EnemyHP = EnemyHP - Hit(RandomHero, HeroWeapon);
            }
            if(HeroHP>EnemyHP)
            {
                Console.WriteLine($"{RandomHero} Save the day!");
            }else if(HeroHP<EnemyHP)
            {
                Console.WriteLine($"{RandomEnemy} Destroy the world!");
            }
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

        public static int GenerateHP(string armor)
        {
            return armor.Length;
        }

        public static int Hit(string character ,string weapon)
        {
            Random rnd = new Random();
            int strike = rnd.Next(weapon.Length - 2);
            Console.WriteLine($"{character} hit {strike}.");
            if(strike == 0)
            {
                Console.WriteLine($"Bad luck. {character} missed the target.");
            } else if(strike == weapon.Length -2)
            {
                Console.WriteLine($"Awesome! {character} made a critical hit!");
            }
            return strike;

        }
    }
}
