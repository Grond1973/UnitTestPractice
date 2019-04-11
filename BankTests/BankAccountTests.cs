using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void DebitWithValidAmountUpdatesBalance()
        {
            /**
             * arrange
             */
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;

            BankAccount account = new BankAccount("Mr. Larry Lastly", beginningBalance);

            /**
             * do something
             */
            account.Debit(debitAmount);

            /**
             * ASSERT
             */
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void DebitWhenAmountIsLessThanZeroShouldThrowArgOutOfRange()
        {
            /**
             * arrange
             */
            double beginBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Dee Dee Lynn", beginBalance);

            /**
             * act
             */
            try
            {
                account.Debit(debitAmount);
            }
            catch(ArgumentOutOfRangeException argEx)
            {
                /**
                * ASSERT
                */
                StringAssert.Contains(argEx.Message, BankAccount.DebitAmountLessThanZeroMessage);
            }

            /*
             * ASSERT is handled by ExpectedException attribute on this test method
             */
        }

        [TestMethod]
        public void DebitMoreThanInAccount()
        {
            /**
             * arrange
             */
            double beginBalance = 11.99;
            double debitAmount = 100.00;
            BankAccount account = new BankAccount("Dee Dee Lynn", beginBalance);

            /**
             * act
             */
            try
            {
                account.Debit(debitAmount);
            }
            catch(ArgumentOutOfRangeException argEx)
            {
                /**
                 * ASSERT
                 */
                StringAssert.Contains(argEx.Message, BankAccount.DebitAmountExceedsBalanceMessage);
            }
        }

        [TestMethod]
        public void DebitWhenAmountIsLessThanBalanceShouldThrowArgOutOfRangeEx()
        {
            /**
             * arrange
             */
            double beginBalance = 11.99;
            double debitAmount = 101.00;
            BankAccount account = new BankAccount("Dee Dee Lynn", beginBalance);

            /**
             * act
             */
            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException argEx)
            {
                /**
                 * ASSERT
                 */
                StringAssert.Contains(argEx.Message, BankAccount.DebitAmountExceedsBalanceMessage);
            }

            //Assert.Fail("The expected exception was not thrown.");

        }

        [TestMethod]
        public void CreditWhenCreditAmountIsLessThanZeroShouldThrowArgOutOfRangeEx()
        {
            /**
             * arrange
             */
            double beginBalance = 11.99;
            double creditAmount = -101.00;
            BankAccount account = new BankAccount("Dee Dee Lynn", beginBalance);

            /**
             * act
             */
            try
            {
                account.Credit(creditAmount);
            }
            catch(ArgumentOutOfRangeException argEx)
            {
                StringAssert.Contains(argEx.Message, account.GetCreditLessThanZeroMsg());
            }
        }
    }
}
