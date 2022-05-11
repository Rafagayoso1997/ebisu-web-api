using AutoMapper;
using EbisuWebApi.Application.Dtos;
using EbisuWebApi.Application.Services.Contracts;
using EbisuWebApi.Domain.Entities;
using EbisuWebApi.Domain.RepositoryContracts.Contracts;
using EbisuWebApi.Domain.Services.Contracts;
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
        private readonly ITransactionDomainService _transactionDomainService;

        public TransactionService(IUnitOfWork unitOfWork, IMapper mapper, ITransactionDomainService transactionDomainService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _transactionDomainService = transactionDomainService;
        }

        public async Task<TransactionDto> AddTransactionAsync(TransactionDto transactionDTO)
        {
            TransactionDataModel transactionDataModel = _mapper.Map<TransactionDataModel>(_mapper.Map<TransactionEntity>(transactionDTO));

            await _transactionDomainService.ValidateTransactionData(transactionDataModel);

            var user = await _unitOfWork.Users.GetEntity(transactionDataModel.UserId);

            var category = await _unitOfWork.Categories.GetEntity(transactionDataModel.CategoryId);

            transactionDataModel.User = user;
            transactionDataModel.Category = category;

            var result = await _unitOfWork.Transactions.Add(transactionDataModel);
            _unitOfWork.Complete();

            return _mapper.Map<TransactionDto>(_mapper.Map<TransactionEntity>(result));
        }

        public async Task<IEnumerable<TransactionDto>> GetAllTransactions()
        {
            return _mapper.Map<IEnumerable<TransactionDto>>(_mapper.Map<IEnumerable<TransactionEntity>>(await _unitOfWork.Transactions.GetAll()));
        }

        public async Task<IEnumerable<TransactionDto>> GetAllTransactionsByUserId(int userId)
        {
            return _mapper.Map<IEnumerable<TransactionDto>>(_mapper.Map<IEnumerable<TransactionEntity>>(await _unitOfWork.Transactions.GetTransactionsByUserId(userId)));
        }

        public async Task<TransactionDto> GeTransactionById(int id)
        {
            return _mapper.Map<TransactionDto>(_mapper.Map<TransactionEntity>(await _unitOfWork.Transactions.GetEntity(id)));
        }

        public async Task<TransactionDto> RemoveTransaction(int id)
        {
            var transactionDto = _mapper.Map<TransactionDto>(_mapper.Map<TransactionEntity>(await _unitOfWork.Transactions.Delete(id)));

            _unitOfWork.Complete();
            return transactionDto;
        }

        public async Task<TransactionDto> UpdateTransaction(TransactionDto transactionDTO)
        {
            var entityDataModel = _mapper.Map<TransactionDataModel>(_mapper.Map<TransactionEntity>(transactionDTO));
            
            await _transactionDomainService.ValidateTransactionData(entityDataModel);
            
            var result = await _unitOfWork.Transactions.Update(entityDataModel);
            _unitOfWork.Complete();

            return _mapper.Map<TransactionDto>(_mapper.Map<TransactionEntity>(result));
        }
    }
}
