using Microsoft.AspNet.Identity;
using SimpleTicket.Models.CustomerModels;
using SimpleTicket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SimpleTicket.MVC.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        public CustomerService CreateCustomerService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userID);
            return service;
        }
        // GET: Customer
        public async Task<ActionResult> Index()
        {
            var service = CreateCustomerService();
            var list = await service.GetCustomersAsync();
            return View(list);
        }

        // GET: Customer/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var service = CreateCustomerService();
            var model = await service.GetCustomerByIDAsync(id);
            return View(model);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            var service = CreateCustomerService();
            var customer = new CustomerCreate();
            return View(customer);
        }

        // POST: Customer/Create
        [HttpPost]
        public async Task<ActionResult> Create(CustomerCreate customer)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
