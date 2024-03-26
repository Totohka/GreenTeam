using GreenTeam.Model.ViewModel;

namespace GreenTeam.Service.Interface
{
    public interface IImageService
    {
        public List<string> Get(int productId);
        public List<string> GetAll();
        public Task Create(ImageCreateViewModel imageCreateViewModel);
        public Task Delete(int productId, int photoId);
        public Task Update(ImageUpdateViewModel imageUpdateViewModel);
    }
}
