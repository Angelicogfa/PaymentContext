using System.Text.RegularExpressions;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ObjectValue
    {
        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;

            AddNotifications(new Contract()
            .Requires()
            .IsNotNullOrEmpty(number, "Document.Number", "Documento não informado!"));

            if (type == EDocumentType.CNPJ && !Regex.IsMatch(number, @"^(\d{2}\.?\d{3}\.?\d{3}\/?\d{4}-?\d{2})$"))
                AddNotification("Document.Number", "CNPJ está incorreto!");
            else if (type == EDocumentType.CPF && !Regex.IsMatch(number, @"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})"))
                AddNotification("Document.Number", "CPF está incorreto!");
        }

        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }
    }
}