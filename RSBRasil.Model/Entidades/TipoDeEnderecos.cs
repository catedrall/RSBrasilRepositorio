using RSBrasil.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBrasil.Model.Entidades
{
    public class TipoDeEnderecos : ModelBase
    {
        public string Descricao { get; set; }
        public int? Enderecos_IdEnderecos { get; set; }
        public int? IdTipoDeEndereços { get; set; }
    }
}
