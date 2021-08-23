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

        [OneTimeSetUp]
        public async Task OneTimeSetUpASync()
        {
            _superheroGoodService = new SingleIDService();
            _superheroBadService = new SingleIDService();
            await _superheroGoodService.MakeRequestAsync(70);
            await _superheroBadService.MakeRequestAsync(300_000_000);
        }

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
    }
}

