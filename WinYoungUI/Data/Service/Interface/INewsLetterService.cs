using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WinYoungUI.ViewModels;

namespace WinYoungUI.Data.Service.Interface
{
    public interface INewsLetterService
    {
        NewsLetterVm AddEditNewsLetter(NewsLetterVm model);
    }
}
