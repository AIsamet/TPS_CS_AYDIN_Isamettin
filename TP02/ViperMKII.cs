using Aydin_Isamettin_Tp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP02
{
    public class ViperMKII : Spaceship
    {

        public override void ShootTarget(Spaceship target)
        {
            Random random = new Random();
            if (WeaponsList.Count() != 0)
            {
                int randomWeapon = random.Next(0, WeaponsList.Count());
                target.TakeDamages(WeaponsList[randomWeapon]);
            }
            else { Console.WriteLine("Tu n'a pas d'arme mon ami"); }
        }
    }
}
