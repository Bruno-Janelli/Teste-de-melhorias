﻿using System;
using System.Collections.Generic;

namespace EstoqueApp
{
    class Program
    {
        static List<Produto> produtos = new List<Produto>();

        static void Main()
        {
            int opcao;
            do
            {
                Console.WriteLine("\n=== Gerenciamento de Estoque ===");
                Console.WriteLine("\n1. Adicionar Produto\n");
                Console.WriteLine("2. Listar Produtos\n");
                Console.WriteLine("3. Sair\n");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("\nOpção inválida! Tente novamente.");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        AdicionarProduto();
                        break;
                    case 2:
                        ListarProdutos();
                        break;
                    case 3:
                        Console.WriteLine("\nSaindo...");
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida! Tente novamente.");
                        break;
                }

            } while (opcao != 3);
        }

        static void AdicionarProduto()
        {
            Console.Write("\nNome do Produto: ");
            string nome = Console.ReadLine();

            Console.Write("Quantidade: ");
            if (!int.TryParse(Console.ReadLine(), out int quantidade))
            {
                Console.WriteLine("Quantidade inválida!");
                return;
            }

            Console.Write("\nPreço: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal preco))
            {
                Console.WriteLine("Preço inválido!");
                return;
            }

            produtos.Add(new Produto(nome, quantidade, preco));
            Console.WriteLine("\nProduto adicionado com sucesso!\n");
        }

        static void ListarProdutos()
        {
            Console.WriteLine("\n=== Lista de Produtos ===");
            if (produtos.Count == 0)
            {
                Console.WriteLine("\nNenhum produto cadastrado.");
                return;
            }

            foreach (var produto in produtos)
            {
                Console.WriteLine($"\nNome: {produto.Nome}, \nQuantidade: {produto.Quantidade}, \nPreço: {produto.Preco:C}");
            }
        }
    }

    /* Recomendo adicionar uma função para deletar produtos, e editar os produtos */

    class Produto
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }

        public Produto(string nome, int quantidade, decimal preco)
        {
            Nome = nome;
            Quantidade = quantidade;
            Preco = preco;
        }
    }
}
