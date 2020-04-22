using Xunit;
using NetStandard.Utils.Maths;

namespace NetStandard.Utils.Tests.Maths
{
    public class MathExtensionTests
    {
        [Fact]
        public void Factorial_Should_Work()
        {
            //This line is to be activated when debugging the test from console
            //using dotnet test command to have time to attach vs code debugger to the process
            //then attached debuger to the dotnet testhost.dll
            //Thread.Sleep(15000);
            var i = 2 ;
            var f = i.Factorial();
            Assert.Equal(2,f);

        }
    }
}