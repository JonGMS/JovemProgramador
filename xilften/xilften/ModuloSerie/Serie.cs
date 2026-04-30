
using System.Runtime.CompilerServices;
using System.Text.Json;

class Serie : RepositorioBase<Serie>, IRepositorioBase
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public int NumeroEpisodios { get; set; }
    public string[] Genero { get; set; }
    public Autor Autor { get; set; }
    public string Nota {get;set;}
    public Serie()
    {

    }
    public override List<Serie> AdicionarDados(Serie novaSerie)
    {
        string caminho = Path.Combine("..", "..", "..", "ModuloDados", "series.json"); 

        string json = File.ReadAllText(caminho);

        List<Serie> listaSeries = JsonSerializer.Deserialize<List<Serie>>(json) ?? new List<Serie>();

        listaSeries.Add(novaSerie);

        return listaSeries;
    }

}