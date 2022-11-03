using System;

namespace TP02

{
    //3.2
    public class F_18 : Spaceship, IAbility
    {
        //3.a.1
        public F_18()
        {
            Name = "Default Name";
            Structure = 15;
            Shield = 0;
            CurrentStructure = Structure;
            CurrentShield = Shield;
            //Weapons = new List<Weapon>();
        }

        public F_18(string name)
        {
            Name = name;
            Structure = 15;
            Shield = 0;
            CurrentStructure = Structure;
            CurrentShield = Shield;
            //Weapons = new List<Weapon>();
        }

        //3.a.2
        public void UseAbility(List<Spaceship> spaceships)
        {
            if (spaceships[0] == this)
            {
                SpaceInvaders Game = SpaceInvaders.GetInstance;
                Console.WriteLine(this.Name + " utilise son aptitude speciale");
                Console.WriteLine("EXPLOSION !");
                foreach (Player player in Game.Players)
                {
                    if (player.BattleShip.IsDestroyed == false)
                    {
                        player.BattleShip.TakeDamages(10);
                        this.CurrentShield = 0;
                        this.CurrentStructure = 0;
                        break;
                    }
                }
            }
        }

    }
}
