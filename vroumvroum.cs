using System;

public class Voiture
{
    public int Id { get; set; }
    public string Marque { get; set; }
    public string Modele { get; set; }
    public int Annee { get; set; }
    public string Statut { get; set; } 

    public Voiture(int id, string marque, string modele, int annee, string statut)
    {
        Id = id;
        Marque = marque;
        Modele = modele;
        Annee = annee;
        Statut = statut;
    }

    public void AfficherInfos()
    {
        Console.WriteLine($"ID: {Id}\nMarque: {Marque}\nModèle: {Modele}\nAnnée: {Annee}\nStatut: {Statut}\n");
    }
}

public class Programme
{
    public static void Main(string[] args)
    {
        Voiture voiture1 = new Voiture(1, "Toyota", "Corolla", 2020, "Disponible");

        voiture1.AfficherInfos();
    }
}
