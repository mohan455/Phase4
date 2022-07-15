using Joes_Pizza_Shop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Joes_Pizza_Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext db;
        public HomeController(DataContext context)
        {
            //DataContext object 
            db = context;
        }
       
        public IActionResult Index()
        {
            TheCart_OnLoad();
            //Show the products' contents for the customers
            var productsList = (from d in db.PizzaItems
                                select d).ToList();
            return View(productsList);
        }

        
        // Menu page
        public IActionResult Menu()
        {
            TheCart_OnLoad();

            //Show the products' contents for the customers
            var productsList = (from d in db.PizzaItems
                                select d).ToList();
            return View(productsList);
        }
 
        public IActionResult AddToCart(int id)
        {
            PizzaItem PID = db.PizzaItems.Find(id);
            if (ModelState.IsValid)
            {
                using (db)
                {
                    //check if the item already added to the cart by chicking the existence of PID
                    var obj = db.CustomerOrderTables.Where(model => model.PID == PID.PID && model.Purchased == 0).FirstOrDefault();
                    if (obj != null)
                    {
                        TempData["AlertMsg"] = "<script> divModal.style.display = 'block';</script>";
                    }
                    else
                    {
                        //insert the values to the table
                        CustomerOrderTable CCT = new CustomerOrderTable();
                        // fields to be inserted
                        CCT.PID = PID.PID;
                        CCT.Quantity = 1;
                        CCT.Purchased = 0;
                        db.CustomerOrderTables.Add(CCT);
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Menu");
        }

        //Fuction to count the cart content
        public int TheCart_OnLoad()
        {
            var CartNumbers = (from d in db.CustomerOrderTables
                               where d.Purchased == 0
                               select d).Count();
            TempData["CartNum"] = CartNumbers;
            return (CartNumbers);
        }

        public IActionResult OrderCheckout()
        {
            // Call the function to display the cart content' count. 
            TheCart_OnLoad();

            //Calculate the total price of all products that are added to the cart.
            var TotalAmount = (from cot in db.CustomerOrderTables
                       join p in db.PizzaItems on cot.PID equals p.PID
                       where cot.Purchased == 0
                               select cot.Quantity * p.Price).Sum();
            if (TotalAmount == 0)
            {
                TempData["msg"] = "<script> divEmptyCart.style.display = 'block'</script>";
            }
            else
            {
                //Save the result in the Session and TempData
                HttpContext.Session.SetString("TotalAmountSession", Convert.ToString(String.Format("{0:0.00}", TotalAmount)));
                TempData["TotalAmount"] = Convert.ToString(String.Format("{0:0.00}", TotalAmount));
            }
            
            //Use the CustomerOrderTables to displays the cart contents
            return View(db.CustomerOrderTables.Where(x=> x.Purchased == 0).ToList());
        }


        //Function to increase the selected product quantity
        public IActionResult IncreaseQuantity(int id)
        {
            //Update the Quantity in CustomerOrderTable Table by using CustomerOrderID and Purchased
            CustomerOrderTable COT = db.CustomerOrderTables.Where(u => u.CustomerOrderID == id && u.Purchased == 0).FirstOrDefault();

            if (ModelState.IsValid)
            {
                using (db)
                {
                    //Update the Quantity by Increasing the value in every click on the plus icon
                    COT.Quantity += 1;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("OrderCheckout");
        }

        //Function to decreasee the selected product quantity
        public IActionResult DecreaseQuantity(int id)
        {
            CustomerOrderTable COT = db.CustomerOrderTables.Where(u => u.CustomerOrderID == id && u.Purchased == 0).FirstOrDefault();

            if (ModelState.IsValid)
            {
                using (db)
                {
                    //Check if the value is less than 1 before decreasing
                    if (COT.Quantity > 1)
                    {
                        //Update the Quantity by decreasing the value in every click on the minus icon.
                        COT.Quantity -= 1;
                        db.SaveChanges();
                    }
                }
            }
            return RedirectToAction("OrderCheckout");
        }

        //Delete specific item from the cart
        public ActionResult DeleteItem(int id)
        {
            CustomerOrderTable COT = db.CustomerOrderTables.Find(id);
            db.CustomerOrderTables.Remove(COT);
            db.SaveChanges();
            return RedirectToAction("OrderCheckout");
        }

        public IActionResult Checkout()
        {
            var TotalAmount = HttpContext.Session.GetString("TotalAmountSession");
            List<CustomerOrderTable> COT = db.CustomerOrderTables.Where(u => u.Purchased == 0).ToList();
            Order ord = new Order();

            if (ModelState.IsValid)
            {
                using (db)
                {
                    //Insert the values to the Order table
                    ord.TotalAmount = Convert.ToDouble(TotalAmount);
                    ord.OrderDate = DateTime.Now;
                    db.Orders.Add(ord);
                    db.SaveChanges();

                    //Update the Purchased and OrderID columns in CustomerOrderTable Table
                    foreach (var item in COT)
                    {
                        item.OrderID = ord.OrderID;
                        item.Purchased = 1;
                        db.SaveChanges();
                        //Save the item.OrderID value to a session
                        HttpContext.Session.SetString("OrderIDSession", Convert.ToString(item.OrderID));
                    }
                }
            }
            return RedirectToAction("OrderConfirmation");
        }


        //Show the the final order's details when the customer finished of paying by using OrderID Session.
        public IActionResult OrderConfirmation()
        {
            int OrderID = Convert.ToInt32(HttpContext.Session.GetString("OrderIDSession"));
            ViewData["Orders Details"] = db.CustomerOrderTables.Where(model => model.OrderID == OrderID && model.Purchased == 1).ToList();
            //Use FirstOrDefault to show only one order's details
            ViewData["Order"] = db.Orders.Where(model => model.OrderID == OrderID).FirstOrDefault();
            ViewBag.OrderID = OrderID;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

