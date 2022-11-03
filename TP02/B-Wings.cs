using System;

namespace TP02

{
    //2.b
    public class B_Wings : Spaceship
    {
        //2.b.1
        public B_Wings()
        {
            Name = "Default Name";
            Structure = 30;
            Shield = 0;
            CurrentStructure = Structure;
            CurrentShield = Shield;
            Weapons.Add(new Weapon("Hammer", 1, 8, Weapon.EWeaponType.Explosive, 1.5));
        }

        public B_Wings(string name)
        {
            Name = name;
            Structure = 30;
            Shield = 0;
            CurrentStructure = Structure;
            CurrentShield = Shield;
            Weapons.Add(new Weapon("Hammer", 1, 8, Weapon.EWeaponType.Explosive, 1.5));
        }

        public override void ShootTarget(Spaceship target)
        {
            Random random = new Random();
            Console.WriteLine("Vous passez a l'attaque ! ");

            if (Weapons.Count() != 0)
            {
                int randomWeapon = random.Next(0, Weapons.Count());

                if (Weapons[randomWeapon].Type == Weapon.EWeaponType.Explosive)
                {
                    Weapons[randomWeapon].TimeBeforReload = 1;
                }

                target.TakeDamages(Weapons[randomWeapon].Shoot());

            }
            else { Console.WriteLine("Tu n'a pas d'arme mon ami\n"); }
            Console.WriteLine("------------------------------------------------------------\n");
        }

    }
}
