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
    public class DesignerDataAccess
    {
        public DesignerDataAccess()
        {
        }

        public void SaveChanges()
        {
            using (Context context = new Context())
            {
                context.SaveChanges();
            }
        }

        public void AddDesigner(Designer designerToBeAdded)
        {
            using (var context = new Context())
            {
                context.Designers.Add(designerToBeAdded);
                context.SaveChanges();
            }
        }

        public void RemoveDesigner(Designer designerForRemoval)
        {
            using (Context context = new Context())
            {
                designerForRemoval = context.Designers.Find(designerForRemoval.Id);
                context.Entry(designerForRemoval).State = EntityState.Deleted;
                context.SaveChanges();
            }
        } 

        public void ModifyDesigner(Designer designer, Designer designerWithNewData)
        {
            using (Context context = new Context())
            {
                context.Designers.Attach(designer);
                designer = context.Designers.Find(designer.Id);
                designer.Name = designerWithNewData.Name;
                designer.Surname = designerWithNewData.Surname;
                designer.UserName = designerWithNewData.UserName;
                context.Entry(designer).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<Designer> GetDesigners()
        {
            List<Designer> designer= new List<Designer>();
            using (Context context = new Context())
            {
                designer = context.Designers.ToList();
            }
            return designer;
        }

        public bool DesignerExists(Designer designer)
        {
            bool exists = false;
            using (Context context = new Context())
            {
                designer = context.Designers.Find(designer.Id);
                exists = (designer != null);
            }
            return exists;
        }

        public Designer GetDesigner(Designer designer)
        {
            Designer returnDesigner = null;
            using (Context context = new Context())
            {
                returnDesigner = context.Designers.First(a => a.Id == designer.Id);
            }
            return returnDesigner;
        }
    }
}
