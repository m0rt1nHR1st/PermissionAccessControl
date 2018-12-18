﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.EfClasses.BusinessClasses;
using DataLayer.EfCode;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataAuthWebApp.Controllers
{
    public class PersonalController : Controller
    {
        private BusinessDbContext _context;

        public PersonalController(BusinessDbContext context)
        {
            _context = context;
        }

        // GET: Personal
        public ActionResult Index()
        {
            return View(_context.PersonalDatas.FirstOrDefault());
        }


        // GET: Personal/Create
        public ActionResult Create()
        {
            if (_context.PersonalDatas.FirstOrDefault() != null)
                return RedirectToAction(nameof(Edit));

            return View();
        }

        // POST: Personal/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Personal/Edit/5
        public ActionResult Edit()
        {
            var entity = _context.PersonalDatas.FirstOrDefault();
            if (entity == null)
                return RedirectToAction(nameof(Create));

            return View(entity);
        }

        // POST: Personal/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IFormCollection collection)
        {
            try
            {
                var entity = _context.PersonalDatas.First();
                entity.SecretToYou = collection[nameof(PersonalData.SecretToYou)];
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Personal/Delete/5
        public ActionResult Delete()
        {
            var entity = _context.PersonalDatas.FirstOrDefault();
            if (entity != null)
            {
                _context.Remove(entity);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Create));
        }


    }
}