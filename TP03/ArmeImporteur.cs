using System;
using System.Text.RegularExpressions;

namespace TP03
{
    //1.a
    public class ArmeImporteur
    {

        //1.a.1 stock la fréquence des mots présents dans un fichier.
        private Dictionary<String, int> wordsFrequency { get; set; }
        public List<string> blacklistedWords { get; set; }

        public ArmeImporteur(String path)
        {
            this.wordsFrequency = new Dictionary<string, int>();
            this.blacklistedWords = new List<string>();
        }

        public void ReadFile(String path, int wordMinSize)
        {
            String line;
            List<String> wordlist = new List<string>();

            try
            {
                StreamReader sr = new StreamReader(@path);
                line = sr.ReadLine().ToLower();

                while (line != null)
                {
                    if (WordIsValid(line, wordMinSize, this.blacklistedWords))
                    {
                        GetFrequence(line, wordMinSize, blacklistedWords);
                    }

                    line = sr.ReadLine();
                }

                sr.Close();
                this.ShowWordFrequency();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public void ShowWordFrequency()
        {
            Console.WriteLine("Word frequencies :");
            foreach (KeyValuePair<string, int> word in wordsFrequency)
            {
                Console.WriteLine("\t" + word.Key + " : " + word.Value);
            }
        }

        //1.a.2 validation du mot avant sa prise en compte
        public bool WordIsValid(string word, int wordMinSize, List<string> blacklistedWords)
        {
            if (word.Length < wordMinSize || blacklistedWords.Contains(word))
            {
                return false;
            }
            return true;
        }

        //1.a.1 && 1.a.4  ajouter une normalisation des mots (supprimer la case et la ponctuation)
        public void GetFrequence(string word, int wordMinSize, List<string> blacklistedWords)
        {
            Regex regex = new Regex(@"[^a-zA-Z ]+");
            word = regex.Replace(word.ToLower(), "");

            if (WordIsValid(word, wordMinSize, blacklistedWords))
            {
                if (this.wordsFrequency.ContainsKey(word))
                    this.wordsFrequency[word]++;
                else
                    this.wordsFrequency.Add(word, 1);
            }
        }

        //1.a.3 && 1.a.5  le mot servira de nom pour l’arme, la taille du mot et sa fréquence détermineront les valeurs de dégâts le type sera généré aléatoirement parmi l’enum type.
        public void WeaponExporter()
        {
            Console.WriteLine("Exporting weapons...\n");
            foreach (KeyValuePair<string, int> word in wordsFrequency)
            {
                int maxDamage = word.Value;
                int minDamage = word.Key.Length;
                Random random = new Random(Guid.NewGuid().GetHashCode());
                int randWeaponType = random.Next(0, 3); //crée un nombre entre 0 et 2
                int randReloadTime = random.Next(1, 6); //crée un nombre entre 1 et 5

                if (word.Key.Length > word.Value)
                {
                    maxDamage = word.Key.Length;
                    minDamage = word.Value;

                    Console.WriteLine("Weapon name : " + word.Key + " | Weapon min damage : " + word.Value + " | Weapon max damage : " + word.Key.Length + " | Weapon type : " + (Weapon.EWeaponType)randWeaponType);
                    Weapon weapon = new Weapon(word.Key, minDamage, maxDamage, (Weapon.EWeaponType)randWeaponType, randReloadTime);
                    SpaceInvaders.GetInstance.GameArmory.AddWeapon(weapon);
                }
                else
                {
                    Weapon weapon = new Weapon(word.Key, minDamage, maxDamage, (Weapon.EWeaponType)randWeaponType, randReloadTime);
                    SpaceInvaders.GetInstance.GameArmory.AddWeapon(weapon);
                }
            }
        }
    }

}

