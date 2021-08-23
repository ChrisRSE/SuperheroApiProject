using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SuperheroAPITests.Services;

namespace SuperheroAPITests.Tests
{
    public class SingleIDTests
    {
        SingleIDService _superheroGoodService;
        SingleIDService _superheroBadService;

        #region 0. Set Up

        [OneTimeSetUp]
        public async Task OneTimeSetUpASync()
        {
            _superheroGoodService = new SingleIDService();
            _superheroBadService = new SingleIDService();
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

        #endregion

        #region 2. Verify response payload

        [Test]
        [Category("Sad Path")]
        public void StatusIsDefault0_WhenNoValueIsPassed()
        {
            var testService = new SingleIDService();
            Assert.That(() => testService.CallManager.Status, Is.EqualTo(0));
        }

        [Test]
        [Category("Happy Path")]
        public void ReturnsCorrectSuperhero_WhenValidIDIsGiven()
        {
            Assert.That(_superheroGoodService.SingleIdDTO.Response.name, Is.EqualTo("Batman"));
        }


        [Test]
        [Category("Happy Path")]
        public void Returns9Catergories_WhenValidIDIsGiven()
        {
            Assert.That(_superheroGoodService.Json_response.Count, Is.EqualTo(9));
        }

        [Test]
        [Category("Happy Path")]
        public void ReturnsCorrectImage_WhenValidIdIsGiven()
        {
            Assert.That(_superheroGoodService.SingleIdDTO.Response.image.url, Is.EqualTo(@"https://www.superherodb.com/pictures2/portraits/10/100/639.jpg"));
        }


        [Test]
        [Category("Happy Path")]
        public void ReturnsCorrectAppearanceDetails_WhenValidIdIsGiven()
        {
            Assert.That(_superheroGoodService.SingleIdDTO.Response.appearance.gender, Is.EqualTo("Male"));
            Assert.That(_superheroGoodService.SingleIdDTO.Response.appearance.race, Is.EqualTo("Human"));
            Assert.That(_superheroGoodService.SingleIdDTO.Response.appearance.height[1], Is.EqualTo("188 cm"));
            Assert.That(_superheroGoodService.SingleIdDTO.Response.appearance.weight[1], Is.EqualTo("95 kg"));
            Assert.That(_superheroGoodService.SingleIdDTO.Response.appearance.eyecolor, Is.EqualTo("blue"));
            Assert.That(_superheroGoodService.SingleIdDTO.Response.appearance.haircolor, Is.EqualTo("black"));
        }

        [Test]
        [Category("Happy Path")]
        public void ReturnsCorrectPowerstatsDetails_WhenValidIdIsGiven()
        {
            Assert.That(_superheroGoodService.SingleIdDTO.Response.powerstats.intelligence, Is.EqualTo("100"));
            Assert.That(_superheroGoodService.SingleIdDTO.Response.powerstats.strength, Is.EqualTo("26"));
            Assert.That(_superheroGoodService.SingleIdDTO.Response.powerstats.speed, Is.EqualTo("27"));
            Assert.That(_superheroGoodService.SingleIdDTO.Response.powerstats.durability, Is.EqualTo("50"));
            Assert.That(_superheroGoodService.SingleIdDTO.Response.powerstats.power, Is.EqualTo("47"));
            Assert.That(_superheroGoodService.SingleIdDTO.Response.powerstats.combat, Is.EqualTo("100"));
        }

        [Test]
        [Category("Happy Path")]
        public void ReturnsCorrectBiographyDetails_WhenValidIdIsGiven()
        {
            Assert.That(_superheroGoodService.SingleIdDTO.Response.biography.fullname, Is.EqualTo("Bruce Wayne"));
            Assert.That(_superheroGoodService.SingleIdDTO.Response.biography.alteregos, Is.EqualTo("No alter egos found."));
            Assert.That(_superheroGoodService.SingleIdDTO.Response.biography.aliases[0], Is.EqualTo("Insider"));
            Assert.That(_superheroGoodService.SingleIdDTO.Response.biography.placeofbirth, Is.EqualTo("Crest Hill, Bristol Township; Gotham County"));
            Assert.That(_superheroGoodService.SingleIdDTO.Response.biography.firstappearance, Is.EqualTo("Detective Comics #27"));
            Assert.That(_superheroGoodService.SingleIdDTO.Response.biography.publisher, Is.EqualTo("DC Comics"));
            Assert.That(_superheroGoodService.SingleIdDTO.Response.biography.alignment, Is.EqualTo("good"));
        }

        [Test]
        [Category("Happy Path")]
        public void ReturnsCorrectWorkDetails_WhenValidIdIsGiven()
        {
            Assert.That(_superheroGoodService.SingleIdDTO.Response.work.occupation, Is.EqualTo("Businessman"));
            Assert.That(_superheroGoodService.SingleIdDTO.Response.work._base, Is.EqualTo("Batcave, Stately Wayne Manor, Gotham City; Hall of Justice, Justice League Watchtower"));
        }

        [Test]
        [Category("Happy Path")]
        public void ReturnsCorrectConnectionsDetails_WhenValidIdIsGiven()
        {
            Assert.That(_superheroGoodService.SingleIdDTO.Response.connections.groupaffiliation, Is.EqualTo("Batman Family, Batman Incorporated, Justice League, Outsiders, Wayne Enterprises, Club of Heroes, formerly White Lantern Corps, Sinestro Corps"));
            Assert.That(_superheroGoodService.SingleIdDTO.Response.connections.relatives.Contains("Martha Wayne"));
        }

        [Test]
        [Category("Happy Path")]
        public void TestJsonResponseHeaders_ContainCorrectHeaderNames()
        {
            Assert.That(_superheroGoodService.Json_response.ContainsKey("response"));
            Assert.That(_superheroGoodService.Json_response.ContainsKey("id"));
            Assert.That(_superheroGoodService.Json_response.ContainsKey("name"));
            Assert.That(_superheroGoodService.Json_response.ContainsKey("powerstats"));
            Assert.That(_superheroGoodService.Json_response.ContainsKey("biography"));
            Assert.That(_superheroGoodService.Json_response.ContainsKey("appearance"));
            Assert.That(_superheroGoodService.Json_response.ContainsKey("work"));
            Assert.That(_superheroGoodService.Json_response.ContainsKey("connections"));
            Assert.That(_superheroGoodService.Json_response.ContainsKey("image"));
        }

        [Test]
        [Category("Happy Path")]
        public void TestIDResponsePowerstats_ContainCorrectSubheaderNames()
        {
            Assert.That(_superheroGoodService.IdResponse.Contains("intelligence"));
            Assert.That(_superheroGoodService.IdResponse.Contains("strength"));
            Assert.That(_superheroGoodService.IdResponse.Contains("speed"));
            Assert.That(_superheroGoodService.IdResponse.Contains("durability"));
            Assert.That(_superheroGoodService.IdResponse.Contains("power"));
            Assert.That(_superheroGoodService.IdResponse.Contains("combat"));
        }

        [Test]
        [Category("Happy Path")]
        public void TestIDResponseBiography_ContainCorrectSubheaderNames()
        {
            Assert.That(_superheroGoodService.IdResponse.Contains("full-name"));
            Assert.That(_superheroGoodService.IdResponse.Contains("alter-egos"));
            Assert.That(_superheroGoodService.IdResponse.Contains("aliases"));
            Assert.That(_superheroGoodService.IdResponse.Contains("place-of-birth"));
            Assert.That(_superheroGoodService.IdResponse.Contains("first-appearance"));
            Assert.That(_superheroGoodService.IdResponse.Contains("publisher"));
            Assert.That(_superheroGoodService.IdResponse.Contains("alignment"));
        }

        [Test]
        [Category("Happy Path")]
        public void TestIDResponseAppearance_ContainCorrectSubheaderNames()
        {
            Assert.That(_superheroGoodService.IdResponse.Contains("gender"));
            Assert.That(_superheroGoodService.IdResponse.Contains("race"));
            Assert.That(_superheroGoodService.IdResponse.Contains("height"));
            Assert.That(_superheroGoodService.IdResponse.Contains("weight"));
            Assert.That(_superheroGoodService.IdResponse.Contains("eye-color"));
            Assert.That(_superheroGoodService.IdResponse.Contains("hair-color"));
        }


        [Test]
        [Category("Happy Path")]
        public void TestIDResponseWork_ContainCorrectSubheaderNames()
        {
            Assert.That(_superheroGoodService.IdResponse.Contains("occupation"));
            Assert.That(_superheroGoodService.IdResponse.Contains("base"));
        }

        [Test]
        [Category("Happy Path")]
        public void TestIDResponseConnections_ContainCorrectSubheaderNames()
        {
            Assert.That(_superheroGoodService.IdResponse.Contains("group-affiliation"));
            Assert.That(_superheroGoodService.IdResponse.Contains("relatives"));
        }

        #endregion

        #region 3. Verify response headers
        [Test]
        [Category("Happy Path")]
        public void CheckHeaderResponse_ReturnsCorrectAmountOfHeaders()
        {
            Assert.That(_superheroGoodService.CallManager.HeaderResponse.Count(), Is.EqualTo(20));
            Assert.That(_superheroGoodService.CallManager.HeaderResponse[0].ToString(), Is.EqualTo("Connection=keep-alive"));
        }

        [Test]
        [Category("Happy Path")]
        public void CheckHeaderResponseConection_ReturnsCorrectValue()
        {
            Assert.That(_superheroGoodService.CallManager.HeaderResponse[0].ToString(), Is.EqualTo("Connection=keep-alive"));
        }


        [Test]
        [Category("Happy Path")]
        public void CheckHeaderResponseContentEncoding_ReturnsCorrectValue()
        {
            Assert.That(_superheroGoodService.CallManager.HeaderResponse[6].ToString(), Is.EqualTo("content-encoding="));
        }

        [Test]
        [Category("Happy Path")]
        public void CheckHeaderResponseVary_ReturnsCorrectValue()
        {
            Assert.That(_superheroGoodService.CallManager.HeaderResponse[7].ToString(), Is.EqualTo("vary=Accept-Encoding"));
        }

        #endregion
    }
}

