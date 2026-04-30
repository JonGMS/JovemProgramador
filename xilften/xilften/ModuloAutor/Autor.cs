using System.Text.Json;

class Autor : RepositorioBase<Autor>
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public override List<Autor> AdicionarDados(Autor autor)
    {
    string caminho = Path.Combine("..", "..", "..", "ModuloDados", "autores.json");

    string json = File.ReadAllText(caminho);

    List<Autor> listaAutor = JsonSerializer.Deserialize<List<Autor>>(json) ?? new List<Autor>();

    listaAutor.Add(autor);

    return listaAutor;
    }
}