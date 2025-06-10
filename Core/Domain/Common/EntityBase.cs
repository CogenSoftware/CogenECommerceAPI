namespace Core.Domain.Common
{
    public class EntityBase : IEntityBase
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; } = Guid.Empty;
        public DateTime UpdatedAt { get; set; }
        public Guid UpdatedBy { get; set; } = Guid.Empty;
        public bool IsDeleted { get; set; } = false;
    }
}