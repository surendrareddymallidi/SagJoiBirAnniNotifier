using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SagEmpDataModel
{
    [Table("SGT_LOCATION")]
    public class busSagLocation
    {
        [DisplayName("Location ID")]
        [Column("LOCATION_ID")]
        [Key]
        public byte locationId { get; set; }

        [DisplayName("Location Name")]
        [Column("LOCATION_NAME")]
        public string locationName { get; set; }
    }
}
