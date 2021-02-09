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
    //© 2021 - Josh Hambright

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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CustomerCreate customer)
        {
            try
            {
                if (!ModelState.IsValid) return View(customer);
                var service = CreateCustomerService();
                if (await service.CreateCustomerAsync(customer))
                {
                    TempData["SaveResult"] = "Your Customer was created.";
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Could not create customer.");
                return View(customer);
            }
            catch
            {
                ModelState.AddModelError("", "Could not create customer.");
                return View(customer);
            }
        }

        // GET: Customer/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var service = CreateCustomerService();
            var details = await service.GetCustomerByIDAsync(id);
            var model = new CustomerEdit
            {
                ID = details.ID,
                Name = details.Name,
                Status = details.Status
            };
            return View(model);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, CustomerEdit customer)
        {
            if (!ModelState.IsValid) return View(customer);
            if(customer.ID != id)
            {
                ModelState.AddModelError("", "ID Mismatch, please try again");
                return View(customer);
            }
            var service = CreateCustomerService();
            if (await service.UpdateCustomerAsync(customer))
            {
                TempData["SaveResult"] = "Customer has been updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Could not update customer.");
            return View(customer);
        }

        // GET: Customer/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var service = CreateCustomerService();
            var detail = await service.GetCustomerByIDAsync(id);
            return View(detail);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            var service = CreateCustomerService();
            await service.HardDeleteCustomerAsync(id);
            TempData["SaveResult"] = "Customer has been deleted";
            return RedirectToAction("Index");
        }
    }
}
