using System;

namespace SolidDAL.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public override bool Equals(object obj)
        {
            return obj is Entity entity && Equals(entity);
        }

        public bool Equals(Entity other)
        {
            return GetType() == other.GetType() && Id == other.Id;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = hash * 29 + GetType().GetHashCode();
                hash = hash * 29 + Id.GetHashCode();
                return hash;
            }
        }
    }
}