using System;
using System.Collections.Generic;
using System.Globalization;
using UbsDevRisk.Models.Interfaces;
using UbsDevRisk.Models;
using UbsDevRisk.Services;
using UbsDevRisk.Rules.Interfaces;
using UbsDevRisk.Rules;

class Program
{
    static void Main()
    {
        string dateFormat = "MM/dd/yyyy";
        DateTime referenceDate = DateTime.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        List<ITrade> trades = new();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            if (input.Length != 3)
            {
                Console.WriteLine("Invalid input format. Skipping line.");
                continue;
            }

            if (!double.TryParse(input[0], out double value) || !DateTime.TryParseExact(input[2], dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime nextPaymentDate))
            {
                Console.WriteLine("Invalid input data. Skipping line.");
                continue;
            }

            string clientSector = input[1];
            trades.Add(new Trade(value, clientSector, nextPaymentDate));
        }

        TradeProcessor processor = new TradeProcessor(new List<ICategoryRule>
            {
                new ExpiredRule(),
                new HighRiskRule(),
                new MediumRiskRule()
            });

        foreach (var trade in trades)
        {
            string category = processor.Categorize(trade, referenceDate);

            switch (category)
            {
                case "HIGHRISK":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "MEDIUMRISK":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "EXPIRED":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }

            Console.WriteLine(category);
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}

