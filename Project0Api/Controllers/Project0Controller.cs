using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ProjectModel;
using ProjectBL;
using ModelApi;

namespace Project0Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Project0Controller : ControllerBase
    {
        private IProjectBL _projectBL;
        private IMemoryCache _memoryCache;

        public Project0Controller(IProjectBL p_projectBL, IMemoryCache p_memoryCache)
        {
            _projectBL = p_projectBL;
            _memoryCache = p_memoryCache;
        }


        // GET: api/Project0
        // [HttpGet("Get All")]
        // public IEnumerable<string> GetAllCustomer()
        // {
        //     return new string[] { "value1", "value2" };
        // }


        [HttpGet("GetAllEmployee")]
        public IActionResult GetAllEmployee()
        {
            try
            {

                return Ok(_projectBL.GetAllEmployee());
            }
            catch (System.Exception e)
            {
                return Conflict(e.Message);
            }
        }
        
        // GET: api/Project0/5
        [HttpGet("GetCustomerByName/{CustomerName}")]
        public IActionResult GetCustomer(string CustomerName)
        {
            try
            {
                List<CustomerModel> Result = _projectBL.SearchCustomer(CustomerName);
                if(Result.Count() == 0)
                {
                    Log.Information("Fail to find Customer");
                    throw new Exception("Customer Not Found");
                }
                Log.Information("Customer(s) found");
                return Ok(Result);
            }
            catch (System.Exception e)
            {
                return Conflict(e.Message);
            }
        }

       [HttpGet("DisplayInventory/")]
       public IActionResult DisplayInventory()
        {
            if(!(CurrentCustomer.currentstore is null))
            {
                List<InventoryDetailsForAPIModel> Result = new List<InventoryDetailsForAPIModel>();
                InventoryDetailsForAPIModel IDFAPI = new InventoryDetailsForAPIModel();
                List<InventoryModel> listOfInventory = _projectBL.SearchInventoryByStoreID(CurrentCustomer.currentstore.storeID);
                Log.Information("Displaying Inventory");
                foreach(var inven in listOfInventory)
                {
                    IDFAPI = new InventoryDetailsForAPIModel();
                    IDFAPI.item = _projectBL.GetItem(inven.itemID);
                    IDFAPI.quantityAvailable = inven.quantity;
                    Result.Add(IDFAPI);

                }
                return Ok(Result);
            }
            else
            {
                Log.Information("Request to display inventory failed");
                return Conflict("Select a store first");
            }
        }

       
        [HttpGet("GetOrders")]
        public IActionResult GetOrders(string? sortby)
        {

            List<OrderDetailsForAPIModel> Result = new List<OrderDetailsForAPIModel>();
            OrderDetailsForAPIModel OrderDetails = new OrderDetailsForAPIModel();
        
            try
            {
                if (CurrentCustomer.currentcustomer.name != "")
                {
                    Log.Information("Displaying Customer's order(s)");
                    List<OrderModel> listOfOrders = _projectBL.GetAllOrder(CurrentCustomer.currentcustomer.customerID);
                    List<OrderItemModel> listOfOrderItems = new List<OrderItemModel>();
                    if (sortby == "DateTime")
                    {
                        Log.Information("sorting order by DateTime");
                        listOfOrders = listOfOrders.OrderBy(o=>o.datetimeoforder).ToList();
                    }
                    else if (sortby == "Cost")
                    {
                        Log.Information("sorting order by Cost");
                        listOfOrders = listOfOrders.OrderBy(o=>o.TotalPrice).ToList();
                    }


                    foreach(var Order in listOfOrders)
                    {   OrderDetails = new OrderDetailsForAPIModel();
                        listOfOrderItems = _projectBL.SearchOrderItem(Order.orderID);
                        OrderDetails.StoreName = _projectBL.SearchStoreFront(Order.storeID).Name;
                        OrderDetails.CustomerName = _projectBL.GetCustomer(Order.customerID).name;
                        OrderDetails.orderID = Order.orderID;
                        OrderDetails.TotalCost = Order.TotalPrice;
                        OrderDetails.DateTimeOfOrder = Order.datetimeoforder;
                        foreach(var OrderItem in listOfOrderItems)
                        {
                            OrderDetails.ItemList.Add(_projectBL.GetItem(OrderItem.itemID));
                            OrderDetails.QuantityList.Add(OrderItem.quantity);
                        }
                        Result.Add(OrderDetails);
                    }
                    
                    return Ok(Result);
                }
                else if(CurrentCustomer.currentemployee.name != "")
                {
                    Log.Information("Displaying all order(s)");
                    List<OrderModel> listOfOrders = _projectBL.GetAllOrder();
                    List<OrderItemModel> listOfOrderItems = new List<OrderItemModel>();
                    if (sortby == "DateTime")
                    {
                        Log.Information("Sorting Orders by DateTime");
                        listOfOrders = listOfOrders.OrderBy(o=>o.datetimeoforder).ToList();
                    }
                    else if (sortby == "Cost")
                    {
                        Log.Information("Sorting Orders by Cost");
                        listOfOrders = listOfOrders.OrderBy(o=>o.TotalPrice).ToList();

                    }
                    foreach(var Order in listOfOrders)
                    {   OrderDetails = new OrderDetailsForAPIModel();
                        listOfOrderItems = _projectBL.SearchOrderItem(Order.orderID);
                        OrderDetails.StoreName = _projectBL.SearchStoreFront(Order.storeID).Name;
                        OrderDetails.CustomerName = _projectBL.GetCustomer(Order.customerID).name;
                        OrderDetails.orderID = Order.orderID;
                        OrderDetails.TotalCost = Order.TotalPrice;
                        OrderDetails.DateTimeOfOrder = Order.datetimeoforder;
                        foreach(var OrderItem in listOfOrderItems)
                        {
                            OrderDetails.ItemList.Add(_projectBL.GetItem(OrderItem.itemID));
                            OrderDetails.QuantityList.Add(OrderItem.quantity);
                        }
                        Result.Add(OrderDetails);
                    }

                    return Ok(Result);
                }
                else if(CurrentCustomer.currentemployee.name == "" && CurrentCustomer.currentcustomer.name == "")
                {
                    Log.Information("Request to display orders failed (user is not logged in)");
                    return Conflict();
                }
                else 
                {
                    Log.Information("Request to display orders failed");
                    return Conflict();
                }
                
            }
            catch (System.Exception)
            {
                return Conflict();
            }
        }

        [HttpGet("GetOrderOfCurrentStore/{sortby}")]
        public IActionResult GetOrderOfStore(string? sortby)
        {
            try
            { 
                Log.Information("Displaying order(s) of current store");
                List<OrderDetailsForAPIModel> Result = new List<OrderDetailsForAPIModel>();
                OrderDetailsForAPIModel OrderDetails = new OrderDetailsForAPIModel();
                List<OrderModel> listOfOrders = _projectBL.GetAllOrder();
                List<OrderItemModel> listOfOrderItems = new List<OrderItemModel>();
                if (sortby == "DateTime")
                {
                    Log.Information("Sorting orders by DateTime");
                    listOfOrders = listOfOrders.Where(order => order.storeID == CurrentCustomer.currentstore.storeID).ToList();
                    listOfOrders = listOfOrders.OrderBy(o=>o.datetimeoforder).ToList();
                }
                else if (sortby == "Cost")
                {
                    Log.Information("Sorting orders by Cost");
                    listOfOrders = listOfOrders.Where(order => order.storeID == CurrentCustomer.currentstore.storeID).ToList();
                    listOfOrders = listOfOrders.OrderBy(o=>o.TotalPrice).ToList();

                }
                foreach(var Order in listOfOrders)
                {   OrderDetails = new OrderDetailsForAPIModel();
                    listOfOrderItems = _projectBL.SearchOrderItem(Order.orderID);
                    OrderDetails.StoreName = _projectBL.SearchStoreFront(Order.storeID).Name;
                    OrderDetails.CustomerName = _projectBL.GetCustomer(Order.customerID).name;
                    OrderDetails.orderID = Order.orderID;
                    OrderDetails.TotalCost = Order.TotalPrice;
                    OrderDetails.DateTimeOfOrder = Order.datetimeoforder;
                    foreach(var OrderItem in listOfOrderItems)
                    {
                        OrderDetails.ItemList.Add(_projectBL.GetItem(OrderItem.itemID));
                        OrderDetails.QuantityList.Add(OrderItem.quantity);
                    }
                    Result.Add(OrderDetails);
                }
                return Ok(Result);}
            catch
            {
                Log.Information("Request to display orders of current store failed");
                return Conflict();
            }

        }


        // POST: api/Project0
        [HttpPost("Registration")]
        public IActionResult Post([FromBody] CustomerModel new_customer)
        {
            try
            {
                //_projectBL.AddCustomer
                Log.Information("Adding new customer");
                return Ok(_projectBL.AddCustomer(new_customer));
            }
            catch (System.Exception)
            {
                Log.Information("Failed to add new customer");
                return Conflict();
            }
        }

        // PUT: api/Project0/5
        [HttpPut("Login/{EmployeeOrCustomer}/{UserID}/{Password}")]
        public IActionResult Put(string EmployeeOrCustomer, int UserID, string Password)
        {
            if (EmployeeOrCustomer == "Customer")
            {
                CustomerModel customer = _projectBL.GetCustomer(UserID);
                if (Password == customer.password)
                {
                    Log.Information("Successfully log in as customer");
                    CurrentCustomer.SetCustomer(customer);
                }
                else
                {
                    Log.Information("Failed to log in");
                    return Conflict();
                }
                return Ok(customer);
            }
            else if (EmployeeOrCustomer == "Employee")
            {
                EmployeeModel employee = _projectBL.GetEmployeeByID(UserID);
                if (Password == employee.password)
                {
                    Log.Information("Successfully log in as employee");
                    CurrentCustomer.SetEmployee(employee);
                }
                else
                {
                    Log.Information("Failed to log in");
                    return Conflict();
                }
                return Ok(employee);
            }
            else
                Log.Information("Failed to log in");
                return Conflict();
            
        }

        [HttpPut("SelectStore/")] 
        public IActionResult SelectStore(int? storeID)
        {
            if(storeID is null)
            {
                if(CurrentCustomer.currentstore is null)
                {
                    return Conflict("No store Selected");
                }
                Log.Information("Returning Current Store");
                return Ok(CurrentCustomer.currentstore);
            }
            else 
            {
                CurrentCustomer.SetStoreFront(_projectBL.SearchStoreFront(storeID));
                CurrentCustomer.clearcart();
                Log.Information("Store Selected");
                return Ok(CurrentCustomer.currentstore);
            }
        }

        [HttpPut("AddToCart/{itemID}/{quantity}")] 
        public IActionResult Put(int itemID, int quantity)
        {
            if(CurrentCustomer.currentcustomer.name == "")
            {
                Log.Information("Failed to add item to cart (user not logged in)");
                return Conflict("Not Logged In");
            }
            if(CurrentCustomer.currentstore.Name is null)
            {
                Log.Information("Failed to add item to cart (store not selected)");
                return Conflict("Store Not Selected");
            }
            else 
            {
                List<object> Cart = new List<object>(); 
                CurrentCustomer.currentcart.Add(_projectBL.GetItem(itemID));
                CurrentCustomer.currentcartquantity.Add(quantity);
                Cart.Add(CurrentCustomer.currentcart);
                Cart.Add(CurrentCustomer.currentcartquantity);
                Log.Information("Successfully added item to cart: x" +quantity + " of "+ _projectBL.GetItem(itemID).ItemName);
                return Ok(Cart);
            }
        }

        [HttpPut("UpdateInventory/")] 
        public IActionResult UpdateInventory(int itemID, int amount)
        {
            if(CurrentCustomer.currentemployee.name != "")
            {
                InventoryModel inven = new InventoryModel();
                inven.storeID = CurrentCustomer.currentstore.storeID;
                inven.itemID = itemID;
                inven.quantity = amount;
                _projectBL.UpdateInventory(inven);
                Log.Information("Inventory Updated: (" + _projectBL.SearchStoreFront(inven.storeID).Name +", "+_projectBL.GetItem(inven.itemID).ItemName +", "+ inven.quantity);
                return Ok();
            }
            else
            {
                Log.Information("Failed to update inventory (user not logged in)");
                return Conflict("Not Logged in");
            }
        }

        [HttpPut("PlaceOrder")] 
        public IActionResult PlaceOrder()
        {
            if(CurrentCustomer.currentcustomer.name == "")
            {
                return Conflict("Not Logged In");
            }
            if(CurrentCustomer.currentcart.Count() == 0)
            {
                return Conflict("Cart is Empty");
            }
            else
            {
                _projectBL.AddOrder(CurrentCustomer.currentOrder);
                _projectBL.AddOrderItem();
                return Ok();
            }
        }


        // DELETE: api/Project0/5
        [HttpDelete("LogOut")]
        public IActionResult Delete()
        {
            try
            {

                CurrentCustomer.LogOut();
                CurrentCustomer.clearcart();
                Log.Information("Logged out");

                return Ok();
            }
            catch(System.Exception)
            {
                Log.Information("Error occured while logging out");
                return Conflict();
            }
        }


    }
}
