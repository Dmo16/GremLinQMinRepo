using ExRam.Gremlinq.Core;
using GremLinQMinRepo.Fixtures;
using TestClassLib;
using TestClassLib.Logic;
using Xunit;

namespace GremLinQMinRepo.Tests
{
    public class StepLabelTestShould : CommonBaseFixture
    {
        public StepLabelTestShould(IGremlinQuerySource g) : base(g)
        {
        }

        [Fact]
        public async void ReturnFoundPerson()
        {
            //Arrange
            var sut = new StepLabelTest(_g);
            
            //Act
            var newPerson1 = new Person
            {
                Name = "Test Person 1",
                City = "Los Angeles",
                group = "Client"
            };

            var newPerson2 = new Person
            {
                Name = "Test Person 2",
                City = "Vancouver",
                group = "Customer"
            };

            var result1 = await SeedTestPersonAsync(newPerson1);
            var result2 = await SeedTestPersonAsync(newPerson2);

            await CreateTestEdge(result1, result2);

            var result = await sut.ReturnTuples();
            
            //Assert
            Assert.Null(result);
        }
    }
}