using EventPlus_.Context;
using EventPlus_.Domains;
using EventPlus_.Interfaces;
using EventPlus_.Utils;
using Microsoft.EntityFrameworkCore;

namespace EventPlus_.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly  Eventos_Context _Context;
        public UsuarioRepository(Eventos_Context context)
        {
            _Context = context;
        }

        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _Context.Usuario.FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }
                }
                return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _Context.Usuario.Find(id)!;

                if (usuarioBuscado != null)
                {
                    return usuarioBuscado;
                }
                return null!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            try
            {

                _Context.Usuario.Add(novoUsuario);

                _Context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

