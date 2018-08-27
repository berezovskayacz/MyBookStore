using System;
using System.Reflection;

namespace MyBookstore.Core
{
    public abstract partial class BaseEntity: IBaseEntity
    {
        public int Id { get; set; }
    }

    public interface IBaseEntity
    {
        int Id { get; set; }
    }
}
