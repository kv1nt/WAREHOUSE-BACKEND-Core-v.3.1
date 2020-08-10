using Entities;
using Entities.Models;
using Entities.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
