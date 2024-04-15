namespace KoperingPizza.Models
{
	public class SizeProduct
	{
        public int Id { get; set; }
        public string Name{ get; set; }
		public ICollection<SizeToProducts> SizeToProducts { get; set; }

	}
}
