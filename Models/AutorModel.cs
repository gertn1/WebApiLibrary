using System.Text.Json.Serialization;

namespace WebApiLibrary.Models
{
    public class AutorModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Sobrenome { get; set; }
        [JsonIgnore]

        public ICollection<LivroModel> Livro { get; set; }

      


    }
}
