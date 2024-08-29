using MVCADO.Models;
using System.Data.SqlClient;

namespace MVCADO.DataAccess
{
    public class ProductDataAccess
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static void getConnection()
        {
            con = new SqlConnection("data source=PTSQLTESTDB01;database=Sports_yuva;integrated security=true;");
            con.Open();

        }
        static void Create()
        {
            getConnection();
            cmd = new SqlCommand("create table Product1(ProId int primary key,ProName varchar(20),Price int)", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
       public static Product Insert(Product prod)
        {
           
                getConnection();
                cmd = new SqlCommand("insert into Product1 values(@id,@name,@price)", con);
                cmd.Parameters.AddWithValue("@id", prod.ProductId);
                cmd.Parameters.AddWithValue("@name", prod.ProductName);
                cmd.Parameters.AddWithValue("@price", prod.ProductPrice);
                cmd.ExecuteNonQuery();
                con.Close();
               return prod;
        }
        public static List<Product> Fetch()
        {
            List<Product> list= new List<Product>();
            getConnection();
            string s1 = "select * from Product1";
            cmd = new SqlCommand(s1, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
               list.Add(new Product(){ ProductId = Convert.ToInt32(sdr[0].ToString()), ProductName = sdr[1].ToString(), ProductPrice = Convert.ToInt32(sdr[2].ToString()) });
            }
            con.Close();
            return list;
           
        }
        public static Product Search(int id)
        {
            getConnection();
            string s1 = "select * from Product1 where ProId=@id";
            cmd = new SqlCommand(s1, con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = cmd.ExecuteReader();
            Product p = new Product();
            while (sdr.Read())
            {
                 p.ProductId= Convert.ToInt32(sdr[0].ToString());
                p.ProductName = sdr[1].ToString();
                p.ProductPrice= Convert.ToInt32(sdr[2].ToString());
            }
            con.Close();
            return p;
        }
        public static void Update(Product p)
        {
            getConnection();
            string s1 = "update Product1 set ProId=@id,ProName=@name,Price=@price where ProId=@id";
            cmd = new SqlCommand(s1, con);
            cmd.Parameters.AddWithValue("@id",p.ProductId);
            cmd.Parameters.AddWithValue("@name", p.ProductName);
            cmd.Parameters.AddWithValue("@price", p.ProductPrice);
            SqlDataReader sdr = cmd.ExecuteReader();
            con.Close();
        }

       public static void Delete(int id,Product p)
        {
            getConnection();
            string s1 = "delete from Product1 where ProId=@id";
            cmd = new SqlCommand(s1, con);
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = cmd.ExecuteReader();
            con.Close();

        }
    }
}
