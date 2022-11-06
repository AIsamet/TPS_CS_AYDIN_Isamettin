using System;

namespace TP02

{
    //2.c
    public class Rocinante : Spaceship
    {
        //2.c.1
        public Rocinante()
        {
            Name = "Rocinante";
            Structure = 3;
            Shield = 5;
            CurrentStructure = Structure;
            CurrentShield = Shield;
            Weapons.Add(new Weapon("Torpille", 3, 3, Weapon.EWeaponType.Guided, 2));
        }

        public Rocinante(string name)
        {
            Name = name;
            Structure = 3;
            Shield = 5;
            CurrentStructure = Structure;
            CurrentShield = Shield;
            Weapons.Add(new Weapon("Torpille", 3, 3, Weapon.EWeaponType.Guided, 2));
        }

        //2.c.2
        public override void TakeDamages(double damages)
        {
            Random random = new Random();
            int chance = random.Next(1, 3); // crée un nombre entre 1 et 2

            //si  = 1 rociante esquive l'attaque
            if (chance == 1)
            {
                Console.WriteLine("Le tir est raté ! Rocinante l'esquive");
            }
            //sinon prends les degats normalement
            else
            {
                base.TakeDamages(damages);
            }
        }
        
    }
}
