using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBContext;
using Models;

namespace Repository
{
    public class TagRepository
    {
        DatabaseContext db = new DatabaseContext();

        public bool Add(Tag tag)
        {
            db.Tags.Add(tag);
            bool isAdded = db.SaveChanges() > 0;
            return isAdded;
        }

        public List<Tag> GetAll()
        {
            var tagList = db.Tags.ToList();
            return tagList;
        }
        public Tag GetById(int id)
        {
            var tag = db.Tags.FirstOrDefault(x => x.Id == id);
            return tag;
        }

        public bool Update(Tag tag)
        {
            db.Tags.Attach(tag);
            db.Entry(tag).State = EntityState.Modified;
            bool isUpdated = db.SaveChanges() > 0;
            return isUpdated;
        }

        public bool Delete(Tag tag)
        {
            db.Tags.Remove(tag);
            bool isDeleted = db.SaveChanges() > 0;
            return isDeleted;
        }
    }
}
