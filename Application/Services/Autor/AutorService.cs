using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services.Autor
{
    public class AutorService : IAutorInterface
    {

        private readonly AppDbContext _context;

        public AutorService(AppDbContext context) {
            _context = context;
        }

        public async Task<ResponseModel<AutorModel>> CreateAutor(AutorModel autor)
        {
            var response = new ResponseModel<AutorModel>();
            try
            {
                await _context.Autores.AddAsync(autor);
                await _context.SaveChangesAsync();

                response.Dados = autor;
                response.Message = "Autor criado com sucesso!";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<string>> DeleteAutor(int id)
        {
            var response = new ResponseModel<string>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autor => autor.Id == id);
                if (autor == null)
                {
                    response.Message = "Autor não encontrado";
                    response.Status = false;

                    return response;
                }
                _context.Autores.Remove(autor);
                await _context.SaveChangesAsync();
                response.Message = "Autor removido com sucesso";

                return response;
            }
            catch (Exception ex) {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> GetAllAutors()
        {
            ResponseModel<List<AutorModel>> response = new();

            try
            {
                var autores = await _context.Autores.ToListAsync();

                response.Dados = autores;
                response.Message = "Autores retornados com sucesso";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }

        }

        public async Task<ResponseModel<AutorModel>> GetAutorById(int id)
        {
            var response = new ResponseModel<AutorModel>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autor => autor.Id == id);
                response.Dados = autor;
                response.Message = "Autor encontrado com sucesso!";
                return response;
            }
            catch (Exception ex) {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
            
        }
       
        public async Task<ResponseModel<AutorModel>> GetAutorByLivro(int idLivro)
        {
            var response = new ResponseModel<AutorModel>();

            try
            {
                var livros = await _context.Livros
                    .Include(autor => autor.Autor)
                    .FirstOrDefaultAsync(livros => livros.Id == idLivro);

                response.Message = "Livros do autor foram encontrados com sucesso!";
                response.Status = true;
                response.Dados = livros.Autor;

                return response;

            }
            catch(Exception e)
            {
                response.Message = e.Message;
                response.Status = false;
                return response;
            }

        }

        public async Task<ResponseModel<AutorModel>> UpdateAutor(int id, AutorModel autor)
        {
            var response = new ResponseModel<AutorModel>();
            try
            {
                var autorModel = await _context.Autores.FirstOrDefaultAsync(autor => autor.Id == id);
                if (autorModel == null)
                {
                    response.Message = "Autor não foi encontrado para fazer a atualização";
                    response.Status = false;
                    return response;
                }

                autorModel.Nome = autor.Nome;
                autorModel.Sobrenome = autor.Sobrenome;

                await _context.SaveChangesAsync();

                response.Dados = autorModel;
                response.Message = "Autor foi atualizado com sucesso";

                return response;
                
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;

                return response;
            }
        }

    }
}
