using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KSDGControllerApp.Models
{
    public partial class GuestMessage
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DatePosted { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string FilePath { get; set; }
    }
}
