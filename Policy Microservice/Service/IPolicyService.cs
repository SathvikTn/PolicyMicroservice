using Policy_Microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Policy_Microservice.Service
{
    public interface IPolicyService
    {
        public Task<string> CreatePolicy(int PropertyId);

        public Task<string> IssuePolicy(int PolicyId, string PaymentDetails);

        public dynamic ViewPolicyById(int PolicyId);

        public Task<Quote> GetQuote(int BusinessValue, int PropertyValue);

        public dynamic GetProperties();

        public dynamic GetPolicies();
    }
}
