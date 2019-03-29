namespace DemoApp
{
    public static class Configs
    {
        private static readonly string Endpoint01 = "";
        private static readonly string Endpoint02 = "";
        private static readonly string Endpoint03 = "";
        private static readonly string EndpointPrimary = "";
        private static readonly string EndpointSecondary = "";
        
        private static readonly string Login = "";
        private static readonly string Password = "";
        private static readonly string Database = "";
        
        public static readonly string Server01 = $"Server=tcp:{Endpoint01},1433;Initial Catalog={Database};Persist Security Info=False;User ID={Login};Password={Password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static readonly string Server02 = $"Server=tcp:{Endpoint02},1433;Initial Catalog={Database};Persist Security Info=False;User ID={Login};Password={Password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static readonly string Server03 = $"Server=tcp:{Endpoint03},1433;Initial Catalog={Database};Persist Security Info=False;User ID={Login};Password={Password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static readonly string ServerPrimary = $"Server=tcp:{EndpointPrimary},1433;Initial Catalog={Database};Persist Security Info=False;User ID={Login};Password={Password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static readonly string ServerSecondary = $"Server=tcp:{EndpointSecondary},1433;Initial Catalog={Database};Persist Security Info=False;User ID={Login};Password={Password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }
}