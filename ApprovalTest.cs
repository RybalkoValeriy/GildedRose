using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace csharp
{
    [UseReporter(typeof(DiffReporter))]
    [TestFixture]
    public class ApprovalTest
    {
        [Test]
        public void ThirtyDays()
        {
            // Arrange
            var daysInput = "30";
            var fakeOutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeOutput));
            Console.SetIn(new StringReader("a\n"));

            // Act
            Program.Main(new string[] { daysInput });
            var output = fakeOutput.ToString();

            // Assert
            Approvals.Verify(output);
        }
    }
}
