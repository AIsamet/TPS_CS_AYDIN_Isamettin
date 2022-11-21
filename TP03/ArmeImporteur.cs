using System;
using System.Diagnostics.Tracing;
using System.Reflection.Emit;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace TP03
{
    //1.a
    [Serializable]
    public class ArmeImporteur
    {

        //1.a.1 Afin de stocker la fréquence des mots présents dans un fichier.
        [XmlAttribute]
        public Dictionary<String, int> frequenceMots { get; set; }
        [XmlAttribute]
        private int wordMaxSize;

        //1.a.2 Ajouter une validation du mot avant sa prise en compte
        public ArmeImporteur(String path, String fileName, int wordMaxSize, String notAllowedWord)
        {
            this.frequenceMots = new Dictionary<string, int>();
            this.wordMaxSize = 0;
            ReadFile(path, fileName, wordMaxSize, notAllowedWord);

            foreach (var item in frequenceMots)
            {
                var itemKey = item.Key;
                var itemValue = item.Value;
                Console.WriteLine(itemKey + itemValue);
            }
        }


        public void ReadFile(String path, String fileName, int wordMaxSize, String notAllowedWord)
        {
            String line;
            try
            {
                StreamReader sr = new StreamReader(@path + "\\" + fileName);
                line = sr.ReadLine().ToLower();
                Console.WriteLine("Words from " + path + "\\" + fileName);

                while (line != null)
                {
                    bool isValid = WordIsValid(line.ToLower(), wordMaxSize, notAllowedWord);
                    Console.WriteLine("\tWord : " + line.ToLower() + ", is valid ? : " + isValid);

                    line = sr.ReadLine();
                }

                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public void WriteFile(String path, String fileName)
        {
            try
            {

                StreamWriter sw = new StreamWriter(@path + "/" + fileName);
                sw.WriteLine("Hello World!!");
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public bool WordIsValid(string word, int wordMaxSize, String notAllowedWord)
        {
            if(word.Length <= wordMaxSize && word != notAllowedWord)
            {
                return true;
            }
            return false;
        }

        public void GetFrequence(string word)
        {
            foreach (var item in frequenceMots.Keys)
            {
                for (int i = 0; i<frequenceMots.Count; i++)
                {
                    if(item != word)
                    {
                        frequenceMots.Add(word, +1);
                    }
                }
            }
        }

    }
}
