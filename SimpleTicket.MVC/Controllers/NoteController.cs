using Microsoft.AspNet.Identity;
using SimpleTicket.Models.NoteModels;
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
    public class NoteController : Controller
    {    //© 2021 - Josh Hambright

        public NoteService CreateNoteService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new NoteService(userID);
            return service;
        }

        // GET: Note
        public async Task<ActionResult> Index()
        {
            var service = CreateNoteService();
            var list = await service.GetNotesAsync();
            return View(list);
        }

        // GET: Note/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var service = CreateNoteService();
            var note = await service.GetNoteByIDAsync(id);
            return View(note);
        }

        //// GET: Note/Create
        //public ActionResult Create()
        //{
        //    var service = CreateNoteService();
        //    var model = new NoteCreate();
        //    return View(model);
        //}

        //Get Note/Create/{TicketID}
        public ActionResult Create(Guid id)
        {
            var service = CreateNoteService();
            var model = new NoteCreate
            {
                TicketID = id
            };
            return View(model);
        }

        // POST: Note/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(NoteCreate note)
        {
            if (!ModelState.IsValid) return View(note);
            var service = CreateNoteService();
            if (await service.CreateNoteAsync(note))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Could not create note.");
            return View(note);
        }

        // GET: Note/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var service = CreateNoteService();
            var details = await service.GetNoteByIDAsync(id);
            var model = new NoteEdit
            {
                ID = details.ID,
                Creator = details.Creator,
                Body = details.Body,
                TicketID = details.TicketID
            };
            return View(model);
        }

        // POST: Note/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, NoteEdit note)
        {
            if (!ModelState.IsValid) return View(note);
            if (note.ID != id)
            {
                ModelState.AddModelError("", "ID Mismatch, please try again");
                return View(note);
            }
            var service = CreateNoteService();
            if (await service.UpdateNoteAsync(note))
            {
                TempData["SaveResult"] = "note has been updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Could not update note.");
            return View(note);
        }

        // GET: Note/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var service = CreateNoteService();
            var detail = await service.GetNoteByIDAsync(id);
            return View(detail);
        }

        // POST: Note/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            var service = CreateNoteService();
            await service.DeleteNoteAsync(id);
            TempData["SaveResult"] = "Note has been deleted";
            return RedirectToAction("Index");
        }
    }
}
