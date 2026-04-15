class Livro
{
    public int? Id {get; set;}
    public string? Nome {get; set;}
    public string? Autor {get; set;}
    public int? NumeroPaginas {get; set;}
    public string[]? Genero{get; set;}
    public string? TipoCapa {get; set;} 
    public Livro()
    {
        
    }
    public Livro(int id, string nome, string autor, int numeroPaginas, string[] genero, string tipoCapa)
    {
        Id = id;
        Nome = nome;
        Autor = autor;
        NumeroPaginas = numeroPaginas;
        Genero = genero;
        TipoCapa = tipoCapa;
    }
    public void Abrir()
    {
        Console.Write($"{Nome}está aberto e pronto para leitura.");
    }
    public void Ler()
    {
        Console.Write($"\nLendo o livro {Nome} do autor {Autor}, esse livro possui {NumeroPaginas} e tem a capa {TipoCapa}");
    }
    public void MatarAranha()
    {
        Console.WriteLine("Matou a aranha, tadinha ;-;");
    }
    public string ArrumarCartinha()
    {
        Random nmrRandon = new Random();
        int numeroRandomico = nmrRandon.Next(1,3);
        if(numeroRandomico == 1)
        {
            return "Arrumou";
        }
        else
        {
            return "Não Arrumou";
        }
        
    }
}   