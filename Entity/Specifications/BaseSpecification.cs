using System.Linq.Expressions;
using Entity.Interfaces;

namespace Entity.Specifications
{
  public class BaseSpecification<T> : ISpecification<T>
  {
    public BaseSpecification()
    {
    }

    public BaseSpecification(Expression<Func<T, bool>> criteria)
    {
      Criteria = criteria;
    }

    public Expression<Func<T, bool>> Criteria { get; }

    public List<Expression<Func<T, object>>> Include { get; } = new List<Expression<Func<T, object>>>();

    public Expression<Func<T, object>> OrderByDescending { get; private set; }

    public Expression<Func<T, object>> Sort { get; private set; }

    public int Take { get; private set; }

    public int Skip { get; private set; }

    public bool IsPagingEnabled { get; private set; }

    protected void IncludeMethod(Expression<Func<T, object>> expression)
    {
      Include.Add(expression);
    }

    protected void SortMethod(Expression<Func<T, object>> sortExpression)
    {
      Sort = sortExpression;
    }

    protected void OrderByDescendingMethod(Expression<Func<T, object>> orderDescendingExpression)
    {
      OrderByDescending = orderDescendingExpression;
    }
    protected void FeedPagination(int take, int skip)
    {
      Take = take;
      Skip = skip;
      IsPagingEnabled = true;
    }
  }
}