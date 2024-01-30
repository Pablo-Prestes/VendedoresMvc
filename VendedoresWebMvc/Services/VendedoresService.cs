﻿using Data;
using Microsoft.EntityFrameworkCore;
using VendedoresWebMvc.Models;
using VendedoresWebMvc.Services.Exceptions;

namespace VendedoresWebMvc.Services
{
    public class VendedoresService
    {
        private readonly VendedoresWebMvcContext _context;

        public VendedoresService(VendedoresWebMvcContext context) 
        {
            _context = context;
        }

        public List<Vendedor> MostrarVendedores() 
        {
            return _context.Vendedor.ToList();
        }

        public void Insert(Vendedor obj) 
        {
            //obj.Departamento = _context.Departamento.First();
            _context.Add(obj);
            _context.SaveChanges();         
        }
        public Vendedor ProcurarPorId(int id)
        {
            return _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefault(obj => obj.Id == id);
        }
        public void Remove(int id) 
        {
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj);
            _context.SaveChanges();
        }
        public void Update(Vendedor obj)
        {
            if (!_context.Vendedor.Any(x => x.Id == obj.Id)) 
            {
                throw new NotFoundExpection("Id não encontrado !");
            }
            
            try 
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}   
