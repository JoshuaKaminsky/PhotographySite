using Photography.Core.Models;
using System.Collections.Generic;
    
namespace Photography.Core.Contracts.Process
{
    /// <summary>
    /// Process for Photos
    /// </summary>
    public interface IPhotoProcess : IProcess
    {
        /// <summary>
        /// Retrieve a photo by id
        /// </summary>
        /// <param name="photoId">The id of the photo</param>
        /// <returns>The photo with the given id</returns>
        Photo GetPhoto(int photoId);

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
        /// Add a photo to the database
        /// </summary>
        /// <param name="name">The name of the photo</param>
        /// <param name="description">A description of the photo</param>
        /// <param name="isPublic">Flag to determine if this photo is public or hidden</param>
        /// <param name="source">The path to the photo source</param>
        /// <param name="thumbnail">The path to the thumbnail source</param>
        /// <param name="tags">A list of tags for this photo</param>
        /// <param name="albumId">The id of the album to add this photo to</param>
        /// <returns>The newly added photo</returns>
        Photo AddPhoto(string name, string description, bool isPublic, string source, string thumbnail, IEnumerable<Tag> tags, int albumId);

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