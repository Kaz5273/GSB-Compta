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
    public class DaoEtat
    {
        private Dbal unDbal;

        public DaoEtat(Dbal unDbal) 
        {
            this.unDbal = unDbal;
        }

        public void Insert(Etat unEtat)
        {
            string values ="(" + unEtat.Id + ", '" + unEtat.Libelle + "')";
            unDbal.Insert("etat", values);
        }

        public void Update(Etat unEtat, string values)
        { 
            string condition = " id= " + unEtat.Id + " ";
            unDbal.Update("etat ", values, condition);
        }

        public void Delete(Etat unEtat)
        {
            string values = "id= " + unEtat.Id;
            unDbal.Delete("etat", values);
        }

        public List<Etat> SelectAll() 
        {
            List<Etat> listEtat= new List<Etat>();
            DataTable myTable = this.unDbal.SelectAll("etat");

            foreach (DataRow r in myTable.Rows)
            {
                listEtat.Add(new Etat((int)r["id"], (string)r["libelle"]));
            }
            return listEtat;
        }

        public Etat SelectedByName(string libelleEtat)
        {
            DataTable result = new DataTable();
            result = this.unDbal.SelectByField("etat ", " libelle = '" + libelleEtat.Replace("'", "''") + "'");
            Etat foundEtat = new Etat((int)result.Rows[0]["id"], (string)result.Rows[0]["libelle"]);
            return foundEtat;
        }

        public Etat SelectedById(int idEtat)
        {
            DataRow result = this.unDbal.SelectById("etat", idEtat);
            return new Etat((int)result["id"], (string)result["libelle"]);
        }

    }
}
