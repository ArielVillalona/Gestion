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
    public class PhonesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPhoneServices<Phone> _phoneServices;

        public PhonesController(ApplicationDbContext context, IPhoneServices<Phone> phoneServices)
        {
            _context = context;
            _phoneServices = phoneServices;
        }

        // GET: Phones/Create
        public IActionResult Create(int id)
        {
            ViewData["ProfileId"] = id;
            return View();
        }

        // POST: Phones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,ProfileId")] Phone phone)
        {
            if (ModelState.IsValid)
            {
                await _phoneServices.CreateAsync(phone);
                return RedirectToAction("fullprofile", "home");
            }
            ViewData["ProfileId"] = new SelectList(_context.Profiles, "Id", "Id", phone.ProfileId);
            return View(phone);
        }

        // GET: Phones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _phoneServices.FindByIdAsync(id);
            if (phone == null)
            {
                return NotFound();
            }
            ViewData["ProfileId"] = phone.ProfileId;
            return View(phone);
        }

        // POST: Phones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,ProfileId")] Phone phone)
        {
            if (id != phone.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _phoneServices.EditAsync(phone);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_phoneServices.PhoneExists(phone.Id))
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
            ViewData["ProfileId"] = new SelectList(_context.Profiles, "Id", "Id", phone.ProfileId);
            return View(phone);
        }

        // GET: Phones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _phoneServices.Delete(id);
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }

        // POST: Phones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phone = await _phoneServices.FindByIdAsync(id);
            await _phoneServices.DeletedConfirmed(phone);
            return RedirectToAction("fullprofile","home");
        }
    }
}
