﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Navigation;

namespace PO_V
{
    class db
    {
        static string str = @"Data Source=VITALI\SQLSERVER;
                         Initial Catalog=Kursach;
                         Integrated Security=True";
        bool o = false, i;


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

        public bool Sign_in(string login, string pass, Start a)
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
                        }
                        if (SaltedHash.Verify(Hash, pass, Salt))
                        {
                            NavigationService.GetNavigationService(a);
                            return o = true;
                        }
                        else
                        {
                            return o = false;
                        }
                    }
                    else
                    {
                        return o = false;
                    }
                }

            }

            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            conn.Close();

            if (o)
            {
                i = o;
            }
            return i;
        }
    }
}