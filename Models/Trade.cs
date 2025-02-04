using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UbsDevRisk.Models.Interfaces;

namespace UbsDevRisk.Models
{
    public class Trade : ITrade
    {
        public double Value { get; }
        public string ClientSector { get; }
        public DateTime NextPaymentDate { get; }

        public Trade(double value, string clientSector, DateTime nextPaymentDate)
        {
            if (string.IsNullOrWhiteSpace(clientSector))
                throw new ArgumentException("Client sector cannot be null or empty.", nameof(clientSector));

            Value = value;
            ClientSector = clientSector;
            NextPaymentDate = nextPaymentDate;
        }
    }
}
