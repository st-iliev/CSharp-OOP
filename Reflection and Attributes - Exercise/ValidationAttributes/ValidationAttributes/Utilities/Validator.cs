using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Reflection_and_Attributes___Exercise.ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties().Where(s => s.CustomAttributes.Any(s => s.AttributeType.BaseType == typeof(MyValidationAttribute))).ToArray();
            foreach (var prop in properties)
            {
                object propValue = prop.GetValue(obj);
                foreach (var data in prop.CustomAttributes)
                {
                    Type customAttributeType = data.AttributeType;
                    object attributeInstance = prop.GetCustomAttribute(customAttributeType);
                    MethodInfo validationMethod = customAttributeType.GetMethods().First(s => s.Name == "IsValid");
                    bool result = (bool)validationMethod.Invoke(attributeInstance, new object[] { propValue });
                    if (!result)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
