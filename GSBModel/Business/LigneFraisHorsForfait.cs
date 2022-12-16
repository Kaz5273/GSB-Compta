using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBModel.Business
{
    public class LigneFraisHorsForfait
    {
        private int id;
        private FicheFrais ficheFrais;
        private string libelle;
        private double montant;
        private DateTime date;

        public LigneFraisHorsForfait(int id, FicheFrais ficheFrais, string libelle, double montant, DateTime date)
        {
            this.id = id;
            this.ficheFrais = ficheFrais;
            this.libelle = libelle;
            this.montant = montant;
            this.date = date;
        }

        public int Id { get => id; set => id = value; }
        public FicheFrais FicheFrais { get => ficheFrais; set => ficheFrais = value; }
        public string Libelle { get => libelle; set => libelle = value; }
        public double Montant { get => montant; set => montant = value; }
        public DateTime Date { get => date; set => date = value; }
    }
}
