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
    public class OptionRepository
    {
        DatabaseContext db = new DatabaseContext();

        public bool Add(Option option)
        {
            db.Options.Add(option);
            bool isAdded = db.SaveChanges() > 0;
            return isAdded;
        }

        public List<Option> GetAll()
        {
            var optionList = db.Options.ToList();
            return optionList;
        }
        public Option GetById(int id)
        {
            var option = db.Options.FirstOrDefault(x => x.Id == id);
            return option;
        }

        public bool Update(Option option)
        {
            db.Options.Attach(option);
            db.Entry(option).State = EntityState.Modified;
            bool isUpdated = db.SaveChanges() > 0;
            return isUpdated;
        }

        public bool Delete(Option option)
        {
            db.Options.Remove(option);
            bool isDeleted = db.SaveChanges() > 0;
            return isDeleted;
        }
    }
}
