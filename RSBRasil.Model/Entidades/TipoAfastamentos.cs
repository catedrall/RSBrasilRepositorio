﻿using RSBrasil.Shared.Model;
using System;

namespace RSBrasil.Model.Entidades
{
    public class TipoAfastamentos : ModelBase
    {
        public TipoAfastamentos()
        {

        }

        public string Descricao { get; set; }
        public DateTime? DataCompra { get; set; }
        public int? Duracao { get; set; }
    }
}
