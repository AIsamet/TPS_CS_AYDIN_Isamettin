using System;

namespace TP02

{
    //3.2
    public class Tardis : Spaceship, IAbility
    {
        public Tardis()
        {
            Name = "Default Name";
            MaxStructure = 1;
            MaxShield = 0;
            CurrentStructure = MaxStructure;
            CurrentShield = MaxShield;
            WeaponsList = new List<Weapon>();
        }

        public Tardis(string name)
        {
            Name = name;
            MaxStructure = 1;
            MaxShield = 0;
            CurrentStructure = MaxStructure;
            CurrentShield = MaxShield;
            WeaponsList = new List<Weapon>();
        }

        public override void ShootTarget(Spaceship target)
        {
            Random random = new Random();
            Console.WriteLine("Vous passez a l'attaque ! ");

            if (WeaponsList.Count() != 0)
            {
                int randomWeapon = random.Next(0, WeaponsList.Count());
                target.TakeDamages(WeaponsList[randomWeapon].Shoot());
            }
            else { Console.WriteLine("Tu n'a pas d'arme mon ami\n");
                SpaceInvaders Game = SpaceInvaders.GetInstance;
                UseAbility(Game.EnemySpaceships);

            }
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
