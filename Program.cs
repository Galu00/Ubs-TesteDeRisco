using UbsDevRisk.Models.Interfaces;
using UbsDevRisk.Models;
using UbsDevRisk.Services;

class Program
{
    static void Main(string[] args)
    {
        DateTime referenceDate = DateTime.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        List<ITrade> trades = new List<ITrade>();


        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            double value = double.Parse(input[0]);
            string clientSector = input[1];
            DateTime nextPaymentDate = DateTime.Parse(input[2]);

            trades.Add(new Trade(value, clientSector, nextPaymentDate));
        }

        TradeProcessor processor = new TradeProcessor();

        foreach (var trade in trades)
        {
            Console.WriteLine(processor.Categorize(trade, referenceDate));
        }
    }
}