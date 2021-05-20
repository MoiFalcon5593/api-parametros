using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiParametros.Models
{
    [Table("REGISTRO_PARAMETROS")]
    public class Parametros
    {
        [Key]
        public int ID { get; set; }
        public string NOM_ESTACIÓN { get; set; }
        public string LATITUD { get; set; }
        public string LONGITUD { get; set; }

        public string NIVEL_ALCALINIDAD { get; set; }
        public int NIVEL_HUMEDAD { get; set; }
        public DateTime FECHA_REGISTRO { get; set; }
    }
}
