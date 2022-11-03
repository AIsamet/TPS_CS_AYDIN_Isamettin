using System;

namespace TP02

{
    //3.2
    public class Tardis : Spaceship, IAbility
    {
        public Tardis()
        {
            Name = "Default Name";
            Structure = 1;
            Shield = 0;
            CurrentStructure = Structure;
            CurrentShield = Shield;
            //Weapons = new List<Weapon>();
        }

        public Tardis(string name)
        {
            Name = name;
            Structure = 1;
            Shield = 0;
            CurrentStructure = Structure;
            CurrentShield = Shield;
            //Weapons = new List<Weapon>();
        }

        public void UseAbility(List<Spaceship> spaceships)
        {
            SpaceInvaders Game = SpaceInvaders.GetInstance;
            Console.WriteLine(this.Name + " utilise son aptitude speciale");
            Console.WriteLine("Tardis se teleporte !");

            Random random = new Random();
            int randomVaisseau = random.Next(0, Game.EnemySpaceships.Count());
            int randomPosition = random.Next(0, Game.EnemySpaceships.Count());

            if (Game.EnemySpaceships.Count() != 1)
            {
                while (randomVaisseau == randomPosition)
                {
                    randomPosition = random.Next(0, Game.EnemySpaceships.Count());
                }
            }

            Spaceship temp = Game.EnemySpaceships[randomPosition];
            Game.EnemySpaceships[randomPosition] = Game.EnemySpaceships[randomVaisseau];
            Game.EnemySpaceships[randomVaisseau] = temp;

        }
    }
}
