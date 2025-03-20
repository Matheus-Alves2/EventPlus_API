using EventPlus_.Context;
using EventPlus_.Domains;
using EventPlus_.Interfaces;

namespace EventPlus_.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly Eventos_Context _Context;
        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = _Context.TipoUsuario.Find(id)!;
                if(tipoUsuarioBuscado != null)
                {
                    tipoUsuarioBuscado.TituloTipoUsuario = tipoUsuario.TituloTipoUsuario;
                }
                _Context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TipoUsuario BuscarPorId(Guid id)
        {
            TipoUsuario tipoUsuarioBuscado = _Context.TipoUsuario.Find(id)!;
            return tipoUsuarioBuscado;
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            try
            {
                _Context.TipoUsuario.Add (novoTipoUsuario);

                _Context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = _Context.TipoUsuario.Find(id)!;
                if(tipoUsuarioBuscado != null)
                {
                    _Context.TipoUsuario.Remove(tipoUsuarioBuscado);
                    _Context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TipoUsuario> Listar()
        {
           List<TipoUsuario> listaTipoUsuario = _Context.TipoUsuario.ToList();
            return listaTipoUsuario;
        }
    }
}
