using System;

namespace TP02

{
    //2.1
    public abstract class Spaceship : ISpaceship
    {

        public string Name { get; set; }
        public double Structure { get; set; }
        public double Shield { get; set; }
        public bool IsDestroyed
        {
            get
            {
                if (CurrentShield == 0 && CurrentStructure == 0)
                { return true; }
                else return false;
            }
        }
        public int MaxWeapons { get; }
        public List<Weapon> Weapons { get; }
        public double AverageDamages
        {
            get
            {
                double moyenne = 0;
                foreach (Weapon weapon in Weapons)
                {
                    moyenne += weapon.AverageDamage;
                }

                if (Weapons.Count() != 0)
                {
                    moyenne = moyenne / Weapons.Count();
                    return moyenne;
                }
                else { return 0; }
            }
        }
        public double CurrentStructure { get; set; }
        public double CurrentShield { get; set; }
        public bool BelongsPlayer
        {
            get
            {
                if (Owner != null)
                {
                    return true;
                }
                else return false;
            }
        }
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

        //on ajoute une arme seulement si elle existe dans l'armurerie
        //et si on a actuellement moins de 3 armes et qu'on a pas deja l'arme souahitee
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


        //on remove une arme seulement si elle existe dans notre vaisseau
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

        //fonction qui verifie si une arme est deja ajoute au spaceship
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
            if (CurrentShield > Shield) { CurrentShield = Shield; }
        }

        //fonction qui recharge toutes les armes
        public void ReloadWeapons()
        {
            foreach (Weapon weapon in Weapons)
            {
                weapon.TimeBeforReload = 0;
            }
        }

        //2.3
        public virtual void TakeDamages(double damages)
        {
            if (damages > 0)
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

                CurrentShield = Math.Round(CurrentShield, 1);
                CurrentStructure = Math.Round(CurrentStructure, 1);

                if (this.BelongsPlayer)
                {
                    Console.WriteLine(this.GetType().Name + " (joueur : " + this.Owner.Alias + ") prends " + damages + " degats \n");
                    if (this.IsDestroyed)
                    {
                        Console.WriteLine(this.GetType().Name + " est detruit \n");
                    }
                }
                else if (!this.BelongsPlayer)
                {
                    Console.WriteLine(this.GetType().Name + " (joueur : Ennemi) prends " + damages + " degats \n");
                    if (this.IsDestroyed)
                    {
                        Console.WriteLine(this.GetType().Name + " est detruit \n");
                    }
                }
            }
        }

        protected void DisplayAttackerProfile()
        {
            if (this.BelongsPlayer) { Console.WriteLine(this.GetType().Name + " (joueur : " + this.Owner.Alias + ") passe a l'attaque ! \n"); }
            if (!this.BelongsPlayer) { Console.WriteLine(this.GetType().Name + " (joueur : Ennemi)  passe a l'attaque ! \n"); }
        }

        //2.4 & 2.d.2
        public virtual void ShootTarget(Spaceship target)
        {
            Random random = new Random();
            DisplayAttackerProfile();

            if (Weapons.Count() != 0)
            {
                int randomWeapon = random.Next(0, Weapons.Count());
                double degatsAttaque = Weapons[randomWeapon].Shoot();
                target.TakeDamages(degatsAttaque);
            }
            else { Console.WriteLine("Tu n'a pas d'arme mon ami\n"); }
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------\n");
        }
    }
}
