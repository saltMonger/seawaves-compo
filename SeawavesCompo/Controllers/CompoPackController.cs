using SeawavesCompo.DataAccess;
using SeawavesCompo.Logger;
using SeawavesCompo.Models.CompoPackModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SeawavesCompo.Controllers
{
    public class CompoPackController : BaseApiController
    {
        [HttpPost]
        public async Task<ApiServiceResponse<CompoPackClientUpdateModel>> CreateCompoPack(CompoPackClientUpdateModel cpcm)
        {
            //generate a new compopack on the database
            var newcompo = new CompoPack()
            {
                Id = Guid.NewGuid().ToString(),
                CompetitionID = cpcm.CompetitionId,
                CompoPackLink = cpcm.CompoPackLink,
                Instructions = cpcm.Instructions,
                isReleased = cpcm.isReleased
            };

            try
            {
                db.CompoPacks.Add(newcompo);
            }
            catch(Exception ex)
            {
                MasterLogger.LogIssue(ex.Message, typeof(CompoPackController).Name, DateTime.Now, LogSeverity.EXCPETION);
                return new ApiServiceResponse<CompoPackClientUpdateModel>
                {
                    ResponseCode = ApiServiceResponseCode.FAILURE,
                    ResponseObject = null,
                    Message = ex.Message,
                };
            }

            return new ApiServiceResponse<CompoPackClientUpdateModel>
            {
                ResponseCode = ApiServiceResponseCode.SUCCESS,
                ResponseObject = null,
                Message = ""
            };
        }
    }
}
