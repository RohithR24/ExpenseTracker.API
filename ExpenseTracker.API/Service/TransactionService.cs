using Data.Models;
using DTO.Create;
using Mappings;
using Repository;
using Service.Impl;

namespace Service{

    public class TransactionService: ITransactionService{

            private readonly ITransactionRepository _transactionRepository;
            private readonly ITransactionMapping _transactionMapping;
            private readonly IBudgetRepository _budgetRepository;

        public TransactionService(ITransactionRepository transactionRepository, ITransactionMapping transactionMapping, IBudgetRepository budgetRepository){
            _transactionRepository = transactionRepository;
            _transactionMapping = transactionMapping;
            _budgetRepository = budgetRepository;
        }
        public bool AddTransaction(NewTransaction createTransaction, out string Message){

                var transaction =  _transactionMapping.ToTransactionEntity(createTransaction);
                if(BudgetCheck(transaction)){
                    bool result = _transactionRepository.AddTransaction(transaction);
                    Message= "Ok";
                    return result;
                }
                else{
                    Message= "Out of Budget";
                    return false;
                }


               

                return false;
        }

        private bool BudgetCheck(Transaction transaction){

            var budget  = _budgetRepository.FetchBudget(transaction.UserId, transaction.CategoryId, transaction.Date);

            if(budget.Amount >= transaction.Amount){
                _budgetRepository.UpdateBudgetAmount(budget.UserId, budget.Amount-transaction.Amount);
                return true;
            }

            return false;
        }
    }
}