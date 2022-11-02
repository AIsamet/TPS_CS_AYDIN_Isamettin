using System;

namespace TP02
    
{
    //3.2
    public class F_18 : Spaceship, IAbility
    {
        //3.a.1
        public F_18()
        {
            Name = "Default Name";
            MaxStructure = 15;
            MaxShield = 0;
            CurrentStructure = MaxStructure;
            CurrentShield = MaxShield;
            WeaponsList = new List<Weapon>();
        }

        public F_18(string name)
        {
            Name = name;
            MaxStructure = 15;
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

        //3.a.2
        public void UseAbility(List<Spaceship> spaceships)
        {
            if (spaceships[0] == this)
            {
                SpaceInvaders Game = SpaceInvaders.GetInstance;
                Console.WriteLine(this.Name + " utilise son aptitude speciale");
                Console.WriteLine("EXPLOSION !");
                foreach (Player player in Game.Players)
                {
                    if (player.MySpaceship.IsDestroyed == false)
                    {
                        player.MySpaceship.TakeDamages(10);
                        this.IsDestroyed = true;
                        break;
                    }
                }
            }
        }

    }
}
