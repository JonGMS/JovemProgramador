class Motorista
{
    public string? nome {get; set;}
    public int? idade {get; set;}

    public static void LigarCarro()
    {
        
    }
    
    public void AcelerarCarro(Carro carro)
    {
        carro.AumentarVelocidade();
    }
    public void AcelerarMoto(Moto moto)
    {
        moto.AumentarVelocidade();
    }
}