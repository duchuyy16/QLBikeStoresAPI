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
            var results = _context.Set<T>().ToList();
            return results;
        }

        public bool Sua(T entity)
        {
            try
            {
                //var ent = _context.Set<T>().FirstOrDefault(x=>x.)(entity);
                //_context.SaveChanges();
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
            }catch(Exception)
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
