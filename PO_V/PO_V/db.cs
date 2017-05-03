using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Navigation;
using System.Data;

namespace PO_V
{
    public class db
    {
        static string lin = @"Data Source=VITALI\SQLSERVER;
                         Initial Catalog=Kursach;
                         Integrated Security=True";
        bool o = false, i = false;

        public static string Name { get; set; }
        public static string Login { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }

        static SqlConnection conn = new SqlConnection(lin);
        
        public bool Vald(string l)
        {
            conn.Open();

            string str = string.Format("Select * from _user where login = @login");

            using (SqlCommand myCommand = new SqlCommand(str, conn))
            {
                myCommand.Parameters.AddWithValue("@login", l);
                myCommand.ExecuteNonQuery();

                SqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    o = false;
                }
                else
                    o = true;
            }
            if (o)
                i = true;
        
            conn.Close();
            return i;
        }

        public void Reg(string login, string name, string salt, string hash)
        {
            conn.Open();
            string sql = string.Format("insert Into _user" +
                            "(login, name, salt, hash) values(@login, @name, @salt, @hash)");

            using (SqlCommand myCommand = new SqlCommand(sql, conn))
            {
                myCommand.Parameters.AddWithValue("@login", login);
                myCommand.Parameters.AddWithValue("@name", name);
                myCommand.Parameters.AddWithValue("@salt", salt);
                myCommand.Parameters.AddWithValue("@hash", hash);
                myCommand.ExecuteNonQuery();
            }
            conn.Close();
        }

        public bool Sign_in(string login, string pass)
        {
            try
            {
                conn.Open();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());

            }
            
            try
            {
                string zapros = string.Format("Select * from _user where login = @login");

                using (SqlCommand myCommand = new SqlCommand(zapros, conn))
                {
                    myCommand.Parameters.AddWithValue("@login", login);
                    myCommand.ExecuteNonQuery();
                    SqlDataReader myReader = myCommand.ExecuteReader();
                    if (myReader.HasRows)
                    { 
                        while (myReader.Read())
                        {
                            Salt = myReader["salt"].ToString();
                            Hash = myReader["hash"].ToString();
                            Name = myReader["name"].ToString();
                        }
                        if (SaltedHash.Verify(Hash, pass, Salt))
                        {
                            o = true;
                        }
                        else
                        {
                            o = false;
                        }
                    }
                    else
                    {
                        o = false;
                    }
                }

            }

            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            if (o)
            {
                i = o;
            }

            conn.Close();
            return i;
        }

        public string ReturnName()
        {
            return Name;
        }
    }
}