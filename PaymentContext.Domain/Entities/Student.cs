using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;

        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;

            AddNotifications(name, document, email);
            _subscriptions = new List<Subscription>();
        }

        public Name Name { get; set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }

        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToList().AsReadOnly(); } }

        public void AddSubscription(Subscription subscription)
        {
            AddNotifications(new Contract().
            Requires().
            IsTrue(Subscriptions.Any(t=> t.Active), "Student.Subscriptions", "Você já possui uma assinatura ativa"));
                
            if(Valid)
                _subscriptions.Add(subscription);
        }
    }
}