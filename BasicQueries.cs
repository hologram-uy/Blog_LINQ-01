using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Fuente de datos: Lista de productos
            var productos = new List<Producto>
            {
                new Producto { Id = 1, Nombre = "Laptop", Precio = 1000, Categoria = "Electrónica" },
                new Producto { Id = 2, Nombre = "Mouse", Precio = 20, Categoria = "Electrónica" },
                new Producto { Id = 3, Nombre = "Monitor", Precio = 150, Categoria = "Electrónica" },
                new Producto { Id = 4, Nombre = "Teclado", Precio = 50, Categoria = "Electrónica" },
                new Producto { Id = 5, Nombre = "Silla", Precio = 85, Categoria = "Muebles" },
                new Producto { Id = 6, Nombre = "Escritorio", Precio = 200, Categoria = "Muebles" },
                new Producto { Id = 7, Nombre = "Libro", Precio = 25, Categoria = "Papelería" }
            };

            // 1. Mostrar todos los productos
            Console.WriteLine("Todos los productos:");
            foreach (var producto in productos)
            {
                Console.WriteLine($"{producto.Nombre} - ${producto.Precio}");
            }

            // 2. Filtrar productos con precio mayor a 100
            var productosCaros = from p in productos
                                 where p.Precio > 100
                                 select p;

            Console.WriteLine("\nProductos con precio mayor a 100:");
            foreach (var producto in productosCaros)
            {
                Console.WriteLine($"{producto.Nombre} - ${producto.Precio}");
            }

            // 3. Ordenar productos por precio de menor a mayor
            var productosOrdenados = from p in productos
                                      orderby p.Precio
                                      select p;

            Console.WriteLine("\nProductos ordenados por precio (menor a mayor):");
            foreach (var producto in productosOrdenados)
            {
                Console.WriteLine($"{producto.Nombre} - ${producto.Precio}");
            }

            // 4. Proyectar solo nombres de los productos (usando select)
            var nombresProductos = from p in productos
                                   select p.Nombre;

            Console.WriteLine("\nNombres de todos los productos:");
            foreach (var nombre in nombresProductos)
            {
                Console.WriteLine(nombre);
            }

            // 5. Agrupar productos por categoría
            var productosPorCategoria = from p in productos
                                        group p by p.Categoria into grupo
                                        select new { Categoria = grupo.Key, Productos = grupo };

            Console.WriteLine("\nProductos agrupados por categoría:");
            foreach (var grupo in productosPorCategoria)
            {
                Console.WriteLine($"Categoría: {grupo.Categoria}");
                foreach (var producto in grupo.Productos)
                {
                    Console.WriteLine($"  {producto.Nombre} - ${producto.Precio}");
                }
            }

            // 6. Contar productos en la lista
            var totalProductos = productos.Count();
            Console.WriteLine($"\nTotal de productos: {totalProductos}");

            // 7. Obtener el producto con el precio más alto
            var productoMasCaro = productos.OrderByDescending(p => p.Precio).FirstOrDefault();
            Console.WriteLine($"\nProducto más caro: {productoMasCaro.Nombre} - ${productoMasCaro.Precio}");
        }
    }

    // Clase Producto
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Categoria { get; set; }
    }
}
