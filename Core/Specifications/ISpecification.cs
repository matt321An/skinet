using System.Linq.Expressions;

namespace Core.Specification
{
    public interface ISpecification<T>
    {
        // Used for the 'where' clause
        Expression<Func<T, bool>> Criteria {get; }

        // Used for the 'include' clause
        List<Expression<Func<T, object>>> Includes {get; }
    }
}