namespace TennisChampionshipMicroservice.Ports.Ins
{
    public interface IJwtCore
    {
        public string GenerateToken(string key, string issuer);
        public void Match(string passwordRequest, string passwordDb);

    }
}
