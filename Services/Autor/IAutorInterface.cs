using WebApiLibrary.DTO.Autor;
using WebApiLibrary.Models;

namespace WebApiLibrary.Services.Autor
{
    public interface IAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores(); 

        Task<ResponseModel<AutorModel>> BuscarAutorPorId( int idAutor);

        Task<ResponseModel<AutorModel>> BuscarAutorIdLivro(int idLivro);

        Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto);
        Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDto autorEdicaoDto);
        Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAutor);






    }
}
