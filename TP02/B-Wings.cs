using Aydin_Isamettin_Tp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Aydin_Isamettin_Tp1.Weapon;

namespace TP02
{
    //2.b
    public class B_Wings : Spaceship
    {
        //2.b.1
        public B_Wings()
        {
            MaxStructure = 30;
            MaxShield = 0;
            CurrentStructure = MaxStructure;
            CurrentShield = MaxShield;
            WeaponsList = new List<Weapon>();
            WeaponsList.Add(new Weapon("Hammer", 1, 8, Weapon.EWeaponType.Explosive, 1.5));
        }

        public B_Wings(string name)
        {
            Name = name;
            MaxStructure = 30;
            MaxShield = 0;
            CurrentStructure = MaxStructure;
            CurrentShield = MaxShield;
            WeaponsList = new List<Weapon>();
            WeaponsList.Add(new Weapon("Hammer", 1, 8, Weapon.EWeaponType.Explosive, 1.5));
        }

        //2.b.2
        public override void ShootTarget(Spaceship target)
        {
            Random random = new Random();

            if (WeaponsList.Count() != 0)
            {
                int randomWeapon = random.Next(0, WeaponsList.Count());

                Weapon weapon = WeaponsList[randomWeapon];

                if (WeaponsList[randomWeapon].weaponType == EWeaponType.Explosive)
                {
                    WeaponsList[randomWeapon].TimeBeforReload = 1;
                }
                Console.WriteLine("Vous passez a l'attaque ! ");
                target.TakeDamages(WeaponsList[randomWeapon]);
            }
            else { Console.WriteLine("Tu n'a pas d'arme mon ami"); }
        }
    }
}
