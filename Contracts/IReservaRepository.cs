namespace reservas_api.Contracts
{
    public interface IReservaRepository
    {
        Task<List<Entities.Reserva>> GetReservas();
    }
}
