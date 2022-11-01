using System;

namespace TP02
    
{
    //3.2
    public class Tardis : Spaceship, IAbility
    {
        public override void ShootTarget(Spaceship target)
        {
            Random random = new Random();
            Console.WriteLine("Vous passez a l'attaque ! ");
            Console.WriteLine(Name + "lance son attaque special");

            if (WeaponsList.Count() != 0)
            {
                int randomWeapon = random.Next(0, WeaponsList.Count());
                Weapon weapon = WeaponsList[randomWeapon];


                target.TakeDamages(WeaponsList[randomWeapon]);
            }
            else { Console.WriteLine("Tu n'a pas d'arme mon ami\n"); }
        }

        public void UseAbility(List<Spaceship> spaceships)
        {
            throw new NotImplementedException();
        }
    }
}
