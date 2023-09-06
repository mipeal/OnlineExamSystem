using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBContext;
using EntityModels;

namespace Repository
{
    public class BatchRepository
    {
        DatabaseContext db = new DatabaseContext();

        public bool Add(Batch batch)
        {
            db.Batches.Add(batch);
            bool isAdded = db.SaveChanges()>0;
            return isAdded;
        }

        public List<Batch> GetAll()
        {
            var batchList= db.Batches.ToList();
            return batchList;
        }
        public Batch GetById(int id)
        {
            var batch = db.Batches.FirstOrDefault(x => x.Id == id);
            return batch;
        }

        public bool Update(Batch batch)
        {
            db.Batches.Attach(batch);
            db.Entry(batch).State = EntityState.Modified;
            bool isUpdated = db.SaveChanges() > 0;
            return isUpdated;
        }

        public bool Delete(Batch batch)
        {
            db.Batches.Remove(batch);
            bool isDeleted = db.SaveChanges() > 0;
            return isDeleted;
        }
    }
}
