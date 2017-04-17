using System;

namespace cloudCommerce
{
    public interface IOrdered
    {
        // TODO: (MC) Make Nullable!
        int Ordinal { get; }
    }
}
