using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Aplicacao.Servico.Interfaces
{
    interface IServicoUploadApi
    {
        Task<HttpResponseMessage> UploadArquivos(List<FileInfo> fileInfos);
    }
}
