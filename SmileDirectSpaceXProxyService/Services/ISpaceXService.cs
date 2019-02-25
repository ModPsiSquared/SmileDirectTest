using SmileDirect.SpaceXProxyService.DTOs;
using System.Collections.Generic;

/// <summary>
/// Summary description for ISpaceXService
/// Serves as the base interface in a strategy pattern
/// The implementation in first draft is the original space X serviced.
/// Future implementation will be a database.
/// </summary>
/// 

namespace SmileDirect.SpaceXProxyService.Services
{
    public interface ISpaceXService
    {
        IEnumerable<LaunchPad> GetLaunchPads();
        LaunchPad GetLaunchPad(int id);
    }
}
