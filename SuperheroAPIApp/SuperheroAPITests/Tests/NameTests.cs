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
          NameService  _nameService;

        public async Task OneTimeSetupAsync()
        {
            _nameService = new NameService();
            await _nameService.MakeRequestAsync("Batman");
        }

        [Test]
        public void StatusIs200()
        {
            Assert.That(_nameService.CallManager.Status, Is.EqualTo(200));
        }

    }
}
