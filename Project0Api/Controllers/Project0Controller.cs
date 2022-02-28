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

        // GET: api/Project0/5
        [HttpGet("GetCustomerByName/{CustomerName}")]
        public IActionResult GetCustomer(string CustomerName)
        {
            try
            {
                List<CustomerModel> Result = _projectBL.SearchCustomer(CustomerName);
                if(Result.Count() == 0)
                {
                    throw new Exception("Customer Not Found");
                }
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
                return Conflict("Select a store first");
            }
        }

       
        [HttpGet("GetOrders")]
        public IActionResult GetOrders(string? sortby, OrderSort type)
        {

            List<OrderDetailsForAPIModel> Result = new List<OrderDetailsForAPIModel>();
            OrderDetailsForAPIModel OrderDetails = new OrderDetailsForAPIModel();
        
            try
            {
                if (CurrentCustomer.currentcustomer.name != "")
                {
                    
                    List<OrderModel> listOfOrders = _projectBL.GetAllOrder(CurrentCustomer.currentcustomer.customerID);
                    List<OrderItemModel> listOfOrderItems = new List<OrderItemModel>();
                    if (sortby == "DateTime")
                    {
                        listOfOrders = listOfOrders.OrderBy(o=>o.datetimeoforder).ToList();
                    }
                    else if (sortby == "Cost")
                    {
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
                    List<OrderModel> listOfOrders = _projectBL.GetAllOrder();
                    List<OrderItemModel> listOfOrderItems = new List<OrderItemModel>();
                    if (sortby == "DateTime")
                    {
                        listOfOrders = listOfOrders.OrderBy(o=>o.datetimeoforder).ToList();
                    }
                    else if (sortby == "Cost")
                    {
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
                    return Conflict();
                }
                else 
                {
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
                { List<OrderDetailsForAPIModel> Result = new List<OrderDetailsForAPIModel>();
                OrderDetailsForAPIModel OrderDetails = new OrderDetailsForAPIModel();
                List<OrderModel> listOfOrders = _projectBL.GetAllOrder();
                List<OrderItemModel> listOfOrderItems = new List<OrderItemModel>();
                if (sortby == "DateTime")
                {
                    listOfOrders = listOfOrders.Where(order => order.storeID == CurrentCustomer.currentstore.storeID).ToList();
                    listOfOrders = listOfOrders.OrderBy(o=>o.datetimeoforder).ToList();
                }
                else if (sortby == "Cost")
                {
                    //from x in Items.ToList() where(x.Code.ToLower().Contains("a")) select x
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
                return Ok(_projectBL.AddCustomer(new_customer));
            }
            catch (System.Exception)
            {
                return NotFound();
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
                    CurrentCustomer.SetCustomer(customer);
                }
                else
                {
                    return Conflict();
                }
                return Ok(customer);
            }
            else if (EmployeeOrCustomer == "Employee")
            {
                EmployeeModel employee = _projectBL.GetEmployeeByID(UserID);
                if (Password == employee.password)
                {
                    CurrentCustomer.SetEmployee(employee);
                }
                else
                {
                    return Conflict();
                }
                return Ok(employee);
            }
            else
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
                return Ok(CurrentCustomer.currentstore);
            }
            else 
            {
                CurrentCustomer.SetStoreFront(_projectBL.SearchStoreFront(storeID));
                CurrentCustomer.clearcart();

                return Ok(CurrentCustomer.currentstore);
            }
        }

        [HttpPut("AddToCart/{itemID}/{quantity}")] 
        public IActionResult Put(int itemID, int quantity)
        {
            if(CurrentCustomer.currentcustomer.name == "")
            {
                return Conflict("Not Logged In");
            }
            if(CurrentCustomer.currentstore.Name is null)
            {
                return Conflict("Store Not Selected");
            }
            else 
            {
                List<object> Cart = new List<object>(); 
                CurrentCustomer.currentcart.Add(_projectBL.GetItem(itemID));
                CurrentCustomer.currentcartquantity.Add(quantity);
                Cart.Add(CurrentCustomer.currentcart);
                Cart.Add(CurrentCustomer.currentcartquantity);
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
                return Ok();
            }
            else
            {
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
                return Ok();
            }
            catch(System.Exception)
            {
                return Conflict();
            }
        }


    }
}
