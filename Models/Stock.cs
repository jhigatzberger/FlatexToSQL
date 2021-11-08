using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlatexToSQL.DataModels
{
    public class Stock
    {
        [Key]
        [MaxLength(12)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string FIGI { get; set; }
        [MaxLength(12)]
        public string ISIN { get; set; }
        [MaxLength(10)]
        public string Ticker { get; set; }
    }
}
