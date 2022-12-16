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
    public class DaoLigneFraisHorsForfait
    {
        private Dbal unDbal;
        private DaoFicheFrais unDaoFicheFrais;

        public DaoLigneFraisHorsForfait(Dbal unDbal, DaoFicheFrais unDaoFicheFrais)
        {
            this.unDbal = unDbal;
            this.unDaoFicheFrais = unDaoFicheFrais;
        }

        public void Insert(LigneFraisHorsForfait uneLigneFraisHorsForfait)
        {
            string values = "(" + uneLigneFraisHorsForfait.Id + ", " + uneLigneFraisHorsForfait.FicheFrais.Id + " ," + uneLigneFraisHorsForfait.FicheFrais.Id + ", '" + uneLigneFraisHorsForfait.Libelle + "', " + uneLigneFraisHorsForfait.Montant + ", " + uneLigneFraisHorsForfait.Date + ")";
            unDbal.Insert("ligne_frais_hors_forfait", values);
        }

        public void Update(LigneFraisHorsForfait uneLigneFraisHorsForfait, string values)
        {
            string condition = "id= " + uneLigneFraisHorsForfait.Id + " ";
            unDbal.Update("ligne_frai_hors_forfait", values, condition);
        }

        public void Delete(LigneFraisHorsForfait uneLigneFraisHorsForfait)
        {
            string value = "id= " + uneLigneFraisHorsForfait.Id;
            unDbal.Delete("ligne_frais_hors_forfait", value);
        }

        public List<LigneFraisHorsForfait> SelectAll()
        {
            List<LigneFraisHorsForfait> listLigneFraisHorsForfait = new List<LigneFraisHorsForfait>();
            DataTable myTable = this.unDbal.SelectAll("ligne_frais_hors_forfait");

            foreach (DataRow r in myTable.Rows)
            {
                FicheFrais uneFicheFrais = unDaoFicheFrais.SelectById((int)r["fiche_frais_id"]);

                listLigneFraisHorsForfait.Add(new LigneFraisHorsForfait((int)r["id"], uneFicheFrais, (string)r["libelle"], (double)r["montant"], (DateTime)r["date"]));
            }

            return listLigneFraisHorsForfait;
        }

        public LigneFraisHorsForfait SelectByName(string nameLigneFraisHorsForfait)
        {
            DataTable result = new DataTable();
            result = this.unDbal.SelectByField("ligne_frais_hors_forfait", "libelle = '" + nameLigneFraisHorsForfait.Replace("'", "''") + "'");
            FicheFrais uneFicheFrais = unDaoFicheFrais.SelectById((int)result.Rows[0]["fiche_frais_id"]);
            LigneFraisHorsForfait foundLigneFraisHorsForfait = new LigneFraisHorsForfait((int)result.Rows[0]["id"], uneFicheFrais, (string)result.Rows[0]["libelle"], (double)result.Rows[0]["montant"], (DateTime)result.Rows[0]["date"]);
            return foundLigneFraisHorsForfait;

        }

        public LigneFraisHorsForfait SelectById(int idLigneFraisHorsForfait)
        {

            DataRow result = this.unDbal.SelectById("ligne_frais_hors_forfait", idLigneFraisHorsForfait);
            FicheFrais uneFicheFrais = unDaoFicheFrais.SelectById((int)result["fiche_frais_id"]);
         
            return new LigneFraisHorsForfait((int)result["id"], uneFicheFrais, (string)result["libelle"], (double)result["montant"], (DateTime)result["date"]);

        }
    }
}
