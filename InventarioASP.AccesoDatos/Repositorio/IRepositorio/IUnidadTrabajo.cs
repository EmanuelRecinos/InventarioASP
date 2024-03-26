using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioASP.AccesoDatos.Repositorio.IRepositorio
{
    public interface IUnidadTrabajo :   IDisposable // se hereda  IDisposable para deshacer cualquier recurso que haya tomado el sistema insesariamente 
    {

        IBodegaRepositorio Bodega { get; }

        Task Guardar();

    }
}
