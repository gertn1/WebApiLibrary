using Microsoft.AspNetCore.Mvc;
using WebApiLibrary.DTO.Livro;
using WebApiLibrary.Models;
using WebApiLibrary.Services.Livros;

namespace WebApiLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface _livroService;

        public LivroController(ILivroInterface livroService)
        {
            _livroService = livroService;
        }

        [HttpGet("ListarLivros")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarLivros()
        {
            var livros = await _livroService.ListarLivros();
            return Ok(livros);
        }

        [HttpGet("BuscarLivroPorId/{idLivro}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorId(int idLivro)
        {
            var livro = await _livroService.BuscarLivroPorId(idLivro);
            return Ok(livro);
        }

        [HttpPost("CriarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            var livros = await _livroService.CriarLivro(livroCriacaoDto);
            return Ok(livros);
        }

        [HttpPut("EditarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
        {
            var livros = await _livroService.EditarLivro(livroEdicaoDto);
            return Ok(livros);
        }

        [HttpDelete("ExcluirLivro/{idLivro}")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ExcluirLivro(int idLivro)
        {
            var livros = await _livroService.ExcluirLivro(idLivro);
            return Ok(livros);
        }
    }
}
