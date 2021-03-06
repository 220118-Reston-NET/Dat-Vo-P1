using Xunit;
using ProjectBL;
using Moq;
using ProjectDL;
using ProjectModel;
using System.Collections.Generic;
using System;


namespace Project0test
{
    public class EmployeeFunctionTest
    {
        [Fact]
        public void GetAllEmployeeTest()
        {
            //Arrange
            string testName = "test name";
            string testEmail = "test@email.com";
            EmployeeModel TestEmployee = new EmployeeModel()
            {
                name = testName,
                email = testEmail
            };

            List<EmployeeModel> expectedEmployeeList = new List<EmployeeModel>();
            expectedEmployeeList.Add(TestEmployee);

            Mock<IRepository> mockRepo = new Mock<IRepository>();
            mockRepo.Setup(repo => repo.GetAllEmployee()).Returns(expectedEmployeeList);
            IProjectBL projectBL = new ProjectBLc(mockRepo.Object);

            //Act
            List<EmployeeModel> actualListOfEmployee = projectBL.GetAllEmployee();

            //Assert
            Assert.Same(expectedEmployeeList, actualListOfEmployee); 
            Assert.Equal(testName, actualListOfEmployee[0].name); 
            Assert.Equal(testEmail, actualListOfEmployee[0].email); 
            Assert.NotNull(actualListOfEmployee[0].email);
            Assert.NotNull(actualListOfEmployee[0].name);
        }

  
        [Fact]
        public void AddEmployeeTest()
        {

            string testname = "Tim";
            string testemail = "Tim@email.com";

            EmployeeModel testEmployee = new EmployeeModel()
            {
                name = testname,
                email = testemail,
                number = "1234567890",
            };

            List<EmployeeModel> expectedListOfEmployee = new List<EmployeeModel>();

            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(repo => repo.AddEmployee(testEmployee)).Returns(testEmployee);            
            mockRepo.Setup(repo => repo.GetAllEmployee()).Returns(expectedListOfEmployee);

            IProjectBL projectBL = new ProjectBLc(mockRepo.Object);

            EmployeeModel E1 = projectBL.AddEmployee(testEmployee);

            Assert.Same(testEmployee, E1);
            Assert.Equal(testEmployee.name, E1.name);
            Assert.Equal(testEmployee.email,E1.email);
            Assert.NotNull(E1.email);
            Assert.NotNull(E1.name);
        }

        [Fact]
        public void RemoveEmployeeTest()
        {

            string testname = "Tim";
            string testemail = "Tim@email.com";

            EmployeeModel testEmployee = new EmployeeModel()
            {
                name = testname,
                email = testemail,
                number = "1234567890",
            };

            List<EmployeeModel> expectedListOfEmployee = new List<EmployeeModel>();

            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(repo => repo.AddEmployee(testEmployee)).Returns(testEmployee);            
            mockRepo.Setup(repo => repo.GetAllEmployee()).Returns(expectedListOfEmployee);

            IProjectBL projectBL = new ProjectBLc(mockRepo.Object);

            EmployeeModel E1 = projectBL.AddEmployee(testEmployee);
            projectBL.RemoveEmployee(testEmployee);


            bool result = (expectedListOfEmployee.Count == 1);
            Assert.False(result);
        }



    }

    public class CustomerFunctionTest
    {
        [Fact]
        public void AddCustomerTest()
        {

            string testname = "Tim";
            string testemail = "Tim@email.com";

            CustomerModel testCustomer = new CustomerModel()
            {
                name = testname,
                email = testemail,
                phonenumber = "1234567890",
                password = "123"
            };

            List<CustomerModel> expectedListOfCustomer= new List<CustomerModel>();

            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(repo => repo.AddCustomer(testCustomer)).Returns(testCustomer);            
            mockRepo.Setup(repo => repo.GetAllCustomer()).Returns(expectedListOfCustomer);

            IProjectBL projectBL = new ProjectBLc(mockRepo.Object);

            CustomerModel E1 = projectBL.AddCustomer(testCustomer);


            Assert.NotNull(E1.name);
            Assert.NotNull(E1.email);
            Assert.NotNull(E1.phonenumber);
            Assert.NotNull(E1.password);
            Assert.Same(testCustomer, E1);
            Assert.Equal(testCustomer.name, E1.name);
            Assert.Equal(testCustomer.email,E1.email);
            Assert.Equal(testCustomer.phonenumber,E1.phonenumber);
            Assert.Equal(testCustomer.password,E1.password);
        } 

        [Fact]
        public void AddCustomerTest2()
        {

            string testname = "Tim";
            string testemail = "Timemail.com";

            CustomerModel testCustomer = new CustomerModel()
            {
                name = testname,
                email = testemail,
                phonenumber = "1234567890",
                password = "123"
            };

            List<CustomerModel> expectedListOfCustomer= new List<CustomerModel>();

            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(repo => repo.AddCustomer(testCustomer)).Returns(testCustomer);            
            mockRepo.Setup(repo => repo.GetAllCustomer()).Returns(expectedListOfCustomer);

            IProjectBL projectBL = new ProjectBLc(mockRepo.Object);

            //CustomerModel E1 = projectBL.AddCustomer(testCustomer);

            
            Assert.Throws<System.Exception>( () => projectBL.AddCustomer(testCustomer));
        } 

        [Fact]
        public void AddCustomerTest3()
        {

            string testname = "Tim";
            string testemail = "Tim@email.com";

            CustomerModel testCustomer = new CustomerModel()
            {
                name = testname,
                email = testemail,
                phonenumber = "1234560",
                password = "123"
            };

            List<CustomerModel> expectedListOfCustomer= new List<CustomerModel>();

            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(repo => repo.AddCustomer(testCustomer)).Returns(testCustomer);            
            mockRepo.Setup(repo => repo.GetAllCustomer()).Returns(expectedListOfCustomer);

            IProjectBL projectBL = new ProjectBLc(mockRepo.Object);

            Assert.Throws<System.Exception>( () => projectBL.AddCustomer(testCustomer));
        } 
        [Fact]
        public void AddCustomerTest4()
        {

            string testname = "Tim";
            string testemail = "Timemail.com";

            CustomerModel testCustomer = new CustomerModel()
            {
                name = testname,
                email = testemail,
                phonenumber = "1560",
                password = "123"
            };

            List<CustomerModel> expectedListOfCustomer= new List<CustomerModel>();

            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(repo => repo.AddCustomer(testCustomer)).Returns(testCustomer);            
            mockRepo.Setup(repo => repo.GetAllCustomer()).Returns(expectedListOfCustomer);

            IProjectBL projectBL = new ProjectBLc(mockRepo.Object);

            Assert.Throws<System.Exception>( () => projectBL.AddCustomer(testCustomer));
        } 


        [Fact]
        public void SearchCustomerTest()
        {
            string Tname = "fake name";
            string Tnumber = "1234567890";
            string Temail = "T@gmail.com";
            string Tpass = "123";
            
            CustomerModel TestCustomer = new CustomerModel()
            {
                customerID = 0,
                name = Tname,
                phonenumber = Tnumber,
                email = Temail,
                password = Tpass
            };
            List<CustomerModel> listofCustomer = new List<CustomerModel>();
            List<CustomerModel> expectedList = new List<CustomerModel>();
            
            Mock<IRepository> mockRepo = new Mock<IRepository>();
            mockRepo.Setup(repo => repo.AddCustomer(TestCustomer)).Returns(TestCustomer); 
            mockRepo.Setup(repo => repo.GetAllCustomer()).Returns(listofCustomer);

            IProjectBL projectBL = new ProjectBLc(mockRepo.Object);
            CustomerModel E1 = projectBL.AddCustomer(TestCustomer);
            List<CustomerModel> Tcus = projectBL.SearchCustomer(TestCustomer.name);
            
            Assert.Equal(expectedList.Count, Tcus.Count); 

        }

    }

    public class OrderFunctionTest
    {
        [Fact]
        public void GetAllOrderTest()
        {
            //Arrange
            decimal a = 1.5m;
            int b = 1;
            int c = 1;
            OrderModel TestOrder = new OrderModel()
            {
                TotalPrice = a,
                customerID = b,      
                storeID = c,
            };

            List<OrderModel> expectedOrderList = new List<OrderModel>();
            expectedOrderList.Add(TestOrder);

            Mock<IRepository> mockRepo = new Mock<IRepository>();
            mockRepo.Setup(repo => repo.GetAllOrder()).Returns(expectedOrderList);
            IProjectBL projectBL = new ProjectBLc(mockRepo.Object);

            //Act
            List<OrderModel> actualListOfOrder = projectBL.GetAllOrder();

            //Assert
            Assert.Same(expectedOrderList, actualListOfOrder); 
            Assert.NotNull(actualListOfOrder[0].TotalPrice);
            Assert.NotNull(actualListOfOrder[0].customerID);
            Assert.NotNull(actualListOfOrder[0].storeID);
            Assert.Equal(a, actualListOfOrder[0].TotalPrice); 
            Assert.Equal(b, actualListOfOrder[0].customerID); 
            Assert.Equal(c, actualListOfOrder[0].storeID); 
        }

        [Fact]
        public void AddOrderTest()
        {
            //Arrange
            Mock<IRepository> mockRepo = new Mock<IRepository>();
            OrderModel Omodel = new OrderModel();
            decimal a = 1.5m;
            int b = 1;
            int c = 3;
            int d = 2;
            DateTime today = DateTime.Now;

            OrderModel TestOrder = new OrderModel()
            {
                TotalPrice = a,
                customerID = b,      
                storeID = c,
                orderID=d,
                datetimeoforder = today
            };

            mockRepo.Setup(repo => repo.AddOrder(TestOrder)).Returns(TestOrder);

            //Act
            IProjectBL projectBL = new ProjectBLc(mockRepo.Object);

            //Assert 
            Assert.Throws<System.NullReferenceException>( () => projectBL.AddOrder(TestOrder));

        }


    }

    public class itemfunctionTest
    {
        [Fact]
        public void GetItemtest()
        {
            string a = "a";
            string b = "b";
            decimal TP = 1.5m;
            string c = "c";
            ItemModel testItem = new ItemModel()
            {
                ItemID = 0,
                ItemName = a,
                ItemPrice = TP,
                ItemCategory = c, 
                ItemDescription = a
            };
            Mock<IRepository> mockRepo = new Mock<IRepository>();
            mockRepo.Setup(repo => repo.GetItem(testItem.ItemID)).Returns(testItem);

            IProjectBL projectBL = new ProjectBLc(mockRepo.Object);
            ItemModel Imodel = projectBL.GetItem(0);

            Assert.Same(testItem, Imodel); 
            Assert.NotNull(Imodel.ItemID); 
            Assert.NotNull(Imodel.ItemName); 
            Assert.NotNull(Imodel.ItemPrice); 
            Assert.NotNull(Imodel.ItemCategory); 
            Assert.NotNull(Imodel.ItemDescription); 
            
        } 


    }

    public class StoreFrontTest
    {
        [Fact]
        public void SearchStoreFrontTest()
        {
            int ID = 0;
            string Tname = "name";
            string location = "location";

            StoreFrontModel TestStore = new StoreFrontModel()
            {
                storeID = ID,
                Name = Tname,
                Location = location
            };

            Mock<IRepository> mockRepo = new Mock<IRepository>();
            mockRepo.Setup(repo => repo.SearchStoreByID(TestStore.storeID)).Returns(TestStore);

            IProjectBL projectBL = new ProjectBLc(mockRepo.Object);
            StoreFrontModel Smodel = projectBL.SearchStoreFront(0);

            Assert.Same(TestStore, Smodel); 
            Assert.NotNull(Smodel.storeID); 
            Assert.NotNull(Smodel.Name); 
            Assert.NotNull(Smodel.Location); 


        }
    }

    public class InventoryFunctionTest
    {
        [Fact]
        public void GetAllInventoryTest()
        {
            int TstoreID = 1;
            int TitemID = 1;
            int Tquantity = 1;
            InventoryModel TestInventory = new InventoryModel()
            {
                storeID = TstoreID,
                itemID = TitemID,
                quantity = Tquantity
                
            };
            List<InventoryModel> expectedListOfInventory = new List<InventoryModel>();
            expectedListOfInventory.Add(TestInventory);

            Mock<IRepository> mockRepo = new Mock<IRepository>();
            mockRepo.Setup(repo => repo.GetAllInventory()).Returns(expectedListOfInventory);

            IProjectBL projectBL = new ProjectBLc(mockRepo.Object);
            
            List<InventoryModel> actualListOfInventory = projectBL.GetAllInventory();

            Assert.Same(expectedListOfInventory,actualListOfInventory);
            Assert.NotNull(actualListOfInventory[0].storeID); 
            Assert.NotNull(actualListOfInventory[0].itemID); 
            Assert.NotNull(actualListOfInventory[0].quantity); 
        }
        

        [Fact]
        public void UpdateInventoryTest()
        {
            int TstoreID = 1;
            int TitemID = 1;
            int Tquantity = 1;
            InventoryModel TestInventory = new InventoryModel()
            {
                storeID = TstoreID,
                itemID = TitemID,
                quantity = Tquantity
                
            };

            InventoryModel TestInventory2 = new InventoryModel()
            {
                storeID = 1,
                itemID = 1,
                quantity = 99
            };
            List<InventoryModel> expectedListOfInventory = new List<InventoryModel>();
            expectedListOfInventory.Add(TestInventory);
            InventoryModel actualListOfInventory = new InventoryModel();


            Mock<IRepository> mockRepo = new Mock<IRepository>();
            mockRepo.Setup(repo => repo.GetAllInventory()).Returns(expectedListOfInventory);
            mockRepo.Setup(repo => repo.UpdateInventory(TestInventory2)).Returns(actualListOfInventory);
            IProjectBL projectBL = new ProjectBLc(mockRepo.Object);
            


            actualListOfInventory = projectBL.UpdateInventory(TestInventory2);
            expectedListOfInventory = projectBL.GetAllInventory();

            bool Result = (actualListOfInventory.quantity == TestInventory.quantity);

            //Assert.Same(expectedListOfInventory,actualListOfInventory);
            Assert.False(Result);
        }

        [Fact]
        public void SearchInventoryByStoreIDTest()
        {
            int TstoreID = 1;
            int TitemID = 1;
            int Tquantity = 1;
            InventoryModel TestInventory = new InventoryModel()
            {
                storeID = TstoreID,
                itemID = TitemID,
                quantity = Tquantity
                
            };
            List<InventoryModel> expectedListOfInventory = new List<InventoryModel>();
            expectedListOfInventory.Add(TestInventory);

            Mock<IRepository> mockRepo = new Mock<IRepository>();
            //mockRepo.Setup(repo => repo.GetAllInventory()).Returns(expectedListOfInventory);
            mockRepo.Setup(repo => repo.SearchInventoryByStoreID(TestInventory.storeID)).Returns(expectedListOfInventory);

            IProjectBL projectBL = new ProjectBLc(mockRepo.Object);
            
            List<InventoryModel> actualListOfInventory = projectBL.GetAllInventory();

            InventoryModel result = projectBL.SearchInventoryByStoreID(TestInventory.storeID)[0];

            Assert.Equal(result.storeID,TestInventory.storeID);
        }


    }

    public class OrderItemsTest
    {
        //[Fact]
        // public void AddOrderItemtest()
        // {
        //     decimal a = 1.5m;
        //     int b = 1;
        //     int c = 1;
        //     OrderModel TestOrder = new OrderModel()
        //     {
        //         TotalPrice = a,
        //         customerID = b,      
        //         storeID = c,
        //     };

        //     List<OrderModel> expectedOrderList = new List<OrderModel>();
        //     expectedOrderList.Add(TestOrder);

        //     Mock<IRepository> mockRepo = new Mock<IRepository>();
        //     mockRepo.Setup(repo => repo.GetAllOrder()).Returns(expectedOrderList);
        //     IProjectBL projectBL = new ProjectBLc(mockRepo.Object);

        //     projectBL.AddOrder();
        //     // bool Result = OI is not null;
        //     // Assert.False(Result);
        //     //Assert.Throws<System.Exception>( () => projectBL.AddOrderItem() is not void);

        // }
    }

    




}