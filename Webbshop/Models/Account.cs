using Webbshop.Models.Base;

namespace Webbshop.Models
{
	public class Account : BaseModel
	{
		public string OpenIDIssuer { get; set; }
		public string OpenIDSubject { get; set; }
		public string Name { get; set; }

        public Basket Basket { get; set; }	
    }
}