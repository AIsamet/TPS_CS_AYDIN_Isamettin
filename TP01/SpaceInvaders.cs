using System;
namespace Aydin_Isamettin_Tp1
{
    public class SpaceInvaders
    {
        //2.3
        private List<Player> Players { get; set; }
        public Armory GameArmory { get; private set; }

        //2.1 & 2.4
        public SpaceInvaders()
        {
            Init();
        }

        //2.2 & 2.4 & 2.5 & 2.6
        static void Main()
        {
            //8.1
            SpaceInvaders myGame = new SpaceInvaders();

            Console.WriteLine("Liste des joueurs :");
            foreach (Player p in myGame.Players)
            {
                Console.WriteLine(p.ToString());
            }
            Console.Write("\n");

            //ESSAI DE LA SURCHARGE DE EQUALS
            Console.WriteLine(myGame.Players[0].Equals(myGame.Players[1]) + "\n");

            //ARMES DU VAISSEAU DU JOUEUR JOHN DOE
            myGame.Players[0].MySpaceship.ViewWeapons();

            //CREATION D'UNE NOUVELLE ARME
            Weapon myWeapon = new Weapon("Annihilateur lourd", 80, 100, Weapon.EWeaponType.Guided);

            //9.a
            //ESSAI D'AJOUT D'ARME N'ETANT PAS DANS L'ARMURERIE AVEC LEVEE D'EXCEPTION
            try
            {
                myGame.Players[0].MySpaceship.AddWeapon(myGame.GameArmory.GetWeapon("Annihilateur lourd"));
            }
            catch (ArmoryException e)
            {
                Console.WriteLine("Erreur ArmoryException: {0}", e.Message);
            }

            //AJOUT DE L'ARME A L'ARMURERIE
            myGame.GameArmory.AddWeapon(myWeapon);

            //8.2
            //AFFICHAGE DES ARMES L'ARMURERIE
            myGame.GameArmory.ViewArmory();

            //REESSAI D'AJOUTE L'ARME APRES L'AVOIR AJOUTE DANS L'ARMURERIE
            try
            {
                myGame.Players[0].MySpaceship.AddWeapon(myGame.GameArmory.GetWeapon("Annihilateur lourd"));
            }
            catch (ArmoryException e)
            {
                Console.WriteLine("Erreur ArmoryException: {0}", e.Message);
            }

            //TEST DES CONDITIONS : AJOUT POSSIBLE QU'UNE SEULE FOIS DANS UN MEME VAISSEAU ET SEULEMENT SI MOINS DE 3 ARMES ACTUELLEMENT 
            myGame.Players[0].MySpaceship.AddWeapon(myGame.GameArmory.GetWeapon("Annihilateur lourd"));
            myGame.Players[0].MySpaceship.AddWeapon(myGame.GameArmory.GetWeapon("Rayon laser"));
            myGame.Players[0].MySpaceship.AddWeapon(myGame.GameArmory.GetWeapon("Rayon laser"));
            myGame.Players[0].MySpaceship.AddWeapon(myGame.GameArmory.GetWeapon("Mitrailleuse"));
            myGame.Players[0].MySpaceship.AddWeapon(myGame.GameArmory.GetWeapon("Lance missile"));

            //AFFICHAGE DES ARMES DU VAISSEAU
            myGame.Players[0].MySpaceship.ViewWeapons();

            //AFFICHAGE DES DEGATS MOYENS DU VAISSEAU
            Console.WriteLine("Degats moyens du vaisseau : " + myGame.Players[0].MySpaceship.AverageDamages() + "\n");

            //LE JOUEUR JANE DOE ATTAQUE LE JOUEUR JOHN DOE
            Console.WriteLine(myGame.Players[1].Name + " attaque le vaisseau de " + myGame.Players[0].Name + "\n");

            Console.WriteLine("Le vaisseau de " + myGame.Players[0].Name + " subit 100 degats");
            myGame.Players[0].MySpaceship.CurrentShield -= 100;
            Console.WriteLine("Etat du current shield : " + myGame.Players[0].MySpaceship.CurrentShield + "/100");
            Console.WriteLine("Le vaisseau de " + myGame.Players[0].Name + " n'a plus de shield\n");

            Console.WriteLine("Le vaisseau de " + myGame.Players[0].Name + " subit a nouveau 100 degats");
            myGame.Players[0].MySpaceship.CurrentStructure -= 100;
            Console.WriteLine("Etat du current structure : " + myGame.Players[0].MySpaceship.CurrentStructure + "/100");

            // LE VAISSEAU DE JOHN DOE EST DETRUIT (CHECK AVEC ISDESTROYED())
            if (myGame.Players[0].MySpaceship.IsDestroyed) { Console.WriteLine("Le vaisseau de " + myGame.Players[0].Name + " est detuit\n"); }

            //ON RETIRE L'ARME DU VAISSEAU PARCEQU'IL A ETE MECHANT
            myGame.Players[0].MySpaceship.RemoveWeapon(myWeapon);

            //ESSAI DE SUPRESSION D'ARME QUE LE VAISSEAU NE POSSEDE PAS
            myGame.Players[0].MySpaceship.RemoveWeapon(myWeapon);

            //REAFFICHAGE DES DEGATS MOYENS ACTUEL DU VAISSEAU
            Console.WriteLine("Degats moyens du vaisseau : " + myGame.Players[0].MySpaceship.AverageDamages() + "\n");

            //AFFICHAGE DES ARMES DU VAISSEAU
            myGame.Players[0].MySpaceship.ViewWeapons();

            //SUPRESSION DE TOUTES LES ARMES DU VAISSEAU
            myGame.Players[0].MySpaceship.ClearWeapons();

            //AFFICHAGE DES ARMES DU VAISSEAU
            myGame.Players[0].MySpaceship.ViewWeapons();

            //8.3 
            //AFFICHAGE DE TOUTES LES INFORMATIONS CONCERNANT LE VAISSEAU
            Console.WriteLine("Informations concernant le vaisseau de " + myGame.Players[0].Name);
            myGame.Players[0].MySpaceship.ViewShip();

        }

        //2.3
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

