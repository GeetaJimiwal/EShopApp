using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTicketApi.Model
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string DirectorName { get; set; }
        public string ProducerName { get; set; }
        public string CastingPartner { get; set; }
        public string MovieType { get; set; }
        public int Rating { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [ForeignKey("CityId")]
        public int CityId { get; set; }

        public virtual City City { get; set; }

        public string ImageName { get; set; }

    }
}
