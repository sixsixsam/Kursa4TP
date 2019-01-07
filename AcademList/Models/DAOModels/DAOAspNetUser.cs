using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademList.Models.DAOModels
{
    public class DAOAspNetUser
    {
        private Entities entities = new Entities();

        //получение списка всех пользователей
        public IEnumerable<AspNetUsers> GetAllUsers()
        {
            return entities.AspNetUsers.Select(n => n);
        }

        //изменение информации о пользователе
        public bool UpdateUser(AspNetUsers user)
        {
            try
            {
                var Entity = entities.AspNetUsers.FirstOrDefault(x => x.Id == user.Id);

                Entity.Surname = user.Surname;
                Entity.Email = user.Email;

                entities.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        //получение пользователя по идентификатору
        public AspNetUsers GetUser(string id)
        {
            return entities.AspNetUsers.Where(n => n.Id == id).First();
        }

        //удаление пользователя по идентификатору
        public bool DeleteUser(string id)
        {
            try
            {
                AspNetUsers anu = GetUser(id);
                entities.AspNetUsers.Remove(anu);
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