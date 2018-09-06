using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBContext;
using Models;

namespace Repository
{
    class TrainerRepository
    {
        DatabaseContext db = new DatabaseContext();

        public bool Add(Trainer trainer)
        {
            db.Trainers.Add(trainer);
            bool isAdded = db.SaveChanges() > 0;
            return isAdded;
        }

        public List<Trainer> GetAll()
        {
            var trainerList = db.Trainers.ToList();
            return trainerList;
        }
        public Trainer GetById(int id)
        {
            var trainer = db.Trainers.FirstOrDefault(x => x.Id == id);
            return trainer;
        }

        public bool Update(Trainer trainer)
        {
            db.Trainers.Attach(trainer);
            db.Entry(trainer).State = EntityState.Modified;
            bool isUpdated = db.SaveChanges() > 0;
            return isUpdated;
        }

        public bool Delete(Trainer trainer)
        {
            db.Trainers.Remove(trainer);
            bool isDeleted = db.SaveChanges() > 0;
            return isDeleted;
        }
    }
}
