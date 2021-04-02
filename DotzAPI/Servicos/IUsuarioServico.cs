﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DotzAPI.Database;
using DotzAPI.Modelos;

namespace DotzAPI.Servicos
{
    public interface IUsuarioServico
    {
        Task<List<Usuario>> ObterTodosAsync();
        Task<Usuario> ObterPorIdAsync(int id);
        Task<Usuario> AdicionarAsync(Usuario usuario);
        Task<Usuario> AdicionarEnderecoAsync(Endereco endereco, int id);
    }
}