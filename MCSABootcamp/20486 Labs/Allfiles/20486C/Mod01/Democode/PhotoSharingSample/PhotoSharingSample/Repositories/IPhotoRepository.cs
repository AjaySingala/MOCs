using PhotoSharingApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoSharingApplication.Repositories
{
    public interface IPhotoRepository
    {
        IList<Photo> GetAll();
        Photo Get(int id);
    }

    public class PhotoRepository : IPhotoRepository
    {
        private PhotoSharingDB db = new PhotoSharingDB();

        public IList<Photo> GetAll()
        {
            return db.Photos.ToList();
        }

        public Photo Get(int id)
        {
            Photo photo = db.Photos.Find(id);
            return photo;
        }

    }
}