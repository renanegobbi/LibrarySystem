using AutoMapper;
using SistemaBiblioteca.App.Mvc.ViewModels;
using SistemaBiblioteca.Business.Models.Emprestimos;
using SistemaBiblioteca.Business.Models.Livros;
using SistemaBiblioteca.Business.Models.Usuarios;
using System;
using System.Linq;
using System.Reflection;

namespace SistemaBiblioteca.App.Mvc
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration GetMapperConfiguration()
        {
            var profiles = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => typeof(Profile).IsAssignableFrom(x));

            return new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(Activator.CreateInstance(profile) as Profile);
                }
            });
        }
    }

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Livro, LivroViewModel>().ReverseMap();
            CreateMap<Emprestimo, EmprestimoViewModel>().ReverseMap();
            CreateMap<Tuple<Usuario[], double>, Tuple<UsuarioViewModel[], double>>().ReverseMap();
        }
    }
}