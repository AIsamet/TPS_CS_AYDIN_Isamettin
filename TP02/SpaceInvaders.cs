using System;
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

            //ARMES DU VAISSEAU DU JOUEUR JOHN DOE
            myGame.Players[0].MySpaceship.ViewWeapons();

            //CREATION D'UNE NOUVELLE ARME
            Weapon myWeapon = new Weapon("Annihilateur lourd", 80, 100, Weapon.EWeaponType.Guided, 2);

            //AJOUT DE L'ARME A L'ARMURERIE
            myGame.GameArmory.AddWeapon(myWeapon);

            //AFFICHAGE DES ARMES L'ARMURERIE
            myGame.GameArmory.ViewArmory();

            //REESSAI D'AJOUTE L'ARME APRES L'AVOIR AJOUTE DANS L'ARMURERIE
            try
            {
                //myGame.Players[0].MySpaceship.AddWeapon(myGame.GameArmory.GetWeapon("Annihilateur lourd"));
                myGame.Players[0].MySpaceship.AddWeapon(myGame.GameArmory.GetWeapon("Rayon laser"));
                myGame.Players[0].MySpaceship.AddWeapon(myGame.GameArmory.GetWeapon("Mitrailleuse"));
                myGame.Players[0].MySpaceship.AddWeapon(myGame.GameArmory.GetWeapon("Lance missile"));
            }
            catch (ArmoryException e)
            {
                Console.WriteLine("Erreur ArmoryException: {0}", e.Message);
            }

            //ARMES DU VAISSEAU DU JOUEUR JOHN DOE
            myGame.Players[0].MySpaceship.ViewWeapons();

            //ESSAI DE LA FONCTION SHOOT
            myGame.Players[0].MySpaceship.WeaponsList[1].Shoot();
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

