using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDBlazorServer.Data
{
    public class Dndbook
    {
        [Key]
        public int DndbookId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public virtual Publisher Publisher { get; set; }

        [ForeignKey("Publisher")]
        public int PublisherId { get; set; }
    }
}
