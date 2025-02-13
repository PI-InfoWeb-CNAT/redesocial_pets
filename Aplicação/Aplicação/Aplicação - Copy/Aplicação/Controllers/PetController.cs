﻿using System;
using System.Collections.Generic;
using System.Linq;
using Aplicação.DAL;
using Aplicação.Models;
using System.Web;
using System.Web.Mvc;

namespace Aplicação.Controllers
{
    public class PetController : Controller
    {
        PetDAL petDAL = new PetDAL();

        // GET: Pet
        public ActionResult Create(int UserID, bool new_pet)
        {
            if (new_pet)
                ViewBag.new_pet = "Pet adicionado!";
                ViewBag.Pets = petDAL.GetPetsByUserId(UserID);

            ViewBag.UserID = UserID;
            return View();
        }

        // POST: Pet
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pet Pet)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    petDAL.GravarPet(Pet);
                    return RedirectToAction("../Pet/Create", new { UserID = Pet.UserID, new_pet = true });
                }

                return View(Pet);
            }
            catch
            {
                return View(Pet);
            }
        }
    }
}