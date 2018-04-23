using Ganss.XSS;
using SeawavesCompo.DataAccess;
using SeawavesCompo.Logger;
using SeawavesCompo.Models.CompetitionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SeawavesCompo.Controllers
{
    [Authorize]
    public class CompetitionApiController : BaseApiController
    {
        [HttpPost]
        public async Task<ApiServiceResponse<ClientCompetitionModel>> CreateNewCompetition(ClientCompetitionUpdateModel updateModel)
        {
            var sanitizer = new HtmlSanitizer();
            //create the competition object
            var competition = new Competition()
            {
                Id = Guid.NewGuid().ToString(),
                CurrentPhase = (int)CompetitionPhase.NOTRELEASED,
                CompoLength = updateModel.CompoLength,
                CompoStartDate = updateModel.CompoStartDate,
                HostUserID = updateModel.HostUserID,
                VoteLength = updateModel.CompoStartDate,
                Created = DateTime.Now,
                Modified = DateTime.Now,
                Title = sanitizer.Sanitize(updateModel.Title),
                CompoType = (int)updateModel.CompetitionType
            };

            try
            {
                db.Competitions.Add(competition);
                db.SaveChanges();

                //schedule competition in QuartzNet here

                //schedule competition in QuartzNet here
            }
            catch(Exception ex)
            {
                MasterLogger.LogIssue(ex.Message, this.GetType().Name, DateTime.Now, LogSeverity.EXCPETION);
                return new ApiServiceResponse<ClientCompetitionModel>
                {
                    ResponseCode = ApiServiceResponseCode.FAILURE,
                    ResponseObject = null,
                    Message = ex.Message
                };
            }

            return new ApiServiceResponse<ClientCompetitionModel>
            {
                ResponseCode = ApiServiceResponseCode.FAILURE,
                ResponseObject = CreateCompetitionClientModel(competition),
                Message = null
            };
        }

        private ClientCompetitionModel CreateCompetitionClientModel(Competition comp)
        {
            return new ClientCompetitionModel
            {
                Id = comp.Id,
                HostUserID = comp.Id, //update this to include the entire user model
                CompetitionType = ((CompetitionTypes)comp.CompoType).ToString(),
                CompoLength = comp.CompoLength,
                CompoStartDate = comp.CompoStartDate,
                VoteLength = comp.VoteLength,
                Title = comp.Title,
                Created = comp.Created,
                Modified = comp.Modified,
                CurrentPhase = ((CompetitionPhase)comp.CurrentPhase).ToString()
            };
        }
    }
}
