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
    public class TrackerController : Controller
    {
        private const string FolderId = "5b608cc191bd41000a1f4dea";
        private const int Accuracy = 95;
        private readonly IDatabase _database;
        private readonly TrackerApi _mantleTracker;
        private readonly string _email;

        public TrackerController(IDatabase database, Task<Configuration> mantleConfig)
        {
            _database = database;
            _mantleTracker = new TrackerApi(mantleConfig.Result);
            var test = mantleConfig.Result;
        }
        
        /// <summary>
        /// Creates an asset in Tracker. This asset will then be issuable and transferable between entities. Requires the Tracker Admin Role.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GreenCredit greenCredit)
//        public StatusCodeResult Create([FromBody] GreenCredit greenCredit)
        {
//            var asset = await _mediator.Send(new CreateAssetCommand(token.ClientId, request.Name));
//            _mantleTracker.
//            var hypervisorRequest = new FactoryCreatePostRequest(request.Name);
//            var asset = await _hypervisorRestClient.SendRequestAsync<AssetIdentity>("/factory/assets", HttpMethod.Post, new RestRequestConfig { Body = hypervisorRequest });
            var asset = await _mantleTracker.TrackerAssetsPostAsync(new TrackerAssetCreateRequest(greenCredit.Type));

            var issuedAsset = await _mantleTracker.TrackerAssetsIssuePostAsync(
                new TrackerAssetIssueRequest(asset.Id, "y.thibodeau1@gmail.com", greenCredit.Amount));
            
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Get all of the assets that have been created in Tracker. Requires the Tracker Admin Role.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("assets")]
//        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAssets()
        {
//            var assets = await _mediator.Send(new GetAssetsQuery(token.ClientId));
//            Console.WriteLine(greenCredit);
            Console.WriteLine(_email);
            var assets = await _mantleTracker.TrackerAssetsGetAsync();
            return Ok(assets);
            //            return StatusCode(StatusCodes.Status200OK);
        }
        
        /// <summary>
        /// Get all of the assets that have been created in Tracker. Requires the Tracker Admin Role.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("transactions")]
//        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTransactions()
        {
//            var assets = await _mediator.Send(new GetAssetsQuery(token.ClientId));
//            Console.WriteLine(greenCredit);
            var transactions = await _mantleTracker.TrackerTransactionsSelfGetAsync();
            return Ok(transactions);
            //            return StatusCode(StatusCodes.Status200OK);
        }        
    }
}
