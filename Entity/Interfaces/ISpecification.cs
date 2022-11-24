using System.Linq.Expressions;

namespace Entity.Interfaces
{
  public interface ISpecification<T>
  {
    Expression<Func<T, bool>> Criteria { get; }

    List<Expression<Func<T, object>>> Include { get; }

    Expression<Func<T, object>> OrderByDescending { get; }

    Expression<Func<T, object>> Sort { get; }

    int Take { get; }

    int Skip { get; }

    bool IsPagingEnabled { get; }
  }
}