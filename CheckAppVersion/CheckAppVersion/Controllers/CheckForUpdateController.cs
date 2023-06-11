using CheckAppVersion.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckAppVersion.Controllers
{
    
    public class CheckForUpdateController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public CheckForUpdateController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("api/updateinfo")]
        public IActionResult CheckForUpdate(string appName, string platform, string version)
        {
            if (string.IsNullOrEmpty(appName) || string.IsNullOrEmpty(platform) || string.IsNullOrEmpty(version))
            {
                return BadRequest("Invalid input parameters.");
            }

            var appVersion = _dbContext.Versions
            .FirstOrDefault(v => v.AppName == appName && v.PlatForm == platform);

            if (appVersion == null)
            {
                return NotFound(); // App version not found for the given app name and platform
            }

            if (IsVersionGreaterThan(version, appVersion.Ver))
            {
                return Ok("Update available"); // Send result for update
            }

            return Ok("No update available");                               
        }
        private bool IsVersionGreaterThan(string version1, string version2)
        {
            // Implement your version comparison logic here
            // For example, you can split the version strings by dot and compare each component numerically

            // Example implementation:
            var version1Components = version1.Split('.').Select(int.Parse).ToList();
            var version2Components = version2.Split('.').Select(int.Parse).ToList();

            for (int i = 0; i < Math.Min(version1Components.Count, version2Components.Count); i++)
            {
                if (version1Components[i] > version2Components[i])
                {
                    return true;
                }
                else if (version1Components[i] < version2Components[i])
                {
                    return false;
                }
            }

            return version1Components.Count > version2Components.Count;
        }
    }
}
