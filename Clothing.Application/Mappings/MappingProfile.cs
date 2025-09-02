using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Clothing.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile(Assembly assembly)
            => ApplyMappingsFromAssembly(assembly);
            

        public void ApplyMappingsFromAssembly (Assembly assembly)
        {
            var types = assembly.GetTypes()
                .Where(a => a.GetInterfaces()
                .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                .ToList();


            foreach (var type in types)
            {
                var instanse = Activator.CreateInstance(type);
                var method = type.GetMethod("Mapping");
                method?.Invoke(instanse, new[] { this });
            }
        }
    }
}
