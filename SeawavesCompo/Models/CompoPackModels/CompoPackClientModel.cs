using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeawavesCompo.Models.CompoPackModels
{
    public class CompoPackClientUpdateModel
    {
        public string CompetitionId { get; set; }
        public string Instructions { get; set; }
        public string CompoPackLink { get; set; }
        public Nullable<bool> isReleased { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}