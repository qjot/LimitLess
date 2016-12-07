using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Limitless.Data.Infrastructure;
using Limitless.Data.Repositories;
using Limitless.Model;

namespace Limitless.Service
{
    public interface IClassesService
    {
        IEnumerable<ClassesType> GetClasses(string name = null);
        ClassesType GetClasses(int id);
        void CreateClasses(ClassesType Classes);
        void SaveClasses();
    }
    public class ClassesService : IClassesService
    {
        private readonly IClassesRepository ClassessRepository;
        private readonly IUnitOfWork unitOfWork;

        public ClassesService(IClassesRepository ClassessRepository, IUnitOfWork unitOfWork)
        {
            this.ClassessRepository = ClassessRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IClassesService Members

        public IEnumerable<ClassesType> GetClasses(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return ClassessRepository.GetAll();
            else
                return ClassessRepository.GetAll().Where(c => c.name == name);
        }

        public ClassesType GetClasses(int id)
        {
            var Classes = ClassessRepository.GetById(id);
            return Classes;
        }
        

        public void CreateClasses(ClassesType Classes)
        {
            ClassessRepository.Add(Classes);
        }

        public void SaveClasses()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}