using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioASP.Modelos
{
    public class Bodega
    {
        // este atributo [Key] sirve para indicar a nuestra tabla cual es la primary key
        [Key]
        public int Id { get; set; }
        // Sirve para indicar que el campo nombre es requerido e indicaremos un mensaje de error

        [Required (ErrorMessage = "Nombre es requerido")]
        [MaxLength (60, ErrorMessage = "Nombre debe ser maximo 60 caracteres")]
        public  string Nombre { get; set; }

        [Required(ErrorMessage = "Descripcion es requerida")]
        [MaxLength(100, ErrorMessage = "Nombre debe ser maximo 100 caracteres")]
        public string Descripcion { get; set;}

        [Required(ErrorMessage = "Estado es requerido")]
        public bool Estado { get; set;}

        // Las propiedades que creamos es la forma en la que se crear nuetras columnas en nuestra base de datos
        //para agregarla como una base de datos debemos agregarlo a nuesto DbContext como un DbSet  
    }
}
