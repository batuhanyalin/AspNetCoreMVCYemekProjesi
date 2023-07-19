using AspNetCoreMVCYemekProjesi.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AspNetCoreMVCYemekProjesi.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        Context con = new Context();
        public List<T> TList()
        {
            return con.Set<T>().ToList();
        }
        public void TDelete(T x)
        {
            con.Set<T>().Remove(x);
            con.SaveChanges();
        }
        public void TUpdate(T x)
        {
            con.Set<T>().Update(x);
            con.SaveChanges();
        }
        public void TCreate(T x)
        {
            con.Set<T>().Add(x);
            con.SaveChanges();
        }
        public T TGet(int x)
        {
           return con.Set<T>().Find(x);
        }
        public List<T> TList(string p)
        {
            return con.Set<T>().Include(p).ToList();
        }
        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return con.Set<T>().Where(filter).ToList();
        }
    }
}
