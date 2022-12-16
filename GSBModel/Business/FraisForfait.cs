    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBModel.Business
{
    public class FraisForfait
    {
        private int id;
        private double montant;
        private string libelle;

        public FraisForfait(int id, double montant, string libelle)
        {
            this.id = id;
            this.montant = montant;
            this.libelle = libelle;
        }

        public int Id { get => id; set => id = value; }
        public double Montant { get => montant; set => montant = value; }
        public string Libelle { get => libelle; set => libelle = value; }
    }
}
