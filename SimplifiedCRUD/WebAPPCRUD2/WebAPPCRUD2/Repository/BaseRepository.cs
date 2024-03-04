using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPPCRUD2.Contracts;

namespace WebAPPCRUD2.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        private DbContext _db;
        private DbSet<T> _table;

        public DbSet<T> Table { get { return _table; } }
        public BaseRepository()
        {
            _db = new SimplifiedCRUDDEntities();
            _table = _db.Set<T>();
        }
        public T Get(object id)
        {
            return _table.Find(id);
        }

        public List<T> GetAll()
        {
            return _table.ToList();
        }

        public ErrorCode Create(T t)
        {
            try
            {
                _table.Add(t);
                _db.SaveChanges();

                return ErrorCode.Success;
            }
            catch (Exception ex)
            {
                return ErrorCode.Error;
            }
        }

        public ErrorCode Delete(object id)
        {

            try
            {
                var obj = Get(id);
                _table.Remove(obj);
                _db.SaveChanges();

                return ErrorCode.Success;
            }
            catch (Exception ex)
            {
                return ErrorCode.Error;
            }
        }


        public ErrorCode Update(object id, T t)
        {

            try
            {
                var oldObj = Get(id);
                _db.Entry(oldObj).CurrentValues.SetValues(t);
                _db.SaveChanges();

                return ErrorCode.Success;
            }
            catch (Exception ex)
            {
                return ErrorCode.Error;
            }
        }

        public T get(object id)
        {
            throw new NotImplementedException();
        }
    }
}