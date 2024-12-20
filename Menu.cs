using System;
using System.Globalization;

namespace TPFinalCsharp
{
    public class Menu
    {
        private GestionParc gestionParc;

        public Menu()
        {
            gestionParc = new GestionParc();
        }

        // Afficher le menu principal

        public void AfficherMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Menu Principal ---");
                Console.WriteLine("1. Lister les voitures");
                Console.WriteLine("2. Louer une voiture");
                Console.WriteLine("3. Rendre une voiture");
                Console.WriteLine("4. Ajouter une nouvelle voiture");
                Console.WriteLine("5. Supprimer une voiture");
                Console.WriteLine("6. Quitter");
                Console.Write("Votre choix : ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        gestionParc.ListerVoitures();
                        break;

                    case "2":
                        LouerVoiture();
                        break;

                    case "3":
                        RendreVoiture();
                        break;

                    case "4":
                        AjouterVoiture();
                        break;

                    case "5":
                        SupprimerVoiture();
                        break;

                    case "6":
                        Console.WriteLine("Au revoir !");
                        return;

                    default:
                        Console.WriteLine("Choix invalide.");
                        break;
                }
            }
        }
        // Louer une voiture par ID.
        private void LouerVoiture()
        {
            Console.Write("Entrez l'ID de la voiture à louer : ");
            if (int.TryParse(Console.ReadLine(), out int idLouer))
                gestionParc.LouerVoiture(idLouer);
            else
                Console.WriteLine("Entrée invalide.");
        }
        
        // Rendre une voiture par ID.
        private void RendreVoiture()
        {
            Console.Write("Entrez l'ID de la voiture à rendre : ");
            if (int.TryParse(Console.ReadLine(), out int idRendre))
                gestionParc.RendreVoiture(idRendre);
            else
                Console.WriteLine("Entrée invalide.");
        }

        // Ajouter une nouvelle voiture au parc.
        private void AjouterVoiture()
        {
            gestionParc.AfficherMarquesModeles();

            string marque;
            do
            {
                Console.Write("Entrez la marque : ");
                marque = Console.ReadLine();
                marque = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(marque.ToLower());

                if (!gestionParc.MarqueExiste(marque))
                {
                    Console.WriteLine("Marque invalide. Veuillez entrer une marque valide.");
                }
            } while (!gestionParc.MarqueExiste(marque));

            string modele;
            do
            {
                Console.Write("Entrez le modèle : ");
                modele = Console.ReadLine();
                modele = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(modele.ToLower());

                if (!gestionParc.ModeleExiste(marque, modele))
                {
                    Console.WriteLine("Modèle invalide. Veuillez entrer un modèle valide.");
                }
            } while (!gestionParc.ModeleExiste(marque, modele));

            int anneeAjout;
            do
            {
                Console.Write("Entrez l'année (entre 2000 et 2024) : ");
                if (!int.TryParse(Console.ReadLine(), out anneeAjout) || anneeAjout < 2000 || anneeAjout > 2024)
                {
                    Console.WriteLine("Année invalide. Veuillez entrer une année entre 2000 et 2024.");
                }
            } while (anneeAjout < 2000 || anneeAjout > 2024);

            gestionParc.AjouterVoiture(marque, modele, anneeAjout);
        }

        // Supprimer une voiture du parc par ID.
        private void SupprimerVoiture()
        {
            Console.Write("Entrez l'ID de la voiture à supprimer : ");
            if (int.TryParse(Console.ReadLine(), out int idSupprimer))
                gestionParc.SupprimerVoiture(idSupprimer);
            else
                Console.WriteLine("Entrée invalide.");
        }
    }
}