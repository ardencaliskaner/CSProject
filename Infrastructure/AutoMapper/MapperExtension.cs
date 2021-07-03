using AutoMapper;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Infrastructure.AutoMapper
{
    public static class MapperExtension
    {
        public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            var flags = BindingFlags.Public | BindingFlags.Instance;
            var sourceType = typeof(TSource);
            var destinationProperties = typeof(TDestination).GetProperties(flags);

            foreach (var property in destinationProperties)
            {
                if (sourceType.GetProperty(property.Name, flags) == null)
                {
                    expression.ForMember(property.Name, opt => opt.Ignore());
                }
            }
            return expression;
        }
        public static IMappingExpression<TSource, TDestination> IgnoreAllNonExistingWithReferance<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        {
            var flags = BindingFlags.Public | BindingFlags.Instance;
            var sourceType = typeof(TSource);
            var destinationProperties = typeof(TDestination).GetProperties(flags);

            foreach (var property in destinationProperties)
            {
                if (sourceType.GetProperty(property.Name, flags) == null)
                {
                    expression.ForMember(property.Name, opt => opt.Ignore());
                }

                if (property.GetMethod.ReturnType.FullName.Contains("FVE.Dto."))
                {
                    expression.ForMember(property.Name, opt => opt.Ignore());
                }
            }
            return expression;
        }

    }
}
