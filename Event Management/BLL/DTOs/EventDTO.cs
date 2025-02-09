using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class EventDTO
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required, MaxLength(255)]
        public string Location { get; set; }

        [MaxLength(50)]
        public string EntryPass { get; set; }
    }
}
