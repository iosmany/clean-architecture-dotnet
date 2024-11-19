using System.Linq.Expressions;

namespace ecommerce.core.EF
{
    public sealed class PredicateBuilder<E> where E: class
    {
        private Expression<Func<E, bool>> _predicate;
        public PredicateBuilder()
        {
            _predicate = e => true;
        }

        public PredicateBuilder<E> And(Expression<Func<E, bool>> rigth)
        {
            _predicate = Combine(_predicate, rigth, Expression.AndAlso);
            return this;
        }
        public PredicateBuilder<E> Or(Expression<Func<E, bool>> rigth)
        {
            _predicate = Combine(_predicate, rigth, Expression.OrElse);
            return this;
        }
        public PredicateBuilder<E> GreaterThan(Expression<Func<E, bool>> rigth)
        {
            _predicate = Combine(_predicate, rigth, Expression.GreaterThan);
            return this;
        }
        public PredicateBuilder<E> GreaterThanOrEqual(Expression<Func<E, bool>> rigth)
        {
            _predicate = Combine(_predicate, rigth, Expression.GreaterThanOrEqual);
            return this;
        }
        public PredicateBuilder<E> LessThan(Expression<Func<E, bool>> rigth)
        {
            _predicate = Combine(_predicate, rigth, Expression.LessThan);
            return this;
        }
        public PredicateBuilder<E> LessThanOrEqual(Expression<Func<E, bool>> rigth)
        {
            _predicate = Combine(_predicate, rigth, Expression.LessThanOrEqual);
            return this;
        }
        public PredicateBuilder<E> Equal(Expression<Func<E, bool>> rigth)
        {
            _predicate = Combine(_predicate, rigth, Expression.Equal);
            return this;
        }

        private Expression<Func<E, bool>> Combine(Expression<Func<E, bool>> left, 
                                                 Expression<Func<E, bool>> right, Func<Expression, Expression, BinaryExpression> merge)
        {
            var parameter = Expression.Parameter(typeof(E));
            var leftParameter = new ParameterReplacerVisitor(left.Parameters[0], parameter);
            var leftExpression= leftParameter.Visit(left.Body);

            var rigthParameter = new ParameterReplacerVisitor(right.Parameters[0], parameter);
            var rightExpression = rigthParameter.Visit(right.Body);

            var expression = merge(leftExpression, rightExpression);
            return Expression.Lambda<Func<E, bool>>(expression, parameter);
        }

        public void Compile() => _predicate.Compile();
        public Expression<Func<E, bool>> Build() => _predicate;

        class ParameterReplacerVisitor : ExpressionVisitor
        {
            readonly ParameterExpression _oldParameter;
            readonly ParameterExpression _newParameter;
            public ParameterReplacerVisitor(ParameterExpression oldParameter, ParameterExpression newParameter)
            {
                _oldParameter = oldParameter;
                _newParameter = newParameter;
            }
            protected override Expression VisitParameter(ParameterExpression parameter)
            {
                return parameter == _oldParameter ? _newParameter : parameter;
            }
        }
    }
}
