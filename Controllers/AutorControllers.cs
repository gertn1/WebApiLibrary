using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiLibrary.DTO.Autor;
using WebApiLibrary.Models;
using WebApiLibrary.Services.Autor;

namespace WebApiLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorControllers : ControllerBase
    {

        public readonly IAutorInterface _autorInterface;
        public AutorControllers(IAutorInterface autorInterface)
        {
            _autorInterface = autorInterface;
        }

        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var autores = await _autorInterface.ListarAutores();

            return Ok(autores);
        }

        [HttpGet("BuscarAutorPorId/{idAutor}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(int idAutor)
        {
            var autor = await _autorInterface.BuscarAutorPorId(idAutor);

            return Ok(autor);
        }


        [HttpGet("BuscarAutorIdLivro/{idLivro}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorIdLivro(int idLivro)
        {
            var autor = await _autorInterface.BuscarAutorIdLivro(idLivro);

            return Ok(autor);
        }


        [HttpPost("Criar Autor")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            var autores = await _autorInterface.CriarAutor(autorCriacaoDto);
            return Ok(autores); 
        }

        [HttpDelete("ExcluirAutor/{idAutor}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> ExcluirAutor(int idAutor)
        {
            var autores = await _autorInterface.ExcluirAutor(idAutor);
            return Ok(autores);
        }

        [HttpPut("EditarAutor")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> EditarAutor(AutorEdicaoDto autorEdicaoDto)
        {
            var autores = await _autorInterface.EditarAutor(autorEdicaoDto);
            return Ok(autores);
        }

    }
    
}
