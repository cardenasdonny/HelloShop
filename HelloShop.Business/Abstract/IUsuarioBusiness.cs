using HelloShop.Business.Dtos.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloShop.Business.Abstract
{
    public interface IUsuarioBusiness
    {
        Task<UsuarioDto> ObtenerUsuarioDtoPorEmail(string email);
        Task<string> Crear(RegistrarUsuarioDto registrarUsuarioDto);
        Task<IEnumerable<UsuarioDto>> ObtenerListaUsuarios();
    }
}
