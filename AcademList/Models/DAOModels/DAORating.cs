using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademList.Models.DAOModels
{
    public class DAORating
    {
        private Entities entities = new Entities();

        //получение списка всех рейтингов
        public IEnumerable<Rating> GetAllRating()
        {
            return entities.Rating.Select(n => n);
        }

        //изменение информации о рейтингах
        public bool UpdateRating(Rating rating)
        {
            try
            {
                var Entity = entities.Rating.FirstOrDefault(x => x.Id == rating.Id);

                Entity.FirstRating = rating.FirstRating;
                Entity.SecondRating = rating.SecondRating;
                Entity.ThirdRating = rating.ThirdRating;
                entities.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        //получение оценок за рейтинги по идентификатору
        public Rating GetRating(int id)
        {
            return entities.Rating.Where(n => n.Id == id).First();
        }

        //удаление оценок за рейтинги по идентификатору
        public bool DeleteRating(int id)
        {
            try
            {
                Rating rat = GetRating(id);
                entities.Rating.Remove(rat);
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