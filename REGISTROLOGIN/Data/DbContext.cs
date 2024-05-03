namespace REGISTROLOGIN.Data
{
    public class DbContext
    {

        public DbContext(string valor) => Valor = valor;
        public String Valor { get; }

    }

}
