using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using Xunit;

namespace PaymentContext.Test.ValueObjects
{
    public class DocumentoTest
    {
        [Theory]
        [InlineData("12.122.472/0001-08", EDocumentType.CNPJ)]
        [InlineData("123.456.789-86", EDocumentType.CPF)]
        public void DocumentoValido(string documento, EDocumentType type)
        {
            Document document = new Document(documento, type);

            Assert.True(document.Valid);
        }

        [Theory]
        [InlineData("", EDocumentType.CNPJ)]
        [InlineData("123.456.258/12-158", EDocumentType.CNPJ)]
        [InlineData("", EDocumentType.CPF)]
        [InlineData("23.56.78986", EDocumentType.CPF)]
        public void DocumentoInvalido(string documento, EDocumentType type)
        {
            Document document = new Document(documento, type);

            Assert.True(document.Invalid);
        }
    }
}