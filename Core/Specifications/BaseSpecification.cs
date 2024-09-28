using System.Linq.Expressions;

namespace Core.Specifications
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

        public List<Expression<Func<T, object>>> Includes { get; }
            = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderByAscending { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; private set; }

        protected void AddIncludes(Expression<Func<T, object>> include) =>
            Includes.Add(include);

        protected void AddOrderByAscending(Expression<Func<T, object>> orderByAscendingExpression) =>
            OrderByAscending = orderByAscendingExpression;

        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression) =>
            OrderByDescending = orderByDescendingExpression;

        protected void ApplyPagination(int skip, int take)
        {
            // Ensure skip and take are valid
            if (skip >= 0 && take > 0)
            {
                Skip = skip;
                Take = take;
                IsPagingEnabled = true;
            }
        }
    }
}
