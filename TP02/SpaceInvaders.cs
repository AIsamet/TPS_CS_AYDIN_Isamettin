using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace TP02

{
    public class SpaceInvaders
    {
        public List<Player> Players { get;  set; }
        public Armory GameArmory { get;  set; }
        public List<Spaceship> Spaceships { get;  set; }
        public List<Spaceship> EnemySpaceships { get;  set; }

        //implementation thread safe du patern singleton pour la classe SpaceInvaders
        private static readonly Lazy<SpaceInvaders> lazy = new Lazy<SpaceInvaders>( () => new SpaceInvaders() );
        public static SpaceInvaders GetInstance { get { return lazy.Value; } }

        private SpaceInvaders()
        {
            Init();
        }

        
        private static void Main()
        {

            SpaceInvaders myGame = GetInstance;

            //NOUVEAU JOUEUR + NOUVEAU VAISSEAU
            myGame.Spaceships.Add(new Dart("Faucon Millenium"));
            myGame.Players.Add(new Player("Isamettin", "Aydin", "iSayD", myGame.Spaceships[0]));

            //NOUVEL ENEMI + NOUVEAU VAISSEAU ENEMI
            myGame.Spaceships.Add(new F_18("Executor"));
            myGame.EnemySpaceships.Add(myGame.Spaceships[1]);
            myGame.Players.Add(new Player("Dark", "Vador", "D4RK_V4D0R", myGame.Spaceships[1]));
            
            myGame.Spaceships.Add(new Tardis("TEST"));
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

            //VAISSEAUX SUITE APTITUDE DU TARDIS
            Console.WriteLine("======== VAISSEAUX SUITE APTITUDE DU TARDIS ========\n");
            myGame.ViewEnemySpaceships();

            //AFFICHAGE DU VAISSEAU ATTAQUE
            myGame.Players[0].BattleShip.ViewShip();

        }

        private void Init()
        {
            Players = new List<Player>();
            Spaceships = new List<Spaceship>();
            EnemySpaceships = new List<Spaceship>();
            /*Players.Add(new Player("john", "doe", "jojo"));
            Players.Add(new Player("jane", "doe", "jaja"));
            Players.Add(new Player("michel", "meyer", "mimi"));*/
            foreach (Player player in Players)
            {
                Spaceships.Add(player.BattleShip);
            }
            GameArmory = new Armory();
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

