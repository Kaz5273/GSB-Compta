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
    public class DaoFicheFrais
    {
        private Dbal unDbal;
        private DaoUser unDaoUser;
        private DaoEtat unDaoEtat;

        public DaoFicheFrais(Dbal unDbal, DaoUser unDaoUser, DaoEtat unDaoEtat)
        {
            this.unDbal = unDbal;
            this.unDaoUser = unDaoUser;
            this.unDaoEtat = unDaoEtat;
        }

        public void Insert(FicheFrais uneficheFrais)
        {
            string values = "(" + uneficheFrais.Id + ", " + uneficheFrais.User.Id + ", " + uneficheFrais.Etat.Id + ", " + uneficheFrais.Nb_justificatifs + ", '" + uneficheFrais.Date_modif.ToString("yyyy-MM-dd") + "', '" + uneficheFrais.Montant.ToString().Replace(",", ".") + "' , '" + uneficheFrais.Mois + "')";
            unDbal.Insert("fiche_frais", values);
        }

        public void Update(FicheFrais uneFicheFrais, string values)
        {

            string conditon = "id= " + uneFicheFrais.Id + " ";
            unDbal.Update("fiche_frais", values, conditon);
        }

        public void Delete(FicheFrais uneFicheFrais)
        {
            string value = "id= " + uneFicheFrais.Id;
            unDbal.Delete("fiche_frais", value);
        }
        public List<FicheFrais> SelectAll()
        {
            List<FicheFrais> listFicheFrais = new List<FicheFrais>();
            DataTable myTable = this.unDbal.SelectAll("fiche_frais");
            

            foreach (DataRow r in myTable.Rows)
            {
                User unUser = unDaoUser.SelectById((int)r["user_id"]);
                Etat unEtat = unDaoEtat.SelectedById((int)r["etat_id"]);
                listFicheFrais.Add(new FicheFrais((int)r["id"], unUser, unEtat, (int)r["nb_justificatifs"], (DateTime)r["date_modif"], (decimal)r["montant"], (string)r["mois"]));
            }

            return listFicheFrais;
        }


        public FicheFrais SelectById(int idFicheFrais)
        {
            
            DataRow result = this.unDbal.SelectById("fiche_frais", idFicheFrais);
            User unUser = unDaoUser.SelectById((int)result["user_id"]);
            Etat unEtat = unDaoEtat.SelectedById((int)result["etat_id"]);
            return new FicheFrais((int)result["id"], unUser, unEtat, (int)result["nb_justificatifs"], (DateTime)result["date_modif"], (decimal)result["montant"], (string)result["mois"]);

        }


    }
}
