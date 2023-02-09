using Microsoft.EntityFrameworkCore;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T:class
    {
        protected readonly demoContext _context;
        public BaseRepository(demoContext context)
        {
            _context = context;
        }
        public IEnumerable<T> DocDanhSach(params System.Linq.Expressions.Expression<Func<T, object>>[] cacthamso)
        {
            var results = _context.Set<T>().AsQueryable();
            foreach(var include in cacthamso)
            {
                results.Include(include);
            }
            return results.ToList();
        }

        public IEnumerable<T> DocTheoDieuKien(System.Linq.Expressions.Expression<Func<T, bool>> dieukien, params System.Linq.Expressions.Expression<Func<T, object>>[] cacthamso)
        {
            var results = _context.Set<T>().Where(dieukien);
            foreach (var include in cacthamso)
            {
                results.Include(include);
            }
            return results.ToList();
        }

        //public IEnumerable<T> DocTheoDieuKien(System.Linq.Expressions.Expression<Func<T, bool>> dieukien, params Expression<Func<T, object>>[] cacthamso)
        //{
        //    var results = _context.Set<T>().AsQueryable();
        //    foreach (var include in cacthamso)
        //    {
        //        results.Include(include);
        //    }
        //    return results.ToList();
        //}

        public bool Sua(T entity)
        {
            try
            {
                _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                //var ent = _context.Set<T>().FirstOrDefault(x=>x.)(entity);
                _context.SaveChanges();
                //return ent.Entity;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public T Them(T entity)
        {
            try
            {
                var ent = _context.Set<T>().Add(entity);
                _context.SaveChanges();
                return ent.Entity;
            }catch(Exception e)
            {
                return null;
            }
        }

        public bool Xoa(T entity)
        {
            try
            {              
                _context.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
