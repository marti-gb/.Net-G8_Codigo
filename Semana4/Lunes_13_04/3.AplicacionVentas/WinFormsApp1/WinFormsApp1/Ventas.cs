using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Ventas
    {
        private string _producto;
        private int _cantidad;

        public string Producto
        {
            get { return _producto; }
            set { _producto = value; }
        }

        public int Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        //Asignacion de precio de los productos
        public double AsignarPrecio()
        {
            switch (Producto)
            {
                case "Celular": return 1000;
                case "Laptop": return 3000;
                case "Monitor": return 500;
                case "Televisor": return 1500;
                case "Lavadora": return 2000;
            }
            return 0;
        }

        //Calcular SubTotal
        public double CalcularSubTotal()
        {
            return AsignarPrecio() * Cantidad;
        }

        //Calcular Descuento
        public double CalcularDescuento()
        {
            double subTotal = CalcularSubTotal();

            if (subTotal <= 1000) return 5.0 / 100 * subTotal;
            else if (subTotal > 1000 && subTotal <= 3000) return 10.0 / 100 * subTotal;
            else return 20.0 / 100 * subTotal;

        }

        //Calcular Neto
        public double CalcularNeto()
        {
            return CalcularSubTotal() - CalcularDescuento();
        }
    }
}
