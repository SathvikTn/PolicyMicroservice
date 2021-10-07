# PolicyMicroservice

Policy Microservice is a middleware microservice, one of the 4 microservices, which is used to create, view and issue policy. It interacts with Consumer Microservice and Quote Microservice, but it gets invoked from Insureity Portal (Angular app). 

Post authorization of request, Policy Microservice allows the following operations: 

* Creates Policy based on Business and Property Value from Consumer Service. For these values, the service will validate the permissible Policies and for the coverage the Agent has quoted, and get the quotes from Quotes service.

* Issue Policy will issue a policy to the consumer based on the payment and acceptance status from consumer, for the quoted insurance cover.

* View Policy allows to view the Policy Details 

It provides 4 REST API Endpoints:

1. POST: /createPolicy (Input: Property Id | Output: Policy Status, Description)
  <br>
  createPolicy is be used to create a policy for the specified property id. Since, property is connected with business and business is connected with consumer, we can get all the necessary inputs such as Consumer Details, Business Details, Accepted Quotes, and Agent Details, from the property id itself. If you try to create a policy for any property, it will display the appropriate response according to the logic. Initially, policy status will be set to "Initiated".

2. PUT: /issuePolicy (Input: Policy ID, Payment Details | Output: Issue Status)
>  issuePlicy takes policy id and payment details as inputs and displays the appropriate policy status. If the policy is being issued for the first time and with valid payment details, it will issue the policy and change the policy status to "Issued". Else, it will display appropriate responses according to the inputs.

3. GET: / viewPolicy (Input: Policy ID | Output: Policy Details) 
  <br>
  viewPolicy takes policy id as input and if such policy exists, it will respond with the details of that policy, else, it will respond as policy not found.

4. GET: /getQuotes (Input: Business Value, Property Value | Quotes details) 
  <br>
  getQuote will take business and property values as input and will respond with quote details for respective values, if such quote exists, else it will respond with quote not found. 

Trigger – Will be invoked from Insureity Portal.

