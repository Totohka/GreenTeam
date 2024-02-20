using GreenTeam.DAL.Repositories.Interface;
using GreenTeam.Model.Entities;
using GreenTeam.Model.ViewModel;
using GreenTeam.Service.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTeam.Service.Realization
{
    public class ChequeService : IChequeService
    {
        private readonly IChequeRepository _chequeRepository;
        private readonly IFileRepository _fileRepository;

        public ChequeService(IChequeRepository chequeRepository,
                             IFileRepository fileRepository) {
            _chequeRepository = chequeRepository;
            _fileRepository = fileRepository;
        }

        public void Create(ChequeCreateViewModel chequeCreateViewModel)
        {
            Cheque cheque = new Cheque()
            {
                UserId = chequeCreateViewModel.User_id,
                Path = chequeCreateViewModel.User_id.ToString()
            };
            _chequeRepository.Create(cheque);
            cheque = _chequeRepository.GetByUserId(cheque.UserId);
            cheque.Path += "/" + cheque.Id.ToString();
            _fileRepository.Create(chequeCreateViewModel.File, chequeCreateViewModel.User_id.ToString(), cheque.Id);
            _chequeRepository.Update(cheque);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Cheque> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cheque>> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ChequeCreateViewModel chequeCreateViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
