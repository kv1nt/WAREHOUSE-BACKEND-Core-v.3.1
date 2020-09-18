using Entities;
using Entities.Models;
using Entities.Models.DTO;
using Entities.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FileService
    {
        private RepositoryContext _repositoryContext { get; set; }
        public FileService(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void UploadUserPhoto(UserPhotoDTO userPhoto)
        {
            UserPhoto userPhotoDB = new UserPhoto()
            {
                Id = Guid.NewGuid(),
                UserId = userPhoto.UserId,
                Content = Encoding.ASCII.GetBytes(userPhoto.Content)
            };

            _repositoryContext.UserPhotos.Add(userPhotoDB);
            _repositoryContext.SaveChanges();

        }

        public UserPhotoDTO GetUserPhotoByUserID(string userId)
        {
           var userPhotoDB = _repositoryContext
                .UserPhotos.FirstOrDefault(p => p.UserId == userId);
            var userPhotoDTO = new UserPhotoDTO
            {
                Id = userPhotoDB.Id.ToString(),
                UserId = userPhotoDB.UserId,
                Content = Encoding.ASCII.GetString(userPhotoDB.Content)
            };    
            
            return userPhotoDTO;
        }

        public void UpdateUserPhoto(UserPhotoDTO photo)
        {
            UserPhoto userPhotoDB = new UserPhoto()
            {
                Id = Guid.Parse(photo.Id),
                UserId = photo.UserId,
                Content = Encoding.ASCII.GetBytes(photo.Content)
            };

            _repositoryContext.UserPhotos.Update(userPhotoDB);
            _repositoryContext.SaveChanges();
        }

        public  IEnumerable<ProductPhoto> GetProductsPhotos()
        {
            var productPhotos = _repositoryContext
                 .ProductPhotos.ToList();
            return productPhotos;
        }

        public async Task<ProductPhotoDTO> GetProductPhotoByProductIDAsync(string productId)
        {
            var productPhotoDB = _repositoryContext
                 .ProductPhotos.FirstOrDefault(p => p.ProductId == productId);
            var userPhotoDTO = new ProductPhotoDTO
            {
                Id = productPhotoDB.Id.ToString(),
                ProductId = productPhotoDB.ProductId,
                Content = Encoding.ASCII.GetString(productPhotoDB.Content)
            };

            return  userPhotoDTO;
        }

        public void UploadProductPhoto(ProductPhotoDTO productPhoto)
        {
            ProductPhoto productPhotoDB = new ProductPhoto()
            {
                Id = Guid.NewGuid(),
                ProductId = productPhoto.ProductId,
                Content = Encoding.ASCII.GetBytes(productPhoto.Content)
            };

            _repositoryContext.ProductPhotos.Add(productPhotoDB);
            _repositoryContext.SaveChanges();

        }
    }
}
