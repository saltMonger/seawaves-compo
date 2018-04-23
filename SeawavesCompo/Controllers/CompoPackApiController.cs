using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Ganss.XSS;
using SeawavesCompo.DataAccess;
using SeawavesCompo.Logger;
using SeawavesCompo.Models.CompoPackModels;

namespace SeawavesCompo.Controllers
{
    public class CompoPackApiController : BaseApiController
    {

        [HttpPost]
        public async Task<ApiServiceResponse<CompoPackClientUpdateModel>> CreateCompoPack(CompoPackClientUpdateModel cpcm)
        {
            //prevent XSS attacks
            var sanitizer = new HtmlSanitizer();
            //create a new compo pack
            var cpck = new CompoPack()
            {
                Id = Guid.NewGuid().ToString(),
                CompetitionID = cpcm.CompetitionId,
                CompoPackLink = sanitizer.Sanitize(cpcm.CompoPackLink),
                Instructions = sanitizer.Sanitize(cpcm.Instructions),
                isReleased = false,
                Created = DateTime.Now,
                Modified = DateTime.Now
            };

            try
            {
                db.CompoPacks.Add(cpck);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                MasterLogger.LogIssue(ex.Message, this.GetType().Name, DateTime.Now, LogSeverity.EXCPETION);
                return new ApiServiceResponse<CompoPackClientUpdateModel>
                {
                    ResponseCode = ApiServiceResponseCode.FAILURE,
                    Message = ex.Message,
                    ResponseObject = null
                };
            }

            return new ApiServiceResponse<CompoPackClientUpdateModel>
            {
                ResponseCode = ApiServiceResponseCode.SUCCESS,
                Message = null,
                ResponseObject = cpcm
            };
        }
    }
}
