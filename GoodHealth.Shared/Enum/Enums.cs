using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GoodHealth.Shared.Enum
{
    public static class Enums
    {
        public static T GetEnumValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new ArgumentException("");
            FieldInfo[] fields = type.GetFields();

            var field = fields
                            .SelectMany(f => f.GetCustomAttributes(
                                typeof(DescriptionAttribute), false), (
                                    f, a) => new { Field = f, Att = a })
                            .FirstOrDefault(a => ((DescriptionAttribute)a.Att)?.Description == description);

            return field == null ? default(T) : (T)field.Field.GetRawConstantValue();
        }

    }
}
