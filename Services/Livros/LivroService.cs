using Microsoft.EntityFrameworkCore;
using WebApiLibrary.Data;
using WebApiLibrary.DTO.Livro;
using WebApiLibrary.Models;
using WebApiLibrary.Services.Livros;

namespace WebApiLibrary.Services.Livros
{
    public class LivroService : ILivroInterface
    {
        private readonly AppDbContext _context;

        public LivroService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livros = await _context.Livro.Include(l => l.Autor).ToListAsync();
                resposta.Dados = livros;
                resposta.Mensagem = "Todos os livros foram coletados!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();
            try
            {
                var livro = await _context.Livro.Include(l => l.Autor).FirstOrDefaultAsync(l => l.Id == idLivro);
                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }
                resposta.Dados = livro;
                resposta.Mensagem = "Livro localizado";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = new LivroModel
                {
                    Titulo = livroCriacaoDto.Titulo,
                    AutorId = livroCriacaoDto.AutorId
                };

                _context.Add(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livro.Include(l => l.Autor).ToListAsync();
                resposta.Mensagem = "Livro criado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = await _context.Livro.FirstOrDefaultAsync(l => l.Id == livroEdicaoDto.Id);

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum livro localizado";
                    return resposta;
                }

                livro.Titulo = livroEdicaoDto.Titulo;
                livro.AutorId = livroEdicaoDto.AutorId;

                _context.Update(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livro.Include(l => l.Autor).ToListAsync();
                resposta.Mensagem = "Livro editado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = await _context.Livro.FirstOrDefaultAsync(l => l.Id == idLivro);
                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum livro localizado!";
                    return resposta;
                }

                _context.Remove(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livro.Include(l => l.Autor).ToListAsync();
                resposta.Mensagem = "Livro excluído com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
