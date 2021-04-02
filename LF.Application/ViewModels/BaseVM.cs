using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LF.Application.ViewModels
{
    public class BaseVM
    {
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

    }
}
