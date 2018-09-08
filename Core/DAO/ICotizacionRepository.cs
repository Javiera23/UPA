using System.Collections.Generic;
using Core.Models;

namespace Core.DAO
{
    public interface ICotizacionRepository
    {
         List<Cotizacion> GetByRut(string rut);
         Cotizacion GetById(int id);
    }
}