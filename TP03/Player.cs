using System;

namespace TP03

{
    public class Player : IPlayer
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }
        public string Alias { get; }
        public string Name { get { return (FirstName + " " + LastName); } }
        public Spaceship BattleShip { get; set; }

        public Player(string firstName, string lastName, string alias)
        {
            FirstName = Format(firstName);
            LastName = Format(lastName);
            Alias = alias;
            BattleShip = new Dart();
            BattleShip.Owner = this;
        }

        public Player(string firstName, string lastName, string alias, Spaceship spaceship)
        {
            FirstName = Format(firstName);
            LastName = Format(lastName);
            Alias = alias;
            BattleShip = spaceship;
            spaceship.Owner = this;
        }

        private static string Format(string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }

        public override string ToString()
        {
            return (Alias + " (" + Name + ")");
        }

        public override bool Equals(object obj)
        {
            Player c = obj as Player;

            if (c == null)
                return false;
            return Alias == c.Alias;
        }

    }
}

