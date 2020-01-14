using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses.CommonRepos
{
    public interface IRepository<T> where T : EntityBase
    {
        T GetById(Guid id);
        IEnumerable<T> List();
        IEnumerable<T> List(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
      // void DeleteById(T entity);
      // void Edit(T entity);
    }

   public abstract class EntityBase
   {
        [Required]
       public Guid ID { get;  set; }
   }
}
