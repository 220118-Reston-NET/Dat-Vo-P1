using Xunit;
using ProjectBL;
using Moq;
using ProjectDL;
using ProjectModel;
using System.Collections.Generic;


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
            };

            List<CustomerModel> expectedListOfCustomer= new List<CustomerModel>();

            Mock<IRepository> mockRepo = new Mock<IRepository>();

            mockRepo.Setup(repo => repo.AddCustomer(testCustomer)).Returns(testCustomer);            
            mockRepo.Setup(repo => repo.GetAllCustomer()).Returns(expectedListOfCustomer);

            IProjectBL projectBL = new ProjectBLc(mockRepo.Object);

            CustomerModel E1 = projectBL.AddCustomer(testCustomer);

            Assert.Same(testCustomer, E1);
            Assert.Equal(testCustomer.name, E1.name);
            Assert.Equal(testCustomer.email,E1.email);
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
            Assert.Equal(a, actualListOfOrder[0].TotalPrice); 
            Assert.Equal(b, actualListOfOrder[0].customerID); 
            Assert.Equal(c, actualListOfOrder[0].storeID); 
        }

        // [Fact]
        // public void AddOrderTest()
        // {
        //     //Arrange
        //     Mock<IRepository> mockRepo = new Mock<IRepository>();
        //     decimal a = 1.5m;
        //     int b = 1;
        //     int c = 1;

        //     OrderModel TestOrder = new OrderModel()
        //     {
        //         TotalPrice = a,
        //         customerID = b,      
        //         storeID = c
        //     };

        //     mockRepo.Setup(repo => repo.AddOrder(TestOrder)).Returns(TestOrder);

        //     //Act
        //     IProjectBL projectBL = new ProjectBLc(mockRepo.Object);
        //     OrderModel Omodel = projectBL.AddOrder(TestOrder);

        //     //Assert
        //     Assert.Same(TestOrder, Omodel); 
        //     Assert.Equal(TestOrder.TotalPrice, Omodel.TotalPrice); 
        //     Assert.Equal(TestOrder.customerID, Omodel.customerID); 
        //     Assert.Equal(TestOrder.storeID, Omodel.storeID); 

        // }


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
            
        } 
    }





}