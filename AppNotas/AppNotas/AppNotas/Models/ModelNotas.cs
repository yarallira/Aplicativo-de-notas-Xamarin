using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppNotas.Models
{
    [Table("Anotacoes")]

    public class ModelNotas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Titulo { get; set; }
        [NotNull]
        public string Dados { get; set; }
        [NotNull]
        public Boolean Favorito { get; set; }

        public ModelNotas()
        {
            this.Id = 0;
            this.Dados = "";
            this.Favorito = false;
            this.Titulo = "";
        }
    }
}
