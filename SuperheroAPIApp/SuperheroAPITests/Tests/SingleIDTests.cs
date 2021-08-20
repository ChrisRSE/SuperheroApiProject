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
            await _superheroGoodService.MakeRequestAsync(69);
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
            Assert.That(_superheroGoodService.Json_response["name"].ToString(), Is.EqualTo("Batman"));
        }


        [Test]
        [Category("Happy Path")]
        public void Returns9Catergories_WhenValidIDIsGiven()
        {
            Assert.That(_superheroGoodService.Json_response.Count, Is.EqualTo(9));
        }

        [Test]
        [Category("Happy Path")]
        public void ReturnsCorrectImage_WhenValidI()
        {
            Assert.That(_superheroGoodService.Json_response["image"]["url"].ToString(), Is.EqualTo(@"https://www.superherodb.com/pictures2/portraits/10/100/10441.jpg"));
        }
    }
}

