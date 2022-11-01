using System;


namespace TP00
{
    public class TP00
    {

        static void Main(string[] args)
        {
            do
            {
                string nom = String.Empty;
                string prenom = String.Empty;
                int age = 0;
                float kg = 0;
                int taille = 0;

                //1
                Console.WriteLine("Bienvenue sur mon programme, jeune étranger imberbe");


                //2 & 11a & 11b
                Console.WriteLine("Donne moi ton nom, vil chenapan : ");
                nom = Console.ReadLine();
                VerifString(ref nom);

                Console.WriteLine("\nEt quel est ton prénom, petit galopin : ");
                prenom = Console.ReadLine();
                VerifString(ref prenom);


                //3 & 6
                Console.WriteLine(String.Format("\nBonjour " + RenvoieNom(nom, prenom) + " !"));


                //4 & 11c & 11d & 11e
                Console.WriteLine("\nCombien de pommes fais-tu (en cm)");
                VerifInt(ref taille);

                Console.WriteLine("\nCombien pèses-tu : ");
                VerifFloat(ref kg);

                Console.WriteLine("\nCombien est-tu vieux : ");
                VerifInt(ref age);


                //5
                if (age < 18)
                {
                    Console.WriteLine("\nPetit morveux puéril et immature qui n’a même pas" +
                        " le droit d’acheter de l’alcool en grande surface. ");
                }


                //8
                Console.WriteLine("\nVotre IMC : " + RenvoieIMC(taille, kg).ToString("f1"));


                //9
                CommentaireIMC(RenvoieIMC(taille, kg));


                //10
                NombreCheveux();



                //FIN
                Console.WriteLine("\nFIN\n");
            }
            while (ChoixFin() == 2);
        }








        //6
        public static string RenvoieNom(string nom, string prenom)
        {
            return (prenom.ToLower() + " " + nom.ToUpper());
        }


        //7
        public static float RenvoieIMC(int taille, float kg)
        {
            float tailleEnMetres = (float)taille / 100;
            return (float)(kg / (tailleEnMetres * tailleEnMetres));
        }


        //9
        public static void CommentaireIMC(float IMC)
        {
            const string COMMENTAIRE_1 = ("Attention à l’anorexie !\n");
            const string COMMENTAIRE_2 = ("Vous êtes un peu maigrichon !\n");
            const string COMMENTAIRE_3 = ("Vous êtes de corpulence normale !\n");
            const string COMMENTAIRE_4 = ("Vous êtes en surpoids !\n");
            const string COMMENTAIRE_5 = ("Obésité modérée !\n");
            const string COMMENTAIRE_6 = ("Obésité sévère !\n");
            const string COMMENTAIRE_7 = ("Obésité morbide !\n");
            const string COMMENTAIRE_8 = ("Vous ne pouvez pas être en vie !\n");

            if (IMC < 16.5)
            {
                Console.WriteLine(COMMENTAIRE_1);
            }

            else if (IMC >= 16.5 && IMC < 18.5)
            {
                Console.WriteLine(COMMENTAIRE_2);
            }

            else if (IMC >= 18.5 && IMC < 25)
            {
                Console.WriteLine(COMMENTAIRE_3);
            }

            else if (IMC >= 25 && IMC < 30)
            {
                Console.WriteLine(COMMENTAIRE_4);
            }

            else if (IMC >= 30 && IMC < 35)
            {
                Console.WriteLine(COMMENTAIRE_5);
            }

            else if (IMC >= 35 && IMC < 40)
            {
                Console.WriteLine(COMMENTAIRE_6);
            }

            else if (IMC >= 40)
            {
                Console.WriteLine(COMMENTAIRE_7);
            }

            else
            {
                Console.WriteLine(COMMENTAIRE_8);
            }

        }


        //10
        public static void NombreCheveux()
        {
            int cheveux = 0;
            Console.WriteLine("Combien de cheveux as-tu ?");
            bool estNombre = int.TryParse(Console.ReadLine(), out cheveux);

            while (!estNombre || (cheveux < 100000 || cheveux > 150000))
            {
                if (!estNombre)
                {
                    Console.WriteLine("Réessaie en entrant un nombre");
                    estNombre = int.TryParse(Console.ReadLine(), out cheveux);
                }

                else if (cheveux < 100000 || cheveux > 150000)
                {
                    Console.WriteLine("Ton nombre de cheveux doit etre compris entre 100 000 et 150 000");
                    estNombre = int.TryParse(Console.ReadLine(), out cheveux);
                }

            }
        }


        //11
        public static void VerifString(ref string texte)
        {
            while (texte.Any(char.IsDigit) || String.IsNullOrEmpty(texte))
            {
                if (texte.Any(char.IsDigit))
                {
                    Console.WriteLine("Votre entrée texte contient des chiffres, réessayez");
                    texte = Console.ReadLine();
                }
                else if (String.IsNullOrEmpty(texte))
                {
                    Console.WriteLine("Allons un effort, entrez quelque chose !");
                    texte = Console.ReadLine();
                }

            }
        }

        public static void VerifInt(ref int nombre)
        {
            bool estNombre = int.TryParse(Console.ReadLine(), out nombre);

            while (nombre <= 0 || !estNombre)
            {

                if (!estNombre)
                {
                    Console.WriteLine("Votre entrée n'est pas un nombre, réessayez");
                    estNombre = int.TryParse(Console.ReadLine(), out nombre);
                }
                else if (nombre <= 0)
                {
                    Console.WriteLine("Votre entrée n'est pas superieur a zero (" + nombre + "), réessayez");
                    estNombre = int.TryParse(Console.ReadLine(), out nombre);
                }


            }
        }

        public static void VerifFloat(ref float kg)
        {
            bool estNombre = float.TryParse(Console.ReadLine(), out kg);

            while (kg <= 0 || !estNombre)
            {

                if (!estNombre)
                {
                    Console.WriteLine("Votre entrée n'est pas un nombre, réessayez");
                    estNombre = float.TryParse(Console.ReadLine(), out kg);
                }
                else if (kg <= 0)
                {
                    Console.WriteLine("Votre entrée n'est pas superieur a zero (" + kg + "), réessayez");
                    estNombre = float.TryParse(Console.ReadLine(), out kg);
                }




            }
        }


        //12
        public static int ChoixFin()
        {
            int choix = 0;
            Console.WriteLine("\nQue veux-tu faire a present ?\nTape le numero de ton choix :\n1 - Pour quitter le programme\n2 - Pour Recommencer le programme" +
                "\n3 - Pour compter jusqu'a 10\n4 - Pour telephonner a Tata Jacqueline\n\nJe t'ecoute :");

            bool verifEntree = int.TryParse(Console.ReadLine(), out choix);

            while (!verifEntree || choix <= 0 || choix >= 5)
            {
                if (!verifEntree)
                {
                    Console.WriteLine("Votre entrée n'est pas un chiffre, réessayez");
                    verifEntree = int.TryParse(Console.ReadLine(), out choix);
                }
                else if (choix <= 0 || choix >= 5)
                {
                    Console.WriteLine("Veuillez entrer un choix valide");
                    verifEntree = int.TryParse(Console.ReadLine(), out choix);
                }
            }

            Console.WriteLine("\nVous avez selectionné le choix " + choix + "\n");


            switch(choix){

                case 1:
                    Console.WriteLine("A bientot !");
                    Thread.Sleep(3000);
                    break;

                case 3:
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine(i + 1);
                        Thread.Sleep(1000);
                    }
                    break;

                case 4:
                    string chaine1 = "Mise en relation avec tata Jacqueline...\n";
                    String chaine2 = "\nTata Jacqueline est momentanément indisponible, cette dernière est en train de chercher son appareil auditif, veuillez réessayer plus tard\n\nA bientot !";
                    for (int i = 0; i < chaine1.Length; i++)
                    {
                        Console.Write(chaine1[i]);
                        Thread.Sleep(50);
                    }

                    for (int i = 0; i < 5; i++)
                    {
                        string chaine3 = ("...");
                        for (int j = 0; j < chaine3.Length; j++)
                        {
                            Console.Write(chaine3[j]);
                            Thread.Sleep(500);
                        }

                        Console.WriteLine("");
                        Thread.Sleep(20);
                    }

                    for (int i = 0; i < chaine2.Length; i++)
                    {
                        Console.Write(chaine2[i]);
                        Thread.Sleep(50);
                    }
                    Thread.Sleep(3000);
                    break;

            }
         
            return choix;
        }
    }
}
