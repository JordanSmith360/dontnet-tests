using DotnetTests.Database.Models;
using DotnetTests.Domain.Models;
using System.Linq.Expressions;

namespace DotnetTests.Database.Specification;

public abstract class Specification<TEntity>(Expression<Func<TEntity, bool>>? criteria = null)
    where TEntity : BaseEntity
{
    public Expression<Func<TEntity, bool>>? Criteria { get; } = criteria;
    public List<Expression<Func<TEntity, object>>> Includes { get; set; } = [];
    public bool UseSplitQuery { get; protected set; }
    public int? PageSize { get; protected set; }
    public int? PageNumber { get; protected set; }
    //TODO add orderby

    protected void AddInclude(Expression<Func<TEntity, object>> include)
    {
        Includes.Add(include);
    }
}
