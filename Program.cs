using System;
using System.Globalization;

Console.WriteLine("Round-Trip-Time Demo...");
Console.WriteLine();
PrintRTTFormat();
PrintRTTConversion();
Console.ReadKey();

void PrintRTTFormat()
{
    DateTime dat = new DateTime(2009, 6, 15, 13, 45, 30, DateTimeKind.Unspecified);
    Console.WriteLine("{0} ({1}) --> {0:O}", dat, dat.Kind);

    DateTime uDat = new DateTime(2009, 6, 15, 13, 45, 30, DateTimeKind.Utc);
    Console.WriteLine("{0} ({1}) --> {0:O}", uDat, uDat.Kind);

    DateTime lDat = new DateTime(2009, 6, 15, 13, 45, 30, DateTimeKind.Local);
    Console.WriteLine("{0} ({1}) --> {0:O}\n", lDat, lDat.Kind);

    DateTimeOffset dto = new DateTimeOffset(lDat);
    Console.WriteLine("{0} --> {0:O}", dto);

    // The example displays the following output:
    //    6/15/2009 1:45:30 PM (Unspecified) --> 2009-06-15T13:45:30.0000000
    //    6/15/2009 1:45:30 PM (Utc) --> 2009-06-15T13:45:30.0000000Z
    //    6/15/2009 1:45:30 PM (Local) --> 2009-06-15T13:45:30.0000000-07:00
    //
    //    6/15/2009 1:45:30 PM -07:00 --> 2009-06-15T13:45:30.0000000-07:00
}

void PrintRTTConversion()
{
	// Round-trip DateTime values.
	DateTime originalDate, newDate;
	string dateString;
	// Round-trip a local time.
	originalDate = DateTime.SpecifyKind(new DateTime(2008, 4, 10, 6, 30, 0), DateTimeKind.Local);
	dateString = originalDate.ToString("o");
	newDate = DateTime.Parse(dateString, null, DateTimeStyles.RoundtripKind);
	Console.WriteLine("Round-tripped {0} {1} to {2} {3}.", originalDate, originalDate.Kind, newDate, newDate.Kind);
	// Round-trip a UTC time.
	originalDate = DateTime.SpecifyKind(new DateTime(2008, 4, 12, 9, 30, 0), DateTimeKind.Utc);
	dateString = originalDate.ToString("o");
	newDate = DateTime.Parse(dateString, null, DateTimeStyles.RoundtripKind);
	Console.WriteLine("Round-tripped {0} {1} to {2} {3}.", originalDate, originalDate.Kind, newDate, newDate.Kind);
	// Round-trip time in an unspecified time zone.
	originalDate = DateTime.SpecifyKind(new DateTime(2008, 4, 13, 12, 30, 0), DateTimeKind.Unspecified);
	dateString = originalDate.ToString("o");
	newDate = DateTime.Parse(dateString, null, DateTimeStyles.RoundtripKind);
	Console.WriteLine("Round-tripped {0} {1} to {2} {3}.", originalDate, originalDate.Kind, newDate, newDate.Kind);

	// Round-trip a DateTimeOffset value.
	DateTimeOffset originalDTO = new DateTimeOffset(2008, 4, 12, 9, 30, 0, new TimeSpan(-8, 0, 0));
	dateString = originalDTO.ToString("o");
	DateTimeOffset newDTO = DateTimeOffset.Parse(dateString, null, DateTimeStyles.RoundtripKind);
	Console.WriteLine("Round-tripped {0} to {1}.", originalDTO, newDTO);

	// The example displays the following output:
	//    Round-tripped 4/10/2008 6:30:00 AM Local to 4/10/2008 6:30:00 AM Local.
	//    Round-tripped 4/12/2008 9:30:00 AM Utc to 4/12/2008 9:30:00 AM Utc.
	//    Round-tripped 4/13/2008 12:30:00 PM Unspecified to 4/13/2008 12:30:00 PM Unspecified.
	//    Round-tripped 4/12/2008 9:30:00 AM -08:00 to 4/12/2008 9:30:00 AM -08:00.
}
