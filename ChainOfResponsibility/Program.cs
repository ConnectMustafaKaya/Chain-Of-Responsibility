using ChainofResponsibility.Business;
using ChainofResponsibility.Business.Models;
using System.Globalization;

var user = new User("Mustafa KAYA",
                "018001XXXX",
                new RegionInfo("SE"),
                new DateTimeOffset(1997, 01, 29, 00, 00, 00, TimeSpan.FromHours(2)));

var processor = new UserProcessor();

var result = UserProcessor.Register(user);

Console.WriteLine(result);
