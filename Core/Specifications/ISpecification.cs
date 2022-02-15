using System.Linq.Expressions;

namespace Core.Specification
{
    public interface ISpecification<T>
    {
        // Used for the 'where' clause
        Expression<Func<T, bool>> Criteria {get; }

        // Used for the 'include' clause
        List<Expression<Func<T, object>>> Includes {get; }

        Expression<Func<T, object>> OrderBy {get; }
        Expression<Func<T, object>> OrderByDescending {get; }

        // Properties for pagination
        int Take {get;}
        int Skip {get;}
        bool IsPagingEnabled {get;}
    }
}