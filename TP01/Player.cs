using System;
namespace Aydin_Isamettin_Tp1
{
    public class Player
    {
        //1.1 & 1.3 & 1.6
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string Alias { get; set; }
        public string Name { get { return (FirstName + " " + LastName); } }
        //7.1
        public Spaceship MySpaceship { get; private set; }

        //1.2 & 1.5
        public Player(string firstName, string lastName, string alias)
        {
            FirstName = Format(firstName);
            LastName = Format(lastName);
            Alias = alias;
            //7.1
            MySpaceship = new Spaceship();
        }

        //1.4
        private static string Format(string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }

        //1.7
        public override string ToString()
        {
            return (Alias + " (" + Name + ")");
        }

        //1.8
        public override bool Equals(object obj)
        {
            Player c = obj as Player;

            if (c == null)
                return false;
            return Alias == c.Alias;
        }

    }
}

