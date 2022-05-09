using System.Data.SqlClient;
using System.IO;

namespace MVCPractice.Models
{
    public class OrderRepositry
    {
        static string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MVCPracticeMid;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static int AddOrder(Order c)
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = "INSERT INTO Orders(NAME,QUANTITY) VALUES(@N,@Q)";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlParameter p1 = new SqlParameter("N", c.Name);
            SqlParameter p2 = new SqlParameter("Q", c.Quantity);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            int r = cmd.ExecuteNonQuery();
            con.Close();
            return r;
        }

        public static List<Order> GetOrders()
        {
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = "SELECT * FROM ORDERS";
            SqlCommand cmd = new SqlCommand(query, con);
            List<Order> list = new List<Order>();
            SqlDataReader sql = cmd.ExecuteReader();
            while (sql.Read())
            {
                Order c = new Order();
                c.Name = sql.GetString(1);
                c.Quantity = sql.GetInt32(2);
                list.Add(c);
            }
            con.Close();
            return list;
        }
    }
}
