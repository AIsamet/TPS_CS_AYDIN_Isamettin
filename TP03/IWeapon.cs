using System;
using static TP03.Weapon;

namespace TP03
{
    public interface IWeapon
    {
        string Name { get; set; }
        EWeaponType Type { get; set; }
        double MinDamage { get; set; }
        double MaxDamage { get; set; }
        double AverageDamage { get; }
        double ReloadTime { get; set; }
        double TimeBeforReload { get; set; }
        bool IsReload { get; }
        double Shoot();
    }
}