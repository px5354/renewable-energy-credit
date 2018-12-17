using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RenewableEnergyCredits.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace RenewableEnergyCredits.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EnergyCreditsController : Controller
    {
        private readonly RestClient _restClient;

        public EnergyCreditsController()
        {
            var client = new RestClient
            {
                BaseUrl = new Uri("https://develop.api.mantleblockchain.com")
            };
            client.AddDefaultHeader("Content-type", "application/json; charset=utf-8");
            client.AddDefaultHeader("x-api-key", "2weTDCXLAJyLF90oTiaL1iDIYghuNhe1XBZrQBAB2oI=");
            _restClient = client;
        }
        
        /// <summary>
        /// Creates a renewable energy credit in Tracker. This credit will then be issuable and transferable.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EnergyCredit([FromBody] GreenEnergy greenEnergy)
        {
//            try
//            {
//                await _mantleTracker.TrackerAssetsPostAsync(new TrackerAssetCreateRequest(greenEnergy.Type));
//                return StatusCode(StatusCodes.Status201Created);
//            }
//            catch (Exception e)
//            {
//                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
//            }
            return Ok();
        }

        /// <summary>
        /// Get all of the energy credits that have been created.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
//            var assets = await _restClient.TrackerAssetsGetAsync();
            
            var request = new RestRequest("apikeys/all", Method.GET);

            var response = _restClient.Execute(request);

            return Ok();
        }
        
        /// <summary>
        /// Get all of the energy credits that have been created.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
//            var assets = await _restClient.TrackerAssetsGetAsync();
            
            var request = new RestRequest("apikeys/all", Method.GET);

            var response = await _restClient.ExecuteGetTaskAsync(request);

            return Ok(response.Content);
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

//            var issueBatch = await _mantleTracker.TrackerAssetsIssuedbatchesByAssetIdGetAsync(assetId);
//            return Ok(issueBatch);
            //            return StatusCode(StatusCodes.Status200OK);
            return Ok();
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
            
//            try
//            {
//                await _mantleTracker.TrackerAssetsIssuePostAsync(
//                    new TrackerAssetIssueRequest(asr.AssetId,asr.RecipientEmail,asr.Amount));
//                return StatusCode(StatusCodes.Status204NoContent);
//            }
//            catch (Exception e)
//            {
//                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
//            }
            return Ok();
        }
        /// <summary>
        /// Get all of the assets that have been created in Tracker. Requires the Tracker Admin Role.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("balances")]
        public async Task<IActionResult> GetBalances()
        {
//            var balances = await _mantleTracker.TrackerWalletDetailedbalancesGetAsync();
//            return Ok(balances);
            return Ok();
        }
        
        /// <summary>
        /// Get all of the transactions that have been created in Tracker. Requires the Tracker Admin Role.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("transactions")]
        public async Task<IActionResult> GetTransactions()
        {        
//            var transactions = await _mantleTracker.TrackerTransactionsGetAsync();
//            return Ok(transactions);
            return Ok();
        }        
        
        /// <summary>
        /// Transfer a certain amount of your asset to a recipient.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("wallet/transfer")]
//        [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> TransferAssetAmount([FromBody] TransferRequest tr)
        {
//            var config = new Configuration
//            {
//                BasePath = "https://dev.api.mantle.services"
//            };
//            var auth = new AuthenticationApi(config);
//            var userResponse =
//                await auth.AuthenticationLoginPostAsync(new UserLoginRequest(
//                    tr.SenderEmail, "Test1234"));
//            config.AddDefaultHeader("Authorization", userResponse.AccessToken);
//            var localTracker = new TrackerApi(config);
//            
//            try
//            {
//                await localTracker.TrackerWalletTransferPostAsync(
//                    new TrackerTransferRequest(tr.RecipientEmail, tr.Amount, tr.AssetId));
//                return StatusCode(StatusCodes.Status201Created);
//            }
//            catch (Exception e)
//            {
//                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
//            }
            return Ok();
        }
    }
}
