using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> GetAllAutors();
        Task<ResponseModel<AutorModel>> GetAutorById(int id);
        Task<ResponseModel<AutorModel>> CreateAutor(AutorModel autor);
        Task<ResponseModel<AutorModel>> GetAutorByLivro(int idLivro);
        Task<ResponseModel<AutorModel>> UpdateAutor(int id, AutorModel autor);
        Task<ResponseModel<string>> DeleteAutor(int id);
    }
}
