using Contract.Requests;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Interfacees
{
    public interface IHeroeRepositorio
    {
        Task<Heroe> ObtenerHeroe(int IdHeroe);
        Task<IEnumerable<Heroe>> ObtenerTodosLosHeroes();
        Task<bool> CrearHeroe(HeroeRequest request);
        Task<bool> ActualizarHereo(HeroeRequest request);
        Task<bool> BorrarHeroe (int idHeroe);
    }
}
