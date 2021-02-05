using Microsoft.AspNetCore.Http;
using RestWitASP_NET5Udemy.Business.Interfaces;
using RestWitASP_NET5Udemy.Data.VO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RestWitASP_NET5Udemy.Business.Implementations
{
    public class FileBusinessImplementation : IFileBusiness
    {
        private readonly string _basePath;
        private readonly IHttpContextAccessor _context;

        public FileBusinessImplementation(IHttpContextAccessor context)
        {
            _context = context;
            _basePath = Directory.GetCurrentDirectory() + "\\UploadDir\\";
        }

        public byte[] GetFile(string fileName)
        {
            var filePath = _basePath + fileName;
            return File.ReadAllBytes(filePath);
        }
        public async Task<FileDetailVO> SaveFileToDisk(IFormFile file)
        {
            FileDetailVO fileDetail = new FileDetailVO();
            var fileType = Path.GetExtension(file.FileName);
            var baseUrl = _context.HttpContext.Request.Host;

            if (fileType.ToLower() == ".pdf" || fileType.ToLower() == ".jpg" || 
                fileType.ToLower() == ".png" || fileType.ToLower() == ".jpeg")
            {
                if (file != null && file.Length > 0)
                {
                    var docName = Path.GetFileName(file.FileName);
                    var destination = Path.Combine(_basePath, "", docName);
                    fileDetail.DocumentName = docName;
                    fileDetail.DocumentType = fileType;
                    fileDetail.DocumentUrl = Path.Combine(baseUrl + "/api/v1/file/", fileDetail.DocumentName);
                    using var strem = new FileStream(destination, FileMode.Create);
                    await file.CopyToAsync(strem);
                }
            }
            return fileDetail;
        }
        public async Task<List<FileDetailVO>> SaveFilesToDisk(List<IFormFile> files)
        {
            List<FileDetailVO> list = new List<FileDetailVO>();
            foreach (IFormFile file in files)
            {
                list.Add(await SaveFileToDisk(file));
            }
            return list;
        }
    }
}
