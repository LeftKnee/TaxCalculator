using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TaxCalculator.Api.Data;
using TaxCalculator.Api.Entities;
using TaxCalculator.Api.Repositories;
using TaxCalculator.Api.Repositories.Contracts;
using TaxCalculator.Models.Dtos;

namespace TaxCalculator.Tests
{
    [TestFixture]
    public class Tests
    {

        public Mock<ITaxCalculatorLogRepository> _logRepository; 
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()
        {
            IList<TaxCalculatorLog> taxLogs = new List<TaxCalculatorLog>
            {
                new TaxCalculatorLog
                {
                    Id = 1,
                    AnnualIncome = 1000,
                    DateAdded = System.DateTime.Now,
                    PostalCode = "7441",
                    TaxedValue = 100
                }
            };

            Mock<ITaxCalculatorLogRepository> mocklogRepository = new Mock<ITaxCalculatorLogRepository>();

            mocklogRepository.Setup(mr => mr.AddLogItem(It.IsAny<TaxCalculatorLogUpdateDto>())).Returns(
                (TaxCalculatorLog taxLog) =>
                {
                    taxLog.AnnualIncome = 1000;
                    taxLog.PostalCode = "7441";

                    taxLogs.Add(taxLog);

                    return taxLog;
                });

            // Complete the setup of our Mock Product Repository
            this._logRepository = (Mock<ITaxCalculatorLogRepository>)mocklogRepository.Object;
            
        }

    }
}
