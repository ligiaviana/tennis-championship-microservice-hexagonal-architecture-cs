using TennisChampionshipMicroservice.Ports.Ins;

namespace TennisChampionshipMicroservice.Cores
{
    public class PlayerLogCore : IPlayerLogCore
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
