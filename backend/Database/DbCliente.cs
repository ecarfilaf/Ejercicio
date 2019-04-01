using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Database
{
    public class DbCliente : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        //public DbQuery<Cliente> Clientes { get; set; }

        public DbCliente(DbContextOptions<DbCliente> options)
            : base(options)
        {

        }

        public List<Cliente> GetAll()
        {
            // Ejemplo con una Query de SQL
            List<Cliente> clientes = this
                                        .Cliente
                                        .FromSql("SELECT * FROM Cliente")
                                        .ToList();

            return clientes;
        }

        public Cliente GetByRut(string rut)
        {
            // Ejemplo con LinQ
            Cliente cliente = this
                                .Cliente
                                .FirstOrDefault(c => c.Rut == rut);
            return cliente;                       
        }

        public Cliente Create(Cliente cliente)
        {
            try
            {
                this
                    .Cliente
                    .Add(cliente);

                this.SaveChanges();

                return cliente;
            }
            catch(Exception ex)
            {
                throw new Exception("No fue posible crear el cliente, por: " + ex.ToString());
            }
        }

        public Cliente Delete(string rut)
        {
            try
            {
                var cliente = this.GetByRut(rut);

                if (cliente == null)
                {
                    throw new Exception($"El cliente {rut} no se puede eliminar debido a no existe.");
                }

                this
                    .Cliente
                    .Remove(cliente);

                this.SaveChanges();

                return cliente;
            }
            catch(Exception ex)
            {
                throw new Exception($"No fue posible eliminar el usuario {rut}, por: " + ex.ToString());
            }
        }

    }
}
