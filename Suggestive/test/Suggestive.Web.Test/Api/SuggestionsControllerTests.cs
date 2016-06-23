using Suggestive.Web.Api;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Suggestive.Web.Test.Api
{
    public class SuggestionsControllerTests
    {
        [Fact]
        public async Task Get_RequestAllTickets_ExpectTicketsReturned()
        {
            var apiController = new SuggestionsController();
            var result = await apiController.Get();
            Assert.True(result.Any(), "Expected one or more suggestions returned");
        }
    }
}
