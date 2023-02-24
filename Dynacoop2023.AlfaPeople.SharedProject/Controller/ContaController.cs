using Dynacoop2023.AlfaPeople.ConsoleApplication.Model;
using Microsoft.Xrm.Sdk;
using System;

namespace Dynacoop2023.AlfaPeople.ConsoleApplication.Controller
{
    public class ContaController
    {
        public IOrganizationService ServiceClient { get; set; }
        public Conta Conta { get; set; }

        public ContaController(IOrganizationService crmServiceCliente)
        {
            ServiceClient = crmServiceCliente;
            this.Conta = new Conta(ServiceClient);
        }

        public Entity GetAccountById(Guid id, string[] columns)
        {
            return Conta.GetAccountById(id, columns);
        }

        public void IncrementOrDecrementNumberOfOpp(Entity oppAccount, bool? incrementOrDecrement)
        {
            Conta.IncrementOrDecrementNumberOfOpp(oppAccount, incrementOrDecrement);
        }
    }
}
