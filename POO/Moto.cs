class Moto : Veiculos
{
        public int? id{get; set;}
    public string? cor {get; set;}
    public string? marca {get; set;}
    public Moto()
    {
    }

     public void AumentarVelocidade()
    {
        velocidade = velocidade + 2 ;
        IrParaFrente();
    }
       void IrParaFrente()
    {
        System.Console.WriteLine($"Indo para frente a: {velocidade}km/h");
    }
    public float VereficarVelocidade()
    {
        return velocidade;
    }
    
}