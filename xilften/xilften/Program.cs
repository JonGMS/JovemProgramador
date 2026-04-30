// See https://aka.ms/new-console-template for more information

using System.Net.WebSockets;

Filme filme = new Filme();
Serie serie = new Serie();
Autor autor = new Autor();

List<Filme> listaFilme = new List<Filme>();
List<Serie> listaSerie = new List<Serie>();
List<Autor> listaAutor = new List<Autor>();

listaFilme = filme.AdicionarDados(filme);
//listaSerie = serie.AdicionarDados(serie);
listaAutor = autor.AdicionarDados(autor);
Console.Clear();

ApresentarComDestaque("XILFTEN", ConsoleColor.Red);
Console.WriteLine();
ApresentarComDestaque("Digite [1] - Filme", ConsoleColor.DarkGray);
Console.WriteLine();
ApresentarComDestaque("Digite [2] - Serie", ConsoleColor.DarkGray);
Console.WriteLine();
Console.Write("Opcao: ");

string opcao = Console.ReadLine();
while (opcao != "0")
    if (opcao == "1") //Filme
    {
        int contador = 0;


        ApresentarComDestaque("XILFTEN", ConsoleColor.Red); Console.Write(" - FILME\n\n");
        while (contador < listaFilme.Count)
        {
            contador = ApresentarConteudo(listaFilme, contador);
            int contadorSemLista = contador - 4;
            Console.Write(" |\n\n");

            ApresentarComDestaque("[>] para ir para a próxima página.", ConsoleColor.Red);
            Console.WriteLine("");
            ApresentarComDestaque("Qual opção você deseja: ", ConsoleColor.DarkGray);
            while (contador < listaFilme.Count)
            {
                string opcaoFilme = "";
                try
                {
                    opcaoFilme = Console.ReadLine();
                }
                catch
                {
                    ApresentarComDestaque("ERRO - Opção inválida.", ConsoleColor.Red);
                }

                if (opcaoFilme == ">")
                {
                    continue;
                }
                else if (opcaoFilme == "1" ||opcaoFilme == "2" ||opcaoFilme == "3" ||opcaoFilme == "4")
                {
                    int opcaoInt = Convert.ToInt16(opcaoFilme);
                    contadorSemLista = contadorSemLista + opcaoInt + 1;
                    Console.Clear();
                    ApresentarComDestaque("XILFTEN", ConsoleColor.Red); Console.Write(" - FILME\n\n");

                    Console.Write(listaFilme[contadorSemLista].Titulo +  "    " + listaFilme[contadorSemLista].Nota + "/5\n");
                    ApresentarComDestaque(listaFilme[contadorSemLista].Sinopse, ConsoleColor.DarkGray);

                }
                else
                {
                    ApresentarComDestaque("ERRO - Opção inválida.", ConsoleColor.Red);
                }
            }

        }

    }
    else if (opcao == "2")
    {
        ApresentarComDestaque("XILFTEN", ConsoleColor.Red); Console.Write(" - SERIE\n\n");
    }
    else
    {
        ApresentarComDestaque("ERRO - Opção inválida.", ConsoleColor.Red);
    }

static int ApresentarConteudo<T>(List<T> lista, int contador) where T : IRepositorioBase
{
    Console.WriteLine("_________________________________________________________");

    for (int i = 0; i < 4; i++)
    {
        string contadorStr = i.ToString();

        string nome = lista[contador].Titulo;

        if (nome.Length > 10)
        {
            nome = nome.Substring(0, 10);

            //nome = nome.PadRight(10, ' ');
        }

        Console.Write("| "); ApresentarComDestaque(contadorStr, ConsoleColor.DarkRed); Console.Write(" " + nome);
        contador++;
    }

    Console.Write("|\n");

    for (int i = 0; i < 4; i++)
    {
        string nota = lista[contador].Nota;

        Console.Write($"|  {nota}"); ApresentarComDestaque("/5", ConsoleColor.DarkYellow); Console.Write("        ");

        contador++;
    }
    Console.WriteLine("|\n¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯");

    return contador;
}

static void ApresentarComDestaque(string destaque, ConsoleColor cor)//Mensagens de ALERTA
{
    Console.ForegroundColor = cor;
    Console.Write(destaque);
    Console.ResetColor();
}
