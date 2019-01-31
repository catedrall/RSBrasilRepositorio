using RSBrasil.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSBrasil.Model.Entidades
{
    public class PerfilAcesso : ModelBase
    {
        public int? IdPerfil { get; set; }
        public int? IdTela { get; set; }
    }
}
