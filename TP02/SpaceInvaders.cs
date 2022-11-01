using System;
using TP02;

namespace Aydin_Isamettin_Tp1
{
    public class SpaceInvaders
    {
        private List<Player> Players { get; set; }
        public Armory GameArmory { get; private set; }

        public SpaceInvaders()
        {
            Init();
        }

        static void Main()
        {
            SpaceInvaders myGame = new SpaceInvaders();

            Console.WriteLine("Liste des joueurs :");
            foreach (Player p in myGame.Players)
            {
                Console.WriteLine(p.ToString());
            }
            Console.Write("\n");

            //VAISSEAU 1
            Spaceship spaceship = new Rocinante("Faucon Millenium");
            myGame.Players.Add(new Player("Isamettin", "Aydin", "iSayD", spaceship));


            //ARMES DU VAISSEAU DU JOUEUR JOHN DOE
            Console.WriteLine("======== ARME DU JOUEUR JOHN DOE ========");
            myGame.Players[0].MySpaceship.ViewWeapons();

            //ATTAQUE DE JOHN DOE SUR LE VAISSEAU 1
            Console.WriteLine("======== ATTAQUE DU Faucon Millenium PAR JOHN DOE ========\n");
            myGame.Players[0].MySpaceship.ShootTarget(myGame.Players[3].MySpaceship);
            myGame.Players[0].MySpaceship.ShootTarget(myGame.Players[3].MySpaceship);
            myGame.Players[0].MySpaceship.ShootTarget(myGame.Players[3].MySpaceship);


            //AFFICHAGE DU VAISSEAU ATTAQUE
            myGame.Players[3].MySpaceship.ViewShip();

        }

        private void Init()
        {
            Players = new List<Player>();
            Players.Add(new Player("john", "doe", "jojo"));
            Players.Add(new Player("jane", "doe", "jaja"));
            Players.Add(new Player("michel", "meyer", "mimi"));
            GameArmory = new Armory();
        }
    }
}

