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
            await _superheroBadService.MakeRequestAsync(30_000_000);
        }
    }
}

 