namespace LeagueSpectator.Models
{
    public class RiotApiResponse<T>
    {
        public RiotApiResponse(RiotApiError? riotApiError)
        {
            RiotApiError = riotApiError;
        }

        public RiotApiResponse(T? response)
        {
            Response = response;
        }

        public T? Response { get; set; }

        public RiotApiError? RiotApiError { get; set; }
    }
}
