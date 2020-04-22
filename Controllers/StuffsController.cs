using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class StuffsController : Controller
    {
        private readonly StuffContext _context;

        public StuffsController(StuffContext context)
        {
            _context = context;
        }
        //
        // Post: CreateTest
        public async Task<IActionResult> CreateT([FromBody] Stuff stuff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stuff);
                await _context.SaveChangesAsync();
            }
            return Ok(stuff);
        }

        public async Task<IActionResult> CreateMT([FromBody] List<Stuff> StuffList)
        {
            foreach (Stuff stuff in StuffList)
            {
                _context.Stuff.Add(stuff);
                await _context.SaveChangesAsync();
            }
            return Ok(StuffList);
        }
        /*public async Task<IActionResult> Get()
        {
            foreach (Stuff stuff in _context.Stuff)
            {
                Stuff stuffs = (from st in _context.Stuff.Include(a => a.FILES)
                         select st
                          ).FirstOrDefault();
                if (stuff == null)
                {
                    return NotFound();
                }
                return Ok(stuffs);
            }
            //return Ok(stuffs);
            Stuff stuff = (from st in _context.Stuff.Include(a => a.FILES)
                           select st.FILES
                           ).ToList();
        }*/
        public IActionResult Get()
        {
            var stuffs = from s in _context.Stuff.Include(a =>a.FILES)
                         select s ;

            if (stuffs == null)
            {
                return NotFound();
            }

            return Ok(stuffs);
        }
        public IActionResult GetD(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var stuff = from st in _context.Stuff.Include(a => a.FILES)
                        where st.SID == id
                        select st;

            if (stuff == null)
            {
                return NotFound();
            }

            return Ok(stuff);
        }

        //
        // GET: Stuffs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stuff.ToListAsync());
        }

        // GET: Stuffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stuff = await _context.Stuff.FirstOrDefaultAsync(m => m.SID == id);
            if (stuff == null)
            {
                return NotFound();
            }

            return View(stuff);
        }

        // GET: Stuffs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stuffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SID,EQPID,COMPID")] Stuff stuff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stuff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stuff);
        }

        // GET: Stuffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stuff = await _context.Stuff.FindAsync(id);
            if (stuff == null)
            {
                return NotFound();
            }
            return View(stuff);
        }

        // POST: Stuffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SID,EQPID,COMPID")] Stuff stuff)
        {
            if (id != stuff.SID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stuff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StuffExists(stuff.SID))
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
            return View(stuff);
        }

        // GET: Stuffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stuff = await _context.Stuff
                .FirstOrDefaultAsync(m => m.SID == id);
            if (stuff == null)
            {
                return NotFound();
            }

            return View(stuff);
        }

        // POST: Stuffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stuff = await _context.Stuff.FindAsync(id);
            _context.Stuff.Remove(stuff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StuffExists(int id)
        {
            return _context.Stuff.Any(e => e.SID == id);
        }
    }
}
