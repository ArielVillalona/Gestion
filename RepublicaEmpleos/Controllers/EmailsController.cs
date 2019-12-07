using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RepublicaEmpleos;
using RepublicaEmpleos.Data;
using RepublicaEmpleos.Services.Interfaces;

namespace RepublicaEmpleos.Controllers
{
    public class EmailsController : Controller
    {
        private readonly IEmailServices<Email> _emailServices;

        public EmailsController(IEmailServices<Email> emailServices)
        {
            _emailServices = emailServices;
        }


        // GET: Emails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var email = _emailServices.GetAllById(id);
            if (email == null)
            {
                return NotFound();
            }

            return View(email);
        }

        [HttpGet]
        // GET: Emails/Create
        public IActionResult Create(int? Id)
        {
            ViewData["ProfileId"] = Id;
            return View();
        }

        // POST: Emails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,ProfileId")] Email email)
        {
            if (ModelState.IsValid)
            {
                email.Id = 0;
                await _emailServices.CreateAsync(email);
                //await _context.SaveChangesAsync();
                return RedirectToAction("fullprofile","home");
            }
            return View(email);
        }

        // GET: Emails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var email = await _emailServices.FindByIdAsync(id);
            if (email == null)
            {
                return NotFound();
            }
            return View(email);
        }

        // POST: Emails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,ProfileId")] Email email)
        {
            if (id != email.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _emailServices.EditAsync(email);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_emailServices.EmailExists(email.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("fullprofile", "home");
            }
            return View(email);
        }

        // GET: Emails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var email = await _emailServices.Delete(id);
            if (email == null)
            {
                return NotFound();
            }

            return View(email);
        }

        // POST: Emails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var email = await _emailServices.FindByIdAsync(id);
            await _emailServices.DeletedConfirmed(email);
            return RedirectToAction("fullprofile", "home");
        }
    }
}
