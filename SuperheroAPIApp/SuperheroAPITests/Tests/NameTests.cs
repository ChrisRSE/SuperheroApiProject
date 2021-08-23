using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SuperheroAPITests.Services;

namespace SuperheroAPITests.Tests
{
    public class NameTests
    {
        NameService  _nameGoodService;
        NameService _nameBadService;
        [OneTimeSetUp]
        public async Task OneTimeSetupAsync()
        {
            _nameGoodService = new NameService();
            await _nameGoodService.MakeRequestAsync("Batman");
            _nameBadService = new NameService();
            await _nameBadService.MakeRequestAsync("-0fgh");
        }

        [Test]
        [Category ("Happy Path")]
        public void StatusIs200WhenValidSuperheroNameIsUsed()
        {
            Assert.That(_nameGoodService.CallManager.Status, Is.EqualTo(200));
        }


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
            Assert.That(_nameGoodService.Json_Response["results"][0]["id"].ToString(), Is.EqualTo("69"));
            Assert.That(_nameGoodService.Json_Response["results"][1]["id"].ToString(), Is.EqualTo("70"));
            Assert.That(_nameGoodService.Json_Response["results"][2]["id"].ToString(), Is.EqualTo("71"));
        }

        [Test]
        [Category("Happy Path")]
        public void WhenValidSuperheroNameIsUsed_Correct_DetailsProvided()
        {
            Assert.That(_nameGoodService.Json_Response["results"][1]["powerstats"]["intelligence"].ToString(), Is.EqualTo("100"));
            Assert.That(_nameGoodService.Json_Response["results"][1]["powerstats"]["durability"].ToString(), Is.EqualTo("50"));
            Assert.That(_nameGoodService.Json_Response["results"][1]["biography"]["full-name"].ToString(), Is.EqualTo("Bruce Wayne"));
            Assert.That(_nameGoodService.Json_Response["results"][2]["biography"]["full-name"].ToString(), Is.EqualTo("Dick Grayson"));
            Assert.That(_nameGoodService.Json_Response["results"][2]["powerstats"]["intelligence"].ToString(), Is.EqualTo("88"));
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


    }
}
