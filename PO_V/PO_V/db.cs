using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace PO_V
{
    class db
    {
        static string str = @"Data Source=VITALI\SQLSERVER;
                         Initial Catalog=Kursach;
                         Integrated Security=True";

        public string Hash { get; set; }
        public string Salt { get; set; }

        static SqlConnection conn = new SqlConnection(str);

        public void Reg(string login, string name, string email, string salt, string hash)
        {
            conn.Open();

            string sql = string.Format("insert Into _user" +
                            "(login, name, email, salt, hash) values(@login, @name ,@email, @salt, @hash)");
            using (SqlCommand myCommand = new SqlCommand(sql, conn))
            {
                myCommand.Parameters.AddWithValue("@login", login);
                myCommand.Parameters.AddWithValue("@name", name);
                myCommand.Parameters.AddWithValue("@email", email);
                myCommand.Parameters.AddWithValue("@salt", salt);
                myCommand.Parameters.AddWithValue("@hash", hash);
                myCommand.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void Sign_in(string login)
        {
            conn.Open();
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
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введен неверный логин или пароль");
                    }
                }
            }

<<<<<<< HEAD
            catch (Exception e)
=======
            catch(Exception e)
>>>>>>> 96e2c75d653a5f110f863e86845e36c43a822e1d
            {
                MessageBox.Show(e.ToString());
            }

            conn.Close();
        }
    }
}