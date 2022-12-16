using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBModel.Data
{
    public class Dbal
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public Dbal()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "localhost";
            database = "gsb_frais_symfony";
            uid = "root";
            password = "&6HAUTdanslaFauré"; //&6HAUTdanslaFauré
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        private void CUDQuery(string query)
        {
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }

        }


        public void Insert(string table, string values)
        {
            string query = "INSERT INTO " + table + " VALUES " + values;
            CUDQuery(query);

        }

        public void Update(string table, string values, string condition)
        {
            string query = "UPDATE " + table + " SET " + values + " WHERE " + condition;
            CUDQuery(query);



        }


        public void Delete(string table, string values)
        {
            string query = "DELETE FROM " + table + " WHERE " + values;
            CUDQuery(query);


        }

        private DataSet RQuery(string query)
        {
            DataSet dataset = new DataSet();
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Add query data in a DataSet
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                adapter.Fill(dataset);
                CloseConnection();
            }
            return dataset;
        }

        public DataTable SelectAll(string table)
        {
            string query = "SELECT* FROM " + table;
            DataSet dataset = RQuery(query);
            return dataset.Tables[0];
        }

        public DataRow SelectById(string table, int id)
        {

            string query = "SELECT * FROM " + table + " where id = '" + id + "'";
            DataSet dataset = RQuery(query);
            return dataset.Tables[0].Rows[0];
        }

        public DataTable SelectByField(string table, string fieldTestCondition)
        {
            string query = "SELECT * FROM " + table + "where" +
            fieldTestCondition;
            DataSet dataset = RQuery(query);
            return dataset.Tables[0];
        }
    }

}
