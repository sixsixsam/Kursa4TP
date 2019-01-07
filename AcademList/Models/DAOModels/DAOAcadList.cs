using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AcademList.Models.DAOModels
{
    public class DAOAcadList
    {
        private Entities entities = new Entities();
        DAOPattern daopat = new DAOPattern();


        public IEnumerable<AcadList> GetAllAcadList()
        {
            return entities.AcadList.Select(n => n);
        }

        public IEnumerable<AcadList> GetGroupAcadList(int id)
        {
            return entities.AcadList.Select(n => n)
                .Where(n => n.Pattern_Id == id);
        }

        public AcadList GetAcadList(int id)
        {
            return entities.AcadList.Where(n => n.Id == id).First();
        }

        public bool AddAcadList(AcadList aclist)
        {
            try
            {
                entities.AcadList.Add(aclist);
                entities.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool UpdateAcadList(AcadList aclist)
        {
            try
            {
                var Entity = entities.AcadList.FirstOrDefault(x => x.Id == aclist.Id);

                Entity.Counter = aclist.Counter;
                entities.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}