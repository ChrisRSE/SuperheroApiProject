using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using SuperheroAPITests.Services;

namespace SuperheroAPITests.Tests
{
    public class NameTests
    {
        NameService  _nameGoodService;
        NameService _nameBadService;

        #region 0. Set Up
        [OneTimeSetUp]
        public async Task OneTimeSetupAsync()
        {
            _nameGoodService = new NameService();
            await _nameGoodService.MakeRequestAsync("Batman");
            _nameBadService = new NameService();
            await _nameBadService.MakeRequestAsync("-0fgh");
        }
        #endregion

        #region 1. Verify correct HTTP status code
        [Test]
        [Category ("Happy Path")]
        public void StatusIs200WhenValidSuperheroNameIsUsed()
        {
            Assert.That(_nameGoodService.CallManager.Status, Is.EqualTo(200));
        }

        [Test]
        [Category("Sad Path")]
        public void StatusIsDefault0_WhenNoValueIsPassed()
        {
            var testNameService = new NameService();
            Assert.That(testNameService.CallManager.Status, Is.EqualTo(0));
        }


        [Test]
        [Category("Sad Path")]
        public void StatusIs400WhenInvalidSuperheroNameIsUsed()
        {
            Assert.That(_nameBadService.Json_Response["response"].ToString(), Is.EqualTo("error"));
        }
        #endregion

        #region 2. Verify response payload
        [Test]
        [Category("Happy Path")]
        public void CheckDetailsCorrectWithValidName()
        {
            Assert.That(_nameGoodService.CountNumberOfCharatcterVersions(), Is.EqualTo(3));
        }

        [Test]
        [Category("Happy Path")]
        public void WhenValidSuperheroNameIsUsed_Correct_MultipleiDsreturned()
        {      
            Assert.That(_nameGoodService.NameDTO.Response.results[0].id, Is.EqualTo("69")); 
            Assert.That(_nameGoodService.NameDTO.Response.results[1].id, Is.EqualTo("70"));
            Assert.That(_nameGoodService.NameDTO.Response.results[2].id, Is.EqualTo("71"));
            
        }

        [Test]
        [Category("Happy Path")]
        public void WhenValidSuperheroNameIsUsed_Correct_DetailsProvided()
        {
            Assert.That(_nameGoodService.NameDTO.Response.results[0].powerstats.intelligence, Is.EqualTo("81"));
            Assert.That(_nameGoodService.NameDTO.Response.results[1].powerstats.intelligence, Is.EqualTo("100"));
            Assert.That(_nameGoodService.NameDTO.Response.results[2].powerstats.intelligence, Is.EqualTo("88"));
            Assert.That(_nameGoodService.NameDTO.Response.results[0].biography.fullname,Is.EqualTo("Terry McGinnis"));
            Assert.That(_nameGoodService.NameDTO.Response.results[1].biography.fullname, Is.EqualTo("Bruce Wayne"));
            Assert.That(_nameGoodService.NameDTO.Response.results[2].biography.fullname, Is.EqualTo("Dick Grayson"));
            
        }

        [Test]
        [Category("Happy Path")]
        public void CheckJsonResponseContainsFiledNames()
        {
            Assert.That(_nameGoodService.Json_Response.ContainsKey("results"));
            Assert.That(_nameGoodService.Json_Response.ContainsKey("response"));
            Assert.That(_nameGoodService.Json_Response.ContainsKey("results-for"));
        }

        [Test]
        [Category("Happy Path")]
        public void CheckNameResponseContainsFieldNames()
        {
            Assert.That(_nameGoodService.NameResponse.Contains("results"));
            Assert.That(_nameGoodService.NameResponse.Contains("id"));
            Assert.That(_nameGoodService.NameResponse.Contains("powerstats"));
            Assert.That(_nameGoodService.NameResponse.Contains("full-name"));
            Assert.That(_nameGoodService.NameResponse.Contains("biography"));
            Assert.That(_nameGoodService.NameResponse.Contains("appearance"));
            Assert.That(_nameGoodService.NameResponse.Contains("work"));
            Assert.That(_nameGoodService.NameResponse.Contains("connections"));
            Assert.That(_nameGoodService.NameResponse.Contains("image"));

        }
        #endregion

        #region 3. Verify response headers

        [Test]
        [Category("Happy Path")]
        public void CheckHeaderResponse_ReturnsCorrectAmountOfHeaders()
        {
            Assert.That(_nameGoodService.CallManager.HeaderResponse.Count(), Is.EqualTo(20));
        }

        [Test]
        [Category("Happy Path")]
        public void CheckHeaderResponseConection_ReturnsKeepAlive()
        {
            Assert.That(_nameGoodService.CallManager.HeaderResponse[0].ToString(), Is.EqualTo("Connection=keep-alive"));
        }

        [Test]
        [Category("Happy Path")]
        public void CheckHeaderResponseServer_ReturnsCloudflare()
        {
            Assert.That(_nameGoodService.CallManager.HeaderResponse[18].ToString(), Is.EqualTo("Server=cloudflare"));
        }

        [Test]
        [Category("Happy Path")]
        public void CheckHeaderResponseXPoweredBy_ReturnsCorrectPHPValue()
        {
            Assert.That(_nameGoodService.CallManager.HeaderResponse[19].ToString(), Is.EqualTo("X-Powered-By=PHP/7.2.34"));
        }

        [Test]
        [Category("Happy Path")]
        public void CheckHeaderAccessControlAllowCredentials_ReturnsFalse()
        {
            Assert.That(_nameGoodService.CallManager.HeaderResponse[2].ToString(), Is.EqualTo("access-control-allow-credentials=false"));
        }

        [Test]
        [Category("Happy Path")]
        public void CheckHeaderResponseAccessControlAllowMethods_ReturnsGET()
        {
            Assert.That(_nameGoodService.CallManager.HeaderResponse[3].ToString(), Is.EqualTo("access-control-allow-methods=GET"));
        }

        [Test]
        [Category("Happy Path")]
        public void CheckHeaderResponseCacheStatus_ReturnsDynamic()
        {
            Assert.That(_nameGoodService.CallManager.HeaderResponse[9].ToString(), Is.EqualTo("CF-Cache-Status=DYNAMIC"));
        }

        [Test]
        [Category("Happy Path")]
        public void CheckHeaderResponseContentType_ReturnsCloudflare()
        {
            Assert.That(_nameGoodService.CallManager.HeaderResponse[16].ToString(), Is.EqualTo("Content-Type=application/json"));
        }

        [Test]
        [Category("Happy Path")]
        public void CheckHeaderResponseContentEncoding_ReturnsNothing()
        {
            Assert.That(_nameGoodService.CallManager.HeaderResponse[6].ToString(), Is.EqualTo("content-encoding="));
        }

        [Test]
        [Category("Happy Path")]
        public void CheckHeaderResponseVary_ReturnsAcceptEncoding()
        {
            Assert.That(_nameGoodService.CallManager.HeaderResponse[7].ToString(), Is.EqualTo("vary=Accept-Encoding"));
        }




        #endregion
    }
}
