using System;

namespace TP02

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
            Weapons.Add(new Weapon("Rayon laser", 50, 80, Weapon.EWeaponType.Direct, 1));
            Weapons.Add(new Weapon("Mitrailleuse", 20, 40, Weapon.EWeaponType.Guided, 1));
            Weapons.Add(new Weapon("Lance missile", 10, 60, Weapon.EWeaponType.Explosive, 1));
        }

        public void ViewArmory()
        {
            Console.WriteLine("Liste des armes de l'armurerie : ");
            foreach (Weapon weapon in Weapons)
            {
                Console.WriteLine(weapon.ToString());
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

        //RETOURNE UNE ARME SI L'ARME EXISTE DANS L'ARMURERIE UTILE LORS DE L'AJOUT D'UNE ARME
        //DANS UN VAISSEAU EN METTANT CETTE FONTION COMME PARAMETRE DE LA FONTION AddWeapon(Weapon weapon)
        //DE LA CLASSE SPACESHIP AFIN DE VERIFIER SI ELLE EXISTE DANS L'ARMURERIE
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
    }
}
