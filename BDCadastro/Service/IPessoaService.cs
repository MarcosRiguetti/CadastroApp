using BDCadastro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDCadastro.Service
{
    public interface IPessoaService
    {
        Task<List<PessoaModel>> GetAllPessoa();

        Task<PessoaModel> GetPessoaByID(int pessoaModel);

        Task<int> AddPessoa(PessoaModel pessoaModel);

        Task<int> UpdatePessoa(PessoaModel pessoaModel);

        Task<int> DeletePessoa(PessoaModel pessoaModel);
    }
}
