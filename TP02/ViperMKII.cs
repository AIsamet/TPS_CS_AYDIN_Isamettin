using System;

namespace TP02

{
    //2.d
    public class ViperMKII : Spaceship
    {
        //2.d.1
        public ViperMKII()
        {
            Name = "ViperMKII";
            Structure = 10;
            Shield = 15;
            CurrentStructure = Structure;
            CurrentShield = Shield;
            //2.d.1.c
            Weapons.Add(new Weapon("Mitrailleuse", 2, 3, Weapon.EWeaponType.Direct, 1));
            Weapons.Add(new Weapon("EMG", 1, 7, Weapon.EWeaponType.Explosive, 1.5));
            Weapons.Add(new Weapon("Missile", 4, 100, Weapon.EWeaponType.Guided, 4));
        }

        public ViperMKII(string name)
        {
            Name = name;
            Structure = 10;
            Shield = 15;
            CurrentStructure = Structure;
            CurrentShield = Shield;
            //2.d.1.c
            Weapons.Add(new Weapon("Mitrailleuse", 2, 3, Weapon.EWeaponType.Direct, 1));
            Weapons.Add(new Weapon("EMG", 1, 7, Weapon.EWeaponType.Explosive, 1.5));
            Weapons.Add(new Weapon("Missile", 4, 100, Weapon.EWeaponType.Guided, 4));
        }

    }
}
