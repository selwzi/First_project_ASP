using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace WebApplication1.Models
{
    public class User
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string BirthDate { get; set; }

        public void OnlyDate()
        {
            BirthDate = DateTime.Now.ToString("yyyy-MM-dd");
		}
    }
}
