namespace DTO.Entities.Base
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool Deleted { get; protected set; }

        public void Delete()
        {
            Deleted = true;
        }
    }
}