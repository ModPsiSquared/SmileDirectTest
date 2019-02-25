using SmileDirect.SpaceXProxyService.DTOs;
using SmileDirect.SpaceXProxyService.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmileDirect.SpaceXProxyServiceTest
{
    public class SpaceXServiceFake : ISpaceXService
    {
        List<LaunchPad> _launchPads;

        public SpaceXServiceFake()
        {
            _launchPads = new List<LaunchPad>
            {
                new LaunchPad() {Id = "1", Name = "Babylon 5", Status="Blowed-up"},
                new LaunchPad() {Id = "12", Name = "Millenium Falcon", Status="On-Kessel-Run"},
                new LaunchPad() {Id = "1701", Name = "Enterprise", Status="Searching-for-Spock"}
            };
        }

        public IEnumerable<LaunchPad> GetLaunchPads()
        {
            return _launchPads;
        }

        public LaunchPad GetLaunchPad(int id)
        {
            return _launchPads.FirstOrDefault(lp => lp.Id == id.ToString());
        }
    }
}


