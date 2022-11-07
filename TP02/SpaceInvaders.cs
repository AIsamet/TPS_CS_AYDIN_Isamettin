using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace TP02

{
    public class SpaceInvaders
    {
        public List<Player> Players { get; set; }
        public Armory GameArmory { get; set; }
        public List<Spaceship> Spaceships { get; set; }

        //4.1
        public List<Spaceship> EnemySpaceships { get; set; }

        //implementation thread safe du patern singleton pour la classe SpaceInvaders
        private static readonly Lazy<SpaceInvaders> lazy = new Lazy<SpaceInvaders>(() => new SpaceInvaders());
        public static SpaceInvaders GetInstance { get { return lazy.Value; } }

        private SpaceInvaders()
        {
            Init();
        }

        private static void Main()
        {

            SpaceInvaders myGame = GetInstance;


            //AFFICHAGE DES JOUEURS ET VAISSEAUX DE LA PARTIE
            Console.WriteLine("======================================== JOUEURS ET VAISSEAUX DE LA PARTIE =======================================");
            myGame.ViewPlayers();
            myGame.ViewSpaceships();
            myGame.ViewEnemySpaceships();

            //DEBUT DU JEU 
            Console.WriteLine("\n====================================================== JEU ======================================================\n");

            //4.4 On lance un tour tant que le vaisseau joueur n'est pas detruit et qu'il y a des vaisseaux ennemis non detruits
            while (!myGame.Players[0].BattleShip.IsDestroyed && myGame.GetCountNonDestroyedEnemies() != 0)
            {
                myGame.PlayRound();
                if (myGame.Players[0].BattleShip.IsDestroyed)
                {
                    Console.WriteLine("Le vaisseau du joueur est detruit, malheureusement c'est perdu !");
                }
                else if (myGame.GetCountNonDestroyedEnemies() == 0)
                {
                    Console.WriteLine("Il ne reste plus de vaisseau ennemis, felicitation c'est gagné !");
                }
            }

            //4.5 Lancez le programme pour afficher une partie
        }

        //4.2
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

        //4.3.c fonction qui calcule la chance de pouvoir attaquer du joueur
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

        //4.3.d les vaisseaux ayant perdu des points de bouclier en regagnent aléatoirement maximum 2
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

        //4.3
        private void PlayRound()
        {
            Console.WriteLine("\n                                                  Debut du tour");
            Console.WriteLine("\n                                Application des soins de maniere aléatoire en cours\n");
            //4.3.d les vaisseaux ayant perdu des points de bouclier en regagnent maximum 2
            Heal();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------\n");

            //sert a savoir si le joueur a deja attaqué
            bool playerAttacked = false;

            //3.3 tout les vaisseaux ennemis ayant une abilité special et non detruits attaquent au debut du tour
            foreach (Spaceship spaceship in EnemySpaceships)
            {
                if (spaceship is IAbility && !spaceship.IsDestroyed)
                {
                    if (spaceship.BelongsPlayer) { Console.WriteLine("Le vaisseau " + spaceship.Name  +" (joueur : " + spaceship.Owner.Alias+ ") a une aptitude speciale et l'utilise\n"); }
                    else { Console.WriteLine("Le vaisseau " + spaceship.Name + " (joueur : Ennemi) a une aptitude speciale et l'utilise\n"); }
                    spaceship.ShootTarget(Players[0].BattleShip);
                }
            }

            //4.3.a On joue dans l'ordre de la liste d'enemies
            for (int i = 0; i < EnemySpaceships.Count(); i++)
            {
                //4.3.c le joueur peut attaquer s'il a de la chance, s'il n'a pas deja attaqué et s'il n'est pas detruit
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

                //4.3.b tous les ennemis qui n'ont pas d'abilité special et qui sont toujours en jeu tirent sur le vaisseau du joueur
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

