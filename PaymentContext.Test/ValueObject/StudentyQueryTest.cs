using System.Collections.Generic;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Queries;
using Xunit;
using System.Linq;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Domain.Enums;

namespace PaymentContext.Test.ValueObject
{
    public class StudentyQueryTest
    {
        private IList<Student> _students;

        public StudentyQueryTest()
        {
            _students = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                _students.Add(new Student(
                    new Name($"Aluno {i}", $"Sobrenome {i}"),
                    new Document($"{i}{i}{i}.{i}{i}{i}.{i}{i}{i}-{i}{i}", EDocumentType.CPF),
                    new Email($"email{i}@gmail.com")));
            }
        }

        [Fact]
        public void PodeRetornarNullQuandoDocumentoNaoEncontrado()
        {
            var exp = StudentyQuery.GetStudentyByDocument("123456");
            var student = _students.ToList().AsQueryable().Where(exp).FirstOrDefault();

            Assert.Null(student);
        }

        [Fact]
        public void DeveRetornarQuandoDocumentoEncontrado()
        {
            var exp = StudentyQuery.GetStudentyByDocument("111.111.111-11");
            var student = _students.ToList().AsQueryable().Where(exp).FirstOrDefault();

            Assert.NotNull(student);
        }
    }
}