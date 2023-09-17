namespace Optimus.AtHomeBestOffer.Application.Service
{
    public interface IProposalService<T, R>
        where T : class
        where R : class
    {
        Task<R> GetProposedOffer(T order);
    }
}