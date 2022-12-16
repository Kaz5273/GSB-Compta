using GSBModel.Business;
using GSBModel.Data;
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBModel.Data
{
    public class DaoUser
    {
        private Dbal unDbal;

        public DaoUser(Dbal undbal)
        {
            this.unDbal = undbal;
        }
        //public void Insert(User unUser)
        //{
        //    string values = "(" + unUser.Id + ", '" + unUser.Login + "', '" + unUser.Password + "', '" + unUser.Nom + "', '" + unUser.Prenom + "', '" + unUser.Adresse + "', '" + unUser.Cp + "', '" + unUser.Date_embauche + ",  '" + unUser.Ville + "', '" + unUser.Old_id + "')";
        //    unDbal.Insert("User", values);
        //}
        //public void Update(User unUser, string values)
        //{
        //    string condition = " id= " + unUser.Id + " ";
        //    unDbal.Update("User", values, condition);
        //}

        //public void Delete(User unUser)
        //{
        //    string values = "id= " + unUser.Id;
        //    unDbal.Delete("User", values);
        //}

        public List<User> SelectAll()
        {
            List<User> listUser = new List<User>();
            DataTable myTable = this.unDbal.SelectAll("User");
            foreach (DataRow r in myTable.Rows)
            {
                listUser.Add(new User((int)r["id"], (string)r["login"], (string)r["password"], (string)r["nom"], (string)r["prenom"], (string)r["adresse"], (string)r["cp"], (DateTime)r["date_embauche"], (string)r["ville"], (string)r["old_id"]));
            }
            return listUser;
        }

        public User SelectByName(string nameUser)
        {
            DataTable result = new DataTable();
            result = this.unDbal.SelectByField("user ", " nom = '" + nameUser.Replace("'", "''") + "'");
            User foundUser = new User((int)result.Rows[0]["id"], (string)result.Rows[0]["login"], (string)result.Rows[0]["password"], (string)result.Rows[0]["nom"], (string)result.Rows[0]["prenom"], (string)result.Rows[0]["adresse"], (string)result.Rows[0]["cp"], (DateTime)result.Rows[0]["date_embauche"], (string)result.Rows[0]["ville"], (string)result.Rows[0]["old_id"]);
            return foundUser;
        }

        public User SelectById(int idUser)
        {
            DataRow result = this.unDbal.SelectById("User", idUser);
            return new User((int)result["id"], (string)result["login"], (string)result["password"], (string)result["nom"], (string)result["prenom"], (string)result["adresse"], (string)result["cp"], (DateTime)result["date_embauche"], (string)result["ville"], (string)result["old_id"]);
        }
    }

}
