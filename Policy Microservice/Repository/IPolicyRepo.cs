using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Policy_Microservice.Models;

namespace Policy_Microservice.Repository
{
    public interface IPolicyRepo
    {
        public Task<string> CreatePolicy(int PropertyId);

        public Task<string> IssuePolicy(int PolicyId, string PaymentDetails);

        public dynamic ViewPolicyById(int PolicyId);

        public Task<Quote> GetQuote(int BusinessValue, int PropertyValue);

        public dynamic GetProperties(); 

        public dynamic GetPolicies();

        
    }
}
