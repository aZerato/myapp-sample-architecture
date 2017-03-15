namespace System
{
    using ComponentModel;
    using Reflection;

    /// <summary>
    /// Enum extensions methods.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Get value setted in [Description] annotation.
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum element)
        {
            Type type = element.GetType();
            MemberInfo[] memInfo = type.GetMember(element.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0)
                {
                    return ((DescriptionAttribute)attributes[0]).Description;
                }
            }

            return element.ToString();
        }
    }
}
