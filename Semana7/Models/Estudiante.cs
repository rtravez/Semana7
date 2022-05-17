using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace Semana7.Models
{
    public class Estudiante
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string Usuario { get; set; }
        [MaxLength(100)]
        public string Contrasenia { get; set; }
    }
}
