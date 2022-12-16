using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBModel.Business
{
    public class LigneFraisForfait
    {
        private int id;
        private FicheFrais ficheFrais;
        private FraisForfait fraisForfait;
        private int quantite;

        public LigneFraisForfait(int id, FicheFrais ficheFrais, FraisForfait fraisForfait, int quantite)
        {
            this.id = id;
            this.ficheFrais = ficheFrais;
            this.fraisForfait = fraisForfait;
            this.quantite = quantite;
        }

        public int Id { get => id; set => id = value; }
        public FicheFrais FicheFrais { get => ficheFrais; set => ficheFrais = value; }
        public FraisForfait FraisForfait { get => fraisForfait; set => fraisForfait = value; }
        public int Quantite { get => quantite; set => quantite = value; }
    }
}
