using System;
using System.Collections.Generic;
using System.Linq;
using PackagingAPI.Models; 

namespace PackagingAPI.Services
{
    public class EmbalagemService
    {
        private List<Caixa> _caixasDisponiveis = new List<Caixa>
        {
            new Caixa { Nome = "Caixa 1", Altura = 30, Largura = 40, Comprimento = 80 },
            new Caixa { Nome = "Caixa 2", Altura = 80, Largura = 50, Comprimento = 40 },
            new Caixa { Nome = "Caixa 3", Altura = 50, Largura = 80, Comprimento = 60 }
        };

        
        public List<Caixa> EmbalarPedido(List<Produto> produtos)
        {
            var caixasUsadas = new List<Caixa>();

            foreach (var produto in produtos)
            {
                var caixaSelecionada = _caixasDisponiveis.FirstOrDefault(caixa =>
                    caixa.Altura >= produto.Altura && caixa.Largura >= produto.Largura && caixa.Comprimento >= produto.Comprimento);
                
                if (caixaSelecionada != null)
                {
                    caixasUsadas.Add(caixaSelecionada);
                }
            }

            
            return caixasUsadas; 
        }

        internal object EmbalagemPedido(List<Produto> produtos)
        {
            throw new NotImplementedException();
        }
    }
}
