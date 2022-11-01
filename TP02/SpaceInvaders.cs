using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace TP02
    
{
    public class SpaceInvaders
    {
        private List<Player> Players { get; set; }
        public Armory GameArmory { get; private set; }
        public List<Spaceship> Spaceships { get; private set; }
        public List<Spaceship> EnemySpaceships { get; private set; }



        public SpaceInvaders()
        {
            Init();
        }

        static void Main()
        {

            SpaceInvaders myGame = new SpaceInvaders();

            //NOUVEAU JOUEUR + NOUVEAU VAISSEAU
            myGame.Spaceships.Add(new Rocinante("Faucon Millenium"));
            myGame.Players.Add(new Player("Isamettin", "Aydin", "iSayD", myGame.Spaceships[0]));

            //NOUVEL ENEMI + NOUVEAU VAISSEAU ENEMI
            myGame.Spaceships.Add(new B_Wings("Executor"));
            myGame.EnemySpaceships.Add(myGame.Spaceships[1]);
            myGame.Players.Add(new Player("Dark", "Vador", "D4RK_V4D0R", myGame.Spaceships[1]));

            //AFFICHAGE DES JOUEURS ET VAISSEAUX DE LA PARTIE
            Console.WriteLine("======== JOUEURS ET VAISSEAUX DE LA PARTIE ========");
            myGame.ViewPlayers();
            myGame.ViewSpaceships();
            myGame.ViewEnemySpaceships();

            //ARMES DU VAISSEAU DU JOUEUR Dark Vador
            Console.WriteLine("======== ARMES DU VAISSEAU DU JOUEUR Dark Vador ========");
            myGame.Players[1].MySpaceship.ViewWeapons();

            //ATTAQUE DE JOHN DOE SUR LE VAISSEAU 1
            Console.WriteLine("======== ATTAQUE DU Faucon Millenium PAR Dark Vador ========\n");
            myGame.Players[1].MySpaceship.ShootTarget(myGame.Players[0].MySpaceship);
            myGame.Players[1].MySpaceship.ShootTarget(myGame.Players[0].MySpaceship);

            //AFFICHAGE DU VAISSEAU ATTAQUE
            myGame.Players[0].MySpaceship.ViewShip();

        }

        private void Init()
        {
            Players = new List<Player>();
            Spaceships = new List<Spaceship>();
            EnemySpaceships = new List<Spaceship>();
            /*Players.Add(new Player("john", "doe", "jojo"));
            Players.Add(new Player("jane", "doe", "jaja"));
            Players.Add(new Player("michel", "meyer", "mimi"));*/
            foreach (Player player in Players) {
                Spaceships.Add(player.MySpaceship);
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

