using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Data;

namespace PO_V
{
    public class db
    {
        static string lin = @"Data Source=VITALI\SQLSERVER;
                         Initial Catalog=Kursach;
                         Integrated Security=True";
        bool o = false;

        public static string Name { get; set; }
        public static string Login { get; set; }
        public string Salt { get; set; }
        public static string Number_passport { get; set; }
        public string Hash { get; set; }
        public static string Number_route { get; set; }
        public static string Number_user { get; set; }
        public static int Number_of_places { get; set; }
        public static int Number_bus { get; set; }

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
            conn.Close();
            return o;
        }

        public void Reg(string login, string ful_name, string salt, string number_passport, string hash)
        {
            conn.Open();
            string sql = string.Format("insert Into _user" +
                            "(login, full_name, salt, number_passprort, hash) values(@login, @ful_name, @salt, @number_passport, @hash)");

            using (SqlCommand myCommand = new SqlCommand(sql, conn))
            {
                myCommand.Parameters.AddWithValue("@login", login);
                myCommand.Parameters.AddWithValue("@ful_name", ful_name);
                myCommand.Parameters.AddWithValue("@salt", salt);
                myCommand.Parameters.AddWithValue("@number_passport", number_passport);
                myCommand.Parameters.AddWithValue("@hash", hash);
                myCommand.ExecuteNonQuery();
            }
            conn.Close();
        }

        public bool Sign_in(string login, string pass)
        {
            conn.Open();

            try
            {
                string zapros = string.Format("Select * from _user where login = @login");

                using (SqlCommand myCommand = new SqlCommand(zapros, conn))
                {
                    myCommand.CommandText = "Select * from _user where login = @login";
                    myCommand.Parameters.AddWithValue("@login", login);
                    myCommand.ExecuteNonQuery();
                    SqlDataReader myReader = myCommand.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        while (myReader.Read())
                        {
                            Salt = myReader["salt"].ToString();
                            Hash = myReader["hash"].ToString();
                            Number_passport = myReader["number_passprort"].ToString();
                            Number_user = myReader["number_user"].ToString();
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

            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            conn.Close();
            return o;
        }

        public void A()
        {
            conn.Open();
            string str1 = string.Format("select * from _user where number_passprort = @number_passprort");
            using (SqlCommand b = new SqlCommand(str1, conn))
            {
                b.CommandText = "select * from _user where number_passprort = @number_passprort";
                b.Parameters.AddWithValue("@number_passprort", Number_passport);
                b.ExecuteNonQuery();
                SqlDataReader myReader = null;
                myReader = b.ExecuteReader();
                while (myReader.Read())
                {
                    Login = myReader["login"].ToString();
                    Name = myReader["full_name"].ToString();
                    Number_user = myReader["number_user"].ToString();
                }
            }
            conn.Close();
        }

        public void UpdateLog(string login)
        {
            conn.Open();
            string str = string.Format("Update _user Set login=@login Where full_name = @name");
            using (SqlCommand a = new SqlCommand(str, conn))
            {
                a.CommandText = "Update _user Set login=@login Where full_name = @name";
                a.Parameters.AddWithValue("@login", login);
                a.Parameters.AddWithValue("@name", Name);
                a.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void UpdateName(string name)
        {
            conn.Open();
            string str = string.Format("Update _user Set full_name = @name Where login = @login");
            using (SqlCommand a = new SqlCommand(str, conn))
            {
                a.CommandText = "Update _user Set full_name = @name Where login = @login";
                a.Parameters.AddWithValue("@login", Login);
                a.Parameters.AddWithValue("@name", name);
                a.ExecuteNonQuery();
            }
            conn.Close();
        }

        public void UpdatePass(string salt, string hash)
        {
            conn.Open();

            string str = string.Format("Update _user Set salt = @salt, hash = @hash Where login = @login");
            using (SqlCommand a = new SqlCommand(str, conn))
            {

                a.CommandText = "Update _user Set salt = @salt, hash = @hash Where login = @login";
                a.Parameters.AddWithValue("@salt", salt);
                a.Parameters.AddWithValue("@hash", hash);
                a.Parameters.AddWithValue("@login", Login);
                a.ExecuteNonQuery();
            }

            conn.Close();
        }

        public void RemovePass()
        {
            conn.Open();

            string str = string.Format("delete from _user where full_name = @name");
            using (SqlCommand a = new SqlCommand(str, conn))
            {

                a.CommandText = "delete from _user where full_name = @name";
                a.Parameters.AddWithValue("@name", Name);
                a.ExecuteNonQuery();
            }

            conn.Close();
        }

        public bool Ticket(string arival_point, string data)
        {
            conn.Open();
            string str1 = string.Format("select * from Route where arival_point = @arival_point and data = @data");
            using (SqlCommand b = new SqlCommand(str1, conn))
            {
                b.CommandText = "select * from Route where arival_point = @arival_point and data = @data";
                b.Parameters.AddWithValue("@arival_point", arival_point);
                b.Parameters.AddWithValue("@data", data);
                b.ExecuteNonQuery();

                SqlDataReader myReader = null;
                myReader = b.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        o = true;
                        Number_route = myReader["number_route"].ToString();
                    }
                }
                else
                {
                    o = false;
                }
            }
            conn.Close();
            return o;
        }

        public bool Bron()
        {
            conn.Open();
            string sql = string.Format("insert Into Ticket" +
                            "(number_route, number_user) values(@number_route, @number_user)");
            string sql1 = string.Format("select number_of_places from Route a join Bus b on a.number_bus=b.number_bus where number_route = @number_route");
            string sql2 = string.Format("Update Bus Set number_of_places = @number_of_places where number_route = @number_route");

            using (SqlCommand myCommand = new SqlCommand(sql1, conn))
            {
                myCommand.CommandText = "select * from Route a join Bus b on a.number_bus=b.number_bus where number_route = @number_route";
                myCommand.Parameters.AddWithValue("@number_route", Number_route);
                myCommand.ExecuteNonQuery();
                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Number_of_places = (int)myReader["number_of_places"];
                    Number_bus = (int)myReader["number_bus"];
                }
                myReader.Close();
                if (Number_of_places > 0)
                {
                    o = true;
                    using (SqlCommand my = new SqlCommand(sql, conn))
                    {
                        my.Parameters.AddWithValue("@number_route", Number_route);
                        my.Parameters.AddWithValue("@number_user", Number_user);
                        my.ExecuteNonQuery();
                    }
                    using (SqlCommand bronir = new SqlCommand(sql2, conn))
                    {
                        bronir.CommandText = "Update Bus Set number_of_places = @number_of_places where number_bus = @number_bus";
                        bronir.Parameters.AddWithValue("@number_bus", Number_bus);
                        bronir.Parameters.AddWithValue("@number_of_places", Number_of_places-1);
                        bronir.ExecuteNonQuery();
                    }
                }
                else { o = false; }
            }
            conn.Close();
            return o;
        }
    }
}