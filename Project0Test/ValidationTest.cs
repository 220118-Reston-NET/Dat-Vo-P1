using Xunit;
using ProjectModel;

namespace Project0test
{
    public class AddCustomerTest
    {
        [Fact]
        public void CustomerNameIsValid()
        {
            //Arrange
            CustomerModel cus = new CustomerModel();
            string validName = "John";

            //Act
            cus.name = validName;

            //Assert
            Assert.Equal(validName, cus.name);
        }
    }

    public class AddCustomerTest2
    {
        [Fact]
        public void CustomerNameIsValid()
        {
            //Arrange
            CustomerModel cus = new CustomerModel();
            string validName = "John";

            //Act
            cus.name = validName;

            //Assert
            Assert.NotNull(cus.name);
        }
    }

    public class AddItemTest
    {
        [Fact]
        public void ItemPriceCheck()
        {
        
            //Arrange
            ItemModel i = new ItemModel();
            string validName = "sprite";

            //Act
            i.ItemName = validName;

            //Assert
            Assert.Equal(validName, i.ItemName);

        }
    }

    public class AddItemTest2
    {
        [Fact]
        public void ItemPriceCheck()
        {
        
            //Arrange
            ItemModel i = new ItemModel();
            string validName = "sprite";

            //Act
            i.ItemName = validName;

            //Assert
            Assert.NotNull(i.ItemName);

        }
    }

    public class SFcheck
    {
        [Fact]
        public void StoreFrontCheck()
        {
            //Arrange 
            StoreFrontModel s = new StoreFrontModel();
            string validName = "Texas Chain";

            //Act
            s.Name = validName;

            //Assert
            Assert.Equal(validName, s.Name);
        }
    }

    public class SFcheck2
    {
        [Fact]
        public void StoreFrontCheck()
        {
            //Arrange 
            StoreFrontModel s = new StoreFrontModel();
            string validName = "Texas Chain";

            //Act
            s.Name = validName;

            //Assert
            Assert.NotNull(s.Name);
        }
    }


    public class AddEmployeeTest
    {
        [Fact]
        public void CustomerName()
        {
            //Arrange 
            EmployeeModel s = new EmployeeModel();
            string validName = "Texas Chain";

            //Act
            s.name = validName;

            //Assert
            Assert.Equal(validName, s.name);
        }
    }
    public class AddEmployeeTest2
    {
        [Fact]
        public void CustomerName()
        {
            //Arrange 
            EmployeeModel s = new EmployeeModel();
            string validName = "Texas Chain";

            //Act
            s.name = validName;

            //Assert
            Assert.NotNull(s.name);
        }
    }

    public class StoreLocation
    {
        [Fact]
        public void StoreFrontCheck()
        {
            //Arrange 
            StoreFrontModel s = new StoreFrontModel();
            string validLocation = "Texas Chain";

            //Act
            s.Location = validLocation;

            //Assert
            Assert.NotNull(s.Location);
            
        }
    }
    public class StoreLocation2
    {
        [Fact]
        public void StoreFrontCheck()
        {
            //Arrange 
            StoreFrontModel s = new StoreFrontModel();
            string validLocation = "Texas Chain";

            //Act
            s.Location = validLocation;

            //Assert
            Assert.Equal(validLocation, s.Location);
            
        }
    }
}