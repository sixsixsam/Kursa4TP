using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademList.Models.DAOModels
{
    public class DAOGroups
    {
        private Entities entities = new Entities();

        //получение списка всех групп
        public IEnumerable<Groups> GetAllGroups()
        {
            return entities.Groups.Select(n => n);
        }

        //добавление новой группы
        public bool AddGroups(Groups groups)
        {
            try
            {
                entities.Groups.Add(groups);
                entities.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        //переименование группы
        public void UpdateGroups(Groups groups)
        {
            var Entity = entities.Groups.FirstOrDefault(x => x.Id == groups.Id);
            Entity.GroupName = groups.GroupName;
            entities.SaveChanges();
        }

        //получение названия группы по идентификатору
        public Groups GetGroups(int id)
        {
            return entities.Groups.Where(n => n.Id == id).First();
        }

        //удаление группы по идентификатору
        public void DeleteGroups(int id)
        {
            Groups gr = GetGroups(id);
            entities.Groups.Remove(gr);
            entities.SaveChanges();
        }
    }
}