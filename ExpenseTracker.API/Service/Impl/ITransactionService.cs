using DTO.Create;

namespace Service.Impl{
    public interface ITransactionService{
        public bool AddTransaction(NewTransaction createTransaction);
    }
}