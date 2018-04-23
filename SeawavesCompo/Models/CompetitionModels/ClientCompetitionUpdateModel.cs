using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeawavesCompo.Models.CompetitionModels
{
    public enum CompetitionTypes
    {
        MUSIC = 1,
        GRAPHICS = 2,
        GAMEJAM = 3
    }

    public class ClientCompetitionUpdateModel
    {
        //Competition Model
        public string CompetitionID { get; set; }
        public System.DateTime CompoLength { get; set; }
        public System.DateTime VoteLength { get; set; }
        public System.DateTime CompoStartDate { get; set; }
        public CompetitionPhase CurrentPhase { get; set; }
        public string HostUserID { get; set; }
        public string Title { get; set; }
        public CompetitionTypes CompetitionType { get; set; }

    }
}