using System;

namespace Codetox.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class CreateMenuAttribute : Attribute
    {
        public string MenuName;

        public CreateMenuAttribute(string menuName)
        {
            MenuName = menuName;
        }
    }
}