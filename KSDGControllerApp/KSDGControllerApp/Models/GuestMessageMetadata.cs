using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSDGControllerApp.Models
{
    [MetadataType(typeof(GuestMessageMD))]
    public partial class GuestMessage
    {
        public class GuestMessageMD
        {
            [Display(Name = "名稱")]
            [Required]
            public string Name { get; set; }
            [Display(Name = "貼文日期")]            
            public DateTime DatePosted { get; set; }
            [Display(Name = "Email")]
            [Required]
            [EmailAddress]
            public string Email { get; set; }
            [Display(Name = "主題")]
            [Required]
            public string Subject { get; set; }
            [Display(Name = "內文")]
            [Required]
            public string Body { get; set; }
            [Display(Name = "檔案路徑")]
            public string FilePath { get; set; }
        }
    }
}
