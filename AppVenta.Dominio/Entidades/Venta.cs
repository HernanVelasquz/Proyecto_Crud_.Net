﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVenta.Dominio.Entidades
{
    public class Venta
    {
        public Guid VentaId { get; set; }
        public long numeroVenta { get; set; }
        public DateTime fecha { get; set; }
        public string concepto { get; set; }
        public decimal subtotal { get; set; }
        public decimal impuesto { get; set; }
        public decimal total { get; set; }

        public bool anulado { get; set; } = false;

        public List<VentaDetalle> VentasDetalle { get; set; }
    }
}
