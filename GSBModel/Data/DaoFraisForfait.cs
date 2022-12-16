using GSBModel.Business;
using GSBModel.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBModel.Data
{
    public class DaoFraisForfait
    {
        private Dbal unDbal;

        public DaoFraisForfait(Dbal unDbal)
        {
            this.unDbal = unDbal;
        }

        public void Insert(FraisForfait unFraisForfait)
        {
            string values = "(" + unFraisForfait.Id + ", '" + unFraisForfait.Montant + "' ,'" + unFraisForfait.Libelle + "')";
            unDbal.Insert("frais_forfait", values);
        }

        public void Update(FraisForfait unFraisForfait, string values)
        {
            string condition = "id= " + unFraisForfait.Id + " ";
            unDbal.Update("frais_forfait", values, condition);
        }

        public void Delete(FraisForfait unFraisForfait)
        {
            string values = "id= " + unFraisForfait.Id;
            unDbal.Delete("frais_forfait", values);
        }

        public List<FraisForfait> SelectAll()
        {
            List<FraisForfait> listFraisForfait = new List<FraisForfait>();
            DataTable myTable = this.unDbal.SelectAll("frais_forfait");

            foreach (DataRow r in myTable.Rows)
            {
                listFraisForfait.Add(new FraisForfait((int)r["id"], (double)r["montant"], (string)r["libelle"]));
            }

            return listFraisForfait;
        }

        public FraisForfait SelectByName(string nameFraisForfait) 
        {
            DataTable result = new DataTable();
            result = this.unDbal.SelectByField("frais_forfait ", " libelle= '" + nameFraisForfait.Replace("'", "''") + "'");
            FraisForfait foundFraisForfait = new FraisForfait((int)result.Rows[0]["id"], (double)result.Rows[0]["montant"], (string)result.Rows[0]["libelle"]);
            return foundFraisForfait;
        }

        public FraisForfait SelectById(int idFraisForfait)
        {
            DataRow result = this.unDbal.SelectById("frais_forfait", idFraisForfait);
            return new FraisForfait((int)result["id"], (double)result["montant"], (string)result["libelle"]);

        }

    }
}
