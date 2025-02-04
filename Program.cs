using System;
using System.Collections.Generic;
using System.Globalization;
using UbsDevRisk.Models.Interfaces;
using UbsDevRisk.Models;
using UbsDevRisk.Services;

class Program
{
    static void Main(string[] args)
    {
        string dateFormat = "MM/dd/yyyy";

        DateTime referenceDate = DateTime.ParseExact(Console.ReadLine(), dateFormat, CultureInfo.InvariantCulture);

        int n = int.Parse(Console.ReadLine());
        List<ITrade> trades = new List<ITrade>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(' ');

            double value = double.Parse(input[0], CultureInfo.InvariantCulture);
            string clientSector = input[1];

            DateTime nextPaymentDate = DateTime.ParseExact(input[2], dateFormat, CultureInfo.InvariantCulture);

            trades.Add(new Trade(value, clientSector, nextPaymentDate));
        }

        TradeProcessor processor = new TradeProcessor();

        foreach (var trade in trades)
        {
            Console.WriteLine(processor.Categorize(trade, referenceDate));
        }
    }
}
