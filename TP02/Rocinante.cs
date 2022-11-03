using System;

namespace TP02

{
    //2.c
    public class Rocinante : Spaceship
    {
        //2.c.1
        public Rocinante()
        {
            Name = "Default Name";
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

        public override void TakeDamages(double damages)
        {
            Random random = new Random();
            //notion d'une chance sur 2, si = 2 on divise les probas 1/10 et 1/4 par 2 donc on a 2x plus de chance
            //d'avoir un tir raté et donc de ne pas prendre de dégats
            //sinon si  = 1 on divise les probas 1/10 et 1/4 par 1 donc aucun changement
            int chance = random.Next(1, 3); // creates a number between 1 and 2

            if (chance == 2)
            {
                Console.WriteLine("Le tir est raté ! Rocinante l'esquive");
            }
            else
            {
                base.TakeDamages(damages);
            }

        }
    }
}
