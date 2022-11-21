using System;

namespace TP03

{
    public class ViperMKII : Spaceship
    {
        public ViperMKII()
        {
            Name = "ViperMKII";
            Structure = 10;
            Shield = 15;
            CurrentStructure = Structure;
            CurrentShield = Shield;
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
            Weapons.Add(new Weapon("Mitrailleuse", 2, 3, Weapon.EWeaponType.Direct, 1));
            Weapons.Add(new Weapon("EMG", 1, 7, Weapon.EWeaponType.Explosive, 1.5));
            Weapons.Add(new Weapon("Missile", 4, 100, Weapon.EWeaponType.Guided, 4));
        }

    }
}
