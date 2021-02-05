using Microsoft.AspNetCore.Http;
using RestWitASP_NET5Udemy.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWitASP_NET5Udemy.Business.Interfaces
{
    public interface IFileBusiness
    {
        public byte[] GetFile(string fileName);
        public Task<FileDetailVO> SaveFileToDisk(IFormFile file);
        public Task<List<FileDetailVO>> SaveFilesToDisk(List<IFormFile> file); 
    }
}
