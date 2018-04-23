using SeawavesCompo.DataAccess;
using SeawavesCompo.Logger;
using SeawavesCompo.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SeawavesCompo.Controllers
{
    [Authorize]
    public class UserApiController : BaseApiController
    {
        private async Task<ApiServiceResponse<User>> GetUserById(string id)
        {
            User user = db.Users.Find(id);
            if (user != null)
            {
                return new ApiServiceResponse<User>
                {
                    ResponseCode = ApiServiceResponseCode.SUCCESS,
                    ResponseObject = user,
                    Message = null
                };
            }
            else
            {
                string message = "Failed to retrieve user with id:" + id;
                MasterLogger.LogIssue(message, typeof(UserApiController).Name, DateTime.Now, LogSeverity.ISSUE);

                return new ApiServiceResponse<User>
                {
                    ResponseCode = ApiServiceResponseCode.SUCCESS,
                    ResponseObject = null,
                    Message = message
                };
            }
        }

        [HttpGet]
        public async Task TestEndpoint()
        {
            Console.WriteLine("SHIT HAPPENED");
            return;
        }

        [System.Web.Http.HttpPost]
        public async Task<ApiServiceResponse<UserProfileFullModel>> UpdateUserInformation([FromBody]UserUpdatePartialModel user)
        {
            //TODO: HARDEN NON-PROFILETEXT
            var userClaimId = (await manager.FindByNameAsync(User.Identity.Name)).Id;
            var attemptingUser = db.Users.FirstOrDefault(u => u.UserID.Equals(userClaimId));
            if(attemptingUser.Id != user.ID && !(await manager.IsInRoleAsync(userClaimId,"ADMIN")))
            {
                //this user is attempting to edit another user, and is not an authorized administrator
                //log the occurence
                MasterLogger.LogIssue("Illegal user profile update.  Attempter: " + attemptingUser.Id + "/" + attemptingUser.UserHandle +
                    " Profile Attempted: " + user.ID, typeof(UserApiController).Name, DateTime.Now, LogSeverity.SECURITYWARNING);
                //fail silently
                return new ApiServiceResponse<UserProfileFullModel>
                {
                    ResponseCode = ApiServiceResponseCode.FAILURE,
                    ResponseObject = null,
                    Message = "ILLEGAL ACTION DETECTED"
                };
            }
            //update user
            var oldUser = db.Users.Find(user.ID);
            if(oldUser == null)
            {
                string message = "Failed to retrieve user with id:" + oldUser.Id;
                MasterLogger.LogIssue(message, typeof(UserApiController).Name, DateTime.Now, LogSeverity.ISSUE);

                return new ApiServiceResponse<UserProfileFullModel>
                {
                    ResponseCode = ApiServiceResponseCode.FAILURE,
                    ResponseObject = null,
                    Message = message
                };
            }
            //update user values
            oldUser.ProfileText = user.ProfileText;
            oldUser.UserHandle = user.UserHandle;
            db.SaveChanges();

            var usermodel = new UserProfileFullModel
            {
                ID = oldUser.Id,
                ProfileText = oldUser.ProfileText,
                VaporAmount = oldUser.VaporAmount,
                AetherAmount = oldUser.AetherAmount,
                UserHandle = oldUser.UserHandle,
                Avatar = oldUser.Avatar
            };

            return new ApiServiceResponse<UserProfileFullModel>
            {
                ResponseCode = ApiServiceResponseCode.SUCCESS,
                ResponseObject = usermodel,
                Message = null
            };
        }
    }
}
