using System.Diagnostics;

namespace CompanyNameSpace.ProjectName.Application.UnitTests.Test
{
    public class TestClass : IDisposable
    {
        public TestClass()
        {
            Debug.WriteLine("Setup");
        }

        public void Dispose()
        {
            Debug.WriteLine("CleanUp");
        }

        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        //[Fact]
        public void FailingTest()
        {
            Assert.Equal(5, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        public void TheoryTest(int value)
        {
            Assert.True(IsOdd(value));
        }

        bool IsOdd(int value)
        {
            return value % 2 == 1;

        }
    }
}
