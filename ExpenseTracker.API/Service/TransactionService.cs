using System.Transactions;
using Data.Models;
using DTO;
using DTO.Create;
using Mappings;
using Repository;
using Service.Impl;

namespace Service
{

    public class TransactionService : ITransactionService
    {

        private readonly ITransactionRepository _transactionRepository;
        private readonly ITransactionMapping _transactionMapping;
        private readonly IBudgetRepository _budgetRepository;
        private readonly ILogger<TransactionService> _logger;


        public TransactionService(ITransactionRepository transactionRepository, ITransactionMapping transactionMapping, IBudgetRepository budgetRepository, ILogger<TransactionService> logger)
        {
            _transactionRepository = transactionRepository;
            _transactionMapping = transactionMapping;
            _budgetRepository = budgetRepository;
            _logger = logger;
        }
        public bool AddTransaction(NewTransaction createTransaction, out string Message)
        {

            var transaction = _transactionMapping.ToTransactionEntity(createTransaction);

            if (transaction.Type == "Income")
            {
                bool result = _transactionRepository.AddTransaction(transaction);
                Message = "Ok";
                return result;
            }
            else
            {
                if (BudgetCheck(transaction))
                {
                    bool result = _transactionRepository.AddTransaction(transaction);
                    Message = "Ok";
                    return result;
                }
                else
                {
                    Message = "Out of Budget";
                    return false;
                }

            }

        }

        public bool DeleteTransaction(int transactionId)
        {
            var transaction = _transactionRepository.FetchById(transactionId);
            if (transaction != null && transaction.Type == "Expense")
            {
                var budget = _budgetRepository.FetchTotalBudget(transaction.UserId, transaction.CategoryId, transaction.Date);
                _budgetRepository.UpdateBudgetAmount(budget.Id, budget.Amount + transaction.Amount);
            }
            return _transactionRepository.MarkTransactionAsDelete(transactionId);
        }

        public List<TransactionDto> TransactionsByUserId(int userId)
        {
            List<TransactionDto> transactionDto = new List<TransactionDto>();
            try
            {
                var transactions = _transactionRepository.FetchTransactionsById(userId);

                Parallel.ForEach( transactions, transaction =>
                {
                    //Converting to transaction  to TransactionDTO
                    transactionDto.Add(_transactionMapping.ToTransactionDTO(transaction));
                });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in type conversion from transaction to transactionDto");
            }
            return transactionDto;
        }

        private bool BudgetCheck(Data.Models.Transaction transaction)
        {

            var budget = _budgetRepository.FetchTotalBudget(transaction.UserId, transaction.CategoryId, transaction.Date);

            if (budget.Amount >= transaction.Amount)
            {
                _budgetRepository.UpdateBudgetAmount(budget.UserId, budget.Amount - transaction.Amount);
                return true;
            }
            return false;
        }

        public bool UpdateTransaction(UpdateTransaction updateTransaction){
            var result  = _transactionRepository.UpdateTransactionById(updateTransaction);

            if(result>0) 
                return true; 

            else 
                return false;
        }



    }
}