using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Limitless.Data.Infrastructure;
using Limitless.Model;

namespace Limitless.Data.Repositories
{
    public class ClassesRepository : RepositoryBase<ClassesType>, IClassesRepository
    {
        public ClassesRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public ClassesType GetClassesById(int id)
        {
            var classes = this.DbContext.classesesType.FirstOrDefault(c => c.classesTypeId == id);

            return classes;
        }

        public override void Update(ClassesType entity)
        {
            
            base.Update(entity);
        }
    }

    public interface IClassesRepository : IRepository<ClassesType>
    {
        ClassesType GetClassesById(int id);
    }
}