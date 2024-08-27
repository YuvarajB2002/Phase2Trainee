// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;
using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace MyApp
{
    internal class Program
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static void Main(string[] args)
        {
            int choice = 0;
            do
            {
                Console.WriteLine(" 1.Create \n 2.Fetch \n 3.Insert \n 4.Update \n 5.Delete \n 6.Exit");
                Console.WriteLine("Enter your option");
                choice=Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Create();
                        break;
                    case 2:
                        Fetch();
                        break;
                    case 3:
                        Insert();
                        break;
                    case 4:
                        Update();
                        break;
                    case 5:
                        Delete();
                        break;
                    default:
                        Console.WriteLine("Thank you");
                        break;

                }

            } while (choice<6);
        }
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
        static void Insert()
        {
            Console.WriteLine("How many records inserted");
            int n = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                getConnection();
                Console.WriteLine("Enter the Product Id");
                int id= Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Product Name");
                string name= Console.ReadLine();
                Console.WriteLine("Enter the Product Price");
                int price= Convert.ToInt32(Console.ReadLine());
                cmd = new SqlCommand("insert into Product1 values(@id,@name,@price)", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.ExecuteNonQuery();
                Console.WriteLine(i+1+" row inserted successfully");
                con.Close();
            }
           
        }
        static void Fetch()
        {
            getConnection();
            string s1 = "select * from Product1";
            cmd = new SqlCommand(s1, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Console.WriteLine(sdr[0].ToString() + "  " + sdr[1].ToString() + "  " + sdr[2].ToString());
            }
            con.Close();
        }

        static void Update()
        {
           
            Console.WriteLine("Which column will be update (price/name) :");
            string column = Console.ReadLine();
            if (column.ToLower().Equals("price"))
            {
                getConnection();
                Console.WriteLine("Enter the Product Id");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Product Price");
                int price = Convert.ToInt32(Console.ReadLine());
                string s1 = "update Product1 set Price=@price where ProId=@id";
                cmd = new SqlCommand(s1, con);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Price Updated successfully");
                con.Close();
            }
            else if (column.ToLower().Equals("name"))
            {
                getConnection();
                Console.WriteLine("Enter the Product Id");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Product Name");
                string name = Console.ReadLine();
                string s2 = "update Product1 set ProName=@name where ProId=@id";
                cmd = new SqlCommand(s2, con);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Product Name Updated successfully");
                con.Close();
            }
        }

        static void Delete()
        {
            Console.WriteLine("If you delete all the records (yes/no)");
            string t = Console.ReadLine();
            if (t.ToLower().Equals("yes"))
            {
                getConnection();
                string s = "delete from Product1";
                cmd = new SqlCommand(s, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("All records deleted successfully");
                con.Close();
            }
            else if (t.ToLower().Equals("no"))
            {
                getConnection();
                Console.WriteLine("Enter the Product Id ");
                int id= Convert.ToInt32(Console.ReadLine());
                string s = "delete from Product1 where ProId=@id";
                cmd = new SqlCommand(s, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                Console.WriteLine("One records deleted successfully");
                con.Close();
            }
           
        }

    }
}
