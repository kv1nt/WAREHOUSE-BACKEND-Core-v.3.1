using Entities;
using Entities.Models;
using Entities.Models.DTO;
using System;
using System.Collections.Generic;
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
    }
}
