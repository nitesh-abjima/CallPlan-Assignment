﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CallPlanApp.Models;

namespace CallPlanApp.Controllers
{
    public class CallPlansController : Controller
    {
        private readonly CallPlanDataContext _context;

        public CallPlansController(CallPlanDataContext context)
        {
            _context = context;
        }

        // GET: CallPlans
        public async Task<IActionResult> Index()
        {
            return View(await _context.CallPlans.ToListAsync());
        }

        // GET: CallPlans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var callPlan = await _context.CallPlans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (callPlan == null)
            {
                return NotFound();
            }

            return View(callPlan);
        }

        // GET: CallPlans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CallPlans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,StartDate,VisitType,Complete")] CallPlan callPlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(callPlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(callPlan);
        }

        // GET: CallPlans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var callPlan = await _context.CallPlans.FindAsync(id);
            if (callPlan == null)
            {
                return NotFound();
            }
            return View(callPlan);
        }

        // POST: CallPlans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,StartDate,VisitType,Complete")] CallPlan callPlan)
        {
            if (id != callPlan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(callPlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CallPlanExists(callPlan.Id))
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
            return View(callPlan);
        }

        // GET: CallPlans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var callPlan = await _context.CallPlans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (callPlan == null)
            {
                return NotFound();
            }

            return View(callPlan);
        }

        // POST: CallPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var callPlan = await _context.CallPlans.FindAsync(id);
            _context.CallPlans.Remove(callPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CallPlanExists(int id)
        {
            return _context.CallPlans.Any(e => e.Id == id);
        }
    }
}
