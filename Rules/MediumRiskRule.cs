﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UbsDevRisk.Models.Interfaces;
using UbsDevRisk.Rules.Interfaces;

namespace UbsDevRisk.Rules
{
    public class MediumRiskRule : ICategoryRule
    {
        public string Category => "MEDIUMRISK";
        public bool Matches(ITrade trade, DateTime referenceDate)
        {
            return trade.Value > 1000000 && trade.ClientSector == "Public";
        }
    }

}
