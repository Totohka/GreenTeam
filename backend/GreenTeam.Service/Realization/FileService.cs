using GreenTeam.DAL.Repositories.Interface;
using GreenTeam.Model.Entities;
using GreenTeam.Model.ViewModel;
using GreenTeam.Service.Interface;

namespace GreenTeam.Service.Realization
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;

        public FileService(IFileRepository fileRepository) {
            _fileRepository = fileRepository;
        }

        public void Create(FileCreateViewModel fileCreateViewModel)
        {
            _fileRepository.Create(fileCreateViewModel.File, fileCreateViewModel.User_id, fileCreateViewModel.Cheque_id);
        }

        public void Delete(int chequeId, int userId)
        {
            _fileRepository.Delete(chequeId, userId);
        }

        public async Task<string> Get(int id)
        {
            return await _fileRepository.Get(id);
        }

        public async Task<List<string>> GetByUserId(int userId)
        {
            return await _fileRepository.GetByUserId(userId);
        }

        public void Update(FileCreateViewModel fileCreateViewModel)
        {
            _fileRepository.Update(fileCreateViewModel.File, fileCreateViewModel.User_id, fileCreateViewModel.Cheque_id);
        }
    }
}
