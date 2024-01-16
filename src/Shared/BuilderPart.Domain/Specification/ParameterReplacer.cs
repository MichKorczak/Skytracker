using System.Linq.Expressions;

namespace BuilderPart.Domain.Specification
{
    internal class ParameterReplacer : ExpressionVisitor
    {
        private readonly ParameterExpression _oldParameter;
        private readonly ParameterExpression _newParameter;

        public ParameterReplacer(ParameterExpression newParameter, ParameterExpression oldParameter)
        {
            _newParameter = newParameter;
            _oldParameter = oldParameter;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return node == _oldParameter ? 
                _newParameter : base.VisitParameter(node);
        }
    }
}