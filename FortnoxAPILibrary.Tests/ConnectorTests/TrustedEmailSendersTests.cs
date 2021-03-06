using System.Linq;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests.ConnectorTests
{
    [TestClass]
    public class TrustedEmailSendersTests
    {
        [TestInitialize]
        public void Init()
        {
            //Set global credentials for SDK
            //--- Open 'TestCredentials.resx' to edit the values ---\\
            ConnectionCredentials.AccessToken = TestCredentials.Access_Token;
            ConnectionCredentials.ClientSecret = TestCredentials.Client_Secret;
        }

        [TestMethod]
        public void Test_TrustedEmailSenders_CRUD()
        {
            #region Arrange
            #endregion Arrange

            ITrustedEmailSendersConnector connector = new TrustedEmailSendersConnector();

            var randomAddress = $"{TestUtils.RandomString()}@test.tst";
            #region CREATE
            var newTrustedEmailSender = new TrustedEmailSender()
            {
                Email = randomAddress
            };

            var createdTrustedEmailSender = connector.Create(newTrustedEmailSender);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(randomAddress, createdTrustedEmailSender.Email);

            #endregion CREATE

            #region UPDATE
            //Not supported
            #endregion UPDATE

            #region READ / GET
            //Single get is not supported, full list is used instead
            var retrievedTrustedEmailSender = connector.GetAll().TrustedSenders.FirstOrDefault(t => t.Id == createdTrustedEmailSender.Id);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(randomAddress, retrievedTrustedEmailSender?.Email);
            #endregion READ / GET

            #region DELETE

            connector.Delete(createdTrustedEmailSender.Id);
            MyAssert.HasNoError(connector);

            retrievedTrustedEmailSender = connector.GetAll().TrustedSenders.FirstOrDefault(t => t.Id == createdTrustedEmailSender.Id);
            Assert.AreEqual(null, retrievedTrustedEmailSender);

            #endregion DELETE

            #region Delete arranged resources

            //Add code to delete temporary resources

            #endregion Delete arranged resources
        }
    }
}
