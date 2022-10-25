using System;
namespace Aydin_Isamettin_Tp1
{
    public class Spaceship
    {
        //3.3
        private bool isDestroyed;
        private int currentStructure;
        //3.1
        private int MaxStructure { get; set; }
        private int MaxShield { get; set; }
        //3.2
        public int CurrentShield { get; set; }
        //3.3
        public int CurrentStructure
        {
            get
            {
                return currentStructure;
            }
            set
            {
                //SI LA CURRENTSTRUCTURE EST SET A ZERO ON MET A JOUR L'ATTRIBUT ISDESTROYED
                currentStructure = value;
                if (CurrentStructure == 0)
                {
                    IsDestroyed = true;
                }
            }
        }
        //3.3
        public bool IsDestroyed
        {
            get
            {
                if (CurrentStructure == 0)
                {
                    return true;
                }
                else return false;
            }
            private set
            {
                isDestroyed = value;
            }
        }


        //6.1
        private List<Weapon> WeaponsList;

        public Spaceship()
        {
            MaxStructure = 100;
            MaxShield = 100;
            CurrentShield = 100;
            CurrentStructure = 100;
            WeaponsList = new List<Weapon>();
        }

        //6.2
        //ON AJOUTE UNE ARME SEULEMENT SI ELLE EXISTE DANS L'ARMURERIE,
        //SI ON A ACTUELLEMENT MOINS DE 3 ARMES ET QU'ON A PAS DEJA L'ARME SOUAHITEE
        public void AddWeapon(Weapon weapon)
        {
            if (WeaponsList.Count() < 3 && !CheckWeapon(weapon))
            {
                WeaponsList.Add(weapon);
                Console.WriteLine(weapon.name + " ajouté au vaisseau \n");
            }
            else if (WeaponsList.Count() >= 3) { Console.WriteLine("Vous avez atteint le nombre d'armes maximum\n"); }
            else { Console.WriteLine("Vous ne pouvez pas ajouter la meme arme une seconde fois (" + weapon.name + ")\n"); }
        }


        //ON REMOVE UNE ARME SEULEMENT SI ELLE EXISTE DANS NOTRE VAISSEAU
        public void RemoveWeapon(Weapon oWeapon)
        {
            if (CheckWeapon(oWeapon))
            {
                WeaponsList.Remove(oWeapon);
                Console.WriteLine("Arme " + oWeapon.name + " supprimé\n");
            }
            else { Console.WriteLine("Vous ne possedez pas l'arme " + oWeapon.name + "\n"); }
        }

        public void ClearWeapons()
        {
            WeaponsList.Clear();
            Console.WriteLine("La liste des armes du vaisseau a été vidée\n");
        }

        //6.3
        public void ViewWeapons()
        {
            Console.WriteLine("Liste d'armes du vaisseau : ");
            foreach (Weapon weapon in WeaponsList)
            {
                Console.WriteLine(weapon.ToString());
            }

            if (WeaponsList.Count == 0) { Console.WriteLine("Vide\n"); }
            else { Console.WriteLine(""); };
        }

        public double AverageDamages()
        {
            double moyenne = 0;
            foreach (Weapon weapon in WeaponsList)
            {
                moyenne += ((weapon.MaxDamage + weapon.MinDamage) / 2);
            }
            if ((moyenne / WeaponsList.Count()) > 0) { return moyenne; }
            return 0;
        }

        //VERIFIE SI UNE ARME EST DEJA AJOUTE AU SPACESHIP
        public bool CheckWeapon(Weapon weapon)
        {
            foreach (Weapon w in WeaponsList)
            {
                if (w.name == weapon.name) { return true; }
            }
            return false;
        }

        public void ViewShip()
        {
            Console.WriteLine("Point de structure maximum : " + MaxStructure);
            Console.WriteLine("Point de bouclier maximum : " + MaxShield);
            Console.WriteLine("Point de structure courrant : " + CurrentStructure);
            Console.WriteLine("Point de bouclier courrant : " + CurrentShield);
            ViewWeapons();
        }
    }
}