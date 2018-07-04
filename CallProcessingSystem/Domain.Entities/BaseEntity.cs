using System;

namespace Domain.Entities
{
    public abstract class BaseEntity<T>
    {
        protected BaseEntity()
        {
            CreateDate = DateTime.Now;
        }

        public T Id { get; set; }

        public DateTime CreateDate { get; set; }

        public override string ToString()
        {
            return string.Format("Type = {0}, Id = {1}", GetType().Name, Id);
        }
    }
}