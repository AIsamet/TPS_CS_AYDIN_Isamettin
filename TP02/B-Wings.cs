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
            //Weapons = new List<Weapon>();
            Weapons.Add(new Weapon("Hammer", 1, 8, Weapon.EWeaponType.Explosive, 1.5));
        }

        public B_Wings(string name)
        {
            Name = name;
            Structure = 30;
            Shield = 0;
            CurrentStructure = Structure;
            CurrentShield = Shield;
            //Weapons = new List<Weapon>();
            Weapons.Add(new Weapon("Hammer", 1, 8, Weapon.EWeaponType.Explosive, 1.5));
        }

       
    }
}
