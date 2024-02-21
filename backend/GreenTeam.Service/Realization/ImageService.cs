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

        public void Create(ImageCreateViewModel imageCreateViewModel)
        {
            _imageRepository.Create(imageCreateViewModel.Image, imageCreateViewModel.Product_id);
        }

        public void Delete(int productId)
        {
            _imageRepository.Delete(productId);
        }

        public string Get(int id)
        {
            return _imageRepository.Get(id);
        }

        public List<string> GetAll()
        {
            return _imageRepository.GetAll();
        }

        public void Update(ImageCreateViewModel imageCreateViewModel)
        {
            _imageRepository.Update(imageCreateViewModel.Image, imageCreateViewModel.Product_id);
        }
    }
}
