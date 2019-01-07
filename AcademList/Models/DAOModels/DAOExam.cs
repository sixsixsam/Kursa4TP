using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademList.Models.DAOModels
{
    public class DAOExam
    {
        private Entities entities = new Entities();

        //получение списка всех оценок за экзамен
        public IEnumerable<Exam> GetAllExam()
        {
            return entities.Exam.Select(n => n);
        }

        //добавление новой оценки за экзамен
        public bool AddExam(Exam exam)
        {
            try
            {
                entities.Exam.Add(exam);
                entities.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        //измнение оценки за экзамен
        public void UpdateExam(Exam exam)
        {
            var Entity = entities.Exam.FirstOrDefault(x => x.Id == exam.Id);

            Entity.ExamValue = exam.ExamValue;

            entities.SaveChanges();
        }

        //получение оценки за экзамен по идентификатору
        public Exam GetExam(int id)
        {
            return entities.Exam.Where(n => n.Id == id).First();
        }

        //удаление оценки за экзамен по идентификатору
        public void DeleteExam(int id)
        {
            Exam ex = GetExam(id);
            entities.Exam.Remove(ex);
            entities.SaveChanges();
        }
    }
}