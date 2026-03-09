using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;

class HelloWorld
{
  static void Main()
  {
    List<Aluno> listaAluno = new List<Aluno>();
    string[] historicoCalculadora = new string[100];
    string[] usuario = { "ADMIN", "LUCAS", "MORTARI", "DUDA" };
    string[] senha = { "ADMIN", "123", "321", "AMOR DA MINHA VIDA" };

    Login(usuario, senha);
    int contador = 0;
    while (true)
    {
      int opcao = ApresentarMenuPrincipal();
     

      if (opcao == 1)//Calculadora
      {
        string operador;
        
        do
        {
          Console.Clear();
          operador = ObterOperador();
          if (operador == "SAIR")
          {
            continue;
          }

          Calculadora(operador, contador, historicoCalculadora);

          for (int i = 0; i < historicoCalculadora.Length; i++)
          {
            string item = historicoCalculadora[i];
            if (!string.IsNullOrEmpty(item))
            {
              Console.WriteLine(historicoCalculadora[i]);
            }

          }
          ApresentarComDestaque("Aperte [ENTER] para continuar!", ConsoleColor.DarkCyan);
          Console.ReadLine();
        } while (operador != "SAIR");


      }
      else if (opcao == 2)//Simulador de cadastro
      {
        string opcaoAluno = "";
        do
        {
           opcaoAluno = ApresentarMenu("FORMULÁRIO");
          string nome = "";

          if (opcaoAluno == "1")
          {
            do
            {
              ApresentarTitulo("Simulador de Formulário", ConsoleColor.DarkCyan);

              Console.Write("Digite o nome ou [SAIR] para sair: ");
              nome = Console.ReadLine();
              if (nome == "SAIR")
              {

                continue;
              }

              Console.Write("Digite a idade: ");
              int idade = Convert.ToInt16(Console.ReadLine());

              if (idade < 18)
              {
                ApresentarComDestaque("Você é menor de Idade\n", ConsoleColor.Cyan);
              }
              else
              {
                ApresentarComDestaque("Você é maior de Idade\n", ConsoleColor.DarkBlue);
              }

              Console.Write("Digite a a altura: ");
              decimal altura = Convert.ToDecimal(Console.ReadLine());

              Console.Write("Digite o peso: ");
              decimal peso = Convert.ToDecimal(Console.ReadLine());

              Console.Write("Digite o endereço: ");
              string endereco = Console.ReadLine();

              decimal[] provas = new decimal[4];

              for (int i = 0; i < provas.Length; i++)
              {
                int j = 0;
                while (j == 0)
                {
                  try
                  {
                    Console.Write($"Digite a nota {i + 1}: ");
                    string strNota = Console.ReadLine();
                    decimal nota = Convert.ToDecimal(strNota);
                    if (nota > 10 || nota < 0)
                    {
                      ApresentarComDestaque("Nota inválida, tente novamente.\n", ConsoleColor.Red);
                      continue;
                    }
                    j++;
                    provas[i] = nota;
                  }
                  catch (Exception e)
                  {
                    ApresentarComDestaque("Nota inválida, tente novamente.", ConsoleColor.Red);
                  }
                }

              }

              Aluno aluno = new Aluno(nome, idade, altura, peso, endereco, provas[0], provas[1], provas[2], provas[3]);
              listaAluno.Add(aluno);

              Console.Clear();

              ApresentarMensagem(nome, idade, altura, peso, endereco);
            } while (nome != "SAIR");
          }

          else if (opcaoAluno == "2")
          {
            foreach (Aluno dadoAluno in listaAluno)
            {
              Console.WriteLine($"Nome: {dadoAluno.Nome}, Idade: {dadoAluno.Idade}, Altura: {dadoAluno.Altura}, Peso: {dadoAluno.Peso}, Endereço: {dadoAluno.Endereco}");

            }
          }
          else
          {
            ApresentarComDestaque("Opcao inválida! Tente novamente apertando [ENTER]", ConsoleColor.Red);
            Console.ReadLine();
          }
        } while (opcaoAluno != "0");

      }
      else if (opcao == 3)
      {
        string strOpcao = ApresentarMenu("BOLETIM");

        if (strOpcao == "1")
        {
          string[] nomeAluno = { "Rogério Silva", "Lucas Andrade", "Fernando Costa", "Gabriel Souza", "Ricardo Oliveira", "Tiago Martins", "Bruno Carvalho", "Larissa Cordova", "Ana Paula Mendes", "Juliana Ferreira", "Camila Rocha", "Mariana Santos", "Patrícia Almeida", "Bianca Teixeira", "João Gabriel Santos" };
          int[] idadeAluno = { 13, 14, 13, 14, 13, 14, 13, 14, 13, 14, 13, 14, 13, 14, 13 };

          int[] idAluno = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
          Random nmrRandon = new Random();
          for (int i = 0; i < idAluno.Length; i++)
          {
            int posicaoAleatoria = nmrRandon.Next(idAluno.Length);

            int temp = idAluno[i];
            idAluno[i] = idAluno[posicaoAleatoria];
            idAluno[posicaoAleatoria] = temp;
          }

          for (int i = 0; i < idAluno.Length; i++)
          {
            Random notasRandon = new Random();
            int[] provas = new int[4];
            for (int j = 0; j < provas.Length; j++)
            {
              int nota = notasRandon.Next(5, 10);
              provas[j] = nota;
            }

            Aluno aluno = new Aluno(nomeAluno[idAluno[i]], idadeAluno[idAluno[i]], 1, 30, "Av qualquer coisa", provas[0], provas[1], provas[2], provas[3]);
            listaAluno.Add(aluno);

          }

        }
        else if (strOpcao == "2")
        {
          if (listaAluno.Count > 0)
          {
            Console.Clear();
            ApresentarComDestaque("   ALUNO   | NOTA 1 | NOTA 2 | NOTA 3 | NOTA 4 | MÉDIA | STATUS\n", ConsoleColor.DarkGray);
            foreach (Aluno dadoAluno in listaAluno)
            {
              string nomeLimitado = dadoAluno.Nome.Substring(0, 11);
              decimal soma = dadoAluno.Prova1 + dadoAluno.Prova2 + dadoAluno.Prova3 + dadoAluno.Prova4;
              decimal media = soma / 4;

              Console.Write(nomeLimitado + "|   " + dadoAluno.Prova1 + "    " + "|   " + dadoAluno.Prova2 + "    " + "|   " + dadoAluno.Prova3 + "    " + "|   " + dadoAluno.Prova4 + "    " + "|  ");
              if (media > 7)
              {
                ApresentarComDestaque(media.ToString("F1") + "  |APROVADO\n", ConsoleColor.Green);
              }
              else
              {
                ApresentarComDestaque(media.ToString("F1") + "  |REPROVADO\n", ConsoleColor.Red);
              }

            }
            ApresentarComDestaque("Boletim apresentado com sucesso! aperte [ENTER] para continuar.", ConsoleColor.Green);
            Console.ReadLine();
          }
          else
          {
            ApresentarComDestaque("Nenhum aluno ou nota cadastrado!! Aperte [ENTER] para tentar novamente.", ConsoleColor.Red);
            Console.ReadLine();
          }
          
        }
      }
      else if (opcao == 0)
      {
        break;
      }
    }

  }
  public static void Login(string[] usuario, string[] senha)
  {
    int resultadoLogin = 0;
    while (resultadoLogin == 0)
    {
      Console.Clear();
      Console.Write("Usuario: ");
      string usuarioStr = Console.ReadLine();
      Console.Write("Senha: ");
      string senhaStr = Console.ReadLine();

      for (int i = 0; i < usuario.Length; i++)
      {
        if (usuario[i] == usuarioStr && senha[i] == senhaStr)
        {
          ApresentarComDestaque("Login efetuado com sucesso!!", ConsoleColor.Green);
          Console.ReadLine();
          i = 10;
          i++;
          resultadoLogin++;
          continue;
        }

      }
      if (resultadoLogin == 0)
      {
        ApresentarComDestaque("Usuario ou Senha incorreto!! Tente novamente apertando [ENTER]", ConsoleColor.Red);
        Console.ReadLine();
      }

    }
  }
  public static int ApresentarMenuPrincipal()
  {

    while (true)
    {
      Console.Clear();

      Console.Write("Escolha a simulação que deseja\nPara Calculadora 1.0 - "); ApresentarComDestaque("Digite [1]", ConsoleColor.DarkBlue);
      Console.Write("\nPara Cadastro de Aluno - "); ApresentarComDestaque("Digite [2]", ConsoleColor.DarkCyan);
      Console.Write("\nPara Notas para Alunos -"); ApresentarComDestaque("Digite [3]", ConsoleColor.Blue);
      Console.Write("\nPara SAIR - "); ApresentarComDestaque("Digite [0]\n", ConsoleColor.Red);
      string strOpcao = Console.ReadLine();
      if (strOpcao == "0" || strOpcao == "1" || strOpcao == "2" || strOpcao == "3")
      {
        int opcao = Convert.ToInt16(strOpcao);
        return opcao;
      }
      ApresentarComDestaque("Opção inválida!! Aperte [ENTER] para tentar novamente.", ConsoleColor.Red);
      Console.ReadLine();
    }

  }
  public static void ApresentarComDestaque(string destaque, ConsoleColor cor)//Mensagens de ALERTA
  {
    Console.ForegroundColor = cor;
    Console.Write(destaque);
    Console.ResetColor();
  }
  public static void ApresentarMensagem(string nome, int idade, decimal altura, decimal peso, string endereco)//Formulario
  {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Aluno Cadastrado com sucesso!!");
    Console.WriteLine($"Nome: {nome}\nIdade: {idade}\nAltura: {altura}\nPeso: {peso}\nEndereço: {endereco}");
    Console.ResetColor();

  }
  public static void ApresentarTitulo(string text, ConsoleColor cor)//Calculadora
  {
    Console.Clear();
    Console.WriteLine(text);
    Console.ForegroundColor = cor;
    Console.WriteLine("================");
    Console.ResetColor();
  }
  public static string ApresentarMenu(string tipo)
  {
    Console.Clear();
    if (tipo == "CALCULADORA")
    {
      Console.WriteLine("Digite [1] para SOMA\nDigite [2] para SUBTRAÇÃO\nDigite [3] para DIVISÃO\nDigite [4] para MULTIPLICAÇÃO\nDigite [0] para SAIR\n");
      Console.Write("Operação: "); string opcao = Console.ReadLine();
      return opcao;
    }
    else if (tipo == "FORMULÁRIO")
    {
      Console.Clear();
      Console.Write("Digite "); ApresentarComDestaque("[1] para CADASTRAR ALUNO\n", ConsoleColor.Blue);
      Console.Write("Digite "); ApresentarComDestaque("[2] para LISTAR ALUNOS\n", ConsoleColor.Cyan);
      Console.Write("Digite "); ApresentarComDestaque("[0] para VOLTAR\n", ConsoleColor.Red);
      string opcao = Console.ReadLine();
      return opcao;
    }
    else if (tipo == "BOLETIM")
    {
      Console.Clear();
      Console.Write("Digite "); ApresentarComDestaque("[1] para adicionar notas (Randomicas)\n", ConsoleColor.DarkBlue);
      Console.Write("Digite "); ApresentarComDestaque("[2] para Apresentar Boletim\n", ConsoleColor.Cyan);
      Console.Write("Digite "); ApresentarComDestaque("[0] para SAIR\n", ConsoleColor.Red);
      string opcao = Console.ReadLine();
      return opcao;
    }

    return "";
  }
  public static string ObterOperador()
  {
    while (true)
    {
      ApresentarTitulo("Calculadora 1.0", ConsoleColor.DarkBlue);

      string opcao = ApresentarMenu("CALCULADORA");

      if (opcao == "1")
      {
        return "+";
      }
      else if (opcao == "2")
      {
        return "-";
      }
      else if (opcao == "3")
      {
        return "/";
      }
      else if (opcao == "4")
      {
        return "*";
      }
      else if (opcao == "0")
      {
        return "SAIR";
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Opção Inválida. Tente novamente apertando [ENTER]");
        Console.ReadLine();
        Console.ResetColor();
        Console.Clear();
        continue;
      }

    }
  }
  public static void Calculadora(string operador, int contador, string[] historicoCalculadora)
  {
    int condicao = 0;
    do
    {
      ApresentarTitulo("Calculadora 1.0", ConsoleColor.DarkBlue);

      Console.Write("Primeiro Número:");
      string strPrimeiroNumero = Console.ReadLine();

      if (strPrimeiroNumero == "SAIR")
      {
        return;
      }
      decimal primeiroNumero = Convert.ToDecimal(strPrimeiroNumero);

      Console.Write(operador);

      Console.Write("\nSegundo Número: ");
      string strSegundoNumero = Console.ReadLine();

      if (operador == "/" && strSegundoNumero == "0")
      {
        for (int i = 0; i == 0;)
        {
          ApresentarComDestaque("Não é possivel divisão por 0 (ZERO)", ConsoleColor.Red);
          Console.Write("\nSegundo Número: ");
          strSegundoNumero = Console.ReadLine();
          if (strSegundoNumero != "0" && strSegundoNumero != "")
          {
            i = 1;
          }
        }
      }
      if (strSegundoNumero == "SAIR")
      {
        return;
      }
      decimal segundoNumero = Convert.ToDecimal(strSegundoNumero);


      Calculadora calculadora = new Calculadora(primeiroNumero, segundoNumero);

      decimal resultado = calculadora.Calcular(operador, primeiroNumero, segundoNumero);

      historicoCalculadora[contador] = primeiroNumero + " " + operador + " " + segundoNumero + " = " + resultado;

      Console.ForegroundColor = ConsoleColor.DarkBlue;
      Console.WriteLine(primeiroNumero + " " + operador + " " + segundoNumero + " = " + resultado + "\n");
      Console.ResetColor();
      Console.Write("Para continuar aparte [ENTER] para sair digite [SAIR]: ");
      string resposta = Console.ReadLine();
      if (resposta == "SAIR" || resposta == "Sair" || resposta == "sair")
      {
        return;
      }
      Console.Clear();
      contador++;
    } while (condicao < 1);


  }


}
class Aluno
{
  public string Nome { get; set; }

  public int Idade { get; set; }

  public decimal Altura { get; set; }

  public decimal Peso { get; set; }

  public string Endereco { get; set; }

  public decimal Prova1 { get; set; }

  public decimal Prova2 { get; set; }

  public decimal Prova3 { get; set; }

  public decimal Prova4 { get; set; }


  public Aluno(string nome, int idade, decimal altura, decimal peso, string endereco, decimal prova1, decimal prova2, decimal prova3, decimal prova4)
  {
    Nome = nome;
    Idade = idade;
    Altura = altura;
    Peso = peso;
    Endereco = endereco;
    Prova1 = prova1;
    Prova2 = prova2;
    Prova3 = prova3;
    Prova4 = prova4;
  }

  float[] lista_notas = new float[4];


}
class Calculadora
{
  public decimal PrimeiroNumero { get; set; }
  public decimal SegundoNumero { get; set; }
  public decimal Resultado { get; set; }

  public Calculadora(decimal primeiroNumero, decimal segundoNumero)
  {
    PrimeiroNumero = primeiroNumero;
    SegundoNumero = segundoNumero;
    // Resultado = resultado;
  }
  public decimal Calcular(string operador, decimal PrimeiroNumero, decimal SegundoNumero)
  {
    if (operador == "+")
    {
      this.Resultado = this.PrimeiroNumero + this.SegundoNumero;
    }
    else if (operador == "-")
    {
      this.Resultado = this.PrimeiroNumero - this.SegundoNumero;
    }
    else if (operador == "/")
    {
      this.Resultado = this.PrimeiroNumero / this.SegundoNumero;
    }
    else if (operador == "*")
    {
      this.Resultado = this.PrimeiroNumero * this.SegundoNumero;
    }

    return this.Resultado;
  }

}