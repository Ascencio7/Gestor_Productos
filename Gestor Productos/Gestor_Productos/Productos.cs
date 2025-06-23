using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_Productos
{
    public class Productos
    {
        #region Variables
        public int Id_Producto { get; set; }
        public string Nombre_Producto { get; set; }
        public string Descripcion_Producto { get; set; }
        public double Precio_Producto { get; set; }
        public int Stock_Producto { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        #endregion


        #region Constructor lleno
        public Productos(int idProducto, string nombreProducto, string descripcionProducto, double precioProducto, int stockProducto, DateTime fechaCreacion)
        {
            Id_Producto = idProducto;
            Nombre_Producto = nombreProducto;
            Descripcion_Producto = descripcionProducto;
            Precio_Producto = precioProducto;
            Stock_Producto = stockProducto;
            Fecha_Creacion = fechaCreacion;
        }
        #endregion


        #region builder Info Producto
        // builder = constructor
        public void MostrarInformacion()
        {
            Console.WriteLine($"\nID: {Id_Producto}");
            Console.WriteLine($"Nombre: {Nombre_Producto}");
            Console.WriteLine($"Descripción: {Descripcion_Producto}");
            Console.WriteLine($"Precio: {Precio_Producto:C}");
            Console.WriteLine($"Stock: {Stock_Producto}");
            Console.WriteLine($"Fecha de Creación: {Fecha_Creacion.ToShortDateString()}");
        }
        #endregion

    }
}