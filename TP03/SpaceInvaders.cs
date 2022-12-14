using System;

namespace TP03

{
    public class SpaceInvaders
    {
        public List<Player> Players { get; set; }
        public Armory GameArmory { get; set; }
        public List<Spaceship> Spaceships { get; set; }

        public List<Spaceship> EnemySpaceships { get; set; }

        //implementation thread safe du patern singleton pour la classe SpaceInvaders
        private static readonly Lazy<SpaceInvaders> lazy = new Lazy<SpaceInvaders>(() => new SpaceInvaders());
        public static SpaceInvaders GetInstance { get { return lazy.Value; } }

        private SpaceInvaders()
        {
            Init();
        }

        private static void Main(string[] args)
        {
            //2.6 appel de la seconde fonction main si un parametre est renseigné
            if (args.Length > 0)
            {
                Main(args[0]);
            }
            else
            {
                string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Words.txt";
                SpaceInvaders myGame = GetInstance;
                int wordMinSize = 6;

                ArmeImporteur importer = new ArmeImporteur(path);
                importer.blacklistedWords.Add("Midnight");

                Console.WriteLine("\n====================================================== FREQUENCES ===================================================================================\n");
                importer.ReadFile(path, wordMinSize);

                Console.WriteLine("\n====================================================== ARMURERIE ====================================================================================\n");
                myGame.GameArmory.ViewArmory();

                Console.WriteLine("\n============================================== EXPORT DANS L'ARMURERIE ==============================================================================\n");
                importer.WeaponExporter();

                Console.WriteLine("\n====================================================== ARMURERIE ====================================================================================\n");
                myGame.GameArmory.ViewArmory();

                //2.6 Affiche les 5 armes avec les plus gros dommages moyens, les 5 armes possédant les dommages minimums les plus hauts
                Console.WriteLine("\n============================================== ORDER BY DEGATS MOY DESC =============================================================================\n");
                Console.WriteLine("\nLes 5 armes avec les plus gros dommages moyens :");
                foreach (Weapon w in myGame.GameArmory.GetFiveHighestAverageDamageDesc())
                {
                    Console.WriteLine("\t" + w.Name + " : " + w.AverageDamage);
                }

                Console.WriteLine("\n============================================== ORDER BY DEGATS MIN DESC =============================================================================\n");
                Console.WriteLine("\nLes 5 armes possédant les dommages minimums les plus hauts :");
                foreach (Weapon w in myGame.GameArmory.GetFiveHighestMinDamageWeaponsDesc())
                {
                    Console.WriteLine("\t" + w.Name + " : " + w.MinDamage);
                }
            }
        }

        //2.5 seconde fonction Main, permettant de passer en arguments du programme le fichier d’entrée
        private static void Main(string chemin)
        {
            string path = chemin;
            SpaceInvaders myGame = GetInstance;
            int wordMinSize = 6;

            ArmeImporteur importer = new ArmeImporteur(path);
            importer.blacklistedWords.Add("Midnight");

            Console.WriteLine("\n====================================================== FREQUENCES ======================================================\n");
            importer.ReadFile(path, wordMinSize);

            Console.WriteLine("\n====================================================== ARMURERIE =======================================================\n");
            myGame.GameArmory.ViewArmory();

            Console.WriteLine("\n============================================== EXPORT DANS L'ARMURERIE =================================================\n");
            importer.WeaponExporter();

            Console.WriteLine("\n====================================================== ARMURERIE =======================================================\n");
            myGame.GameArmory.ViewArmory();

            //2.6 Affiche les 5 armes avec les plus gros dommages moyens, les 5 armes possédant les dommages minimums les plus hauts
            Console.WriteLine("\n============================================== ORDER BY DEGATS MOY DESC ================================================\n");
            Console.WriteLine("\nles 5 armes avec les plus gros dommages moyens :");
            foreach (Weapon w in myGame.GameArmory.GetFiveHighestAverageDamageDesc())
            {
                Console.WriteLine("\t" + w.Name + " : " + w.AverageDamage);
            }

            Console.WriteLine("\n============================================== ORDER BY DEGATS MIN DESC ================================================\n");
            Console.WriteLine("\nles 5 armes possédant les dommages minimums les plus hauts :");
            foreach (Weapon w in myGame.GameArmory.GetFiveHighestMinDamageWeaponsDesc())
            {
                Console.WriteLine("\t" + w.Name + " : " + w.MinDamage);
            }
        }

        private void Init()
        {
            Players = new List<Player>();
            GameArmory = new Armory();
            Spaceships = new List<Spaceship>();
            EnemySpaceships = new List<Spaceship>();

            Spaceships.Add(new B_Wings("Faucon Millenium"));
            Players.Add(new Player("Isamettin", "Aydin", "iSayD", Spaceships[0]));

            EnemySpaceships.Add(new Dart("Dart"));
            EnemySpaceships.Add(new B_Wings("B_Wings"));
            EnemySpaceships.Add(new Rocinante("Rocinante"));
            EnemySpaceships.Add(new ViperMKII("ViperMKII"));
            EnemySpaceships.Add(new F_18("F_18"));
            EnemySpaceships.Add(new Tardis("Tardis"));

            //on ajoute les vaisseaux ennemis dans la liste globale de tout les vaisseaux
            foreach (Spaceship spaceship in EnemySpaceships)
            {
                Spaceships.Add(spaceship);
            }

        }

        private bool CanAttack(int i, int NumberOfEnemies)
        {
            Random random = new Random();
            int chance = random.Next(NumberOfEnemies);

            if (chance <= i)
            {
                return true;
            }
            else return false;
        }

        //fonction qui retourne le nombre de vaisseau ennemis non detruits
        private int GetCountNonDestroyedEnemies()
        {
            int count = 0;
            foreach (Spaceship spaceship in EnemySpaceships)
            {
                if (!spaceship.IsDestroyed)
                {
                    count++;
                }
            }
            return count;
        }

        //fonction qui retourne un ennemi aleatoire a attaquer
        private int RandomEnemyToAttack()
        {
            int attackableEnnemies = GetCountNonDestroyedEnemies();
            Random random = new Random();
            int randomEnemy = 0;

            //premiere verification afin de ne pas surcharger le processeur pour rien dans le cas d'un seul vaisseau ennemi
            if (attackableEnnemies == 1)
            {
                randomEnemy = 0;
                return randomEnemy;
            }

            //sinon on cherche un vaisseau aleatoire parmi tout les ennemis
            else if (attackableEnnemies > 1)
            {
                randomEnemy = random.Next(attackableEnnemies);
                while (EnemySpaceships[randomEnemy].IsDestroyed)
                {
                    randomEnemy = random.Next(attackableEnnemies);
                }
                return randomEnemy;
            }
            return -1;
        }

        private void Heal()
        {
            foreach (Spaceship spaceship in Spaceships)
            {
                if (spaceship.CurrentShield < spaceship.Shield && !spaceship.IsDestroyed)
                {
                    Random random = new Random();
                    int randomHeal = random.Next(0, 3); //genere des reparations entre 0 et 2
                    spaceship.RepairShield(randomHeal);
                    Console.WriteLine("Le vaisseau " + spaceship.Name + " gagne " + randomHeal + " point de shield\n");
                }
            }
        }

        private void PlayRound()
        {
            Console.WriteLine("\n                                                  Debut du tour");
            Console.WriteLine("\n                                Application des soins de maniere aléatoire en cours\n");
            //4.3.d les vaisseaux ayant perdu des points de bouclier en regagnent maximum 2
            Heal();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------\n");

            //sert a savoir si le joueur a deja attaqué
            bool playerAttacked = false;

            foreach (Spaceship spaceship in EnemySpaceships)
            {
                if (spaceship is IAbility && !spaceship.IsDestroyed)
                {
                    if (spaceship.BelongsPlayer) { Console.WriteLine("Le vaisseau " + spaceship.Name + " (joueur : " + spaceship.Owner.Alias + ") a une aptitude speciale et l'utilise\n"); }
                    else { Console.WriteLine("Le vaisseau " + spaceship.Name + " (joueur : Ennemi) a une aptitude speciale et l'utilise\n"); }
                    spaceship.ShootTarget(Players[0].BattleShip);
                }
            }

            for (int i = 0; i < EnemySpaceships.Count(); i++)
            {
                if (CanAttack(i, EnemySpaceships.Count()) && !playerAttacked && !Players[0].BattleShip.IsDestroyed)
                {
                    int proba = i + 1;
                    //le joueur peut attaquer
                    Console.WriteLine("Le joueur peut attaquer (probabilité " + proba + "/" + EnemySpaceships.Count() + ")\n");
                    if (RandomEnemyToAttack() != -1)
                    {
                        Players[0].BattleShip.ShootTarget(EnemySpaceships[RandomEnemyToAttack()]);
                    }
                    playerAttacked = true;
                }

                //si le vaisseau du joueur n'est pas encore deja detruit
                if (EnemySpaceships[i] is IAbility == false && !EnemySpaceships[i].IsDestroyed && !Players[0].BattleShip.IsDestroyed)
                {
                    EnemySpaceships[i].ShootTarget(Players[0].BattleShip);
                }


            }
            Console.WriteLine("\n                                                  Fin du tour\n");
            ViewSpaceships();
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");
            ViewDestroyedSpaceships();
            Console.WriteLine("Nombre de vaisseaux ennemis restants : " + GetCountNonDestroyedEnemies());
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");

        }

        private void ViewPlayers()
        {
            Console.WriteLine("Liste des joueurs :");
            foreach (Player p in this.Players)
            {
                Console.WriteLine(p.ToString());
            }
            Console.Write("\n");
        }

        //fonction permettant de generer un affichage selon le proprietaire du vaisseau (joueur ou ennemi)
        private void DisplaySpaceshipByOwnerType(Spaceship spaceship)
        {
            if (spaceship.Owner != null)
            {
                if (spaceship.IsDestroyed) { Console.Write("Destroyed : "); }
                Console.WriteLine(spaceship.Name + " de type " + spaceship.GetType().Name + " (owner : " + spaceship.Owner + ") : Strucutre = " + spaceship.CurrentStructure + "/" + spaceship.Structure + " ; Shield = " + spaceship.CurrentShield + "/" + spaceship.Shield);
            }
            else
            {
                if (spaceship.IsDestroyed) { Console.Write("Destroyed : "); }
                Console.WriteLine(spaceship.Name + " de type " + spaceship.GetType().Name + " (owner : Ennemi) : Strucutre = " + spaceship.CurrentStructure + "/" + spaceship.Structure + " ; Shield = " + spaceship.CurrentShield + "/" + spaceship.Shield);
            }
        }

        //fonction qui affiche tout les vaisseaux du jeu (joueur ou ennemi)
        private void ViewSpaceships()
        {
            Console.WriteLine("Liste de tout les vaisseaux : ");
            foreach (Spaceship spaceship in this.Spaceships)
            {
                DisplaySpaceshipByOwnerType(spaceship);
            }
            Console.Write("\n");
        }

        //fonction qui affiche tout les vaisseaux detruits (joueur ou ennemi)
        private void ViewDestroyedSpaceships()
        {
            Console.WriteLine("Liste des vaisseaux detruits : ");
            foreach (Spaceship spaceship in this.Spaceships)
            {
                if (spaceship.IsDestroyed)
                {
                    DisplaySpaceshipByOwnerType(spaceship);
                }
            }
            Console.Write("\n");
        }

        //fonction qui affiche les vaisseaux ennemis
        private void ViewEnemySpaceships()
        {
            Console.WriteLine("Liste des vaisseaux ennemis : ");
            foreach (Spaceship spaceship in this.EnemySpaceships)
            {
                DisplaySpaceshipByOwnerType(spaceship);
            }
            Console.Write("\n");
        }

    }
}

