namespace Ecommerce.Core.Entities
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; } = null;
        public bool IsDeleted { get; set; } = false;

    }

}

