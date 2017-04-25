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
            List<String> val = new List<string>();

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("select login, salt, hash from _user",
                                                         conn);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    val.Add(myReader.GetString(0));
                }

                foreach (string log in val)
                {
                    if (login == log)
                    {
                        MessageBox.Show(login);
                    }
                    else
                        MessageBox.Show("Неверно введет логин или пароль!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            conn.Close();
        }
    }
}
