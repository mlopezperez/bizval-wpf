﻿using BizVal.Model;

namespace BizVal.Services.CwAggregation
{
    internal class CwAggregator : ICwAggregator
    {
        private readonly IExpertiseStandardizer standardizer;

        public CwAggregator(IExpertiseStandardizer standardizer)
        {
            this.standardizer = standardizer;
        }

        Interval ICwAggregator.AggregateByExpertone(Expertise expertise)
        {
            //var standardExpertise = this.standardizer.Standardize(expertise);
            // Get cardinalities
            // Create expertone
            // Get R-Expertone
            // Get math expectation
            return null;
        }
    }
}