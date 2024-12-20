using System;

namespace TPFinalCsharp
{
    // Classe Voiture pour représenter une voiture dans le parc automobile avec ses attributs et méthodes.
    public class Voiture
    {
        // Attributs de la classe Voiture.
        public int Id { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public int Annee { get; set; }
        public string Statut { get; set; } 

        public Voiture(int id, string marque, string modele, int annee, string statut)
        {
            // Initialisation des attributs.
            Id = id;
            Marque = marque;
            Modele = modele;
            Annee = annee;
            Statut = statut;
        }

        // Méthode pour afficher les informations de la voiture.
        public void AfficherInfo()
        {
            Console.WriteLine($"ID: {Id}, Marque: {Marque}, Modèle: {Modele}, Année: {Annee}, Statut: {Statut}");
        }
    }
}
