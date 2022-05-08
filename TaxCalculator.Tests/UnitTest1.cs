using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TaxCalculator.Api.Data;
using TaxCalculator.Api.Entities;
using TaxCalculator.Api.Repositories;
using TaxCalculator.Api.Repositories.Contracts;


namespace TaxCalculator.Tests
{
    [TestFixture]
    public class Tests
    {

        public readonly ITaxCalculatorLogRepository _logRepository; 
        [SetUp]
        public void Setup()
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

            Mock<ITaxCalculatorLogRepository> logRepositoryMock = new Mock<ITaxCalculatorLogRepository>();

            logRepositoryMock.Setup(x => x.GetLogAsync()).Returns((System.Threading.Tasks.Task<IEnumerable<TaxCalculatorLog>>)taxLogs);

            logRepositoryMock = (Mock<ITaxCalculatorLogRepository>)logRepositoryMock.Object;
        }

        [Test]
        public void Test1()
        {
            IList<TaxCalculatorLog> logs = (IList<TaxCalculatorLog>)_logRepository.GetLogAsync();

            Assert.IsNotNull(logs);

        }
    }
}
