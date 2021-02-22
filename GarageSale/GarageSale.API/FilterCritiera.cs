using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace GarageSale.API
{
	public class FilterCritiera<T>
	{
		public PropertyInfo Prop { get; set; }
		public FieldInfo Field { get; set; }
		public object Value { get; set; }
		public Type FilteringType => typeof(T);

		public FilterCritiera(string filterName, object value)
		{
			Prop = FilteringType.GetProperty(filterName);
			Field = FilteringType.GetField(filterName);
			Value = value;
		}

		public Expression<Func<T, bool>> Filter(string methodName)
		{
			var filterOnType = Field is null ? Prop.PropertyType : Field.FieldType;
			var value = Convert.ChangeType(Value, filterOnType);
			MethodInfo method = filterOnType.GetMethod(methodName, new[] { filterOnType });
			ParameterExpression prm = Expression.Parameter(FilteringType);
			MethodCallExpression callExpr;

			if (Prop is null)
			{
				//method = Field?.FieldType.GetMethod(methodName, new[] { Field.FieldType })!;
				//var value = Convert.ChangeType(Value, Field.FieldType);
				callExpr = Expression.Call(Expression.Field(prm, Field), method, Expression.Constant(value));
			}
			else
			{
				//method = Prop?.PropertyType.GetMethod(methodName, new[] { Prop.PropertyType })!;
				//var value = Convert.ChangeType(Value, Prop.PropertyType);
				callExpr = Expression.Call(Expression.Property(prm, Prop), method, Expression.Constant(value));
			}

			return Expression.Lambda<Func<T, bool>>(callExpr, prm);
		}
	}
}
