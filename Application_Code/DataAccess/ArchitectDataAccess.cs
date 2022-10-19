using DataBase;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ArchitectDataAccess
    {
        public ArchitectDataAccess()
        {
        }

        public void SaveChanges()
        {
            using (Context context = new Context())
            {
                context.SaveChanges();
            }
        }

        public void AddArchitect(Architect architectToBeAdded)
        {
            using (var context = new Context())
            {
                context.Architects.Add(architectToBeAdded);
                context.SaveChanges();
            }
        }

        public void RemoveArchitect(Architect architectForRemoval)
        {
            using (Context context = new Context())
            {
                architectForRemoval = context.Architects.Find(architectForRemoval.Id);
                context.Entry(architectForRemoval).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void ModifyArchitect(Architect architect, Architect architectWithNewData)
        {
            using (Context context = new Context())
            {
                context.Architects.Attach(architect);
                architect = context.Architects.Find(architect.Id);
                architect.Name = architectWithNewData.Name;
                architect.Surname = architectWithNewData.Surname;
                architect.UserName = architectWithNewData.UserName;
                context.Entry(architect).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<Architect> GetArchitects()
        {
            List<Architect> architect = new List<Architect>();
            using (Context context = new Context())
            {
                architect = context.Architects.ToList();
            }
            return architect;
        }

        public bool ArchitectExists(Architect architect)
        {
            bool exists = false;
            using (Context context = new Context())
            {
                architect = context.Architects.Find(architect.Id);
                exists = (architect != null);
            }
            return exists;
        }

        public Architect GetArchitect (Architect architect)
        {
            Architect returnArchitect = null;
            using (Context context = new Context())
            {
                returnArchitect = context.Architects.First(a => a.Id == architect.Id);
            }
            return returnArchitect;
        }
    }
}
