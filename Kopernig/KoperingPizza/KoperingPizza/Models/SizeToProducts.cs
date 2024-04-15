using System.ComponentModel.DataAnnotations.Schema;

namespace KoperingPizza.Models
{
	public class SizeToProducts
	{
		public int ProductId { get; set; }
		public int SizeProductId { get; set; }
		public Product Product { get; set; }
		public SizeProduct SizeProduct { get; set; }
	}
}
