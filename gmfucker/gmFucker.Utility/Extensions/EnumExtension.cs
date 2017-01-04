using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace gmFucker.Utility.Extensions
{
    public static class EnumExtension
    {
        /// <summary>
        /// 取得列舉變數中的Description屬性描述
        /// </summary>
        /// <param name="enumerationValue">列舉變數</param>
        /// <returns></returns>
        public static string GetDescription(this Enum enumerationValue)
        {
            if (enumerationValue == null)
            {
                return string.Empty;
            }
            Type type = enumerationValue.GetType();
            if (type.IsEnum)
            {
                MemberInfo memberInfo = type.GetMember(enumerationValue.ToString()).Single();
                var attrs = memberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
                else
                {
                    return enumerationValue.ToString();
                }
            }
            throw new ArgumentException($"{nameof(enumerationValue)} 型別必須要是列舉", nameof(enumerationValue));
        }

        /// <summary>
        /// 以Description屬性描述取得列舉內所對應的變數
        /// </summary>
        /// <typeparam name="T">所要取得的列舉</typeparam>
        /// <param name="description">Description屬性描述</param>
        /// <returns></returns>
        public static T GetEnumValueFromDescription<T>(string description)
        {
            Type type = typeof(T);
            if (!type.IsEnum && type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>) && Nullable.GetUnderlyingType(type).IsEnum)
            {
                type = Nullable.GetUnderlyingType(type);
            }
            if (!type.IsEnum)
            {
                throw new ArgumentException($"{nameof(T)} 型別必須要是列舉", nameof(T));
            }
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                if ((attribute != null && attribute.Description == description) || field.Name == description)
                {
                    return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException();
        }        
    }
}
