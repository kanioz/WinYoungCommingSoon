using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace WinYoungUI.Extensions
{
    public interface IPathProvider
    {
        string GetRootPath();
    }

    public class PathProvider : IPathProvider
    {
        private IHostingEnvironment _hostingEnvironment;

        public PathProvider(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        public string GetRootPath()
        {
            return _hostingEnvironment.WebRootPath;
        }
    }
}
