using System;
namespace Aydin_Isamettin_Tp1
{
    public class Player
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string Alias { get; set; }
        public string Name { get { return (FirstName + " " + LastName); } }
        public Spaceship MySpaceship { get; private set; }

        public Player(string firstName, string lastName, string alias)
        {
            FirstName = Format(firstName);
            LastName = Format(lastName);
            Alias = alias;
            //7.1
            MySpaceship = new Spaceship();
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

