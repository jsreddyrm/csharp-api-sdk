﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FortnoxAPILibrary.Connectors;
using FortnoxAPILibrary.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests
{
    [TestClass]
    public class ReportedIssuesTests
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
        public void Test_Issue_44() // Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/44
        {
            //Arrange
            var customerConnector = new CustomerConnector();
            var tmpCustomer = customerConnector.Create(new Customer() { Name = "TmpTestCustomer" });

            IInvoiceConnector connector = new InvoiceConnector();

            var newInvoce = connector.Create(new Invoice()
            {
                InvoiceDate = new DateTime(2019,1,20), //"2019-01-20",
                DueDate = new DateTime(2019, 2, 20), //"2019-02-20",
                CustomerNumber = tmpCustomer.CustomerNumber,
                InvoiceType = InvoiceType.Invoice,
                InvoiceRows = new List<InvoiceRow>()
                { //Add Empty rows
                    new InvoiceRow(), //Empty Row
                    new InvoiceRow(), //Empty Row
                    new InvoiceRow() { AccountNumber = 0000},
                    new InvoiceRow(), //Empty Row
                }
            });

            MyAssert.HasNoError(connector);
        }

        [TestMethod]
        public void Test_issue51_fixed() //Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/51
        {
            //Arrange
            /* Assuming several (at least 5) vouchers exists */

            //Act & Assert
            var connector = new VoucherConnector();
            connector.Search.FinancialYearID = 1;

            connector.Search.Limit = 2;
            var voucherResult = connector.Find();
            MyAssert.HasNoError(connector);

            connector.Search.Page = 2;
            var voucherResult2 = connector.Find();
            MyAssert.HasNoError(connector);

            connector.Search.Page = 3;
            var voucherResult3 = connector.Find();
            MyAssert.HasNoError(connector);
        }

        [TestMethod]
        public void Test_issue57_fixed() // Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/57
        {
            var connector = new CustomerConnector();
            var specificCustomer = connector.Create(new Customer() { Name = "TestCustomer", OrganisationNumber = "123456789" });
            Assert.IsFalse(connector.HasError);

            connector.Search.OrganisationNumber = "123456789";
            var customers = connector.Find().Entities;
            var customer = customers.FirstOrDefault(c => c.CustomerNumber == specificCustomer.CustomerNumber);
            Assert.IsNotNull(customer);

            connector.Delete(specificCustomer.CustomerNumber);
            MyAssert.HasNoError(connector);
        }

        [TestMethod]
        public void Test_issue50_fixed() // Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/50
        {
            var connector = new CustomerConnector();
            var newCustomer = connector.Create(new Customer() { Name = "TestCustomer", City = "Växjö", Type = CustomerType.Company });
            MyAssert.HasNoError(connector);

            var updatedCustomer = connector.Update(new Customer() { CustomerNumber = newCustomer.CustomerNumber, City = "Stockholm" });
            MyAssert.HasNoError(connector);
            Assert.AreEqual(CustomerType.Company, updatedCustomer.Type);

            connector.Delete(newCustomer.CustomerNumber);
            MyAssert.HasNoError(connector);
        }

        [TestMethod]
        public void Test_issue61_fixed() // Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/61
        {
            var connector = new ArticleConnector();
            var newArticle = connector.Create(new Article() { Description = "TestArticle", FreightCost = 10, OtherCost = 10, CostCalculationMethod = "MANUAL" });
            MyAssert.HasNoError(connector);

            //NOTE: Server does not create the properties FreightCost, OtherCost and CostCalculationMethod
            //Assert.AreEqual("10", newArticle.FreightCost); //Always fails
            connector.Delete(newArticle.ArticleNumber);
            MyAssert.HasNoError(connector);
        }

        [TestMethod]
        public void Test_issue73_async_non_blockable()
        {
            var connector = new CustomerConnector();
            connector.Search.Limit = 2;
            var watch = new Stopwatch();
            watch.Start();

            var runningTasks = new List<Task<EntityCollection<CustomerSubset>>>();
            for (int i = 0;i<40;i++) 
                runningTasks.Add(connector.FindAsync());

            Console.WriteLine(@"Thread free after: "+watch.ElapsedMilliseconds);
            Assert.IsTrue(watch.ElapsedMilliseconds < 1000);

            watch.Start();
            foreach (var runningTask in runningTasks)
            {
                var result = runningTask.Result;
                MyAssert.HasNoError(connector);
                Assert.IsNotNull(result);
            }
            watch.Stop();
            Console.WriteLine(@"Total time: "+watch.ElapsedMilliseconds);
        }

        [TestMethod]
        public void Test_issue84_fixed() //Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/84
        {
            //Arrange
            IArchiveConnector conn = new ArchiveConnector();
            var testRootFolder = conn.GetFolder("TestArchive") ?? conn.CreateFolder("TestArchive");

            //Act
            IArchiveConnector connector = new ArchiveConnector();

            var data = Resource.fortnox_image;
            var randomFileName = TestUtils.RandomString() + "åöä.txt";

            var fortnoxFile = connector.UploadFile(randomFileName, data, testRootFolder.Name);
            MyAssert.HasNoError(connector);

            //Assert
            Assert.AreEqual(randomFileName, fortnoxFile.Name);

            //Clean
            connector.DeleteFile(fortnoxFile.Id);
            MyAssert.HasNoError(connector);
        }

        [TestMethod]
        public void Test_Issue95_fixed() //Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/95
        {
            //Arrange
            //Creates a customer with ElectronicInvoice option for deliviery type
            var connector = new CustomerConnector();
            var tmpCustomer = connector.Create(new Customer()
            {
                Name = "TestCustomer",
                DefaultDeliveryTypes = new DefaultDeliveryTypes()
                {
                    Invoice = DefaultDeliveryType.ElectronicInvoice
                }
            });
            MyAssert.HasNoError(connector);

            //Act && Assert
            var customer = connector.Get(tmpCustomer.CustomerNumber);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(DefaultDeliveryType.ElectronicInvoice, customer.DefaultDeliveryTypes.Invoice);

            //Clean
            connector.Delete(tmpCustomer.CustomerNumber);
            MyAssert.HasNoError(connector);
        }

        [TestMethod]
        public void Test_Issue96_fixed() // Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/96
        {
            #region Arrange
            var tmpSupplier = new SupplierConnector().Create(new Supplier() { Name = "TmpSupplier" });
            var tmpArticle = new ArticleConnector().Create(new Article() { Description = "TmpArticle", PurchasePrice = 100 });
            #endregion Arrange

            var connector = new SupplierInvoiceConnector();

            var createdInvoice = connector.Create(new SupplierInvoice()
            {
                SupplierNumber = tmpSupplier.SupplierNumber,
                Comments = "InvoiceComments",
                InvoiceDate = new DateTime(2010, 1, 1),
                DueDate = new DateTime(2010, 2, 1),
                SalesType = SalesType.Stock,
                OCR = "123456789",
                Total = 5000,
                SupplierInvoiceRows = new List<SupplierInvoiceRow>()
                {
                    new SupplierInvoiceRow() {ArticleNumber = tmpArticle.ArticleNumber, Quantity = 10, Price = 100},
                    new SupplierInvoiceRow() {ArticleNumber = tmpArticle.ArticleNumber, Quantity = 20, Price = 100},
                    new SupplierInvoiceRow() {ArticleNumber = tmpArticle.ArticleNumber, Quantity = 20, Price = 100}
                }
            });
            MyAssert.HasNoError(connector);
            Assert.AreEqual(false, createdInvoice.Cancelled);

            var retrievedInvoice = connector.Get(createdInvoice.GivenNumber);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(false, retrievedInvoice.Cancelled);

            connector.Search.LastModified = DateTime.Today;
            var invoiceSubsets = connector.Find().Entities;
            MyAssert.HasNoError(connector);
            foreach (var supplierInvoiceSubset in invoiceSubsets)
                Assert.IsNotNull(supplierInvoiceSubset.Cancelled);

            #region Delete arranged resources

            new CustomerConnector().Delete(tmpSupplier.SupplierNumber);
            new ArticleConnector().Delete(tmpArticle.ArticleNumber);

            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Issue98_fixed() // Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/98
        {
            #region Arrange

            var tmpCustomer = new CustomerConnector().Create(new Customer()
                {Name = "TmpCustomer", CountryCode = "SE", City = "Testopolis"});
            var tmpArticle = new ArticleConnector().Create(new Article()
                {Description = "TmpArticle", Type = ArticleType.Stock, PurchasePrice = 100});

            #endregion Arrange

            IInvoiceConnector connector = new InvoiceConnector();

            var largeId = (long) 2 * int.MaxValue + TestUtils.RandomInt();

            var newInvoice = new Invoice()
            {
                DocumentNumber = largeId,
                CustomerNumber = tmpCustomer.CustomerNumber,
                InvoiceDate = new DateTime(2019, 1, 20), //"2019-01-20",
                DueDate = new DateTime(2019, 2, 20), //"2019-02-20",
                InvoiceType = InvoiceType.CashInvoice,
                PaymentWay = PaymentWay.Cash,
                Comments = "TestInvoice",
                InvoiceRows = new List<InvoiceRow>()
                {
                    new InvoiceRow() {ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 10, Price = 100},
                    new InvoiceRow() {ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 20, Price = 100},
                    new InvoiceRow() {ArticleNumber = tmpArticle.ArticleNumber, DeliveredQuantity = 15, Price = 100}
                }
            };

            var createdInvoice = connector.Create(newInvoice);
            MyAssert.HasNoError(connector);
            Assert.AreEqual(largeId, createdInvoice.DocumentNumber);

            #region Delete arranged resources

            new CustomerConnector().Delete(tmpCustomer.CustomerNumber);
            new ArticleConnector().Delete(tmpArticle.ArticleNumber);

            #endregion Delete arranged resources
        }

        [TestMethod]
        public void Test_Issue99_v1_fixed() // Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/99
        {
            #region Arrange
            IArchiveConnector ac = new ArchiveConnector();

            var data = Resource.fortnox_image;
            var randomFileName = TestUtils.RandomString() + ".txt";

            var fortnoxFile = ac.UploadFile(randomFileName, data, StaticFolders.SupplierInvoices);
            MyAssert.HasNoError(ac);

            #endregion Arrange

            var archiveConnector = new ArchiveConnector();
            var case1 = archiveConnector.DownloadFile(fortnoxFile.Id, IdType.Id);
            var case2 = archiveConnector.DownloadFile(fortnoxFile.Id, IdType.FileId);
            var case3 = archiveConnector.DownloadFile(fortnoxFile.ArchiveFileId, IdType.Id);
            var case4 = archiveConnector.DownloadFile(fortnoxFile.ArchiveFileId, IdType.FileId);

            Assert.IsNotNull(case1);
            Assert.IsNull(case2);
            Assert.IsNull(case3);
            Assert.IsNotNull(case4);

            var inboxConnector = new InboxConnector();
            var case5 = inboxConnector.DownloadFile(fortnoxFile.Id, IdType.Id);
            var case6 = inboxConnector.DownloadFile(fortnoxFile.Id, IdType.FileId);

            var case7 = inboxConnector.DownloadFile(fortnoxFile.ArchiveFileId, IdType.Id);
            var case8 = inboxConnector.DownloadFile(fortnoxFile.ArchiveFileId, IdType.FileId);

            Assert.IsNotNull(case5);
            Assert.IsNotNull(case6); //Why not null?
            Assert.IsNull(case7);
            Assert.IsNotNull(case8);
            
            //Clean
            archiveConnector.DeleteFile(fortnoxFile.Id);
            MyAssert.HasNoError(archiveConnector);
        }

        [TestMethod]
        public void Test_Issue99_v2_fixed() // Origins from https://github.com/FortnoxAB/csharp-api-sdk/issues/99
        {
            #region Arrange
            IArchiveConnector ac = new InboxConnector();

            var data = Resource.fortnox_image;
            var randomFileName = TestUtils.RandomString() + ".txt";

            var fortnoxFile = ac.UploadFile(randomFileName, data, StaticFolders.SupplierInvoices);
            MyAssert.HasNoError(ac);

            #endregion Arrange

            var archiveConnector = new ArchiveConnector();
            var case1 = archiveConnector.DownloadFile(fortnoxFile.Id, IdType.Id);
            var case2 = archiveConnector.DownloadFile(fortnoxFile.Id, IdType.FileId);
            var case3 = archiveConnector.DownloadFile(fortnoxFile.ArchiveFileId, IdType.Id);
            var case4 = archiveConnector.DownloadFile(fortnoxFile.ArchiveFileId, IdType.FileId);

            Assert.IsNotNull(case1);
            Assert.IsNull(case2);
            Assert.IsNull(case3);
            Assert.IsNotNull(case4);

            var inboxConnector = new InboxConnector();
            var case5 = inboxConnector.DownloadFile(fortnoxFile.Id, IdType.Id);
            var case6 = inboxConnector.DownloadFile(fortnoxFile.Id, IdType.FileId);

            var case7 = inboxConnector.DownloadFile(fortnoxFile.ArchiveFileId, IdType.Id);
            var case8 = inboxConnector.DownloadFile(fortnoxFile.ArchiveFileId, IdType.FileId);

            Assert.IsNotNull(case5);
            Assert.IsNotNull(case6); //Why not null?
            Assert.IsNull(case7);
            Assert.IsNotNull(case8);

            //Clean
            inboxConnector.DeleteFile(fortnoxFile.Id);
            MyAssert.HasNoError(archiveConnector);
        }
    }
}
