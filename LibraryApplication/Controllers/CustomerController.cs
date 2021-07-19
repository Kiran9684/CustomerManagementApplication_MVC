using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryApplication.Repository;
using LibraryApplication.Models;

namespace LibraryApplication.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            //In this action method I'm display Customers list

            CustomerRepository custRepo = new CustomerRepository();
            ModelState.Clear();
            return View(custRepo.getAllCustomers());
        }

        public ActionResult addCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addCustomer(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    CustomerRepository custRepo = new CustomerRepository();
                    if (custRepo.addCustomer(customer))
                    {
                        return RedirectToAction("Index");
                        // ViewBag.Message = "Employee Details Added Successfully";
                    }
                }
                return View();
            }
            catch(Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex,"Customer","addCustomer"));
            }
        }

        public ActionResult editCustomer(int id)
        {
            CustomerRepository custRepo = new CustomerRepository();
           // Customer customer = custRepo.
           return View(custRepo.getAllCustomers().Find(Customer => Customer.CustomerID == id));
        }

        [HttpPost]
        public ActionResult editCustomer(Customer customer)
        {
            try
            {

                CustomerRepository custRepo = new CustomerRepository();
                custRepo.updateCustomer(customer);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Customer", "editCustomer"));
            }
        }

        public ActionResult deleteCustomer(int id)
        {
            try
            {
                CustomerRepository custRepo = new CustomerRepository();
                if (custRepo.deleteCustomer(id))
                {
                    ViewBag.Message = "Record Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Customer", "editCustomer"));
            }
        }

    }
}