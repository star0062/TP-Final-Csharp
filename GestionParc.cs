using System;
using System.Collections.Generic;

namespace TPFinalCsharp
{
    public class GestionParc
    {
        private List<Voiture> voitures;
        private Dictionary<string, string[]> marquesModeles;
        private int nextId;

        public GestionParc()
        {
            voitures = new List<Voiture>();
            marquesModeles = new Dictionary<string, string[]>(); // Initialize here
            nextId = 1;
            InitialiserParc();
        }

        // Initialiser le parc automobile avec des marques et modèles prédéfinis
        private void InitialiserParc()
        {
            marquesModeles = new Dictionary<string, string[]>
            {
                { "Toyota", new string[] { "Corolla", "Camry", "RAV4", "Prius", "Highlander" } },
                { "Renault", new string[] { "Clio", "Megane", "Captur", "Talisman", "Kadjar" } },
                { "BMW", new string[] { "Serie 3", "Serie 5", "X3", "X5", "i8" } },
                { "Mercedes", new string[] { "Classe A", "Classe C", "GLE", "GLA", "Classe E" } },
                { "Peugeot", new string[] { "208", "308", "3008", "5008", "508" } },
                { "Honda", new string[] { "Civic", "Accord", "CR-V", "Jazz", "HR-V" } },
                { "Ford", new string[] { "Focus", "Fiesta", "Mustang", "Explorer", "Kuga" } },
                { "Audi", new string[] { "A3", "A4", "Q5", "Q7", "A8" } },
                { "Volkswagen", new string[] { "Golf", "Polo", "Passat", "Tiguan", "Touareg" } },
                { "Fiat", new string[] { "500", "Panda", "Tipo", "Punto", "Doblo" } }
            };

            Random random = new Random();
            var marques = new List<string>(marquesModeles.Keys);

            for (int i = 0; i < 10; i++)
            {
                string marque = marques[random.Next(marques.Count)];
                string modele = marquesModeles[marque][random.Next(marquesModeles[marque].Length)];
                int annee = random.Next(2000, 2024);
                voitures.Add(new Voiture(nextId++, marque, modele, annee, "Disponible"));
            }
        }

        // Afficher les marques et modèles disponibles
        public void AfficherMarquesModeles()
        {
            Console.WriteLine("Marques et Modèles disponibles:");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("| {0,-15} | {1, -40} |", "Marque", "Modèles");
            Console.WriteLine("-------------------------------------------------------------");
        
            foreach (var marque in marquesModeles.Keys)
            {
                Console.WriteLine("| {0,-15} | {1, -40} |", marque, string.Join(", ", marquesModeles[marque]));
                Console.WriteLine("-------------------------------------------------------------");
            }
        }

        // Vérifier si la marque existe
        public bool MarqueExiste(string marque)
        {
            return marquesModeles.ContainsKey(marque);
        }

        // Vérifier si le modèle existe pour une marque donnée
        public bool ModeleExiste(string marque, string modele)
        {
            return marquesModeles.ContainsKey(marque) && Array.Exists(marquesModeles[marque], m => m == modele);
        }

        // Ajouter une nouvelle voiture au parc
        public void AjouterVoiture(string marque, string modele, int annee)
        {
            voitures.Add(new Voiture(nextId++, marque, modele, annee, "Disponible"));
            Console.WriteLine("Voiture a bien été ajoutée avec succès !");
        }

        // Supprimer une voiture du parc par ID
        public void SupprimerVoiture(int id)
        {
            for (int i = 0; i < voitures.Count; i++)
            {
                if (voitures[i].Id == id)
                {
                    if (voitures[i].Statut == "Louée")
                    {
                        Console.WriteLine($"La voiture de l'ID {id} est actuellement louée elle ne peut pas être supprimée.");
                        return;
                    }

                    voitures.RemoveAt(i);
                    Console.WriteLine($"La voiture ID {id} a été supprimée.");
                    return;
                }
            }

            Console.WriteLine("Voiture introuvable.");
        }

        // Lister toutes les voitures du parc
        public void ListerVoitures()
        {
            if (voitures.Count == 0)
            {
                Console.WriteLine("Aucune voiture dans le parc.");
                return;
            }

            Console.WriteLine("ID\tMarque\t\tModèle\t\tAnnée\tStatut");
            Console.WriteLine("-----------------------------------------------------------");

            foreach (var voiture in voitures)
            {
                Console.WriteLine($"{voiture.Id}\t{voiture.Marque,-10}\t{voiture.Modele,-10}\t{voiture.Annee}\t{voiture.Statut}");
            }
        }

        // Louer une voiture par ID
        public void LouerVoiture(int id)
        {
            for (int i = 0; i < voitures.Count; i++)
            {
                if (voitures[i].Id == id)
                {
                    if (voitures[i].Statut == "Disponible")
                    {
                        voitures[i].Statut = "Louée";
                        Console.WriteLine($"La voiture de l'ID {id} vient d'être louée.");
                    }
                    else
                    {
                        Console.WriteLine("La voiture est déjà louée.");
                    }
                    return;
                }
            }
            Console.WriteLine("Voiture introuvable.");
        }

        // Rendre une voiture louée par ID
        public void RendreVoiture(int id)
        {
            for (int i = 0; i < voitures.Count; i++)
            {
                if (voitures[i].Id == id)
                {
                    if (voitures[i].Statut == "Louée")
                    {
                        voitures[i].Statut = "Disponible";
                        Console.WriteLine($"La voiture ID {id} a été rendue.");
                    }
                    else
                    {
                        Console.WriteLine("La voiture est déjà disponible elle n'est pas louée.");
                    }
                    return;
                }
            }
            Console.WriteLine("Voiture introuvable.");
        }
    }
}