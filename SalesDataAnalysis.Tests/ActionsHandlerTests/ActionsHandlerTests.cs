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

        [Fact]
        public void ActionsHandler_Max_ReturnResultModel()
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
                    Name = "Klinkenputzer AG",
                    Employees = 1647,
                    Outposts = 19,
                    Profit = (decimal) 12452791.43,
                    SalesVolume = (decimal) 79536721.17
                }
            };

            var action = new Action
            {
                Function = "Max",
                Name = "salesVolumeMax",
                Source = "salesVolume",
                Filter = ".*n.*"
            };

            // Act
            var result = ActionsHandler.Max(companies, action);

            // Assert
            result.Should().BeOfType<ResultModel>();
            result.Should().BeEquivalentTo(new ResultModel
            {
                Name = "salesVolumeMax",
                Value = (decimal) 79536721.17
            });
        }

        [Fact]
        public void ActionsHandler_Min_ReturnResultModel()
        {
            // Arrange
            var companies = new List<Company>
            {
                new Company
                {
                    Name = "Netzsprache",
                    Employees = 126,
                    Outposts = 2,
                    Profit = (decimal) 148550.06,
                    SalesVolume = (decimal) 656543.71
                },
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
                    Name = "Mystery puppets",
                    Employees = 855,
                    Outposts = 3,
                    Profit = (decimal) 1448324.66,
                    SalesVolume = (decimal) 9511678.84
                },
                new Company
                {
                    Name = "Salecom",
                    Employees = 612,
                    Outposts = 4,
                    Profit = (decimal) 648550.18,
                    SalesVolume = (decimal) 1511678.25
                },
                new Company
                {
                    Name = "Klinkenputzer AG",
                    Employees = 1647,
                    Outposts = 19,
                    Profit = (decimal) 12452791.43,
                    SalesVolume = (decimal) 79536721.17
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
                Function = "Min",
                Name = "salesVolumeMin",
                Source = "salesVolume",
                Filter = ".*e.*"
            };

            // Act
            var result = ActionsHandler.Min(companies, action);

            // Assert
            result.Should().BeOfType<ResultModel>();
            result.Should().BeEquivalentTo(new ResultModel
            {
                Name = "salesVolumeMin",
                Value = (decimal) 611721.17
            });
        }

        [Fact]
        public void ActionsHandler_Average_ReturnResultModel()
        {
            // Arrange
            var companies = new List<Company>
            {
                new Company
                {
                    Name = "Netzsprache",
                    Employees = 126,
                    Outposts = 2,
                    Profit = (decimal) 148550.06,
                    SalesVolume = (decimal) 656543.71
                },
                new Company
                {
                    Name = "Mystery puppets",
                    Employees = 855,
                    Outposts = 3,
                    Profit = (decimal) 1448324.66,
                    SalesVolume = (decimal) 9511678.84
                },
            };

            var action = new Action
            {
                Function = "average",
                Name = "outpostsAverage",
                Source = "outposts",
                Filter = ".*e.*s.*"
            };

            // Act
            var result = ActionsHandler.Average(companies, action);

            // Assert
            result.Should().BeOfType<ResultModel>();
            result.Should().BeEquivalentTo(new ResultModel
            {
                Name = "outpostsAverage",
                Value = (decimal) 2.5
            });
        }
    }
}