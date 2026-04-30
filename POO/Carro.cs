class Carro : Veiculos
{
    public int? id{get; set;}
    public string? cor {get; set;}
    public string? marca {get; set;}
    // private float velocidade;
    
    // public Carro(Parameters)
    // {
        
    // }
    void IrParaFrente()
    {
        System.Console.WriteLine($"Indo para frente a: {velocidade}km/h");
    }
    public void AumentarVelocidade()
    {
        velocidade = velocidade + 2 ;
        IrParaFrente();
    }
    public float VereficarVelocidade()
    {
        return velocidade;
    }
}