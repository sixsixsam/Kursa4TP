using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademList.Models.DAOModels
{
    public class DAOLabs
    {
        private Entities entities = new Entities();

        //получение списка всех оценок за лабораторные
        public IEnumerable<Labs> GetAllLabs()
        {
            return entities.Labs.Select(n => n);
        }

        //изменение информации оценок за лабораторные
        public bool UpdateLabs(Labs labs)
        {
            try
            {
                var Entity = entities.Labs.FirstOrDefault(x => x.Id == labs.Id);

                Entity.FirstLab = labs.FirstLab;
                Entity.SecondLab = labs.SecondLab;
                Entity.ThirdLab = labs.ThirdLab;
                Entity.FourthLab = labs.FourthLab;
                Entity.FifthLab = labs.FifthLab;
                entities.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        //получение оценок за лабораторные по идентификатору
        public Labs GetLabs(int id)
        {
            return entities.Labs.Where(n => n.Id == id).First();
        }

        //удаление оценок за лабораторные по идентификатору
        public bool DeleteLabs(int id)
        {
            try
            {
                Labs lb = GetLabs(id);
                entities.Labs.Remove(lb);
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