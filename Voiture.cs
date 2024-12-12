namespace TP_Final_Csharp
{
    public class Voiture
    {
        public int Id { get; set; }
        public Marque Marque { get; set; }
        public Modele Modele { get; set; }
        public int Annee { get; set; }
        public bool Statut { get; set; }

        public Voiture(int id, Marque marque, Modele modele, int annee)
        {
            Id = id;
            Marque = marque;
            Modele = modele;
            Annee = annee;
            Statut = true;
        }

        public void AfficherInformations()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Marque: {Marque}");
            Console.WriteLine($"Modèle: {Modele}");
            Console.WriteLine($"Année: {Annee}");
            Console.WriteLine($"Statut: {(Statut ? "Disponible" : "Louée")}");
        }
    }
}
