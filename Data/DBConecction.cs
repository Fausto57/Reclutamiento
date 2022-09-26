namespace Reclutamiento.Data
{
    public class DBConecction
    {
        private string CadenaSQL = string.Empty;

        public DBConecction()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            CadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        public string getCadena()
        {
            return CadenaSQL;
        }
    }
}
