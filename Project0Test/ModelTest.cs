using Xunit;
using ProjectModel;

namespace Project0test
{
    public class CustomerTest
    {
        [Fact]
        public void CustomerName()
        {
            //Arrange
            CustomerModel cus = new CustomerModel();
            string validName = "John";

            //Act
            cus.name = validName;

            //Assert
            Assert.Equal(validName, cus.name);
        }

        [Fact]
        public void CustomerNumber()
        {
            //Arrange
            CustomerModel cus = new CustomerModel();
            string valid = "1234567890";

            //Act
            cus.phonenumber = valid;

            //Assert
            Assert.Equal(valid, cus.phonenumber);
        }

        [Fact]
        public void CustomerEmail()
        {
            //Arrange
            CustomerModel cus = new CustomerModel();
            string valid = "1234567890@email.com";

            //Act
            cus.email = valid;

            //Assert
            Assert.Equal(valid, cus.email);
        }
        [Fact]
        public void CustomerID()
        {
            //Arrange
            CustomerModel cus = new CustomerModel();
            int valid = 0;

            //Act
            cus.customerID = valid;

            //Assert
            Assert.Equal(valid, cus.customerID);
        }

    }


    public class ItemModelTest
    {
        [Fact]
        public void ItemNameCheck()
        {
        
            //Arrange
            ItemModel i = new ItemModel();
            string validName = "sprite";

            //Act
            i.ItemName = validName;

            //Assert
            Assert.Equal(validName, i.ItemName);

        }

        [Fact]
        public void ItemPriceCheck()
        {
        
            //Arrange
            ItemModel i = new ItemModel();
            decimal valid = 1.5m;

            //Act
            i.ItemPrice  = valid;

            //Assert
            Assert.Equal(valid, i.ItemPrice);

        }

        [Fact]
        public void ItemCatCheck()
        {
        
            //Arrange
            ItemModel i = new ItemModel();
            string valid = "Category";

            //Act
            i.ItemCategory = valid;

            //Assert
            Assert.Equal(valid, i.ItemCategory);

        }

        [Fact]
        public void ItemDescCheck()
        {
        
            //Arrange
            ItemModel i = new ItemModel();
            string valid = "Description";

            //Act
            i.ItemDescription = valid;

            //Assert
            Assert.Equal(valid, i.ItemDescription);

        }
        
    }


    public class EmployeeModelTest
    {
        [Fact]
        public void Name()
        {
            //Arrange 
            EmployeeModel s = new EmployeeModel();
            string validName = "Texas Chain";

            //Act
            s.name = validName;

            //Assert
            Assert.Equal(validName, s.name);
        }

        [Fact]
        public void number()
        {
            //Arrange 
            EmployeeModel s = new EmployeeModel();
            string valid = "1234567890";

            //Act
            s.number = valid;

            //Assert
            Assert.Equal(valid, s.number);
        }

        [Fact]
        public void email()
        {
            //Arrange 
            EmployeeModel s = new EmployeeModel();
            string valid = "something@email.com";

            //Act
            s.email = valid;

            //Assert
            Assert.Equal(valid, s.email);
        }

    }


    public class StoreModel
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

        [Fact]
        public void StoreFrontCheck2()
        {
            //Arrange 
            StoreFrontModel s = new StoreFrontModel();
            string validLocation = "Texas";

            //Act
            s.Location = validLocation;

            //Assert
            Assert.Equal(validLocation, s.Location);
            
        }
        [Fact]
        public void StoreFrontCheck3()
        {
            //Arrange 
            StoreFrontModel s = new StoreFrontModel();
            int valid = 1;

            //Act
            s.storeID = valid;

            //Assert
            Assert.NotNull(s.storeID);
        }
    }

    public class InventoryModelTest
    {   
        [Fact]
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

        [Fact]
        public void Inventory3()
        {
            //Arrange 
            InventoryModel s = new InventoryModel();
            int valid = 3;

            //Act
            s.quantity = valid;

            //Assert
            Assert.Equal(valid, s.quantity);
            
        }
    }

    public class OrderItemModelTest
    {
        [Fact]
        public void OrderID()
        {
            //Arrange 
            OrderItemModel s = new OrderItemModel();
            int valid = 2;

            //Act
            s.orderID = valid;

            //Assert
            Assert.Equal(valid, s.orderID);
            
        }
        [Fact]
        public void ItemID()
        {
            //Arrange 
            OrderItemModel s = new OrderItemModel();
            int valid = 2;

            //Act
            s.itemID = valid;

            //Assert
            Assert.Equal(valid, s.itemID);
            
        }
    }

    
}