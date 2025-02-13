﻿using System;
using Aplicação.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace Aplicação.DAL
{
    public class PetDAL
    {
        EFContext context = new EFContext();

        public void GravarPet(Pet Pet)
        {
            if (Pet.ID == 0)
            {
                context.Pets.Add(Pet);
                Usuario User = context.Usuarios.Where(u => u.ID == Pet.UserID).First();
                User.Pets.Add(Pet);
            }
                
            else
                context.Entry(Pet).State = EntityState.Modified;

            context.SaveChanges();
        }

        public Usuario GetUserByID(long id)
        {
            return context.Usuarios.Where(u => u.ID == id).Include("Pets").Include("Postagens").First();
        }

        public IQueryable<Pet> GetPetsByUserId(long UserID)
        {
            return context.Pets.Where(p => p.UserID == UserID);
        }

        
    }
}