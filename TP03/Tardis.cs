using System;

namespace TP02

{
    public class Tardis : Spaceship, IAbility
    {
        public Tardis()
        {
            Name = "Tardis";
            Structure = 1;
            Shield = 0;
            CurrentStructure = Structure;
            CurrentShield = Shield;
        }

        public Tardis(string name)
        {
            Name = name;
            Structure = 1;
            Shield = 0;
            CurrentStructure = Structure;
            CurrentShield = Shield;
        }

        public void UseAbility(List<Spaceship> spaceships)
        {
            Random random = new Random();
            int randomVaisseau = random.Next(0, spaceships.Count());
            int randomPosition = random.Next(0, spaceships.Count());

            //on verifie que l'on deplace le vaisseau sur une nouvelle position
            if (spaceships.Count() != 1)
            {
                while (randomVaisseau == randomPosition || randomVaisseau == spaceships.IndexOf(this) || spaceships[randomPosition].IsDestroyed)
                {
                    randomVaisseau = random.Next(0, spaceships.Count());
                    randomPosition = random.Next(0, spaceships.Count());
                }
            }

            Console.WriteLine(this.Name + " utilise son aptitude speciale et teleporte le vaisseau " + spaceships[randomVaisseau].Name + "\n");

            Spaceship temp = spaceships[randomPosition];
            spaceships[randomPosition] = spaceships[randomVaisseau];
            spaceships[randomVaisseau] = temp;

        }

        public override void ShootTarget(Spaceship target)
        {
            SpaceInvaders Game = SpaceInvaders.GetInstance;
            UseAbility(Game.Spaceships);
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------\n");
        }

    }
}
