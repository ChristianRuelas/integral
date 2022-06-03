using System;
using inmobiliaria.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace inmobiliaria.Dato
{
    public class CasaAdmin
    {
        /// <summary>
        /// Consultar casas
        /// </summary>
        /// <returns>Lista de casas</returns>
        public IEnumerable<casa> consultar()
        {
            using (PropiedadesDbEntities contexto=new PropiedadesDbEntities())
            {
                return contexto.casas.AsNoTracking().ToList();
                
            }

        }
        /// <summary>
        /// Guardar nueva casa
        /// </summary>
        /// <param name="modelo"></param>
        public void guardar(casa modelo)
        {
            using (PropiedadesDbEntities contexto=new PropiedadesDbEntities())
            {
                contexto.casas.Add(modelo);
                contexto.SaveChanges();

            }
        }
        /// <summary>
        /// Consultar los detalles de una casa
        /// </summary>
        /// <returns></returns>
        public casa consultarDetalles(int id)
        {
            using (PropiedadesDbEntities contexto = new PropiedadesDbEntities())
            {
                return contexto.casas.FirstOrDefault(c=>c.Idcasa==id);

            }
        } 
        /// <summary>
        /// modifica una propiedad
        /// </summary>
        /// <param name="modelo"></param>
        public void modificar(casa modelo)
        {
            using (PropiedadesDbEntities contexto = new PropiedadesDbEntities())
            {
                contexto.Entry(modelo).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();

            }
        }
        /// <summary>
        /// Eliminar una propiedad
        /// </summary>
        /// <param name="modelo"></param>
        public void Eliminar(casa modelo)
        {
            using (PropiedadesDbEntities contexto = new PropiedadesDbEntities())
            {
                try
                {
                    contexto.Entry(modelo).State = System.Data.Entity.EntityState.Deleted;
                    contexto.SaveChanges();

                }
                catch (Exception e)
                {
                    throw e;
                }
               
            }
        }
        public void entrar(string us, string pass)
        {
          
        }
    }
}