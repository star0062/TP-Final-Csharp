using System;
using GestionParc;

namespace GestionParc
{
    public class Menu
    {
        private static Parc parc;
        public static void Initialiser(Parc parcInstance){
            parc = parcInstance;
        }

        public void AfficherMenu(){
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nMenu de gestion du parc automobile :");
                Console.WriteLine("1. Ajouter une voiture");
                Console.WriteLine("2. Lister les voitures");
                Console.WriteLine("3. Louer une voiture");
                Console.WriteLine("4. Rendre une voiture");
                Console.WriteLine("5. Quitter");
                Console.Write("Choisissez une option : ");

                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        AjouterVoiture();
                        break;

                    case "2":
                        parc.ListerVoitures();
                        break;

                    case "3":
                        LouerVoiture();
                        break;

                    case "4":
                        RendreVoiture();
                        break;

                    case "5":
                        Console.WriteLine("Vous avez quitté le programme.");
                        return;

                    default:
                        Console.WriteLine("Option invalide. Veuillez réessayer.");
                        break;
                }
                Console.WriteLine("Appuyez sur une touche pour continuer...");
                Console.ReadKey();
            }
        }
    }
}
