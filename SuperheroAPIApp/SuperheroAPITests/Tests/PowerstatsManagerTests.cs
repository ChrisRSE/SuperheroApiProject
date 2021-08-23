using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SuperheroAPITests.Managers;

namespace SuperheroAPITests.Tests
{
    class PowerstatsManagerTests
    {
        enum Superheroes
        { 
            CaptainAmerica = 149, Hulk = 332, Ironman = 732, Thor = 659, BlackWidow = 109, Hawkeye = 313, Superman = 644
        }

        PowerstatsManager _manager;
        int[] _superheroes;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _manager = new PowerstatsManager();
            _superheroes = new int[]
            {
                ((int)Superheroes.CaptainAmerica),
                ((int)Superheroes.Hulk),
                ((int)Superheroes.Ironman),
                ((int)Superheroes.Thor),
                ((int)Superheroes.BlackWidow),
                ((int)Superheroes.Hawkeye),
                ((int)Superheroes.Superman),
            };
        }
        [Test]
        public void CorrectlyReturnsMostPowerfulSuperhero_FromSuperheroList()
        {
            Assert.That(_manager.GetMostPowerfulSuperhero(_superheroes).Result, Is.EqualTo((int)Superheroes.Superman));
        }

        [Test]
        public void MostPowerfulSuperhero_ReturnsMinus1_WhenArrayLengthIsLessThan2()
        {
            Assert.That(_manager.GetMostPowerfulSuperhero(new int[0]).Result, Is.EqualTo(-1));
        }

        [Test]
        public void CorrectlyReturnsWeakestSuperhero_FromSuperheroList()
        {
            Assert.That(_manager.GetWeakestSuperhero(_superheroes).Result, Is.EqualTo((int)Superheroes.Hawkeye));
        }

        [Test]
        public void WeakestSuperhero_ReturnsMinus1_WhenArrayLengthIsLessThan2()
        {
            Assert.That(_manager.GetWeakestSuperhero(new int[0]).Result, Is.EqualTo(-1));
        }
    }
}
