using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademList.Models.DAOModels
{
    public class DAOPattern
    {
        private Entities entities = new Entities();

        public IEnumerable<Pattern> GetAllPattern()
        {
            return entities.Pattern.Select(n => n);
        }

        public Pattern GetPattern(int id)
        {
            return entities.Pattern.Where(n => n.Id == id).First();
        }

        public IEnumerable<Pattern> GetUserPattern(string id)
        {
            return entities.Pattern.Where(n => n.Professor_Id == id);
        }

        public bool AddPattern(Pattern pattern)
        {
            try
            {
                entities.Pattern.Add(pattern);
                entities.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool UpdatePattern(Pattern pattern)
        {
            try
            {
                var Entity = entities.Pattern.FirstOrDefault(x => x.Id == pattern.Id);
                
                Entity.Status = pattern.Status;
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