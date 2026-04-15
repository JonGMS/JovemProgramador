// See https://aka.ms/new-console-template for more information
using System.Globalization;

Console.WriteLine("Hello, World!");

Livro livro = new Livro();
livro.Id = 1;
livro.Nome = "Harry Potter e a Pedra Filosofal";
livro.Autor = "J. K. Rowling";
livro.NumeroPaginas = 264;

livro.Genero = new string[1];
livro.Genero[0] = "Fantasia";

livro.TipoCapa = "Fino";

livro.Abrir();
livro.Ler();
livro.MatarAranha();
string statusLivro = livro.ArrumarCartinha();
while(statusLivro == "Não Arrumou")
{
    statusLivro = livro.ArrumarCartinha();
}