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
