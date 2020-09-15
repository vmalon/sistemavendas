using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Aplicacao.Models;
using Aplicacao.Servico.Interfaces;
using Newtonsoft.Json;

namespace Aplicacao.Servico
{
    public class ServicoUploadApi : IServicoUploadApi
    {
        private string BASE_URL = "https://localhost:44354/api/FileUpload/";

        public Task<HttpResponseMessage> UploadArquivos(List<FileInfo> fileInfos)
        {
            var httpClient = new HttpClient();
            var fileUploadResult = new FileUploadResultViewModel();

            httpClient.BaseAddress = new Uri(BASE_URL);
            var multipartFormDataContent = new MultipartFormDataContent();

            try
            {
                foreach (var file in fileInfos)
                {
                    var fileContent = new ByteArrayContent(File.ReadAllBytes(file.FullName));
                    multipartFormDataContent.Add(fileContent, "files", file.Name);
                }
                var fileResult = httpClient.PostAsync("upload", multipartFormDataContent).Result;

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
