using System;

namespace TP03

{
    public class F_18 : Spaceship, IAbility
    {
        public F_18()
        {
            Name = "F_18";
            Structure = 15;
            Shield = 0;
            CurrentStructure = Structure;
            CurrentShield = Shield;
        }

        public F_18(string name)
        {
            Name = name;
            Structure = 15;
            Shield = 0;
            CurrentStructure = Structure;
            CurrentShield = Shield;
        }

        public void UseAbility(List<Spaceship> spaceships)
        {

            SpaceInvaders Game = SpaceInvaders.GetInstance;

            //On recupere l'index du f-18 puis on verifie si i+1 ou i-1 correspond au vaisseau du joueur
            for (int i = 0; i < spaceships.Count(); i++)
            {
                if (spaceships[i] == this)
                {
                    //si un vaisseau voisin est le vaisseau d'un joueur on l'attaque avec verifs pour pas etre out of range
                    if ((i - 1 >= 0 && spaceships[i - 1].BelongsPlayer) || (i + 1 < spaceships.Count() && spaceships[i + 1].BelongsPlayer))
                    {

                        Console.WriteLine(this.Name + " utilise son aptitude speciale\n");
                        Console.WriteLine("Mode Kamikaze activé ! Les vaisseaux a proximité prennent 10 de degats\n");

                        if (i - 1 >= 0) { spaceships[i - 1].TakeDamages(10); }
                        if (i + 1 < spaceships.Count()) { spaceships[i + 1].TakeDamages(10); }
                        this.CurrentShield = 0;
                        this.CurrentStructure = 0;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Pas de vaisseau joueur a proximite, F-18 ne peut pas utiliser son aptitude speciale\n");
                        break;
                    }
                }
            }
        }

        public override void ShootTarget(Spaceship target)
        {
            SpaceInvaders Game = SpaceInvaders.GetInstance;
            UseAbility(Game.Spaceships);
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------\n");
        }

    }
}

