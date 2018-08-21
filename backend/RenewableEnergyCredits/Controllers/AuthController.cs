using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RenewableEnergyCredits.Models;
using mantle.lib.Api;
using mantle.lib.Client;
using mantle.lib.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RenewableEnergyCredits.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        /// <summary>
        /// Login a user and return an access token.
        /// </summary>
        /// <returns></returns>
        // [HttpPost]
        // public async Task<IActionResult> Login([FromBody] GreenEnergy greenEnergy)
        // {
        //     try
        //     {
        //         await _mantleTracker.TrackerAssetsPostAsync(new TrackerAssetCreateRequest(greenEnergy.Type));
        //         return StatusCode(StatusCodes.Status201Created);
        //     }
        //     catch (Exception e)
        //     {
        //         return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        //     }
        // }
    }
}