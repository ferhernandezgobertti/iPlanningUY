using System;
using System.Text;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class SignatureTest
    {

        private Signature signatureToTest;

        [TestInitialize]
        public void TestInitialize()
        {
            Architect firstToSign = new Architect();
            firstToSign.UserName = "Fer55";
            firstToSign.Password = "Fer.55";
            firstToSign.Name = "Hernan";
            firstToSign.Surname = "Hernandez";
            signatureToTest = new Signature(firstToSign);
        }

        [TestMethod]
        public void TestIsOnlyOneSignerTrue()
        {
            Assert.IsTrue(this.signatureToTest.IsOnlyOneSigner());
        }

        [TestMethod]
        public void TestIsOnlyOneSignerFalse() {
            Architect secondToSign = new Architect();
            secondToSign.UserName = "Caro30";
            secondToSign.Password = "Caro.30";
            secondToSign.Name = "Carola";
            secondToSign.Surname = "Rodriguez";
            this.signatureToTest.SecondSigner = secondToSign;
            Assert.IsFalse(this.signatureToTest.IsOnlyOneSigner());
        }

        [TestMethod]
        public void TestRegisterSecondSignature()
        {
            Architect secondToSign = new Architect();
            secondToSign.UserName = "Caro30";
            secondToSign.Password = "Caro.30";
            secondToSign.Name = "Carola";
            secondToSign.Surname = "Rodriguez";
            this.signatureToTest.RegisterSecondSignature(secondToSign);
            Assert.IsNotNull(this.signatureToTest.SecondSigner);
        }

        [TestMethod]
        public void TestSignatureToStringOneSigner()
        {
            StringBuilder signatureStringExpected = new StringBuilder();
            signatureStringExpected.Append(" - 1st Signature: Fer55 at ");
            signatureStringExpected.Append(this.signatureToTest.FirstSigning.ToString());
            Assert.AreEqual(this.signatureToTest.ToString(), signatureStringExpected.ToString());
        }

        [TestMethod]
        public void TestSignatureToStringBothSigners()
        {
            Architect secondToSign = new Architect();
            secondToSign.UserName = "Caro30";
            secondToSign.Password = "Caro.30";
            secondToSign.Name = "Carola";
            secondToSign.Surname = "Rodriguez";
            this.signatureToTest.RegisterSecondSignature(secondToSign);

            StringBuilder signatureStringExpected = new StringBuilder();
            signatureStringExpected.Append(" - 1st Signature: Fer55 at ");
            signatureStringExpected.Append(this.signatureToTest.FirstSigning.ToString());
            signatureStringExpected.Append(" - 2nd Signature: Caro30 at ");
            signatureStringExpected.Append(this.signatureToTest.SecondSigning.ToString());
            Assert.AreEqual(this.signatureToTest.ToString(), signatureStringExpected.ToString());
        }

        [TestMethod]
        public void TestEqualsSignatureWithOneSignerTrue()
        {
            Architect firstToSign = new Architect();
            firstToSign.UserName = "Fer55";
            firstToSign.Password = "Fer.55";
            firstToSign.Name = "Hernan";
            firstToSign.Surname = "Hernandez";
            Signature signatureToCompare = new Signature(firstToSign);
            signatureToCompare.FirstSigning = this.signatureToTest.FirstSigning;
            Assert.IsTrue(this.signatureToTest.Equals(signatureToCompare));
        }

        [TestMethod]
        public void TestEqualsSignatureWithBothSignersTrue()
        {
            Architect firstToSign = new Architect();
            firstToSign.UserName = "Fer55";
            firstToSign.Password = "Fer.55";
            firstToSign.Name = "Hernan";
            firstToSign.Surname = "Hernandez";
            Signature signatureToCompare = new Signature(firstToSign);
            signatureToCompare.FirstSigning = this.signatureToTest.FirstSigning;

            Architect secondToSign = new Architect();
            secondToSign.UserName = "Caro30";
            secondToSign.Password = "Caro.30";
            secondToSign.Name = "Carola";
            secondToSign.Surname = "Rodriguez";
            this.signatureToTest.RegisterSecondSignature(secondToSign);
            signatureToCompare.RegisterSecondSignature(secondToSign);
            signatureToCompare.SecondSigning = this.signatureToTest.SecondSigning;

            Assert.IsTrue(this.signatureToTest.Equals(signatureToCompare));
        }

        [TestMethod]
        public void TestEqualsSignatureWithOneSignerFalse()
        {
            Architect firstToSign = new Architect();
            firstToSign.UserName = "Pedro43";
            firstToSign.Password = "Paul.23";
            firstToSign.Name = "Pablo";
            firstToSign.Surname = "Joaquin";
            Signature signatureToCompare = new Signature(firstToSign);
            Assert.IsFalse(this.signatureToTest.Equals(signatureToCompare));
        }

        [TestMethod]
        public void TestEqualsSignatureWithBothSignersFalse()
        {
            Architect firstToSign = new Architect();
            firstToSign.UserName = "Fer55";
            firstToSign.Password = "Fer.55";
            firstToSign.Name = "Hernan";
            firstToSign.Surname = "Hernandez";
            Signature signatureToCompare = new Signature(firstToSign);
            signatureToCompare.FirstSigning = this.signatureToTest.FirstSigning;

            Architect secondToSign = new Architect();
            secondToSign.UserName = "Caro30";
            secondToSign.Password = "Caro.30";
            secondToSign.Name = "Carola";
            secondToSign.Surname = "Rodriguez";
            this.signatureToTest.RegisterSecondSignature(secondToSign);

            Architect otherSecondToSign = new Architect();
            otherSecondToSign.UserName = "Caro53";
            otherSecondToSign.Password = "Caro.53";
            otherSecondToSign.Name = "Carolina";
            otherSecondToSign.Surname = "Rodriguez";
            signatureToCompare.RegisterSecondSignature(otherSecondToSign);
            
            Assert.IsFalse(this.signatureToTest.Equals(signatureToCompare));
        }

        [TestMethod]
        public void TestEqualsSignatureNull ()
        {
            Signature signatureToCompare = null;
            Assert.IsFalse(this.signatureToTest.Equals(signatureToCompare));
        }

    }
}
