// See https://aka.ms/new-console-template for more information
using WeekEndTask;

Console.WriteLine("Enter the details");

Console.WriteLine("Enter the type of Employee:");
string etype=Console.ReadLine();

if (etype.ToLower().Equals("permanent"))
{
    Console.WriteLine("Employee Id:");
    int eid = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Employee Name:");
    string ename = Console.ReadLine();
    Console.WriteLine("Basic Salary:");
    float basicsal = float.Parse(Console.ReadLine());
    Console.WriteLine("PF:");
    int pf = Convert.ToInt32(Console.ReadLine());

    PermanentEmployee pobj = new PermanentEmployee() { Id=eid,Name=ename,Pf=pf,BasicSalary=basicsal};
    pobj.NetSalary=pobj.CalculateSalary(eid,ename,basicsal);

    pobj.Bonus = pobj.CalculateBonus(basicsal, pf);

    Console.WriteLine("The details are:");
    Console.WriteLine("Employee Id:"+pobj.Id);
    Console.WriteLine("Employee Name:"+pobj.Name);
    Console.WriteLine("Basic Salary:"+pobj.BasicSalary);
    Console.WriteLine("PF:"+pobj.Pf);
    Console.WriteLine("Bonus:" + pobj.Bonus);
    Console.WriteLine("Net Salary:"+pobj.NetSalary);
        }
else if (etype.ToLower().Equals("temporary")) {
    Console.WriteLine("Employee Id:");
    int eid = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Employee Name:");
    string ename = Console.ReadLine();
    Console.WriteLine("Daily Wages:");
    int wages = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("No.of days worked:");
    int day= Convert.ToInt32(Console.ReadLine());
    TemporaryEmployee tobj = new TemporaryEmployee() { Id = eid, Name = ename, DailyWages = wages, NoOfDays = day };
    tobj.NetSalary = tobj.CalculateSalary(eid, ename, tobj.BasicSalary);
    tobj.CalculateBonus(tobj.BasicSalary, wages);
    Console.WriteLine("The details are:");
    Console.WriteLine("Employee Id:" + tobj.Id);
    Console.WriteLine("Employee Name:" + tobj.Name);
    Console.WriteLine("Daily Wages:" + tobj.DailyWages);
    Console.WriteLine("No.of days worked:" + tobj.NoOfDays);
    Console.WriteLine("Bonus:" + tobj.Bonus);
    Console.WriteLine("Net Salary:" + tobj.NetSalary);
}
else
{
    Console.WriteLine("Invalid employee type entered.");
}
