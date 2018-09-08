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
    public class OrganizationRepository
    {
        DatabaseContext db = new DatabaseContext();

        public bool Add(Organization organization)
        {
            db.Organizations.Add(organization);
            bool isAdded = db.SaveChanges() > 0;
            return isAdded;
        }

        public List<Organization> GetAll()
        {
            var organizationList = db.Organizations.ToList();
            return organizationList;
        }
        public Organization GetById(int id)
        {
            var organization = db.Organizations.FirstOrDefault(x => x.Id == id);
            return organization;
        }

        public bool Update(Organization organization)
        {
            db.Organizations.Attach(organization);
            db.Entry(organization).State = EntityState.Modified;
            bool isUpdated = db.SaveChanges() > 0;
            return isUpdated;
        }

        public bool Delete(Organization organization)
        {
            db.Organizations.Remove(organization);
            bool isDeleted = db.SaveChanges() > 0;
            return isDeleted;
        }
    }
}
