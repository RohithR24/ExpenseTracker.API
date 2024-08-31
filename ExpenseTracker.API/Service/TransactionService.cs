using DTO.Create;
using Mappings;
using Repository;
using Service.Impl;

namespace Service{

    public class TransactionService: ITransactionService{

            private readonly ITransactionRepository _transactionRepository;
            private readonly ITransactionMapping _transactionMapping;

        public TransactionService(ITransactionRepository transactionRepository, ITransactionMapping transactionMapping){
            _transactionRepository = transactionRepository;
            _transactionMapping = transactionMapping;
        }
        public bool AddTransaction(NewTransaction createTransaction){
                var result =  _transactionRepository.AddTransaction(_transactionMapping.ToTransactionEntity(createTransaction));
                return result;
        }
    }
}