using Azure.Storage.Blobs; 

namespace clinica_bravo_backend.Utils {
    public class AzureStorage : IStorageFiles {
        private string connectionString;

        public AzureStorage(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("AzureStorage");
        }

        public async Task<string> SaveFile(string container, IFormFile file)
        {
            var cliente = new BlobContainerClient(connectionString, container);
            await cliente.CreateIfNotExistsAsync();
            cliente.SetAccessPolicy(Azure.Storage.Blobs.Models.PublicAccessType.Blob);

            var extension = Path.GetExtension(file.FileName);
            var archivoNombre = $"{Guid.NewGuid()}{extension}";
            var blob = cliente.GetBlobClient(archivoNombre);
            await blob.UploadAsync(file.OpenReadStream());
            return blob.Uri.ToString();
        }

        public async Task DeleteFile(string route, string container)
        {
            if (string.IsNullOrEmpty(route))
            {
                return;
            }

            var cliente = new BlobContainerClient(connectionString, container);
            await cliente.CreateIfNotExistsAsync();
            var archivo = Path.GetFileName(route);
            var blob = cliente.GetBlobClient(archivo);
            await blob.DeleteIfExistsAsync();
        }

        public async Task<string> EditFile(string container, IFormFile file, string route)
        {
            await DeleteFile(route, container);
            return await SaveFile(container, file);
        }
    }
}
