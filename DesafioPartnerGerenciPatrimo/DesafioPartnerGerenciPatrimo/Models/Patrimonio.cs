using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesafioPartnerGerenciPatrimo.Models
{
    public class Patrimonio
    {
        public int PatrimonioId { get; set; }
        public string Nome { get; set; }
        public int MarcaId { get; set; }
        public string Descricao { get; set; }
        public int NrTombo { get; set; }
    }
}