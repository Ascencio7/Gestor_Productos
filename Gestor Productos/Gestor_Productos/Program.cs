using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_Productos
{
    public class Program
    {
        #region Variables Globales
        static List<Productos> productos = new List<Productos>(); // Lista para almacenar los productos
        static int nextId = 1; // Variable para asignar el ID de los productos de manera incremental
        #endregion

        static void Main(string[] args)
        {
            #region Variables Globales
            // declarar la variable para el menu
            int opcion = 0;
            #endregion


            #region Bucle del Menu
            // Bucle para mostrar el menú hasta que se elija salir
            do
            {
                Console.WriteLine("\n====== Menú de Gestión de Productos ======");
                Console.WriteLine("1. Agregar Producto");
                Console.WriteLine("2. Mostrar Productos");
                Console.WriteLine("3. Buscar Producto por ID");
                Console.WriteLine("4. Eliminar Producto por ID");
                Console.WriteLine("5. Salir");
                Console.Write("\nSelecciona una opción: ");

                if(int.TryParse(Console.ReadLine(), out opcion)) // intenta convertir la entrada del usuario a un numero entero
                {
                    // Leer la opción del usuario
                    switch (opcion)
                    {
                        case 1:
                            AgregarProductos();
                            break;
                        case 2:
                            MostrarProductos();
                            break;
                        case 3:
                            BuscarProductoID();
                            break;
                        case 4:
                            EliminarProductoID();
                            break;
                        case 5:
                            Console.WriteLine("\nSaliendo del programa...");
                            break;
                        default:
                            Console.WriteLine("\nOpción no válida. Por favor, selecciona una opción del 1 al 5.");
                            break;
                    }
                }

            } while (opcion != 5);
            #endregion

        }


        #region Agregar Producto
        public static void AgregarProductos()
        {
            // Solicitar datos del producto
            Console.WriteLine("\nIngresa los datos del producto a ingresar.");

            Console.Write("\nNombre del Producto: ");
            string nombreProducto = Console.ReadLine(); // se guarda el dato ingresado en la variable (asi sucesivamente para los demas campos)

            Console.Write("Descripción del Producto: ");
            string descripcionProducto = Console.ReadLine();

            Console.Write("Precio del Producto: ");
            double precioProducto = double.Parse(Console.ReadLine()); // Convertir el dato ingresado a double

            Console.Write("Stock del Producto: ");
            int stockProducto = int.Parse(Console.ReadLine()); // Convertir el dato ingresado a int

            DateTime fechaCreacion = DateTime.Now; // esto obtiene la fecha actual del sistema

            // Crear un nuevo producto
            Productos nuevoProducto = new Productos(nextId++, nombreProducto, descripcionProducto, (double)precioProducto, stockProducto, fechaCreacion);
            
            // Agregar el producto a la lista
            productos.Add(nuevoProducto);
            
            // Mostrar mensaje de éxito
            Console.WriteLine($"\nProducto '{nuevoProducto.Nombre_Producto}' agregado exitosamente con ID: {nuevoProducto.Id_Producto}.");
        }
        #endregion


        #region Mostrar Productos
        public static void MostrarProductos()
        {
            if (productos.Count == 0) // verifica si la lista de productos esta vacia
            {
                Console.WriteLine("\nNo hay productos disponibles."); // si esta vacia se muestra el mensaje
                return; // y se sale del metodo
            }

            // mostrar los datos del producto si la lista no esta vacia
            Console.WriteLine("\nLista de Productos:");

            // Iterar sobre la lista de productos y mostrar la información de cada uno
            foreach (var producto in productos)
            {
                producto.MostrarInformacion(); // se llama al metodo de la clase Productos
            }
        }
        #endregion


        #region Buscar Producto por ID
        public static void BuscarProductoID()
        {
            Console.Write("\nIngresa el Id del productoa a buscar: "); // solicita el id del producto a buscar
            int idProducto = Convert.ToInt32(Console.ReadLine()); // se guarda el dato en la variable y se convierte a int

            // Buscar el producto en la lista utilizando LINQ
            var productoEncontrado = productos.FirstOrDefault(p => p.Id_Producto == idProducto); // se busca el id del producto en la lista de productos

            // Verificar si se encontró el producto
            if (productoEncontrado != null) // si el producto fue encontrado
            {
                Console.WriteLine("\nProducto Encontrado"); // se muestra el mensaje
                productoEncontrado.MostrarInformacion(); // y se llama al metodo de la clase Productos
            }
            else
            {
                Console.WriteLine($"\nNo se encontró un producto con ID: {idProducto}."); // si no se encuentra el producto se muestra el mensaje
            }
        }
        #endregion


        #region Eliminar Producto por ID
        public static void EliminarProductoID()
        {
            Console.Write("\nIngresa el Id del producto a eliminar: "); // solicita el id del producto a eliminar
            
            if(int.TryParse(Console.ReadLine(), out int idproducto)) // intenta convertir el dato ingresado a int
            {
                // Buscar el producto en la lista utilizando LINQ
                var productoEliminar = productos.FirstOrDefault(p => p.Id_Producto == idproducto); // se busca el id del producto en la lista de productos

                // Verificar si se encontró el producto
                if (productoEliminar != null)
                {
                    productos.Remove(productoEliminar); // se elimina el producto de la lista
                    Console.WriteLine($"Producto con id {idproducto} eliminado exitosamente"); // se muestra el mensaje de exito
                }
                else
                {
                    Console.WriteLine($"\nNo se encontró un producto con ID: {idproducto}."); // si no se encuentra el producto se muestra el mensaje
                }
            }
            else
            {
                Console.WriteLine("\nID inválido. Por favor, ingresa un número válido."); // si el dato ingresado no es un numero se muestra el mensaje
            }
        }
        #endregion


    }
}