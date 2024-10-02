using DotnetTests.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetTests.Database.Specification;

public static class SpecificationEvaulator
{
    public static IQueryable<TEntity> UseSpecification<TEntity>(this IQueryable<TEntity> inputQueryable, Specification<TEntity> specification)
        where TEntity : BaseEntity
    {
        var queryable = inputQueryable;

        if (specification is null)
        {
            return queryable;
        }

        if (specification.Criteria is not null)
        {
            queryable.Where(specification.Criteria);
        }

        queryable = specification.Includes
            .Aggregate(queryable, (current, include) => current.Include(include));

        if (specification.UseSplitQuery)
        {
            queryable = queryable.AsSplitQuery();
        }

        if (specification.PageNumber is not null 
            && specification.PageSize is not null)
        {
            queryable.Skip(((int)specification.PageNumber - 1) * (int)specification.PageSize)
                .Take((int)specification.PageSize);
        }

        return queryable;
    }
}
