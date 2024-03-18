using GreenTeam.DAL.Repositories.Interface;
using GreenTeam.Model.Entities;
using GreenTeam.Service.Interface;
using GreenTeam.Service.Realization;
using Moq;

namespace GreenTeam.Unit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        #region GetTestData
        private List<Category> GetTestCategories()
        {
            var categories = new List<Category>
            {
                new Category { Id=1, Name="1", Description="11"},
                new Category { Id=2, Name="2", Description="12"},
                new Category { Id=3, Name="3", Description="13"},
                new Category { Id=4, Name="4", Description="14"}
            };
            return categories;
        }

        private List<Supplier> GetTestSuppliers()
        {
            var suppliers = new List<Supplier>
            {
                new Supplier { Id=1, Name="1", Description="21"},
                new Supplier { Id=2, Name="2", Description="22"},
                new Supplier { Id=3, Name="3", Description="23"},
                new Supplier { Id=4, Name="4", Description="24"}
            };
            return suppliers;
        }

        private List<User> GetTestUsers()
        {
            var users = new List<User>
            {
                new User { Id=1, FirstName="Name1", LastName="LastName1", Email="ee@dj.com", Password="123", Phone="9999"},
                new User { Id=2, FirstName="Name2", LastName="LastName2", Email="ee@dj.com", Password="123", Phone="9999"},
                new User { Id=3, FirstName="Name3", LastName="LastName3", Email="ee@dj.com", Password="123", Phone="9999"},
                new User { Id=4, FirstName="Name4", LastName="LastName4", Email="ee@dj.com", Password="123", Phone="9999"}
            };
            return users;
        }

        private List<Product> GetTestProducts()
        {
            var products = new List<Product>
            {
                new Product { Id=1, Name="Name1", Amount = 1, CategoryId = 1, Description="Des1", Path="123", Price=1.00M, SupplierId=1},
                new Product { Id=2, Name="Name2", Amount = 1, CategoryId = 1, Description="Des2", Path="123", Price=1.00M, SupplierId=1},
                new Product { Id=3, Name="Name3", Amount = 1, CategoryId = 1, Description="Des3", Path="123", Price=1.00M, SupplierId=1},
                new Product { Id=4, Name="Name4", Amount = 1, CategoryId = 1, Description="Des4", Path="123", Price=1.00M, SupplierId=1},
            };
            return products;
        }
        #endregion

        #region CategoryTests
        [Test]
        public void IsGetAllNotNullInCategoryService()
        {
            // Arrange
            var categoryRepository = new Mock<IRepository<Category>>();
            categoryRepository.Setup(repo => repo.GetAll()).ReturnsAsync(GetTestCategories());
            ICategoryService service = new CategoryService(categoryRepository.Object);
            // Act
            var result = service.GetAll();
            // Assert
            Assert.NotNull(result);
        }

        [Test]
        public async Task IsGetAllEqualsInCategoryService()
        {
            // Arrange
            var categoryRepository = new Mock<IRepository<Category>>();
            categoryRepository.Setup(repo => repo.GetAll()).ReturnsAsync(GetTestCategories());
            ICategoryService service = new CategoryService(categoryRepository.Object);
            // Act
            var result = await service.GetAll();
            var models = GetTestCategories();
            // Assert
            Assert.That(models.Count, Is.EqualTo(result.Count));
        }

        [Test]
        public void IsGetNotNullInCategoryService() {
            int id = 1;
            var categoryRepository = new Mock<IRepository<Category>>();
            categoryRepository.Setup(repo => repo.Get(id)).ReturnsAsync(new Category() { Id = 1, Name = "1", Description = "1" });
            ICategoryService service = new CategoryService(categoryRepository.Object);
            // Act
            var result = service.Get(id);
            // Assert
            Assert.NotNull(result);
        }

        [Test]
        public async Task IsGetEqualsIdInCategoryService()
        {
            int id = 1;
            var categoryRepository = new Mock<IRepository<Category>>();
            var category = new Category() { Id = 1, Name = "1", Description = "1" };
            categoryRepository.Setup(repo => repo.Get(id)).ReturnsAsync(category);
            ICategoryService service = new CategoryService(categoryRepository.Object);
            // Act
            var result = await service.Get(id);
            // Assert
            Assert.That(result.Id, Is.EqualTo(id));
        }

        //[Test]
        //public void IsCreateInCategoryService()
        //{
        //    List<Category> bd = new List<Category>();
        //    var category = new Category() { Id = 1, Name = "1", Description = "1" };
        //    var categoryRepository = new Mock<IRepository<Category>>();
        //    categoryRepository.Setup(repo => repo.Create(category)){
        //        bd.Add(category);
        //    };
        //    ICategoryService service = new CategoryService(categoryRepository.Object);
        //    // Act
        //    service.Create(category);
        //    // Assert
        //    Assert.That(result.Id, Is.EqualTo(id));
        //}
        #endregion

        #region SupplierTests
        [Test]
        public void IsGetAllNotNullInSupplierService()
        {
            // Arrange
            var supplierRepository = new Mock<IRepository<Supplier>>();
            supplierRepository.Setup(repo => repo.GetAll()).ReturnsAsync(GetTestSuppliers());
            ISupplierService service = new SupplierService(supplierRepository.Object);
            // Act
            var result = service.GetAll();
            // Assert
            Assert.NotNull(result);
        }
        #endregion

        #region ProductTests
        [Test]
        public void IsGetAllNotNullInProductService()
        {
            // Arrange
            var productRepository = new Mock<IRepository<Product>>();
            productRepository.Setup(repo => repo.GetAll()).ReturnsAsync(GetTestProducts());
            IProductService service = new ProductService(productRepository.Object);
            // Act
            var result = service.GetAll();
            // Assert
            Assert.NotNull(result);
        }
        #endregion

        #region UserTests
        [Test]
        public void IsGetAllNotNullInUserService()
        {
            // Arrange
            var userRepository = new Mock<IUserRepository>();
            var roleRepository = new Mock<IRepository<Role>>();
            userRepository.Setup(repo => repo.GetAll()).ReturnsAsync(GetTestUsers());
            IUserService service = new UserService(userRepository.Object, roleRepository.Object);
            // Act
            var result = service.GetAll();
            // Assert
            Assert.NotNull(result);
        }
        #endregion

    }
}