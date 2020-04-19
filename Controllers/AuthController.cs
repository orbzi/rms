using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Entities;

namespace Project.Controllers
{
    class AuthController
    {
        public User Login(string username, string password)
        {
            DataTable dtUser = new DataTable();
            DataTable dtUserType = new DataTable();
            User user = null;
            UserType userType;
            using (SqlConnection sqlCon = new SqlConnection(Program.ConPath))
            {
                sqlCon.Open();
                string query = "SELECT TOP 1 * From Users where usr_username='"+username+"' and usr_password='"+password+"'";
                SqlDataAdapter da = new SqlDataAdapter(query,sqlCon);
                da.Fill(dtUser);
                foreach (DataRow row in dtUser.Rows)
                {
                    user = new User();
                    userType = new UserType();
                    user.username = row["usr_username"].ToString();
                    user.password = row["usr_password"].ToString();
                    user.email = row["usr_email"].ToString();
                    user.id = int.Parse(row["id"].ToString());
                    user.phone = row["usr_phone"].ToString();
                    int type = int.Parse(row["usr_usertype"].ToString());
                    query = "SELECT * From UserTypes where id=" + type;
                    da = new SqlDataAdapter(query,sqlCon);
                    //dtUser.Clear();
                    da.Fill(dtUserType);
                    foreach (DataRow dataRow in dtUserType.Rows)
                    {
                        userType.id = int.Parse(dataRow["id"].ToString());
                        userType.userType = dataRow["usr_usertype"].ToString();
                    }
                    user.userType = userType;
                }
            }

            return user;
        }

        public int Register(User user)
        {
            int isRegistered = GetUser(user);
            if (isRegistered >= 0)
            {
                DataTable dt = new DataTable();
                using (SqlConnection sqlCon = new SqlConnection(Program.ConPath))
                {
                    string query =
                        "INSERT INTO Users(usr_username,usr_password,usr_email,usr_phone,usr_usertype) values('" +
                        user.username + "','" + user.password + "','" + user.email + "','" + user.phone + "',2)";
                    SqlDataAdapter da = new SqlDataAdapter(query, sqlCon);
                    da.Fill(dt);
                    return 0;
                }
            }
            return isRegistered;
        }

        public int GetUser(User user)
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(Program.ConPath))
            {
                string query = "SELECT * FROM Users where usr_username='" + user.username + "'";
                SqlDataAdapter da = new SqlDataAdapter(query,sqlCon);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return -1;
                }
                query = "SELECT * FROM Users where usr_email='" + user.email + "'";
                da = new SqlDataAdapter(query,sqlCon);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return -1;
                }
            }
            return 0;
        }

        public int Update(User user)
        {
            int isUpdated = -1;
            return isUpdated;
        }

        public void UpdateUserInfo(string _oldUSerName, string _pass, string _email, string _phone)
        {
            using(SqlConnection sqlCon = new SqlConnection(Program.ConPath))
            {
                sqlCon.Open();
                string query = "UPDATE Users SET usr_password = '" + _pass + "', usr_email = '" + _email + "', usr_phone = '" + _phone + "' WHERE id = (select id from Users where usr_username = '" + _oldUSerName + "')";

                SqlCommand com = new SqlCommand(query, sqlCon);
                SqlDataAdapter adp = new SqlDataAdapter();

                com.ExecuteNonQuery();

                com.Dispose();
                sqlCon.Close();
            }
        }
    }
}
