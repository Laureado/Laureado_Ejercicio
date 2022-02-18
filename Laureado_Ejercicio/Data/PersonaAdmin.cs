using Laureado_Ejercicio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laureado_Ejercicio.Data
{
    public class PersonaAdmin
    {
        /// <summary>
        /// Consulta todas las lineas de la tabla persona
        /// </summary>
        /// <returns>datos de las personas</returns>
        public IEnumerable<Persona> GetPersonas()
        {
            
            using (Laureado_PruebaEntity context = new Laureado_PruebaEntity())
            {
                return context.Persona.AsNoTracking().ToList();
            }
        }

        /// <summary>
        /// Guardar una persona en la Base de Datos
        /// </summary>
        /// <param name="modelo">datos de la persona (Nombre, fecha de nacimiento) </param>
        public void SubmitPersona(Persona model)
        {
            using (Laureado_PruebaEntity context = new Laureado_PruebaEntity()) 
            {
                context.Persona.Add(model);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Obtener una persona a traves de filtrar el id
        /// </summary>
        /// <param name="id">Id de la persona</param>
        /// <returns>Datos de la persona (Nombre, fecha de nacimiento)</returns>
        public Persona GetPersonaDetail(int id)
        {
            using (Laureado_PruebaEntity context = new Laureado_PruebaEntity())
            {
                return context.Persona.FirstOrDefault(p => p.ID == id);
            }
        }

        /// <summary>
        /// Modificar la data de la persona
        /// </summary>
        /// <param name="model">Datos de la persona</param>
        public void Update(Persona model)
        {
            using(Laureado_PruebaEntity context = new Laureado_PruebaEntity())
            {
                context.Entry(model).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Elimina la data de la persona
        /// </summary>
        /// <param name="model">Datos de la persona</param>
        public void Delete(Persona model)
        {
            using (Laureado_PruebaEntity context = new Laureado_PruebaEntity())
            {
                context.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }


    }
}