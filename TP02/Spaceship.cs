using System;

namespace TP02
    
{
    //2.1
    public abstract class Spaceship : ISpaceship
    {
        
        public string Name { get; set; }
        public double Structure { get; set; }
        public double Shield { get; set; }
        public bool IsDestroyed { get
            {
                if (CurrentShield == 0 && CurrentStructure == 0)
                { return true; }
                else return false;
            } }
        public int MaxWeapons { get; }
        public List<Weapon> Weapons { get; }
        public double AverageDamages { get
            {
                double moyenne = 0;
                foreach (Weapon weapon in Weapons)
                {
                    moyenne += ((weapon.MaxDamage + weapon.MinDamage) / 2);
                }
                if ((moyenne / Weapons.Count()) > 0) { return moyenne; }
                return 0;
            } }
        public double CurrentStructure { get; set; }
        public double CurrentShield { get; set; }
        public bool BelongsPlayer { get; }
        public Player Owner { get; set; }

        public Spaceship()
        {
            Name = "Default Name";
            Structure = 100;
            Shield = 100;
            CurrentStructure = Structure;
            CurrentShield = Shield;
            Weapons = new List<Weapon>();
        }

        public Spaceship(string name)
        {
            Name = name;
            Structure = 100;
            Shield = 100;
            CurrentStructure = Structure;
            CurrentShield = Shield;
            Weapons = new List<Weapon>();
        }

        //ON AJOUTE UNE ARME SEULEMENT SI ELLE EXISTE DANS L'ARMURERIE,
        //SI ON A ACTUELLEMENT MOINS DE 3 ARMES ET QU'ON A PAS DEJA L'ARME SOUAHITEE
        public void AddWeapon(Weapon weapon)
        {
            if (Weapons.Count() < 3 && !CheckWeapon(weapon))
            {
                Weapons.Add(weapon);
                Console.WriteLine(weapon.Name + " ajouté au vaisseau \n");
            }
            else if (Weapons.Count() >= 3) { Console.WriteLine("Vous avez atteint le nombre d'armes maximum\n"); }
            else { Console.WriteLine("Vous ne pouvez pas ajouter la meme arme une seconde fois (" + weapon.Name + ")\n"); }
        }


        //ON REMOVE UNE ARME SEULEMENT SI ELLE EXISTE DANS NOTRE VAISSEAU
        public void RemoveWeapon(Weapon oWeapon)
        {
            if (CheckWeapon(oWeapon))
            {
                Weapons.Remove(oWeapon);
                Console.WriteLine("Arme " + oWeapon.Name + " supprimé\n");
            }
            else { Console.WriteLine("Vous ne possedez pas l'arme " + oWeapon.Name + "\n"); }
        }

        public void ClearWeapons()
        {
            Weapons.Clear();
            Console.WriteLine("La liste des armes du vaisseau a été vidée\n");
        }

        public void ViewWeapons()
        {
            Console.WriteLine("Liste d'armes du vaisseau : ");
            foreach (Weapon weapon in Weapons)
            {
                Console.WriteLine(weapon.ToString());
            }

            if (Weapons.Count == 0) { Console.WriteLine("Vide\n"); }
            else { Console.WriteLine(""); };
        }

        //VERIFIE SI UNE ARME EST DEJA AJOUTE AU SPACESHIP
        public bool CheckWeapon(Weapon weapon)
        {
            foreach (Weapon w in Weapons)
            {
                if (w.Name == weapon.Name) { return true; }
            }
            return false;
        }

        public void ViewShip()
        {
            Console.WriteLine("======== INFOS VAISSEAU ========");
            Console.WriteLine("Nom du vaisseau : " + Name);
            Console.WriteLine("Point de bouclier : " + CurrentShield + "/" + Shield);
            Console.WriteLine("Point de structure : " + CurrentStructure + "/" + Structure);
            if (IsDestroyed) { Console.WriteLine("Le vaisseau est détruit"); }
            ViewWeapons();
        }

        public void RepairShield(double repair)
        {
            CurrentShield += repair;
        }

        public void ReloadWeapons()
        {
            
        }

        //2.3
        public virtual void TakeDamages(double damages)
        {
            if (CurrentShield > 0)
            {
                CurrentShield -= damages;
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
                CurrentStructure -= damages;
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