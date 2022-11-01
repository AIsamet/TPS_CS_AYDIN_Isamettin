using System;
namespace Aydin_Isamettin_Tp1
{
    //2.1
    public abstract class Spaceship
    {
        
        public string Name { get; set; }
        
        protected bool isDestroyed;
        
        protected int currentStructure;
        protected int MaxStructure { get; set; }
        protected int MaxShield { get; set; }
        protected int CurrentShield { get; set; }
        protected int CurrentStructure
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
        protected bool IsDestroyed
        {
            get
            {
                if (CurrentStructure == 0)
                {
                    return true;
                }
                else return false;
            }
            set
            {
                isDestroyed = value;
            }
        }

        public List<Weapon> WeaponsList { get; protected set; }

        public Spaceship()
        {
            MaxStructure = 100;
            MaxShield = 100;
            CurrentStructure = MaxStructure;
            CurrentShield = MaxShield;
            WeaponsList = new List<Weapon>();
        }

        public Spaceship(string name)
        {
            Name = name;
            MaxStructure = 100;
            MaxShield = 100;
            CurrentStructure = MaxStructure;
            CurrentShield = MaxShield;
            WeaponsList = new List<Weapon>();
        }

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
            Console.WriteLine("======== INFOS VAISSEAU ========");
            Console.WriteLine("Nom du vaisseau : " + Name);
            Console.WriteLine("Point de bouclier : " + CurrentShield + "/" + MaxShield);
            Console.WriteLine("Point de structure : " + CurrentStructure + "/" + MaxStructure);
            if (IsDestroyed) { Console.WriteLine("Le vaisseau est détruit"); }
            ViewWeapons();
        }

        //2.3
        public virtual void TakeDamages(Weapon weapon)
        {
            if (CurrentShield > 0)
            {
                CurrentShield -= weapon.Shoot();
                if (CurrentShield < 0)
                {
                    CurrentStructure += CurrentShield;
                    CurrentShield = 0;
                    if (CurrentStructure < 0)
                    {
                        CurrentStructure = 0;
                    }
                }
            }
            else
            {
                CurrentStructure -= weapon.Shoot();
                if (CurrentStructure < 0)
                {
                    CurrentStructure = 0;
                }
            }
        }

        //2.4
        public abstract void ShootTarget(Spaceship target);
    }
}