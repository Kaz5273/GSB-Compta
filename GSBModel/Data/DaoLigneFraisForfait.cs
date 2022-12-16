using GSBModel.Business;
using GSBModel.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBModel.Data
{
    public class DaoLigneFraisForfait
    {
        private Dbal unDbal;
        private DaoFicheFrais unDaoFicheFrais;
        private DaoFraisForfait unDaoFraisForfait;


        public DaoLigneFraisForfait(Dbal unDbal, DaoFicheFrais unDaoFicheFrais, DaoFraisForfait unDaoFraisForfait)
        {
            this.unDbal = unDbal;
            this.unDaoFicheFrais = unDaoFicheFrais;
            this.unDaoFraisForfait = unDaoFraisForfait;
        }

        public void Insert(LigneFraisForfait uneLigneFraisForfait)
        {
            string values = "(" + uneLigneFraisForfait.Id + ", " + uneLigneFraisForfait.FicheFrais.Id + " ," + uneLigneFraisForfait.FraisForfait.Id + ", " + uneLigneFraisForfait.Quantite + ")";
            unDbal.Insert("ligne_frais_forfait", values);
        }
        public void Update(LigneFraisForfait uneLigneFraisForfait, string values)
        {
            string condition = "id= " + uneLigneFraisForfait.Id + " ";
            unDbal.Update("ligne_frai_forfait", values, condition);
        }

        public void Delete(LigneFraisForfait uneLigneFraisForfait)
        {
            string value = "id= " + uneLigneFraisForfait.Id;
            unDbal.Delete("ligne_frais_forfait", value);
        }

        public List<LigneFraisForfait> SelectAll()
        {
            List<LigneFraisForfait> listLigneFraisForfait = new List<LigneFraisForfait>();
            DataTable myTable = this.unDbal.SelectAll("ligne_frais_forfait");

            foreach (DataRow r in myTable.Rows)
            {
                FicheFrais uneFicheFrais = unDaoFicheFrais.SelectById((int)r["fiche_frais_id"]);
                FraisForfait unFraisForFait = unDaoFraisForfait.SelectById((int)r["frais_forfait_id"]);
                listLigneFraisForfait.Add(new LigneFraisForfait((int)r["id"], uneFicheFrais, unFraisForFait, (int)r["quantite"]));
            }

            return listLigneFraisForfait;
        }


        public LigneFraisForfait SelectById(int idLigneFraisForfait)
        {

            DataRow result = this.unDbal.SelectById("ligne_frais_forfait", idLigneFraisForfait);
            FicheFrais uneFicheFrais = unDaoFicheFrais.SelectById((int)result["fiche_frais_id"]);
            FraisForfait unFraisForFait = unDaoFraisForfait.SelectById((int)result["frais_forfait_id"]);
            return new LigneFraisForfait((int)result["id"], uneFicheFrais, unFraisForFait, (int)result["quantite"]);

        }
    }
}
