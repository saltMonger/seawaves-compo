using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeawavesCompo.Models.UserModels
{
    public class UserProfileFullModel
    {
        //PROFILE PROPERTIES
        public string ID { get; set; }
        public string ProfileText { get; set; }
        public Nullable<int> VaporAmount { get; set; }
        public Nullable<int> AetherAmount { get; set; }
        public string Avatar { get; set; }
        public string UserHandle { get; set; }

        //ENTRY PROPERTIES

        //COMPETITONS PROPERTIES
    }
}