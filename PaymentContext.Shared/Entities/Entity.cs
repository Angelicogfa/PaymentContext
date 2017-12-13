using System;


namespace PaymentContext.Shared.Entities
{
    public abstract class Entity : Flunt.Notifications.Notifiable
    {
        public Entity() => Id = Guid.NewGuid();

        public Guid Id { get; private set; }
    }    
}