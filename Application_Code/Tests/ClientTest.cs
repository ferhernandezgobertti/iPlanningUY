using System;
using System.Text;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void TestIsTelephoneBeginningRightTrue()
        {
            Client aClient = new Client();
            aClient.Telephone = "09874";
            Assert.IsTrue(aClient.IsTelephoneBeginningRight());
        }

        [TestMethod]
        public void TestIsTelephoneBeginningRightFalse()
        {
            Client aClient = new Client();
            aClient.Telephone = "99874";
            Assert.IsFalse(aClient.IsTelephoneBeginningRight());
        }

        [TestMethod]
        public void TestIsTelephoneRightTrue()
        {
            Client aClient = new Client();
            aClient.Telephone = "098742547";
            Assert.IsTrue(aClient.IsTelephoneRight());
        }

        [TestMethod]
        public void TestIsTelephoneRightWrongLength()
        {
            Client aClient = new Client();
            aClient.Telephone = "0987";
            Assert.IsFalse(aClient.IsTelephoneRight());
        }

        [TestMethod]
        public void TestIsTelephoneRightWrongFormat()
        {
            Client aClient = new Client();
            aClient.Telephone = "09874abcd";
            Assert.IsFalse(aClient.IsTelephoneRight());
        }

        [TestMethod]
        public void TestCheckRangePositiveNumberTrue()
        {
            Client aClient = new Client();
            int number = 100;
            int length = 3;
            Assert.IsTrue(aClient.CheckRangePositiveNumber(number,length));
        }

        [TestMethod]
        public void TestCheckRangePositiveNumberWrongLength()
        {
            Client aClient = new Client();
            int number = 100;
            int length = 2;
            Assert.IsFalse(aClient.CheckRangePositiveNumber(number, length));
        }

        [TestMethod]
        public void TestCheckRangePositiveNumberWrongNumber()
        {
            Client aClient = new Client();
            int number = 10;
            int length = 3;
            Assert.IsFalse(aClient.CheckRangePositiveNumber(number, length));
        }

        [TestMethod]
        public void TestCheckOldNumberIDTrue()
        {
            Client aClient = new Client();
            aClient.NumberID = "100.304-6";
            Assert.IsTrue(aClient.CheckOldNumberID(aClient.NumberID));
        }

        [TestMethod]
        public void TestCheckOldNumberIDWrongFormatFirstNumber()
        {
            Client aClient = new Client();
            aClient.NumberID = "1003046";
            Assert.IsFalse(aClient.CheckOldNumberID(aClient.NumberID));
        }

        [TestMethod]
        public void TestCheckOldNumberIDWrongFormatSecondNumber()
        {
            Client aClient = new Client();
            aClient.NumberID = "100.3046";
            Assert.IsFalse(aClient.CheckOldNumberID(aClient.NumberID));
        }

        [TestMethod]
        public void TestCheckOldNumberIDDifferentFirstNumber()
        {
            Client aClient = new Client();
            aClient.NumberID = "10.304-6";
            Assert.IsTrue(aClient.CheckOldNumberID(aClient.NumberID));
        }

        [TestMethod]
        public void TestCheckOldNumberIDWrongSecondNumber()
        {
            Client aClient = new Client();
            aClient.NumberID = "100.30-6";
            Assert.IsFalse(aClient.CheckOldNumberID(aClient.NumberID));
        }

        [TestMethod]
        public void TestCheckOldNumberIDWrongLastNumber()
        {
            Client aClient = new Client();
            aClient.NumberID = "10.304-60";
            Assert.IsFalse(aClient.CheckOldNumberID(aClient.NumberID));
        }

        [TestMethod]
        public void TestCheckOldNumberIDWrongWithSymbols()
        {
            Client aClient = new Client();
            aClient.NumberID = "100a.304b-6c";
            Assert.IsFalse(aClient.CheckOldNumberID(aClient.NumberID));
        }

        [TestMethod]
        public void TestCheckNewNumberIDTrue()
        {
            Client aClient = new Client();
            aClient.NumberID = "4.851.112-6";
            Assert.IsTrue(aClient.CheckNewNumberID());
        }

        [TestMethod]
        public void TestCheckNewNumberIDWrongFirstNumber()
        {
            Client aClient = new Client();
            aClient.NumberID = "A.851.112-6";
            Assert.IsFalse(aClient.CheckNewNumberID());
        }

        [TestMethod]
        public void TestCheckNewNumberIDWrongSecondNumber()
        {
            Client aClient = new Client();
            aClient.NumberID = "4M851.112-6";
            Assert.IsFalse(aClient.CheckNewNumberID());
        }

        [TestMethod]
        public void TestIsNumberIDRightTrueWithNew()
        {
            Client aClient = new Client();
            aClient.NumberID = "4.851.112-6";
            Assert.IsTrue(aClient.IsNumberIDRight());
        }

        [TestMethod]
        public void TestIsNumberIDRightTrueWithFalse()
        {
            Client aClient = new Client();
            aClient.NumberID = "151.112-6";
            Assert.IsTrue(aClient.IsNumberIDRight());
        }

        [TestMethod]
        public void TestIsNumberIDRightFalse()
        {
            Client aClient = new Client();
            aClient.NumberID = "A3.151ABCD112-6";
            Assert.IsFalse(aClient.IsNumberIDRight());
        }

        [TestMethod]
        public void TestCheckNumberWithCerosTrue()
        {
            int someNumber;
            Client aClient = new Client();
            aClient.NumberID = "001.012-6";
            String[] divisions = aClient.NumberID.Split('.');
            int.TryParse(divisions[0], out someNumber);
            Assert.IsTrue(aClient.CheckNumberWithCeros(divisions[0], someNumber));
        }

        [TestMethod]
        public void TestCheckNumberWithCerosFalse()
        {
            int someNumber;
            Client aClient = new Client();
            aClient.NumberID = "000.012-6";
            String[] divisions = aClient.NumberID.Split('.');
            int.TryParse(divisions[0], out someNumber);
            Assert.IsFalse(aClient.CheckNumberWithCeros(divisions[0], someNumber));
        }


        [TestMethod]
        public void TestIsWellRegisteredTrue()
        {
            Client aClient = new Client();
            aClient.Name = "Carlos";
            aClient.Surname = "Perez";
            aClient.UserName = "Carlitos23";
            aClient.Password = "Carlos.4123";
            aClient.NumberID = "3.523.345-3";
            aClient.Telephone = "099643452";
            aClient.Address = "Canelones 1267";
            Assert.IsTrue(aClient.IsWellRegistered());
        }

        [TestMethod]
        public void TestIsWellRegisteredWrongName()
        {
            Client aClient = new Client();
            aClient.Name = "Carlos Gonzalo";
            aClient.Surname = "Perez";
            aClient.UserName = "Carlitos23";
            aClient.Password = "Carlos.4123";
            aClient.NumberID = "3.523.345-3";
            aClient.Telephone = "099643452";
            aClient.Address = "Canelones 1267";
            Assert.IsFalse(aClient.IsWellRegistered());
        }

        [TestMethod]
        public void TestIsWellRegisteredWrongSurname()
        {
            Client aClient = new Client();
            aClient.Name = "Carlos";
            aClient.Surname = "Perez Gutierrez";
            aClient.UserName = "Carlitos23";
            aClient.Password = "Carlos.4123";
            aClient.NumberID = "3.523.345-3";
            aClient.Telephone = "099643452";
            aClient.Address = "Canelones 1267";
            Assert.IsFalse(aClient.IsWellRegistered());
        }

        [TestMethod]
        public void TestIsWellRegisteredWrongUserName()
        {
            Client aClient = new Client();
            aClient.Name = "Carlos";
            aClient.Surname = "Perez";
            aClient.UserName = "Carlitos23AAAAAAAAAAAAA";
            aClient.Password = "Carlos.4123";
            aClient.NumberID = "3.523.345-3";
            aClient.Telephone = "099643452";
            aClient.Address = "Canelones 1267";
            Assert.IsFalse(aClient.IsWellRegistered());
        }

        [TestMethod]
        public void TestIsWellRegisteredWrongPassword()
        {
            Client aClient = new Client();
            aClient.Name = "Carlos";
            aClient.Surname = "Perez";
            aClient.UserName = "Carlitos23";
            aClient.Password = "soloCarlos";
            aClient.NumberID = "3.523.345-3";
            aClient.Telephone = "099643452";
            aClient.Address = "Canelones 1267";
            Assert.IsFalse(aClient.IsWellRegistered());
        }

        [TestMethod]
        public void TestIsWellRegisteredWrongNumberID()
        {
            Client aClient = new Client();
            aClient.Name = "Carlos";
            aClient.Surname = "Perez";
            aClient.UserName = "Carlitos23";
            aClient.Password = "Carlos.4123";
            aClient.NumberID = "C.ARL.345-3";
            aClient.Telephone = "099643452";
            aClient.Address = "Canelones 1267";
            Assert.IsFalse(aClient.IsWellRegistered());
        }

        [TestMethod]
        public void TestIsWellRegisteredWrongTelephone()
        {
            Client aClient = new Client();
            aClient.Name = "Carlos";
            aClient.Surname = "Perez";
            aClient.UserName = "Carlitos23";
            aClient.Password = "Carlos.4123";
            aClient.NumberID = "3.523.345-3";
            aClient.Telephone = "09964MAL3452";
            aClient.Address = "Canelones 1267";
            Assert.IsFalse(aClient.IsWellRegistered());
        }

        [TestMethod]
        public void TestIsWellRegisteredWrongAddress()
        {
            Client aClient = new Client();
            aClient.Name = "Carlos";
            aClient.Surname = "Perez";
            aClient.UserName = "Carlitos23";
            aClient.Password = "Carlos.4123";
            aClient.NumberID = "3.523.345-3";
            aClient.Telephone = "099643452";
            aClient.Address = "Canelones";
            Assert.IsFalse(aClient.IsWellRegistered());
        }

        [TestMethod]
        public void TestGetClientDataEditing() {
            Client oneClient = new Client();
            oneClient.Name = "Caro";
            oneClient.Surname = "Rodriguez";
            oneClient.UserName = "CaroRod30";
            oneClient.NumberID = "4.851.112-6";
            oneClient.Telephone = "098665533";
            oneClient.Address = "Colonia 1288";
            String[] dataEditing = { "CaroRod30", "Caro", "Rodriguez", "4.851.112-6", "098665533", "Colonia 1288" };
            Client otherClient = new Client();
            otherClient.GetDataEditing(dataEditing);
            Assert.AreEqual(oneClient, otherClient);
        }

        //ME QUEDE ACA 

        [TestMethod]
        public void TestStoreClientDataTrue() {
            SketchItAppTest oneTest = new SketchItAppTest();
            oneTest.TestInitialize();
            Client clientToStore = new Client();
            clientToStore.UserName = "CaroFer33";
            clientToStore.Password = "CaroSol.44";
            clientToStore.Name = "Caro";
            clientToStore.Surname = "Dominguez";
            clientToStore.NumberID = "4.898.323-9";
            clientToStore.Telephone = "098543556";
            clientToStore.Address = "Portones 2020";
            Client clientToReplace = new Client();
            clientToReplace.UserName = "CaroRod33";
            clientToReplace.Password = "CaroFer.44";
            clientToReplace.Name = "Carolina";
            clientToReplace.Surname = "Rodriguez";
            clientToReplace.NumberID = "4.987.342-9";
            clientToReplace.Telephone = "098783456";
            clientToReplace.Address = "Malvin 1330";
            Assert.IsTrue(clientToReplace.StoreData(oneTest.newProgram, clientToStore));
        }

        [TestMethod]
        public void TestStoreClientDataFalse()
        {
            SketchItAppTest oneTest = new SketchItAppTest();
            oneTest.TestInitialize();
            Client clientToStore = new Client();
            clientToStore.UserName = "CaroRod33";
            clientToStore.Password = "CaroFer.44";
            clientToStore.Name = "Carolina";
            clientToStore.Surname = "Rodriguez";
            clientToStore.NumberID = "4.987.342-9";
            clientToStore.Telephone = "098783456";
            clientToStore.Address = "Malvin 1330";
            Client clientToReplace = new Client();
            clientToReplace.UserName = "CaroMar59";
            clientToReplace.Password = "CaroLOL.69";
            clientToReplace.Name = "Carol";
            clientToReplace.Surname = "Michigan";
            clientToReplace.NumberID = "4.909.323-9";
            clientToReplace.Telephone = "098908833";
            clientToReplace.Address = "Union 5657";
            Assert.IsFalse(clientToReplace.StoreData(oneTest.newProgram, clientToStore));
        }

        [TestMethod]
        public void TestChangeClientPassword()
        {
            SketchItAppTest oneTest = new SketchItAppTest();
            oneTest.TestInitialize();
            String newPassword = "CaroRod.30";
            Client clientToModify = (Client)oneTest.newProgram.GetClientsFromUsers()[0];
            clientToModify.ChangePassword(oneTest.newProgram, newPassword);
            Assert.AreEqual(clientToModify.Password, newPassword);
        }

        [TestMethod]
        public void TestPasswordEqualsClientTrue()
        {
            SketchItAppTest oneTest = new SketchItAppTest();
            oneTest.TestInitialize();
            String newPassword = "CaroRod.30";
            Client clientToCompare = (Client)oneTest.newProgram.GetClientsFromUsers()[0];
            clientToCompare.Password = "CaroRod.30";
            Assert.IsTrue(clientToCompare.PasswordEquals(newPassword));
        }

        [TestMethod]
        public void TestPasswordEqualsClientFalse()
        {
            SketchItAppTest oneTest = new SketchItAppTest();
            oneTest.TestInitialize();
            String newPassword = "CaroRod.30";
            Client clientToCompare = (Client)oneTest.newProgram.GetClientsFromUsers()[0];
            clientToCompare.Password = "FerHer.50";
            Assert.IsFalse(clientToCompare.PasswordEquals(newPassword));
        }

        [TestMethod]
        public void TestCheckClientLogInWhenNotPossible()
        {
            SketchItAppTest oneTest = new SketchItAppTest();
            oneTest.TestInitialize();
            Client otherClient = new Client();
            otherClient = (Client)otherClient.CheckLogIn(oneTest.newProgram, "CaroRod3", "Fer.3030");
            Assert.AreEqual(otherClient, null);
        }

        [TestMethod]
        public void TestCheckClientLogIn()
        {
            SketchItAppTest oneTest = new SketchItAppTest();
            oneTest.TestInitialize();
            Client oneClient = (Client)oneTest.newProgram.GetClientsFromUsers()[0];
            Client otherClient = new Client();
            otherClient = (Client)otherClient.CheckLogIn(oneTest.newProgram, oneClient.UserName, oneClient.Password);
            Assert.AreNotEqual(otherClient, null);
        }

        [TestMethod]
        public void TestEqualsSameNameAndSurname()
        {
            Client aClient = new Client();
            aClient.Name = "Carlos";
            aClient.Surname = "Perez";
            Client otherClient = new Client();
            otherClient.Name = "Carlos";
            otherClient.Surname = "Perez";

            aClient.UserName = "Carlitos23";
            otherClient.UserName = "Carlos25";
            aClient.Telephone = "098742547";
            otherClient.Telephone = "099732521";
            aClient.NumberID = "4.881.322-5";
            otherClient.NumberID = "5.890.375-5";
            aClient.Address = "Aguada 2020";
            otherClient.Address = "Montecristo 2302";

            Assert.IsTrue(aClient.Equals(otherClient));
        }

        [TestMethod]
        public void TestEqualsSameUsername()
        {
            Client aClient = new Client();
            aClient.UserName = "Carlos55";
            Client otherClient = new Client();
            otherClient.UserName = "Carlos55";

            aClient.Name = "Carlos";
            aClient.Surname = "Perez";
            otherClient.Name = "Juan";
            otherClient.Surname = "Perez";
            aClient.NumberID = "4.881.322-5";
            otherClient.NumberID = "5.890.375-5";
            aClient.Telephone = "098742547";
            otherClient.Telephone = "099732521";
            aClient.Address = "Aguada 2020";
            otherClient.Address = "Montecristo 2302";

            Assert.IsTrue(aClient.Equals(otherClient));
        }

        [TestMethod]
        public void TestEqualsSameTelephone()
        {
            Client aClient = new Client();
            aClient.Telephone = "098742547";
            Client otherClient = new Client();
            otherClient.Telephone = "098742547";

            aClient.UserName = "Carlitos23";
            otherClient.UserName = "Carlos25";
            aClient.Name = "Carlos";
            aClient.Surname = "Perez";
            otherClient.Name = "Juan";
            otherClient.Surname = "Perez";
            aClient.NumberID = "4.881.322-5";
            otherClient.NumberID = "5.890.375-5";
            aClient.Address = "Aguada 2020";
            otherClient.Address = "Montecristo 2302";

            Assert.IsTrue(aClient.Equals(otherClient));
        }

        [TestMethod]
        public void TestEqualsSameAddress()
        {
            Client aClient = new Client();
            aClient.Address = "Centro 1267";
            Client otherClient = new Client();
            otherClient.Address = "Centro 1267";

            aClient.UserName = "Carlitos23";
            otherClient.UserName = "Carlos25";
            aClient.Name = "Carlos";
            aClient.Surname = "Perez";
            otherClient.Name = "Juan";
            otherClient.Surname = "Perez";
            aClient.NumberID = "4.881.322-5";
            otherClient.NumberID = "5.890.375-5";
            aClient.Telephone = "098742547";
            otherClient.Telephone = "099732521";

            Assert.IsTrue(aClient.Equals(otherClient));
        }

        [TestMethod]
        public void TestEqualsSameNumberID()
        {
            Client aClient = new Client();
            aClient.NumberID = "4.881.322-5";
            Client otherClient = new Client();
            otherClient.NumberID = "4.881.322-5";

            aClient.UserName = "Carlitos23";
            otherClient.UserName = "Carlos25";
            aClient.Name = "Carlos";
            aClient.Surname = "Perez";
            otherClient.Name = "Juan";
            otherClient.Surname = "Perez";
            aClient.Address = "Carrasco 8888";
            otherClient.Address = "Centro 1267";
            aClient.Telephone = "098742547";
            otherClient.Telephone = "099732521";

            Assert.IsTrue(aClient.Equals(otherClient));
        }

        [TestMethod]
        public void TestEqualsClientNull()
        {
            Client aClient = new Client();
            aClient.NumberID = "4.881.322-5";
            aClient.UserName = "Carlitos23";
            aClient.Name = "Carlos";
            aClient.Surname = "Perez";
            aClient.Address = "Carrasco 8888";
            aClient.Telephone = "098742547";

            Client otherClient = null;

            Assert.IsFalse(aClient.Equals(otherClient));
        }

        [TestMethod]
        public void TestEqualsClientFalse()
        {
            Client aClient = new Client();
            Client otherClient = new Client();

            aClient.UserName = "Carlitos23";
            otherClient.UserName = "Carlos25";
            aClient.Name = "Carlos";
            aClient.Surname = "Perez";
            otherClient.Name = "Juan";
            otherClient.Surname = "Perez";
            aClient.NumberID = "4.855.232-6";
            otherClient.NumberID = "4.325.872-9";
            aClient.Address = "Carrasco 8888";
            otherClient.Address = "Centro 1267";
            aClient.Telephone = "098742547";
            otherClient.Telephone = "099732521";

            Assert.IsFalse(aClient.Equals(otherClient));
        }

        [TestMethod]
        public void TestToStringClientTrue()
        {
            Client aClient = new Client();
            aClient.UserName = "Carlitos23";
            aClient.Password = "Car.4Ever";
            aClient.Name = "Carlos";
            aClient.Surname = "Perez";
            aClient.NumberID = "4.855.232-6";
            aClient.Address = "Carrasco 8888";
            aClient.Telephone = "098742547";
            
            StringBuilder buildOfExpected = new StringBuilder();
            buildOfExpected.Append("UserName: Carlitos23 Password: Car.4Ever Name: Carlos" +
                " Surname: Perez Registration Date: ");
            buildOfExpected.Append(aClient.Registration);
            buildOfExpected.Append(" Last Entry: ");
            buildOfExpected.Append(aClient.LastEntry);
            buildOfExpected.Append(" Number ID: 4.855.232-6 Telephone: 098742547 Address: Carrasco 8888");

            Assert.AreEqual(aClient.ToString(), buildOfExpected.ToString());
        }

    }
}
