namespace BoatSalesApi.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string BaseUrl = $"{Root}/{Version}";

        public static class Boats
        {
            public const string GetAll = $"{BaseUrl}/boats";
            public const string Get = BaseUrl +"/boats/{boatId}:guid";
            public const string Create = $"{BaseUrl}/boats";
            public const string Update = BaseUrl +"/boats/{boatId}:guid";
            public const string Delete = BaseUrl +"/boats/{boatId}:guid";

        }
    }
}
