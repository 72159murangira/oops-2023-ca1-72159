using System;
using System.Collections.Generic;

abstract class CarPark
{
    protected double MaxRate;
    protected double MinRate;
    protected double ExtraRate;

    public CarPark(double maxRate, double minRate, double extraRate)
    {
        MaxRate = maxRate;
        MinRate = minRate;
        ExtraRate = extraRate;
    }

    public abstract double TotalCharge(int hours);
}
// car park1 with the defined data (0.50 for additional fee)
class Park1 : CarPark
{
    public Park1() : base(2.00, 10.00, 0.50) { }

    public override double TotalCharge(int hours)
    {
        double charge = MinRate;
        if (hours > 3)
            charge += (hours - 3) * ExtraRate;

        return Math.Min(charge, MaxRate);
    }
}
// car park2 with the defined data (0.60 for additional fee)
class Park2 : CarPark
{
    public Park2() : base(2.00, 10.00, 0.60) { }

    public override double TotalCharge(int hours)
    {
        double charge = MinRate;
        if (hours > 3)
            charge += (hours - 3) * ExtraRate;

        return Math.Min(charge, MaxRate);
    }
}
// car park3 with the defined data (0.75 for additional fee)
class Park3 : CarPark
{
    public Park3() : base(2.00, 10.00, 0.75) { }

    public override double TotalCharge(int hours)
    {
        double charge = MinRate;
        if (hours > 3)
            charge += (hours - 3) * ExtraRate;

        return Math.Min(charge, MaxRate);
    }
}

class Program
{
    public static object Faker { get; private set; }

    static void Main()
    {
        Random random = new Random();
        List<CarPark> parks = new List<CarPark>
        {
            new Park1(),
            new Park2(),
            new Park3()
        };

        // This is the part that will simulate the customers.
        for (int i = 0; i < 10; i++)
        {
            var customer = Faker.Name.FullName();
            int ParkTime = random.Next(1, 24);

            
            foreach (var park in parks)
            {
                double charge = park.TotalCharge(ParkTime);
                Console.WriteLine($"Customer Name: {customer}, Parking Spot: {park.GetType().Name}, Total Hours: {ParkTime}, Total Rate: €{charge}");
            }
        }
    }
}