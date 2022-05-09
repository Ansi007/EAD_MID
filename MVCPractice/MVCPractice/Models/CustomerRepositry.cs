using System.Data.SqlClient;
using System.IO;

namespace MVCPractice.Models
{
    public class CustomerRepositry
    {
        static string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MVCPracticeMid;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static int AddCustomer(Customer c)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = "INSERT INTO CUSTOMERS(NAME,USERNAME,PASSWORD) VALUES(@N,@U,@P)";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlParameter p1 = new SqlParameter("N", c.Name);
            SqlParameter p2 = new SqlParameter("U", c.Username);
            SqlParameter p3 = new SqlParameter("P", c.Password);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            int r = cmd.ExecuteNonQuery();
            con.Close();
            return r;
        }

        public static bool ValidateCustomer(Customer c)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = $"SELECT * FROM CUSTOMERS WHERE USERNAME = '{c.Username}' AND PASSWORD = '{c.Password}'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader sql = cmd.ExecuteReader();
            bool r = sql.HasRows;
            con.Close();
            return r;
        }
    }
}
