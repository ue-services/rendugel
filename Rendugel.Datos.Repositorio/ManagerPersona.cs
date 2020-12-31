using Rendugel.Datos.Interface;
using Rendugel.Datos.Modelo;
using Rendugel.Dominio.Entidades.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendugel.Datos.Repositorio
{
    public class ManagerPersona : IManagerPersona, IDisposable
    {
        public void Dispose()
        {
            return;
        }

        public Persona getPersonaPorDNI(string dni)
        {
            using (var _context = new rendugelDBContext())
            {
                var item = _context.Persona
                    .Where(x => x.EsActivo == true & x.EsBorrado == false & x.DniPersona == dni)                    
                    .FirstOrDefault();
                return item;
            }
        }

        public int savePersona(Persona persona)
        {
            using (var _context = new rendugelDBContext())
            {
                _context.Persona.Add(persona);
                _context.SaveChanges();
                return persona.IdPersona;
            }
        }

        public void updatePersona(Persona persona)
        {
            using (var _context = new rendugelDBContext())
            {
                _context.Persona.Update(persona);
                _context.SaveChanges();
            }
        }
    }
}
