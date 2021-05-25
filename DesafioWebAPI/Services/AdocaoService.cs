using System;
using System.Collections.Generic;
using System.Linq;
using DesafioWebAPI.Domain;
using DesafioWebAPI.Domain.DTO;
using DesafioWebAPI.Services.Base;

namespace DesafioWebAPI.Services
{

    public class AdocaoService
    {
        private static List<Adocao> listaDeAdocao;
        private static int proximoId = 1;


        public AdocaoService()
        {
            if (listaDeAdocao == null)
            {
                listaDeAdocao = new List<Adocao>();

            }
        }

        public ServiceResponse<Adocao> CadastrarNovo(AdocaoCreateRequest model)
        {

            List<string> EspeciesValidas = new List<string>();
            EspeciesValidas.Add("cachorro");
            EspeciesValidas.Add("gato");
            EspeciesValidas.Add("coelho");
            EspeciesValidas.Add("capivara");

            if (!model.NvFofura.HasValue || model.NvFofura < 1 || model.NvFofura > 5)
            {
                return new ServiceResponse<Adocao>("Seu nível de fofura deve ser entre 1 e 5.");
            }

            if (!model.NvCarinho.HasValue || model.NvCarinho < 1 || model.NvCarinho > 5)
            {
                return new ServiceResponse<Adocao>("Seu nível de carinho deve ser entre 1 e 5.");
            }


            if (!EspeciesValidas.Contains(model.Especie.ToLower()))
                {
                    return new ServiceResponse<Adocao>("Somente é possível cadastrar as espécies: Cachorro, Gato, Coelho e Capivara.");
                }


            if(model.DtNascimento.HasValue && model.DtNascimento.Value.Date > DateTime.Now)
            {
                return new ServiceResponse<Adocao>("A data de nascimento não pode ser maior que: " + DateTime.Now.ToShortDateString());
            }

            var novaAdocao = new Adocao()
            {
                IdAdocao = proximoId++,
                Nome = model.Nome,
                Idade = model.Idade.Value,
                Especie = model.Especie,
                DtNascimento = model.DtNascimento,
                NvFofura = model.NvFofura.Value,
                NvCarinho = model.NvCarinho.Value,      
                Email = model.Email
            };       
            listaDeAdocao.Add(novaAdocao);
            return  new ServiceResponse<Adocao>(novaAdocao);
        }
        public List<Adocao> ListarTodos()
        {
            return listaDeAdocao;
        }

        public ServiceResponse<Adocao> PesquisarPorId(int id)
        {
            var resultado = listaDeAdocao.Where(x => x.IdAdocao == id).FirstOrDefault();
            if (resultado == null)
                return new ServiceResponse<Adocao>("Não foi encontrada uma adoção com esse Id");
            else
                return new ServiceResponse<Adocao>(resultado);

        }

        public ServiceResponse<Adocao> PesquisarPorNome(string nome)
        {
            var resultado = listaDeAdocao.Where(x => x.Nome.ToLower() == nome.ToLower()).FirstOrDefault();
            if (resultado == null)
                return new ServiceResponse<Adocao>("Não foi encontrada uma adoção com esse Nome");
            else
                return new ServiceResponse<Adocao>(resultado);
        }

        public ServiceResponse<Adocao> Editar(int id, AdocaoUpdateRequest model)
        {
            var resultado = listaDeAdocao.Where(x => x.IdAdocao == id).FirstOrDefault();

            if (resultado == null)
            {
                return new ServiceResponse<Adocao>("Adoção não encontrada.");
            }

            else
            {
                resultado.Nome = model.Nome;
                return new ServiceResponse<Adocao>(resultado);
            }
        }

        public ServiceResponse<bool> Deletar(int id)
        {
            var resultado = listaDeAdocao.Where(x => x.IdAdocao == id).FirstOrDefault();

            if (resultado == null)
                return new ServiceResponse<bool>("Adoção não encontrada.");

            listaDeAdocao.Remove(resultado);

            return new ServiceResponse<bool>(true);
        }

    }
}
















