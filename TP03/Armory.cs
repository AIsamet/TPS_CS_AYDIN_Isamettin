using System;

namespace TP03

{
    public class Armory
    {
        private List<Weapon> Weapons { get; set; }

        public Armory()
        {
            Init();
        }

        private void Init()
        {
            Weapons = new List<Weapon>();
            Weapons.Add(new Weapon("Rayon laser", 2, 3, Weapon.EWeaponType.Direct, 2));
            Weapons.Add(new Weapon("Mitrailleuse", 6, 8, Weapon.EWeaponType.Guided, 1));
            Weapons.Add(new Weapon("Lance missile", 4, 100, Weapon.EWeaponType.Explosive, 4));
        }

        public void ViewArmory()
        {
            Console.WriteLine("Liste des armes de l'armurerie : ");
            foreach (Weapon weapon in Weapons)
            {
                Console.WriteLine("\t" + weapon.ToString());
            }
            Console.Write("\n");
        }

        public void AddWeapon(Weapon weapon)
        {
            Weapons.Add(weapon);
            Console.WriteLine("L'arme " + weapon.Name + " a été ajouté a l'armurerie\n");
        }

        public void RemoveWeapon(Weapon armeSupprimer)
        {
            foreach (Weapon weapon in Weapons)
            {
                if (weapon.Name == armeSupprimer.Name)
                {
                    Weapons.Remove(armeSupprimer);
                    break;
                }
            }
        }
        public int CountWeapons()
        {
            return Weapons.Count();
        }

        public Weapon GetWeapon(String name)
        {
            foreach (Weapon weapon in Weapons)
            {
                if (weapon.Name == name)
                {
                    return weapon;
                }
            }
            throw new ArmoryException("L'arme n'existe pas dans l'armurerie\n");
        }

        //1.b.1 retourne les 5 armes avec les plus gros dommages moyens
        public List<Weapon> GetFiveHighestAverageDamageDesc()
        {
            return Weapons.OrderByDescending(x => x.AverageDamage).Take(5).ToList();
        }

        //1.b.2 retourne les 5 armes possédant les dommages minimums les plus hauts
        public List<Weapon> GetFiveHighestMinDamageWeaponsDesc()
        {
            return Weapons.OrderByDescending(x => x.MinDamage).Take(5).ToList();
        }

    }
}
