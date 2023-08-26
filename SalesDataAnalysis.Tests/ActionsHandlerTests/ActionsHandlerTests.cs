using System.Collections.Generic;
using FluentAssertions;
using SalesDataAnalysis.Handlers;
using SalesDataAnalysis.Models.action;
using SalesDataAnalysis.Models.Input;
using SalesDataAnalysis.Models.Result;
using Xunit;

namespace SalesDataAnalysis.Tests.ActionsHandlerTests
{
    public class ActionsHandlerTests
    {
        [Fact]
        public void ActionsHandler_Sum_ReturnResultModel()
        {
            // Arrange
            var companies = new List<Company>
            {
                new Company
                {
                    Name = "Noname Ltd.",
                    Employees = 438,
                    Outposts = 5,
                    Profit = (decimal) 513778.38,
                    SalesVolume = (decimal) 7511678.43
                },
                new Company
                {
                    Name = "Scare Ltd.",
                    Employees = 47,
                    Outposts = 2,
                    Profit = (decimal) -43791.43,
                    SalesVolume = (decimal) 611721.17
                }
            };

            var action = new Action
            {
                Function = "Sum",
                Name = "profitSum",
                Source = "profit",
                Filter = ".*Ltd."
            };

            // Act
            var result = ActionsHandler.Sum(companies, action);

            // Assert
            result.Should().BeOfType<ResultModel>();
            result.Should().BeEquivalentTo(new ResultModel
            {
                Name = "profitSum",
                Value = (decimal) 469986.95
            });
        }
    }
}