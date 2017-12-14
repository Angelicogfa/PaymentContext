using System.Collections.Generic;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Test.Mocks
{
    public class FakeStudentyRepository : IStudentyRepository
    {
        private List<string> documents = new List<string>() { "99999999999", "11111111111111" };
        private List<string> emails = new List<string>() { "batman@dc.com", "jose_silva@gmail.com" };

        public void CreateSubscription(Student student)
        {
            //ToDO save data
        }

        public bool DocumentExists(string document)
        {
            return documents.Contains(document);
        }

        public bool EmailExists(string email)
        {
            return emails.Contains(email);
        }
    }
}