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

            //NOUVEAU JOUEUR + NOUVEAU VAISSEAU
            myGame.Spaceships.Add(new Rocinante("Faucon Millenium"));
            myGame.Players.Add(new Player("Isamettin", "Aydin", "iSayD", myGame.Spaceships[0]));

            //NOUVEL ENEMI + NOUVEAU VAISSEAU ENEMI
            myGame.Spaceships.Add(new F_18("Executor"));
            myGame.EnemySpaceships.Add(myGame.Spaceships[1]);
            myGame.Players.Add(new Player("Dark", "Vador", "D4RK_V4D0R", myGame.Spaceships[1]));

            myGame.Spaceships.Add(new B_Wings("TEST"));
            myGame.EnemySpaceships.Add(myGame.Spaceships[2]);
            myGame.Players.Add(new Player("TEST", "TEST", "TEST", myGame.Spaceships[2]));

            //AFFICHAGE DES JOUEURS ET VAISSEAUX DE LA PARTIE
            Console.WriteLine("======== JOUEURS ET VAISSEAUX DE LA PARTIE ========");
            myGame.ViewPlayers();
            myGame.ViewSpaceships();
            myGame.ViewEnemySpaceships();

            //ARMES DU VAISSEAU DU JOUEUR Dark Vador
            Console.WriteLine("======== ARMES DU VAISSEAU DU JOUEUR Dark Vador ========");
            myGame.Players[2].BattleShip.ViewWeapons();

            //ATTAQUE DE JOHN DOE SUR LE VAISSEAU 1
            Console.WriteLine("======== ATTAQUE DU Faucon Millenium PAR Dark Vador ========\n");
            myGame.Players[2].BattleShip.ShootTarget(myGame.Players[0].BattleShip);
            myGame.Players[2].BattleShip.ShootTarget(myGame.Players[0].BattleShip);
            myGame.Players[2].BattleShip.ShootTarget(myGame.Players[0].BattleShip);

            //VAISSEAUX SUITE APTITUDE DU TARDIS
            Console.WriteLine("======== LISTE VAISSEAUX SUITE APTITUDE DU TARDIS ========\n");
            myGame.ViewEnemySpaceships();

            //AFFICHAGE DU VAISSEAU ATTAQUE
            myGame.Players[0].BattleShip.ViewShip();

        }

        //4.2
        private void Init()
        {
            Players = new List<Player>();
            GameArmory = new Armory();
            Spaceships = new List<Spaceship>();
            EnemySpaceships = new List<Spaceship>();

            //Spaceships.Add(new Rocinante("Faucon Millenium"));
            //Players.Add(new Player("Isamettin", "Aydin", "iSayD", Spaceships[0]));

            EnemySpaceships.Add(new Dart("Dart"));
            EnemySpaceships.Add(new B_Wings("B_Wings"));
            EnemySpaceships.Add(new Rocinante("Rocinante"));
            EnemySpaceships.Add(new ViperMKII("ViperMKII"));
            EnemySpaceships.Add(new F_18("F_18"));
            EnemySpaceships.Add(new Tardis("Tardis"));


            foreach (Player player in Players)
            {
                Spaceships.Add(player.BattleShip);
            }
        }


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
        //4.3
        private void PlayRound()
        {
            Console.WriteLine("Debut du tour");
            //4.3.a & 4.3.b
            for (int i = 0; i < EnemySpaceships.Count(); i++)
            {
                if (!Players[0].BattleShip.IsDestroyed)
                {
                    if (CanAttack(i, EnemySpaceships.Count()))
                    {
                        //le joueur est chanceux, il a le droit d'attaquer
                        Console.WriteLine("Le joueur est chanceux il a le droit d'attaquer" + +i + " chance sur " + EnemySpaceships.Count() + ")");

                        Random random = new Random();
                        int randomEnemy = random.Next(0, EnemySpaceships.Count());

                    }
                }
                else
                {

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
                Console.WriteLine(spaceship.Name + " (owner : " + spaceship.Owner + ")");
            }
            Console.Write("\n");
        }
        private void ViewEnemySpaceships()
        {
            Console.WriteLine("Liste des vaisseaux ennemis : ");
            foreach (Spaceship spaceship in this.EnemySpaceships)
            {
                Console.WriteLine(spaceship.Name + " (owner : " + spaceship.Owner + ")");
            }
            Console.Write("\n");
        }

    }
}

