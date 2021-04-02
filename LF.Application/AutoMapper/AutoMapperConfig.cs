using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace LF.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(x => { x.AddProfile(new MappingsWithReverse()); });
        }
    }
}
