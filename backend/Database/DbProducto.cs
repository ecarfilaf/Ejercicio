using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Database
{
	public class DbProducto : DbContext
	{
		public DbSet<Producto> Producto { get; set; }
		//public DbQuery<Producto> Productos { get; set; }

		public DbProducto(DbContextOptions<DbProducto> options)
			: base(options)
		{

		}

		public List<Producto> GetAll()
		{
			// Ejemplo con una Query de SQL
			List<Producto> Productos = this
										.Producto
										.FromSql("SELECT * FROM Producto")
										.ToList();

			return Productos;
		}

		public Producto GetByCodProducto(string CodProducto)
		{
			// Ejemplo con LinQ
			Producto Producto = this
								.Producto
								.FirstOrDefault(c => c.CodProducto == CodProducto);
			return Producto;                       
		}

		public Producto Create(Producto Producto)
		{
			try
			{
				this
					.Producto
					.Add(Producto);

				this.SaveChanges();

				return Producto;
			}
			catch(Exception ex)
			{
				throw new Exception("No fue posible crear el Producto, por: " + ex.ToString());
			}
		}

		public Producto Delete(string CodProducto)
		{
			try
			{
				var Producto = this.GetByCodProducto(CodProducto);

				if (Producto == null)
				{
					throw new Exception($"El Producto {CodProducto} no se puede eliminar debido a no existe.");
				}

				this
					.Producto
					.Remove(Producto);

				this.SaveChanges();

				return Producto;
			}
			catch(Exception ex)
			{
				throw new Exception($"No fue posible eliminar el usuario {CodProducto}, por: " + ex.ToString());
			}
		}

	}
}
