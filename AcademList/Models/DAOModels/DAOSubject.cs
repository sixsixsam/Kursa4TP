using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademList.Models.DAOModels
{
    public class DAOSubject
    {
        private Entities entities = new Entities();

        //получение списка всех предметов
        public IEnumerable<Subject> GetAllSubject()
        {
            return entities.Subject.Select(n => n);
        }

        //добавление нового предмета
        public bool AddSubject(Subject subject)
        {
            try
            {
                entities.Subject.Add(subject);
                entities.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        //переименование предмета
        public void UpdateSubject(Subject subject)
        {
            var Entity = entities.Subject.FirstOrDefault(x => x.Id == subject.Id);
            Entity.SubjectName = subject.SubjectName;
            entities.SaveChanges();
        }

        //получение названия предмета по идентификатору
        public Subject GetSubject(int id)
        {
            return entities.Subject.Where(n => n.Id == id).First();
        }

        //удаление предмета по идентификатору
        public void DeleteSubject(int id)
        {
            Subject sub = GetSubject(id);
            entities.Subject.Remove(sub);
            entities.SaveChanges();
        }
    }
}