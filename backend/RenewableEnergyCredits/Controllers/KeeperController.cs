using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RenewableEnergyCredits.Models;
using mantle.lib.Api;
using mantle.lib.Client;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace RenewableEnergyCredits.Controllers
{
    [EnableCors("SiteCorsPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class KeeperController : Controller
    {
        private const string FolderId = "5b608cc191bd41000a1f4dea";
        private const int Accuracy = 95;
        private readonly IDatabase _database;
        private readonly KeeperApi _mantleKeeper;

        public KeeperController(IDatabase database, Task<Configuration> mantleConfig)
        {
            _database = database;
            _mantleKeeper = new KeeperApi(mantleConfig.Result);
        }

        [HttpPost]
        public async Task<IActionResult> CheckGraduation([FromBody] GraduationRequest graduationRequest)
        {
            var graduation = new Graduation
            {
                PermanentCode = graduationRequest.PermanentCode,
                University = await _database.GetUniversityById(graduationRequest.University),
                Program = await _database.GetProgramById(graduationRequest.Program),
                GraduationYear = graduationRequest.GraduationYear,
                Gpa = graduationRequest.Gpa
            };

            var fileString = graduation.ToString();
            using (var ms = new MemoryStream())
            {
                var sw = new StreamWriter(ms);
                try
                {
                    sw.Write(fileString);
                    sw.Flush();
                    ms.Seek(0, SeekOrigin.Begin);

                    using (var fs = new FileStream($"{graduation.PermanentCode}.txt", FileMode.Create, FileAccess.ReadWrite))
                    {
                        ms.CopyTo(fs);
                        fs.Seek(0, SeekOrigin.Begin);

                        var keeperFiles = await _mantleKeeper.KeeperFilesGetAsync(FolderId);
                        var fileToCompare = keeperFiles.FirstOrDefault(file => file.DisplayName.Contains(graduation.PermanentCode));
                        if (fileToCompare != null)
                        {
                            var compareRate = await _mantleKeeper.KeeperFilesDiffPostAsync(fileToCompare.Id, fs);
                            return compareRate.Accuracy == 1 ? Ok(true) : Ok(false);
                        }
                    }
                }
                catch (Exception e)
                {
                }
                finally
                {
                    sw.Dispose();
                }
            }

            return NotFound();
        }
    }
}
