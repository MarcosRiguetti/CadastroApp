using BDCadastro.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDCadastro.Service
{
    public class PessoaService : IPessoaService
    {
        private SQLiteAsyncConnection _dbConnection;

        public PessoaService()
        {
            SetUpDb();
        }

        private async void SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Pessoas.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<PessoaModel>();
            }
        }

        public async Task<int> AddPessoa(PessoaModel pessoaModel)
        {
            return await _dbConnection.InsertAsync(pessoaModel);
        }

        public async Task<int> DeletePessoa(PessoaModel pessoaModel)
        {
            return await _dbConnection.DeleteAsync(pessoaModel);
        }

        public async Task<List<PessoaModel>> GetAllPessoa()
        {
            return await _dbConnection.Table<PessoaModel>().ToListAsync();
        }

        public async Task<PessoaModel> GetPessoaByID(int PessoaID)
        {
            var pessoa = await _dbConnection.QueryAsync<PessoaModel>($"Select * From {nameof(PessoaModel)} where PessoaID={PessoaID} ");
            return pessoa.FirstOrDefault();
        }

        public async Task<int> UpdatePessoa(PessoaModel pessoaModel)
        {
            return await _dbConnection.UpdateAsync(pessoaModel);
        }
    }
}
