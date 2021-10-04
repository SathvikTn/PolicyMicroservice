using System;
using System.Collections.Generic;

#nullable disable

namespace Policy_Microservice.Models
{
    public partial class Property
    {
        public Property()
        {
            ConsumerPolicies = new HashSet<ConsumerPolicy>();
        }

        public int PropertyId { get; set; }
        public string BuildingType { get; set; }
        public int BuildingStoreys { get; set; }
        public int BuildingAge { get; set; }
        public int BusinessId { get; set; }
        public int PropertyMasterId { get; set; }

        public virtual Business Business { get; set; }
        public virtual PropertyMaster PropertyMaster { get; set; }
        public virtual ICollection<ConsumerPolicy> ConsumerPolicies { get; set; }
    }
}
