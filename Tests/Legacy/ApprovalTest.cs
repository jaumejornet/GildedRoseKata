using ApprovalTests.Reporters;
using NUnit.Framework;

namespace GildedRose.Tests.Legacy
{
	[TestFixture]
	[UseReporter(typeof(NUnitReporter))]
	public class ApprovalTest
	{
        //[Test]
        //public void ThirtyDays()
        //{
        //    StringBuilder fakeoutput = new StringBuilder();
        //    Console.SetOut(new StringWriter(fakeoutput));
        //    Console.SetIn(new StringReader("a\n"));

        //    Program.Main(new string[] { });
        //    String output = fakeoutput.ToString();
        //    Approvals.Verify(output);
        //}
	}
	
}