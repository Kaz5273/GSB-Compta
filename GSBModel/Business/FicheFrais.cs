using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBModel.Business
{
    public class FicheFrais
    {
        private int id;
        private User user;
        private Etat etat;
        private int nb_justificatifs;
        private DateTime date_modif;
        private decimal montant;
        private string mois;

        public FicheFrais(int id, User user, Etat etat, int nb_justificatifs, DateTime date_modif, decimal montant, string mois) 
        {
            this.id = id;
            this.user = user;
            this.etat = etat;
            this.nb_justificatifs= nb_justificatifs;
            this.date_modif = date_modif;
            this.montant = montant;
            this.mois= mois;
        }

        public int Id { get => id; set => id = value; }
        public User User { get => user; set => user = value; }
        public Etat Etat { get => etat; set => etat = value; }
        public int Nb_justificatifs { get => nb_justificatifs; set => nb_justificatifs = value; }
        public DateTime Date_modif { get => date_modif; set => date_modif = value; }
        public decimal Montant { get => montant; set => montant = value; }
        public string Mois { get => mois; set => mois = value; }
    }
}
