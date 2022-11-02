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
            else { Console.WriteLine("Tu n'a pas d'arme mon ami\n"); }
        }

        public void UseAbility(List<Spaceship> spaceships)
        {
            throw new NotImplementedException();
        }
    }
}
