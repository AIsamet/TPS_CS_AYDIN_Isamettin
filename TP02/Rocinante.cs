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
            //Weapons = new List<Weapon>();
            Weapons.Add(new Weapon("Torpille", 3, 3, Weapon.EWeaponType.Guided, 2));
        }

        public Rocinante(string name)
        {
            Name = name;
            Structure = 3;
            Shield = 5;
            CurrentStructure = Structure;
            CurrentShield = Shield;
            //Weapons = new List<Weapon>();
            Weapons.Add(new Weapon("Torpille", 3, 3, Weapon.EWeaponType.Guided, 2));
        }


       
    }
}
