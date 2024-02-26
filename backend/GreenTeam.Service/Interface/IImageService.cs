using GreenTeam.Model.ViewModel;

namespace GreenTeam.Service.Interface
{
    public interface IImageService
    {
        public string Get(int id);
        public List<string> GetAll();
        public void Create(ImageCreateViewModel imageCreateViewModel);
        public void Delete(int productId);
        public void Update(ImageCreateViewModel imageCreateViewModel);
    }
}
