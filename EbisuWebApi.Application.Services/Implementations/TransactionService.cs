using AutoMapper;
using EbisuWebApi.Application.Dtos;
using EbisuWebApi.Application.Services.Contracts;
using EbisuWebApi.Domain.Entities;
using EbisuWebApi.Domain.RepositoryContracts.Contracts;
using EbisuWebApi.Infrastructure.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Application.Services.Implementations
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TransactionDTO> AddTransactionAsync(TransactionDTO transactionDTO)
        {
            TransactionDataModel transactionDataModel = _mapper.Map<TransactionDataModel>(_mapper.Map<TransactionEntity>(transactionDTO));

            var result = await _unitOfWork.Transactions.Add(transactionDataModel);
            _unitOfWork.Complete();

            return _mapper.Map<TransactionDTO>(_mapper.Map<TransactionEntity>(result));
        }

        public async Task<IEnumerable<TransactionDTO>> GetAllTransactions()
        {
            return _mapper.Map<IEnumerable<TransactionDTO>>(_mapper.Map<IEnumerable<TransactionEntity>>(await _unitOfWork.Transactions.GetAll()));
        }

        public async Task<TransactionDTO> GeTransactionById(int id)
        {
            return _mapper.Map<TransactionDTO>(_mapper.Map<TransactionEntity>(await _unitOfWork.Transactions.GetEntity(id)));
        }

        public async Task<TransactionDTO> RemoveTransaction(int id)
        {
            var transactionDto = _mapper.Map<TransactionDTO>(_mapper.Map<TransactionEntity>(await _unitOfWork.Transactions.Delete(id)));

            _unitOfWork.Complete();
            return transactionDto;
        }

        public async Task<TransactionDTO> UpdateTransaction(TransactionDTO transactionDTO)
        {
            var entityDataModel = _mapper.Map<TransactionDataModel>(_mapper.Map<TransactionEntity>(transactionDTO));

            var result = await _unitOfWork.Transactions.Update(entityDataModel);
            _unitOfWork.Complete();

            return _mapper.Map<TransactionDTO>(_mapper.Map<TransactionEntity>(result));
        }
    }
}
