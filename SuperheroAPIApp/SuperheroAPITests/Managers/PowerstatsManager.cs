using SuperheroAPITests.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperheroAPITests.Managers
{
    public class PowerstatsManager
    {
        private PowerstatsService Service { get; set; }

        public PowerstatsManager()
        {
            Service = new PowerstatsService();
        }

        public async Task<int> GetMostPowerfulSuperhero(int[] idList)
        {
            if (idList.Length < 2)
            {
                return -1;
            }
            int mostPowerfulHeroID = 0;
            int highestPower = 0;
            foreach (var id in idList)
            {
                await Service.MakeRequestAsync(id);
                if (Service.CallManager.Status == 200)
                {
                    int overallPower = OverallPower();
                    if (overallPower > highestPower)
                    {
                        highestPower = overallPower;
                        mostPowerfulHeroID = id;
                    }
                }

            }
            return mostPowerfulHeroID;
        }

        public async Task<int> GetWeakestSuperhero(int[] idList)
        {
            if (idList.Length < 2)
            {
                return -1;
            }
            int weakestHeroID = 0;
            int weakestPower = int.MaxValue;
            foreach (var id in idList)
            {
                await Service.MakeRequestAsync(id);
                if (Service.CallManager.Status == 200)
                {
                    int overallPower = OverallPower();
                    if (overallPower < weakestPower)
                    {
                        weakestPower = overallPower;
                        weakestHeroID = id;
                    }
                }

            }
            return weakestHeroID;
        }

        private int OverallPower()
        {
            int overallPower = 0;
            overallPower += int.Parse(Service.PowerstatDTO.Response.combat);
            overallPower += int.Parse(Service.PowerstatDTO.Response.durability);
            overallPower += int.Parse(Service.PowerstatDTO.Response.intelligence);
            overallPower += int.Parse(Service.PowerstatDTO.Response.power);
            overallPower += int.Parse(Service.PowerstatDTO.Response.speed);
            overallPower += int.Parse(Service.PowerstatDTO.Response.strength);
            return overallPower;
        }
    }
}
