// See https://aka.ms/new-console-template for more information
using System.Globalization;
Carro car = new Carro();
Motorista motorista = new Motorista();
Moto moto = new Moto();
motorista.nome = "João Gabriel";
while (car.VereficarVelocidade() < 160 || car.VereficarVelocidade() < 160)
{
    try
    {
        Console.Write("Moto [1]\nCarro [2]\nQual veiculo você deseja: ");
        string opcao = Console.ReadLine();
        if (opcao == "1")
        {
            while (moto.VereficarVelocidade() < 160)
            {
                motorista.AcelerarMoto(moto);
            }
        }
        else if (opcao == "2")
        {
            while (car.VereficarVelocidade() < 160)
            {
                motorista.AcelerarCarro(car);
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nOpcao inválida, tente novamente.");
            Console.ResetColor();
        }
    }
    catch (Exception e)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nOpcao inválida, tente novamente.");
        Console.ResetColor();
    }
}





