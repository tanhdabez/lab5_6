using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppData.DbContexxt;
using AppData.IRepository;
using Microsoft.EntityFrameworkCore;

namespace AppData.Repository
{
    public class NhanVienRepositories<T> : INhanVienRepositories<T> where T : class
    {
        DbSet<T> dbset;
        Lab_DbContext context;
        public NhanVienRepositories()
        {
            
        }
        public NhanVienRepositories(Lab_DbContext context, DbSet<T> dbset)
        {
            this.context = context;
            this.dbset = dbset;
        }

        public bool CreateItem(T item)
        {
            try
            {
                dbset.Add(item);
                context.SaveChanges(); return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool DeleteItem(T item)
        {
            try
            {
                dbset.Remove(item);
                context.SaveChanges(); return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        

        public IEnumerable<T> GetAllItem()
        {
            return dbset.ToList();
        }

        

        public bool UpdateItem(T item)
        {
            try
            {
                dbset.Update(item);
                context.SaveChanges(); return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        
    }
}