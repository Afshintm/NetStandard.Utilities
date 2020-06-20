using NetStandard.Utils.Strings;
using Xunit;

namespace NetStandard.Utils.Tests.Strings
{
    public class StringExtensionClassTests
    {
        public class StringTests
        {
            [Theory]
            [InlineData("abc", "cba")]
            [InlineData(null, null)]
            [InlineData("", "")]
            [InlineData("1234", "4321")]
            [InlineData("1", "1")]
            [InlineData("a1", "1a")]
            public void StringReverse_Should_Reverse_String(string inital , string expected)
            {
                var actual = inital.StringReverse();
                Assert.Equal(actual,expected);
            }
        
            [Theory]
            [InlineData("abc", "cba")]
            public void StrReverse_Should_Reverse_String(string inital , string expected)
            {
                var str = inital.StrReverse();
                Assert.Equal(str,expected);
            }
            
            [Fact]
            public void Should_Insert_Char_At_Postion(){
                var source = "12345" ;
                var target = source.InsertAt('a',2);
                Assert.Equal("12a345", target);
            }
            
            [Fact]
            public void String_Should_Be_Enumerable()
            {
                var str = "12345";
                var strEnum = str.AsMyEnumerator();
                var i = -1;
                foreach (var item in str.AsMyEnumerator())
                {
                    Assert.NotNull(item);
                    Assert.Equal(str[++i],item);
                }
            }

        }
    }
}