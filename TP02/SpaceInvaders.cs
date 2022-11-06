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
            Console.WriteLine("========================= JOUEURS ET VAISSEAUX DE LA PARTIE =========================");
            myGame.ViewPlayers();
            myGame.ViewSpaceships();
            myGame.ViewEnemySpaceships();

            //VAISSEAUX SUITE APTITUDE DU TARDIS
            Console.WriteLine("\n======================================== JEU ========================================\n\n");

            //4.4
            while (!myGame.Players[0].BattleShip.IsDestroyed && myGame.RandomEnemyToAttack() != -1)
            {
                myGame.PlayRound();
            }
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

            EnemySpaceships.Add(new ViperMKII("Dart"));
           // EnemySpaceships.Add(new B_Wings("B_Wings"));
           // EnemySpaceships.Add(new Rocinante("Rocinante"));
           // EnemySpaceships.Add(new ViperMKII("ViperMKII"));
            //EnemySpaceships.Add(new F_18("F_18"));
            //EnemySpaceships.Add(new Tardis("Tardis"));

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


        private int RandomEnemyToAttack()
        {
            Random random = new Random();
            for (int i = EnemySpaceships.Count(); i > 0; i--)
            {
                int randomEnemy = random.Next(0, i);
                if (!EnemySpaceships[randomEnemy].IsDestroyed)
                {
                    return randomEnemy;
                }
            }
            return -1;
        }

        //4.3.d les vaisseaux ayant perdu des points de bouclier en regagnent maximum 2
        private void Heal()
        {
            foreach(Spaceship spaceship in Spaceships)
            {
                if(spaceship.CurrentShield < spaceship.Shield)
                {
                    Random random = new Random();
                    int randomHeal = random.Next(0, 2);
                    spaceship.CurrentShield += randomHeal;
                }
            }
        }

        //4.3
        private void PlayRound()
        {
            Console.WriteLine("\n                    Debut du tour                 \n");
            Console.WriteLine("------------------------------------------------------------\n");

            //4.3.d les vaisseaux ayant perdu des points de bouclier en regagnent maximum 2
            Heal();

            //sert a savoir si le joueur a deja attaqué
            bool playerAttacked = false;

            //3.3
            foreach (Spaceship spaceship in EnemySpaceships)
            {
                if (spaceship is IAbility)
                {
                    Console.WriteLine("Le vaisseau " + spaceship.Name + " a une aptitude speciale et l'utilise\n");
                    spaceship.ShootTarget(Players[0].BattleShip);
                }
            }

            //4.3.a On joue dans l'ordre de la liste d'enemies
            for (int i = 0; i < EnemySpaceships.Count(); i++)
            {
                //On joue si le vaisseau du joueur n'est pas detruit
                if (!Players[0].BattleShip.IsDestroyed)
                {
                    //4.3.c
                    if (CanAttack(i, EnemySpaceships.Count()) && !playerAttacked)
                    {
                        int proba = i + 1; 
                        //le joueur peut attaquer
                        Console.WriteLine("Le joueur peut attaquer (probabilité " + proba + "/" + EnemySpaceships.Count() + ")");
                        if (RandomEnemyToAttack() != -1)
                        {
                            Players[0].BattleShip.ShootTarget(EnemySpaceships[RandomEnemyToAttack()]);
                        }
                        else
                        {
                            Console.WriteLine("Il ne reste plus de vaisseau enemi a attaquer, feliciations !");
                            break;
                        }
                        playerAttacked = true;
                    }

                    //4.3.b tous les ennemis tirent sur le vaisseau du joueur
                    EnemySpaceships[i].ShootTarget(Players[0].BattleShip);
                }
                else
                {
                    Console.WriteLine("Le vaisseau du joueurs est detruit, la partie est finie");
                    break;
                }

            }
            Console.WriteLine("\n                    Fin du tour                    \n");
            ViewSpaceships();
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");
            Console.WriteLine("\n               Application des soins :               \n");
            ViewSpaceships();
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n");

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

        private void ViewSpaceships()
        {
            Console.WriteLine("Liste des vaisseaux : ");
            foreach (Spaceship spaceship in this.Spaceships)
            {
                if (spaceship.Owner != null)
                {
                    if (spaceship.IsDestroyed) { Console.Write("Destroyed : "); }
                    Console.WriteLine(spaceship.Name + " (owner : " + spaceship.Owner + ") : Strucutre = " + spaceship.CurrentStructure + "/" + spaceship.Structure + " ; Shield = " + spaceship.CurrentShield + "/" + spaceship.Shield);
                }
                else
                {
                    if (spaceship.IsDestroyed) { Console.Write("Destroyed : "); }
                    Console.WriteLine(spaceship.Name + " (owner : Ennemi ) : Strucutre = " + spaceship.CurrentStructure + "/" + spaceship.Structure + " ; Shield = " + spaceship.CurrentShield + "/" + spaceship.Shield);
                }
            }
            Console.Write("\n");
        }
        private void ViewEnemySpaceships()
        {
            Console.WriteLine("Liste des vaisseaux ennemis : ");
            foreach (Spaceship spaceship in this.EnemySpaceships)
            {
                Console.WriteLine(spaceship.Name + " (owner : Ennemi )");
            }
            Console.Write("\n");
        }

    }
}

