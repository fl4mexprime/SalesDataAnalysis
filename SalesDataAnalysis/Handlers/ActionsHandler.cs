using System;
using System.Collections.Generic;
using System.Linq;
using SalesDataAnalysis.Extensions;
using SalesDataAnalysis.Models.Input;
using SalesDataAnalysis.Models.Result;
using Action = SalesDataAnalysis.Models.action.Action;

namespace SalesDataAnalysis.Handlers
{
    /// <summary>
    /// Handler for working with Companies
    /// </summary>
    public static class ActionsHandler
    {
        /// <summary>
        /// Gets the sum of in the action specified attribute from all passed companies
        /// </summary>
        /// <param name="companies"></param>
        /// <param name="action"></param>
        /// <returns></returns>
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
                Value = sum,
                Name = action.Name
            };
        }

        /// <summary>
        /// Gets the maximum value of in the action specified attribute from all passed companies
        /// </summary>
        /// <param name="companies"></param>
        /// <param name="action"></param>
        /// <returns></returns>
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
                Value = max,
                Name = action.Name
            };
        }

        /// <summary>
        /// Gets the minimum value of in the action specified attribute from all passed companies
        /// </summary>
        /// <param name="companies"></param>
        /// <param name="action"></param>
        /// <returns></returns>
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
                Value = min,
                Name = action.Name
            };
        }

        /// <summary>
        /// Gets the average value of in the action specified attribute from all passed companies
        /// </summary>
        /// <param name="companies"></param>
        /// <param name="action"></param>
        /// <returns></returns>
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
                Value = count / companyList.Count,
                Name = action.Name
            };
        }
    }
}