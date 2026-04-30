using System.Text.Json;

class Filme : RepositorioBase<Filme>, IRepositorioBase
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string[] Genero { get; set; }
    public Autor Autor { get; set; }
    public string Sinopse { get; set; }
    public string Nota {get;set;}

    public override List<Filme> AdicionarDados(Filme filme)
    {
        string caminho = Path.Combine("..", "..", "..", "ModuloDados", "filmes.json");

        string json = File.ReadAllText(caminho);

        List<Filme> listaFilmes = JsonSerializer.Deserialize<List<Filme>>(json) ?? new List<Filme>();

        listaFilmes.Add(filme);

        return listaFilmes;
    }
}