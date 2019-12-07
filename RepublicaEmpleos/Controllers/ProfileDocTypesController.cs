using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RepublicaEmpleos.Data;
using RepublicaEmpleos.Models;

namespace RepublicaEmpleos.Controllers
{
    public class ProfileDocTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfileDocTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProfileDocTypes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProfileDocType.Include(p => p.DocType).Include(p => p.Profile);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProfileDocTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileDocType = await _context.ProfileDocType
                .Include(p => p.DocType)
                .Include(p => p.Profile)
                .FirstOrDefaultAsync(m => m.ProfileID == id);
            if (profileDocType == null)
            {
                return NotFound();
            }

            return View(profileDocType);
        }

        // GET: ProfileDocTypes/Create
        public IActionResult Create()
        {
            ViewData["DocTypeID"] = new SelectList(_context.DocTypes, "ID", "ID");
            ViewData["ProfileID"] = new SelectList(_context.Profiles, "Id", "Id");
            return View();
        }

        // POST: ProfileDocTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocTypeID,ProfileID,NumberDocument")] ProfileDocType profileDocType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profileDocType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DocTypeID"] = new SelectList(_context.DocTypes, "ID", "ID", profileDocType.DocTypeID);
            ViewData["ProfileID"] = new SelectList(_context.Profiles, "Id", "Id", profileDocType.ProfileID);
            return View(profileDocType);
        }

        // GET: ProfileDocTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileDocType = await _context.ProfileDocType.FindAsync(id);
            if (profileDocType == null)
            {
                return NotFound();
            }
            ViewData["DocTypeID"] = new SelectList(_context.DocTypes, "ID", "ID", profileDocType.DocTypeID);
            ViewData["ProfileID"] = new SelectList(_context.Profiles, "Id", "Id", profileDocType.ProfileID);
            return View(profileDocType);
        }

        // POST: ProfileDocTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DocTypeID,ProfileID,NumberDocument")] ProfileDocType profileDocType)
        {
            if (id != profileDocType.ProfileID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profileDocType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfileDocTypeExists(profileDocType.ProfileID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DocTypeID"] = new SelectList(_context.DocTypes, "ID", "ID", profileDocType.DocTypeID);
            ViewData["ProfileID"] = new SelectList(_context.Profiles, "Id", "Id", profileDocType.ProfileID);
            return View(profileDocType);
        }

        // GET: ProfileDocTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profileDocType = await _context.ProfileDocType
                .Include(p => p.DocType)
                .Include(p => p.Profile)
                .FirstOrDefaultAsync(m => m.ProfileID == id);
            if (profileDocType == null)
            {
                return NotFound();
            }

            return View(profileDocType);
        }

        // POST: ProfileDocTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profileDocType = await _context.ProfileDocType.FindAsync(id);
            _context.ProfileDocType.Remove(profileDocType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfileDocTypeExists(int id)
        {
            return _context.ProfileDocType.Any(e => e.ProfileID == id);
        }
    }
}
