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

        [OneTimeSetUp]
        public async Task OneTimeSetupAsync()
        {
            _superheroGoodService = new PowerstatsService();
            _superheroBadService = new PowerstatsService();
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
            var testService = new PowerstatsService();
            Assert.That(() => testService.CallManager.Status, Is.EqualTo(0));
        }

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
    }
}
