using System.Collections.Generic;
using System.Linq;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.DAO
{
    public class CotizacionRepository : ModelRepository<Cotizacion>,ICotizacionRepository
    {
        public CotizacionRepository(DbContext dbContext) : base(dbContext)
        {
            // Nothing here
        }
        
        public List<Cotizacion> GetByRut(string rut)
        {
            return _dbContext.Set<Cotizacion>().Where(p => p.persona.Rut.Equals(rut)).ToList();
        }

        public Cotizacion GetById(int id)
        {
            return _dbContext.Set<Cotizacion>().Find(id);
        }
    }
}