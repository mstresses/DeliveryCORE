namespace DTO.Entities.Base
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; private set; } = false;

        public void SetAsDeleted()
        {
            IsDeleted = true;
        }
    }
}