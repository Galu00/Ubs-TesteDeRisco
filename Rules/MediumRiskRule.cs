﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UbsDevRisk.Models.Interfaces;
using UbsDevRisk.Rules.Interfaces;

namespace UbsDevRisk.Rules
{
    public class MediumRiskRule : BaseCategoryRule
    {
        public override string Category => "MEDIUMRISK";
        public override bool Matches(ITrade trade, DateTime referenceDate) =>
            trade.Value > 1_000_000 && trade.ClientSector.Equals("Public", StringComparison.OrdinalIgnoreCase);
    }

}
