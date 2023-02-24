using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;

namespace Dynacoop2023.AlfaPeople.ConsoleApplication.Model
{
    public class Conta
    {
        public IOrganizationService ServiceClient { get; set; }

        public string Logicalname { get; set; }

        public Conta(IOrganizationService crmServiceClient)
        {
            this.ServiceClient = crmServiceClient;
            this.Logicalname = "account";
        }

        public Conta(CrmServiceClient crmServiceClient)
        {
            this.ServiceClient = crmServiceClient;
            this.Logicalname = "account";
        }
        public Entity GetAccountById(Guid id, string[] columns)
        {
            return ServiceClient.Retrieve(this.Logicalname, id, new ColumnSet(columns));
        }

        public void IncrementOrDecrementNumberOfOpp(Entity oppAccount, bool? decrementOrIncrement)
        {
            int numberOfOpp = oppAccount.Contains("dcp_numero_total_opp") ? (int)oppAccount["dcp_numero_total_opp"] : 0;

            if (Convert.ToBoolean(decrementOrIncrement))
            {
                numberOfOpp += 1;
            }
            else
            {
                numberOfOpp -= 1;
            }
            oppAccount["dcp_numero_total_opp"] = numberOfOpp;
            ServiceClient.Update(oppAccount);
        }
    }
}
