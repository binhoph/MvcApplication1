using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.ViewModels
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Idade { get; set; }
  
        public int IdTelefone { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
    }
}