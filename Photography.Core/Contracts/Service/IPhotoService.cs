using System.Collections.Generic;
using Photography.Core.Models;

namespace Photography.Core.Contracts.Service
{
    public interface IPhotoService : IService
    {
        /// <summary>
        /// Retrieve a list of photos for an album
        /// </summary>
        /// <param name="albumId">The album id</param>
        /// <returns>A list of photos associated with this album</returns>
        IEnumerable<Photo> GetAlbumPhotos(int albumId);

        /// <summary>
        /// Get photos meeting a certain search criteria
        /// </summary>
        /// <param name="searchCriteria">The search criteria</param>
        /// <returns>All photos meeting the given search criteria</returns>
        IEnumerable<Photo> GetPhotos(SearchCriteria searchCriteria);
        
        /// <summary>
        /// Retrieve a photo by id
        /// </summary>
        /// <param name="photoId">The id of the photo</param>
        /// <returns>The photo with the given id</returns>
        Photo GetPhoto(int photoId);

        /// <summary>
        /// Add a photo to the database
        /// </summary>
        /// <param name="name">The name of the photo</param>
        /// <param name="description">A description of the photo</param>
        /// <param name="isPublic">Flag to determine if this photo is public or hidden</param>
        /// <param name="data">The photo as a byte array</param>
        /// <param name="tags">A list of tags for this photo</param>
        /// <returns>The newly added photo</returns>
        Photo AddPhoto(string name, string description, bool isPublic, byte[] data, IEnumerable<Tag> tags);

        /// <summary>
        /// Update a photo
        /// </summary>
        /// <param name="photo">The photo to update</param>
        /// <returns>The udated photo</returns>
        Photo UpdatePhoto(Photo photo);

        /// <summary>
        /// Remove a photo from an album
        /// </summary>
        /// <param name="albumId">The id of the album</param>
        /// <param name="photoId">The id of the photo</param>
        /// <returns>True if successful, otherwise false</returns>
        bool RemovePhotoFromAlbum(int albumId, int photoId);

        /// <summary>
        /// Delete a photo
        /// </summary>
        /// <param name="photoId">The id of the photo to delete</param>
        /// <returns>True if successful, otherwise false</returns>
        bool DeletePhoto(int photoId);
    }
}
