using System;

namespace TP02

{
    //2.a
    public class Dart : Spaceship
    {
        //2.a.1
        public Dart()
        {
            Name = "Default Name";
            Structure = 10;
            Shield = 3;
            CurrentStructure = Structure;
            CurrentShield = Shield;
            //Weapons = new List<Weapon>();
            Weapons.Add(new Weapon("Rayon laser", 2, 3, Weapon.EWeaponType.Direct, 2));
        }

        public Dart(string name)
        {
            Name = name;
            Structure = 10;
            Shield = 3;
            CurrentStructure = Structure;
            CurrentShield = Shield;
            //Weapons = new List<Weapon>();
            Weapons.Add(new Weapon("Rayon laser", 2, 3, Weapon.EWeaponType.Direct, 2));
        }

  
    }
}
