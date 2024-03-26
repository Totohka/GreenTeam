using GreenTeam.DAL.Repositories.Interface;
using GreenTeam.Model.ViewModel;
using GreenTeam.Service.Interface;

namespace GreenTeam.Service.Realization
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository) {
            _imageRepository = imageRepository;
        }

        public async Task Create(ImageCreateViewModel imageCreateViewModel)
        {
            await _imageRepository.Create(imageCreateViewModel.Image, imageCreateViewModel.Product_id);
        }

        public async Task Delete(int productId, int photoId)
        {
            await _imageRepository.Delete(productId, photoId);
        }

        public List<string> Get(int productId)
        {
            return _imageRepository.Get(productId);
        }

        public List<string> GetAll()
        {
            return _imageRepository.GetAll();
        }

        public async Task Update(ImageUpdateViewModel imageUpdateViewModel)
        {
            await _imageRepository.Update(imageUpdateViewModel.Image, imageUpdateViewModel.Product_id, imageUpdateViewModel.Photo_id);
        }
    }
}
