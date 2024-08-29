// See https://aka.ms/new-console-template for more information


using Assesment1;

Console.WriteLine("Insurance Number : ");
string insNo=Console.ReadLine();
Console.WriteLine("Insurance Name : ");
string insName=Console.ReadLine();
Console.WriteLine("Amount Covered : ");
double amount=Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Select \n 1. Life Insurance \n 2.Motor Insurance");
int choice=Convert.ToInt32(Console.ReadLine());
Insurance obj=new Insurance() { InsuranceNo=insNo,InsuranceName=insName,AmountCovered=amount};
double result = addPolicy(obj, choice);
if (result == -1)
{
    Console.WriteLine("Invalid option");
}
else
{
    Console.WriteLine("Calculated Premium : " + result);
}


 double addPolicy(Insurance ins,int opt) {
    if (opt == 1)
    {
        Console.WriteLine("Policy Term : ");
        int polterm=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Benefit Percent : ");
        float benPer=Convert.ToSingle(Console.ReadLine());
        LifeInsurance life = new LifeInsurance() {InsuranceNo=ins.InsuranceNo,InsuranceName=ins.InsuranceName,AmountCovered=ins.AmountCovered, PolicyTerm = polterm, BenefitPercent = benPer };
        return life.calculatePremium();
    }
    else if (opt == 2)
    {
        Console.WriteLine("Depreciation Percent : ");
        float depPer=Convert.ToSingle(Console.ReadLine());
        MotorInsurance motor = new MotorInsurance() { InsuranceNo = ins.InsuranceNo, InsuranceName = ins.InsuranceName, AmountCovered = ins.AmountCovered ,DepPercent=depPer};
        return motor.calculatePremium();
    }
    else
    {
        return -1;
    }
}
