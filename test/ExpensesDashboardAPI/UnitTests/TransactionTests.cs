using System;
using ExpensesDashboard.Models;
using Xunit;

namespace UnitTests
{
    public class TransactionTests : IDisposable
    {
        public Transaction testTransaction { get; set; }
        
        public TransactionTests()
        {
            testTransaction = new Transaction
            {
                Date = new DateTime(2015, 12, 20, 10, 20, 30),
                Sum = 0,
                Recipent = "",
                Note = "",
                AccountNr = "",
                TransactionId = ""
            };
        }

        public void Dispose()
        {
            testTransaction = null;
        }

        [Fact]
        public void CanChangeDate()
        {
            // Arange

            //Act
            DateTime testDate = new DateTime(2019, 5, 6, 23, 24, 5);
            testTransaction.Date = testDate;

            //AssertEqual
            Assert.Equal(testDate, testTransaction.Date);
        }

        [Fact]
        public void CanChangeSum()
        {
            // Arange

            //Act
            testTransaction.Sum = 99.99M;

            //AssertEqual
            Assert.Equal(99.99M, testTransaction.Sum);
        }


        [Fact]
        public void CanChangeRecipent()
        {
            // Arange

            //Act
            testTransaction.Recipent = "10.00";

            //AssertEqual
            Assert.Equal("10.00", testTransaction.Recipent);
        }

        [Fact]
        public void CanChangeNote()
        {
            // Arange

            //Act
            testTransaction.Note = "TestComment";

            //AssertEqual
            Assert.Equal("TestComment", testTransaction.Note);
        }

        [Fact]
        public void CanChangeAccountNr()
        {
            // Arange

            //Act
            testTransaction.AccountNr = "LT999999999999";

            //AssertEqual
            Assert.Equal("LT999999999999", testTransaction.AccountNr);
        }

        [Fact]
        public void CanChangeTransactionId()
        {
            // Arange

            //Act
            testTransaction.TransactionId = "1234567";

            //AssertEqual
            Assert.Equal("1234567", testTransaction.TransactionId);
        }

    }
}
