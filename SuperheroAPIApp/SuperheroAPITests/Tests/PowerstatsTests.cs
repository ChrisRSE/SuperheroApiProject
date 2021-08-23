using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SuperheroAPITests.Services;

namespace SuperheroAPITests.Tests
{
    public class PowerstatsTests
    {
        PowerstatsService _superheroGoodService;
        PowerstatsService _superheroBadService;

        #region 0. Set Up

        [OneTimeSetUp]
        public async Task OneTimeSetupAsync()
        {
            _superheroGoodService = new PowerstatsService();
            _superheroBadService = new PowerstatsService();
            await _superheroGoodService.MakeRequestAsync(70);
            await _superheroBadService.MakeRequestAsync(300_000_000);
        }

        #endregion

        #region 1. Verify correct HTTP status code

        [Test]
        [Category("Happy Path")]
        public void StatusIsSuccess_IfValidIDIsGiven()
        {
            Assert.That(_superheroGoodService.Json_response["response"].ToString(), Is.EqualTo("success"));
        }

        [Test]
        [Category("Happy Path")]
        public void StatusIs200_IfValidIDIsGiven()
        {
            Assert.That(_superheroGoodService.CallManager.Status, Is.EqualTo(200));
        }

        [Test]
        [Category("Sad Path")]
        public void StatusIsError_IfInvalidIDIsGiven()
        {
            Assert.That(_superheroBadService.Json_response["response"].ToString(), Is.EqualTo("error"));
        }

        [Test]
        [Category("Sad Path")]
        public void InvalidIDErrorIsGiven_IfInvalidIDIsGiven()
        {
            Assert.That(_superheroBadService.Json_response["error"].ToString(), Is.EqualTo("invalid id"));
        }

        [Test]
        [Category("Sad Path")]
        public void StatusIsDefault0_WhenNoValueIsPassed()
        {
            var testService = new PowerstatsService();
            Assert.That(() => testService.CallManager.Status, Is.EqualTo(0));
        }

        #endregion

        #region 2. Verify response payload

        [Test]
        [Category("Happy Path")]
        public void ReturnsCorrectSuperhero_WhenValidIDIsGiven()
        {
            Assert.That(_superheroGoodService.Json_response["name"].ToString(), Is.EqualTo("Batman"));

        }

        [Test]
        [Category("Happy Path")]
        public void ReturnsIntelligence100_WhenBatmanIDIsGiven()
        {
            Assert.That(_superheroGoodService.PowerstatDTO.Response.intelligence, Is.EqualTo("100"));

        }

        [Test]
        [Category("Happy Path")]
        public void ReturnsStrength26_WhenBatmanIDIsGiven()
        {
            Assert.That(_superheroGoodService.PowerstatDTO.Response.strength, Is.EqualTo("26"));
        }

        [Test]
        [Category("Happy Path")]
        public void ReturnsSpeed27_WhenBatmanIDIsGiven()
        {
            Assert.That(_superheroGoodService.PowerstatDTO.Response.speed, Is.EqualTo("27"));
        }

        [Test]
        [Category("Happy Path")]
        public void ReturnsDurability50_WhenBatmanIDIsGiven()
        {
            Assert.That(_superheroGoodService.PowerstatDTO.Response.durability, Is.EqualTo("50"));
        }

        [Test]
        [Category("Happy Path")]
        public void ReturnsPower47_WhenBatmanIDIsGiven()
        {
            Assert.That(_superheroGoodService.PowerstatDTO.Response.power, Is.EqualTo("47"));
        }

        [Test]
        [Category("Happy Path")]
        public void ReturnsCombat100_WhenBatmanIDIsGiven()
        {
            Assert.That(_superheroGoodService.PowerstatDTO.Response.combat, Is.EqualTo("100"));
        }
        public void TestJsonResponseHeaders_ContainCorrectHeaderNames()
        {
            Assert.That(_superheroGoodService.Json_response.ContainsKey("intelligence"));
            Assert.That(_superheroGoodService.Json_response.ContainsKey("strength"));
            Assert.That(_superheroGoodService.Json_response.ContainsKey("speed"));
            Assert.That(_superheroGoodService.Json_response.ContainsKey("durability"));
            Assert.That(_superheroGoodService.Json_response.ContainsKey("power"));
            Assert.That(_superheroGoodService.Json_response.ContainsKey("combat"));
        }


        #endregion

        #region 3. Verify response headers
        [Test]
        [Category("Happy Path")]
        public void CheckHeaderResponse_ReturnsCorrectAmountOfHeaders()
        {
            Assert.That(_superheroGoodService.CallManager.HeaderResponse.Count(), Is.EqualTo(20));
        }

        [Test]
        [Category("Happy Path")]
        public void CheckHeaderResponseConection_ReturnsKeepAlive()
        {
            Assert.That(_superheroGoodService.CallManager.HeaderResponse[0].ToString(), Is.EqualTo("Connection=keep-alive"));
        }

        [Test]
        [Category("Happy Path")]
        public void CheckHeaderResponseServer_ReturnsCloudflare()
        {
            Assert.That(_superheroGoodService.CallManager.HeaderResponse[18].ToString(), Is.EqualTo("Server=cloudflare"));
        }

        [Test]
        [Category("Happy Path")]
        public void CheckHeaderResponseXPoweredBy_ReturnsCorrectPHPValue()
        {
            Assert.That(_superheroGoodService.CallManager.HeaderResponse[19].ToString(), Is.EqualTo("X-Powered-By=PHP/7.2.34"));
        }

        [Test]
        [Category("Happy Path")]
        public void CheckHeaderAccessControlAllowCredentials_ReturnsFalse()
        {
            Assert.That(_superheroGoodService.CallManager.HeaderResponse[2].ToString(), Is.EqualTo("access-control-allow-credentials=false"));
        }

        [Test]
        [Category("Happy Path")]
        public void CheckHeaderResponseAccessControlAllowMethods_ReturnsGET()
        {
            Assert.That(_superheroGoodService.CallManager.HeaderResponse[3].ToString(), Is.EqualTo("access-control-allow-methods=GET"));
        }

        [Test]
        [Category("Happy Path")]
        public void CheckHeaderResponseCacheStatus_ReturnsDynamic()
        {
            Assert.That(_superheroGoodService.CallManager.HeaderResponse[9].ToString(), Is.EqualTo("CF-Cache-Status=DYNAMIC"));
        }

        [Test]
        [Category("Happy Path")]
        public void CheckHeaderResponseContentType_ReturnsCloudflare()
        {
            Assert.That(_superheroGoodService.CallManager.HeaderResponse[16].ToString(), Is.EqualTo("Content-Type=application/json"));
        }

        [Test]
        [Category("Happy Path")]
        public void CheckHeaderResponseContentEncoding_ReturnsNothing()
        {
            Assert.That(_superheroGoodService.CallManager.HeaderResponse[6].ToString(), Is.EqualTo("content-encoding="));
        }

        [Test]
        [Category("Happy Path")]
        public void CheckHeaderResponseVary_ReturnsAcceptEncoding()
        {
            Assert.That(_superheroGoodService.CallManager.HeaderResponse[7].ToString(), Is.EqualTo("vary=Accept-Encoding"));
        }

        #endregion

    }
}
