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

    }
}