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
    public class ClassesRepository : RepositoryBase<Classes>, IClassesRepository
    {
        public ClassesRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }

        public Classes GetClassesByName(string classesName)
        {
            var category = this.DbContext.classeses.FirstOrDefault(c => c.name == classesName);

            return category;
        }

        public override void Update(Classes entity)
        {
            
            base.Update(entity);
        }
    }

    public interface IClassesRepository : IRepository<Classes>
    {
        Classes GetClassesByName(string classesName);
    }
}