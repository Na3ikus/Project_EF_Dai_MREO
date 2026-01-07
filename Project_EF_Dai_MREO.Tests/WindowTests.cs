using NUnit.Framework;
using DAI_MREO.UI.Design;
using System.Collections.ObjectModel;

namespace DAI_MREO.Tests
{
    public class WindowTests
    {
        [Test]
        public void DrawTable_PrintsRowsWithoutThrowing()
        {
            var headers = new[] { "Id", "Name" };
            var rows = new ReadOnlyCollection<string[]>(new[] {
                new[] { "1", "Alpha" },
                new[] { "2", "Beta" }
            });
            var colWidths = new[] { 5, 10 };

            Assert.DoesNotThrow(() => Window.DrawTable(headers, rows, colWidths));
        }

        [Test]
        public void DrawHeader_CentersTitle()
        {
            Assert.DoesNotThrow(() => Window.DrawHeader("Test Title"));
        }
    }
}
