﻿using System;
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
        private readonly TrackerApi _mantleTrackerProducer;
        private readonly TrackerApi _mantleTrackerClient;
        private readonly string _email;

        public TrackerController(IDatabase database, Task<Configuration> mantleConfigProducer, Task<Configuration> mantleConfigClient)
        {
            _database = database;
            _mantleTrackerProducer = new TrackerApi(mantleConfigProducer.Result);
            _mantleTrackerClient = new TrackerApi(mantleConfigClient.Result);
        }
        
        /// <summary>
        /// Creates an asset in Tracker. This asset will then be issuable and transferable between entities. Requires the Tracker Admin Role.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GreenEnergy greenEnergy)
//        public StatusCodeResult Create([FromBody] GreenCredit greenCredit)
        {
//            var asset = await _mediator.Send(new CreateAssetCommand(token.ClientId, request.Name));
//            _mantleTrackerProducer.
//            var hypervisorRequest = new FactoryCreatePostRequest(request.Name);
//            var asset = await _hypervisorRestClient.SendRequestAsync<AssetIdentity>("/factory/assets", HttpMethod.Post, new RestRequestConfig { Body = hypervisorRequest });
            try
            {
                await _mantleTrackerProducer.TrackerAssetsPostAsync(new TrackerAssetCreateRequest(greenEnergy.Type));
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            

//            await _mantleTrackerProducer.TrackerAssetsIssuePostAsync(new TrackerAssetIssueRequest(asset.Id, "y.thibodeau1@gmail.com", greenCredit.Amount));
//            await _mantleTrackerProducer.TrackerAssetsIssuePostAsync(new TrackerAssetIssueRequest("ba0fa87f-fca1-44ad-a4ff-fe4bfeb1c0c6", "y.thibodeau1@gmail.com", greenCredit.Amount));
//                new TrackerAssetIssueRequest(asset.Id, "y.thibodeau1@gmail.com", greenCredit.Amount));
     
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
            var assets = await _mantleTrackerProducer.TrackerAssetsGetAsync();
            return Ok(assets);
            //            return StatusCode(StatusCodes.Status200OK);
        }
        /// <summary>
        /// Get all issue batch for an asset by id.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("assets/issuedbatches/{assetId}")]
//        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAssetDetails(string assetId)
        {
//            var assets = await _mediator.Send(new GetAssetsQuery(token.ClientId));
//            Console.WriteLine(greenCredit);
            var issueBatch = await _mantleTrackerProducer.TrackerAssetsIssuedbatchesByAssetIdGetAsync(assetId);
            return Ok(issueBatch);
            //            return StatusCode(StatusCodes.Status200OK);
        }
        
        /// <summary>
        /// Issue a certain amount of asset to a recipient.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("assets/issue")]
//        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> AssetIssueAmount([FromBody] AssetIssueRequest asr)
        {
//            var assets = await _mediator.Send(new GetAssetsQuery(token.ClientId));
//            Console.WriteLine(greenCredit);
            
            try
            {
                await _mantleTrackerProducer.TrackerAssetsIssuePostAsync(
                    new TrackerAssetIssueRequest(asr.AssetId,asr.RecipientEmail,asr.Amount));
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
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
//            var transactions = await _mantleTrackerProducer.TrackerTransactionsSelfGetAsync();
            var transactions = await _mantleTrackerProducer.TrackerTransactionsSelfGetAsync();
            return Ok(transactions);
            //            return StatusCode(StatusCodes.Status200OK);
        }
        /// <summary>
        /// Get all of the assets that have been created in Tracker. Requires the Tracker Admin Role.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("balances")]
        public async Task<IActionResult> GetBalances()
        {
            var balances = await _mantleTrackerClient.TrackerWalletDetailedbalancesGetAsync();
            return Ok(balances);
            //            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
