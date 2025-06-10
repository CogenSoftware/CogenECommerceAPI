namespace Core.Domain.Common
{
    public interface IEntityBase
    {
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}