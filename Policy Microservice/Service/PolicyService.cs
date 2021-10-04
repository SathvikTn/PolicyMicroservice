using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Policy_Microservice.Models;
using Policy_Microservice.Repository;

namespace Policy_Microservice.Service
{
    public class PolicyService : IPolicyService
    {
        private readonly IPolicyRepo _policyRepo;

        public PolicyService(IPolicyRepo policyRepo)
        {
            _policyRepo = policyRepo;
        }

        public async Task<string> CreatePolicy(int PropertyId)
        {
            return await _policyRepo.CreatePolicy(PropertyId);
        }

        public async Task<string> IssuePolicy(int PolicyId, string PaymentDetails)
        {
            return await _policyRepo.IssuePolicy(PolicyId, PaymentDetails);
        }

        public dynamic ViewPolicyById(int PolicyId)
        {
            return _policyRepo.ViewPolicyById(PolicyId);
        }

        public async Task<Quote> GetQuote(int BusinessValue, int PropertyValue)
        {
            return await _policyRepo.GetQuote(BusinessValue, PropertyValue);
        }


        public dynamic GetProperties()
        {
            return _policyRepo.GetProperties();
        }

        public dynamic GetPolicies()
        {
            return _policyRepo.GetPolicies();
        }
    }
}
