using System;
using System.Collections.Generic;

namespace TP_Final_Csharp
{
    public class GestionParc
    {
        private List<Voiture> voitures;

        public GestionParc()
        {
            voitures = new List<Voiture>();
        }

        public void AjouterVoiture(Voiture voiture)
        {
            voitures.Add(voiture);
            Console.WriteLine("Voiture ajoutée avec succès !");
        }

        public void ListerVoitures()
        {
            if (voitures.Count == 0)
            {
                Console.WriteLine("Aucune voiture dans le parc.");
                return;
            }

            Console.WriteLine("Liste des voitures :");
            for (int i = 0; i < voitures.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                voitures[i].AfficherInfos();
            }
        }

        
}