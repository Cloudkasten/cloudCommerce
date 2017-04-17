using System;

namespace cloudCommerce
{ 
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)] 
    public sealed class ObjectSignatureAttribute : Attribute
    {
    }
}
