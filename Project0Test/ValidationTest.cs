using Xunit;
using ProjectModel;

namespace Project0test
{
    public class CustomerTest
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

    public class CustomerTest2
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

    public class ItemTest
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

    public class ItemTest2
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


    public class EmployeeTest
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
    public class EmployeeTest2
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

    public class ModelTest
    {   [Fact]
        public void Inventory()
        {
            //Arrange 
            InventoryModel s = new InventoryModel();
            int valid = 2;

            //Act
            s.itemID = valid;

            //Assert
            Assert.Equal(valid, s.itemID);
            
        }

        [Fact]
        public void Inventory2()
        {
            //Arrange 
            InventoryModel s = new InventoryModel();
            int valid = 2;

            //Act
            s.storeID = valid;

            //Assert
            Assert.Equal(valid, s.storeID);
            
        }
    }
    
}