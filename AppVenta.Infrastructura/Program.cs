// See https://aka.ms/new-console-template for more information
using System;

using AppVenta.Infrastructura.Datos.Contexto;
namespace AppVenta.Infrastructura.Datos
{
    class Progam
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creando la DB si no existe...");
            VentaContexto db = new VentaContexto();
            db.Database.EnsureCreated();
            Console.WriteLine("Listo, Existe");
            Console.ReadLine();
        }
    }
}