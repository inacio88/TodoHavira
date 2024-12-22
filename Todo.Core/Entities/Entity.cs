namespace Todo.Core.Entities
{
    public abstract class Entity : IEquatable<Guid>
    {
        protected Entity() => Id = Guid.NewGuid();
        public Guid Id { get;}
        public bool Equals(Guid other)
        {
            return Id == other;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}