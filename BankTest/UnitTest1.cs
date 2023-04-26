using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BankAccountNS;

namespace BankTest
{


    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void TestMethod1()
        {
        }

        // unit test code  
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // arrange  
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            account.Debit(debitAmount);

            // assert  
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // arrange  
            double beginningBalance = 100.00;
            double debitAmount = 300.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            account.Debit(debitAmount);

            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert  
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("No exception was thrown.");
        
        }

        [TestMethod]
        public void Credit_AccountFrozen()
        {
            // arrange  
            double beginningBalance = 11.99;
            double creditAmount = 4.55;
            double expected = 7.44;
            double actual = 0.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            
            //act
            account.Credit(creditAmount);

           
            
                // assert  
                Assert.AreEqual(expected, actual, "Account is frozen!");
                return;
            
        }

            [TestMethod]
            public void CreditAmountIsNegative()
            {
                // arrange  
                double beginningBalance = 0.00;
                double creditAmount = 4.55;
                BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            account.Debit(creditAmount);

            try
            {
                account.Debit(creditAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert  
                StringAssert.Contains(e.Message, BankAccount.CreditAmountIsNegative);
                return;
            }
            Assert.Fail("No exception was thrown.");


            }

        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // arrange  
            double beginningBalance = 11.99;
            double creditAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            account.Debit(creditAmount);

            // assert  
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not credited correctly");
        }


    }








    }




