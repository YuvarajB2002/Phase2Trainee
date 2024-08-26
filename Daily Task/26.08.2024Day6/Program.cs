// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;
Console.WriteLine("Hello, World!");

//Create();
//Insert();
Fetch();
static void Create()
{
    SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=Sports_yuva;integrated security=true;");

    con.Open();

    SqlCommand cmd = new SqlCommand("create table Product1(ProId int primary key,ProName varchar(20),Price int)",con);
    cmd.ExecuteNonQuery();
    con.Close();
}
static void Insert()
{
    SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=Sports_yuva;integrated security=true;");

    con.Open();
    string s="insert into Product1 values(111,'yuva',200)";
    SqlCommand ins=new SqlCommand(s, con);
    ins.ExecuteNonQuery();
    Console.WriteLine("Inserted  successfully");
    con.Close();
}
static void Fetch()
{
    SqlConnection con = new SqlConnection("data source=PTSQLTESTDB01;database=Sports_yuva;integrated security=true;");

    con.Open();
    string s1 = "select * from Product1";
    SqlCommand sel = new SqlCommand(s1, con);
    SqlDataReader sdr = sel.ExecuteReader();
    while (sdr.Read())
    {
        Console.WriteLine(sdr[0].ToString() + "  " + sdr[1].ToString() + "  " + sdr[2].ToString());
    }
    con.Close();
}
