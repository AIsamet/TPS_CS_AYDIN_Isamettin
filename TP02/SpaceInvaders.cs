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
            Console.WriteLine("======== JOUEURS ET VAISSEAUX DE LA PARTIE ========");
            myGame.ViewPlayers();
            myGame.ViewSpaceships();
            myGame.ViewEnemySpaceships();

            //VAISSEAUX SUITE APTITUDE DU TARDIS
            Console.WriteLine("======== JEU ========\n");
            myGame.PlayRound();

        }
        
        //4.2
        private void Init()
        {
            Players = new List<Player>();
            GameArmory = new Armory();
            Spaceships = new List<Spaceship>();
            EnemySpaceships = new List<Spaceship>();

            Spaceships.Add(new Rocinante("Faucon Millenium"));
            Players.Add(new Player("Isamettin", "Aydin", "iSayD", Spaceships[0]));

            EnemySpaceships.Add(new Dart("Dart"));
            EnemySpaceships.Add(new B_Wings("B_Wings"));
            EnemySpaceships.Add(new Rocinante("Rocinante"));
            EnemySpaceships.Add(new ViperMKII("ViperMKII"));
            EnemySpaceships.Add(new F_18("F_18"));
            EnemySpaceships.Add(new Tardis("Tardis"));
            
            foreach(Spaceship spaceship in EnemySpaceships)
            {
                Spaceships.Add(spaceship);
            }
            //ISRELOAD a utiliser dans playround voir 1.2
            // + Q3.3
        }

        //4.3.c
        private bool CanAttack(int i, int NumberOfEnemies)
        {
            Random random = new Random();
            int chance = random.Next(NumberOfEnemies);
            if (chance < i - 1)
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
        
        //4.3
        private void PlayRound()
        {
            Console.WriteLine("Debut du tour");
            
            //4.3.a
            for (int i = 0; i < EnemySpaceships.Count(); i++)
            {
                if (!Players[0].BattleShip.IsDestroyed)
                {
                    //4.3.c
                    if (CanAttack(i, EnemySpaceships.Count()))
                    {
                        //le joueur est chanceux, il a le droit d'attaquer
                        Console.WriteLine("Le joueur attaque (" + i + " chance sur " + EnemySpaceships.Count() + ")");
                        if (RandomEnemyToAttack() != -1)
                        {
                            Players[0].BattleShip.ShootTarget(EnemySpaceships[RandomEnemyToAttack()]);
                        }
                        else
                        {
                            Console.WriteLine("Il ne reste plus de vaisseau enemi a attaquer, feliciations !");
                            break;
                        }
                    }
                    //4.3.b
                    EnemySpaceships[i].ShootTarget(Players[0].BattleShip);
                }
                else
                {
                    Console.WriteLine("Le vaisseau du joueurs est detruit, la partie est finie");
                    break;
                }

            }
            Console.WriteLine("Fin du tour");
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
                    Console.WriteLine(spaceship.Name + " (owner : " + spaceship.Owner + ")");
                }
                else
                {
                    Console.WriteLine(spaceship.Name + " (owner : Ennemi )");
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

