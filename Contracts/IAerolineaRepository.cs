namespace reservas_api.Contracts
{
    public interface IAerolineaRepository
    {
        Task<List<Entities.Aerolinea>> GetAerolineas();
    }
}
