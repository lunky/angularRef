namespace Entities
{
	public class EntityBase: IEntity
	{
		public int Id { get; set; }
		public bool IsDeleted { get; set; }
	}
}