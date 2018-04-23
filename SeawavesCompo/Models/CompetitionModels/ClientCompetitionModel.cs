using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeawavesCompo.Models.CompetitionModels
{
    public enum CompetitionPhase
    {
        NOTRELEASED = 0,
        ACTIVE = 1,
        VOTE = 2,
        ENDED = 3
    }

    public class ClientCompetitionModel
    {
        public string Id { get; set; }
        public System.DateTime CompoLength { get; set; }
        public System.DateTime VoteLength { get; set; }
        public System.DateTime CompoStartDate { get; set; }
        public string CurrentPhase { get; set; }
        public string HostUserID { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string CompetitionType { get; set; }
    }
}