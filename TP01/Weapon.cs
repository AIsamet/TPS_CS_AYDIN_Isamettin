using System;
namespace Aydin_Isamettin_Tp1
{
    public class Weapon
    {
        //4.3
        public EWeaponType weaponType;

        //4.1
        public string name { get; private set; }
        public int MinDamage { get; private set; }
        public int MaxDamage { get; private set; }

        //4.3
        public Weapon(string nom, int minDamage, int maxDamage, EWeaponType type)
        {
            name = nom;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            weaponType = type;
        }

        //4.2
        public enum EWeaponType
        {
            Direct,
            Explosive,
            Guided
        }

        public override string ToString()
        {
            return (name + " : dommages mini : " + MinDamage + ", dommages maxi : " + MaxDamage + ", type d'arme : " + weaponType);
        }

    }
}
