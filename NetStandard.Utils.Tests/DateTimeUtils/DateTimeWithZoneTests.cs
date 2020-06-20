using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Xunit;

public class TestClassWithDateTime{
    public DateTime DateTime { get; set; }
    public string DateTimeString {get;set;}

}
public class DateTimeWithZoneTests
{
    private ReadOnlyCollection<TimeZoneInfo> TimeZones = TimeZoneInfo.GetSystemTimeZones(); 
    [Fact]
    public void Same_DateTime_Different_TimeZone_Should_Have_The_Same_UTC(){
        var utcDateTime = DateTime.UtcNow;
        //var dateTimeWithZone1 = new  DateTimeWithZone(utcDateTime, TimeZones[])
        foreach(var item in TimeZones){
            Console.WriteLine(item);
            Assert.NotNull(item);

        }
        var dateTime = DateTime.UtcNow;
        var dateTimeOffset = new DateTimeOffset(dateTime);
        var datetimeOffsetToStr = dateTimeOffset.ToString("O");
        Console.WriteLine($"DateTimeOffset UtcNow is: {datetimeOffsetToStr}");

        
        var dateTimeStr = dateTime.ToString("o");
        Console.WriteLine($"DateTime UtcNow is{dateTimeStr}");

        var testClassWithDateTime = new TestClassWithDateTime{DateTime = dateTime, DateTimeString = dateTimeStr };
        var jsonStringTestClass = JsonConvert.SerializeObject(testClassWithDateTime);

        Console.WriteLine($"Json stringify of the datetime is: \n\r{jsonStringTestClass}");



    }
}