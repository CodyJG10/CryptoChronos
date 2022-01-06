using Azure.Storage.Blobs;

namespace CryptoChronos.Server.Services
{
    public class ProfilePictureService
    {
        private BlobContainerClient _blobClient;

        public ProfilePictureService(string connectionString)
        {
            _blobClient = new BlobContainerClient(connectionString, "profile-pictures");
        }

        public async Task<Uri> UploadProfilePicture(string userAddress, Stream fileStream)
        {
            await _blobClient.DeleteBlobIfExistsAsync(userAddress + ".png");
            BlobClient blob = _blobClient.GetBlobClient(userAddress + ".png");
            await blob.UploadAsync(fileStream);
            return blob.Uri;
        }

        public Uri GetProfilePictureUrl(string userAddress)
        {
            BlobClient blob = _blobClient.GetBlobClient(userAddress + ".png");
            return blob.Uri;
        }
    }
}