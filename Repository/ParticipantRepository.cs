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
   public class ParticipantRepository
    {
        DatabaseContext db = new DatabaseContext();

        public bool Add(Participant participant)
        {
            db.Participants.Add(participant);
            bool isAdded = db.SaveChanges() > 0;
            return isAdded;
        }

        public List<Participant> GetAll()
        {
            var participantList = db.Participants.ToList();
            return participantList;
        }
        public Participant GetById(int id)
        {
            var participant = db.Participants.FirstOrDefault(x => x.Id == id);
            return participant;
        }

        public bool Update(Participant participant)
        {
            db.Participants.Attach(participant);
            db.Entry(participant).State = EntityState.Modified;
            bool isUpdated = db.SaveChanges() > 0;
            return isUpdated;
        }

        public bool Delete(Participant participant)
        {
            db.Participants.Remove(participant);
            bool isDeleted = db.SaveChanges() > 0;
            return isDeleted;
        }
    }
}
