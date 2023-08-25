using System;
using System.Collections.Generic;
using System.Linq;
using SalesDataAnalysis.Extensions;
using SalesDataAnalysis.Models.Input;
using SalesDataAnalysis.Models.Result;
using Action = SalesDataAnalysis.Models.action.Action;

namespace SalesDataAnalysis.Handlers
{
    public static class ActionsHandler
    {
        public static ResultModel Sum(IEnumerable<Company> companies, Action action)
        {
            decimal sum = 0;

            companies.ToList().ForEach(company =>
            {
                var type = typeof(Company);
                var prop = type.GetProperty(action.Source.ToUpperFirstLetter())?.GetValue(company);
                sum += Convert.ToDecimal(prop);
            });

            return new ResultModel
            {
                Result = sum,
                Name = action.Name
            };
        }

        public static ResultModel Max(IEnumerable<Company> companies, Action action)
        {
            decimal max = 0;

            companies.ToList().ForEach(company =>
            {
                var type = typeof(Company);
                var prop = type.GetProperty(action.Source.ToUpperFirstLetter())?.GetValue(company);
                var count = Convert.ToDecimal(prop);
                
                if(count > max)
                    max = Convert.ToDecimal(prop);
            });
            
            return new ResultModel
            {
                Result = max,
                Name = action.Name
            };
        }

        public static ResultModel Min(IEnumerable<Company> companies, Action action)
        {
            decimal min = 0;

            companies.ToList().ForEach(company =>
            {
                var type = typeof(Company);
                var prop = type.GetProperty(action.Source.ToUpperFirstLetter())?.GetValue(company);
                var count = Convert.ToDecimal(prop);

                if (min == 0)
                {
                    min = count;
                    return;
                }

                if (count < min)
                    min = Convert.ToDecimal(prop);
            });

            return new ResultModel
            {
                Result = min,
                Name = action.Name
            };
        }

        public static ResultModel Average(IEnumerable<Company> companies, Action action)
        {
            decimal count = 0;

            var companyList = companies.ToList();
            companyList.ForEach(company =>
            {
                var type = typeof(Company);
                var prop = type.GetProperty(action.Source.ToUpperFirstLetter())?.GetValue(company);
                count += Convert.ToDecimal(prop);
            });

            return new ResultModel
            {
                Result = count / companyList.Count,
                Name = action.Name
            };
        }
    }
}