using System;
using System.Collections.Generic;

namespace ListaDeTarefas
{
    public class Tarefa
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public bool Concluida { get; set; }
    }

    public class ListaDeTarefas
    {
        private static List<Tarefa> tarefas = new List<Tarefa>();

        static void Main(string[] args)
        {
            while (true)
            {
                ExibirMenu();
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarTarefa();
                        break;

                    case "2":
                        ListarTarefasPendentes();
                        break;

                    case "3":
                        RemoverTarefa();
                        break;

                    case "4":
                        MarcarTarefaComoConcluida();
                        break;

                    case "5":
                        FiltrarTarefasConcluidas();
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Esta opção não é válida, tente novamente");
                        break;
                }
            }
        }

        static void ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine("Bem-vindo à sua lista de tarefas");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Qual operação você deseja fazer? \n");
            Console.WriteLine("1- Adicionar uma nova tarefa");
            Console.WriteLine("2- Listar tarefas pendentes");
            Console.WriteLine("3- Remover tarefa");
            Console.WriteLine("4- Marcar tarefa como concluída");
            Console.WriteLine("5- Filtrar tarefas concluídas");
            Console.WriteLine("6- Sair \n");
            Console.Write("Digite a opção que você deseja: ");
        }

        static void AdicionarTarefa()
        {
            Console.WriteLine("\nDigite o título da tarefa:");
            string titulo = Console.ReadLine();

            Console.WriteLine("Digite a descrição da tarefa:");
            string descricao = Console.ReadLine();

            tarefas.Add(new Tarefa
            {
                Titulo = titulo,
                Descricao = descricao,
                Concluida = false
            });

            Console.WriteLine("Tarefa adicionada com sucesso!");
        }

        static void ListarTarefasPendentes()
        {
            Console.WriteLine("\nEssas são as tarefas pendentes:");
            for (int i = 0; i < tarefas.Count; i++)
            {
                if (!tarefas[i].Concluida)
                {
                    Console.WriteLine($"{i + 1}- {tarefas[i].Titulo}: {tarefas[i].Descricao}");
                }
            }
        }

        static void RemoverTarefa()
        {
            ListarTarefasPendentes();
            Console.WriteLine("\nDigite o número da tarefa que deseja remover:");
            if (int.TryParse(Console.ReadLine(), out int indice) && indice > 0 && indice <= tarefas.Count)
            {
                tarefas.RemoveAt(indice - 1);
                Console.WriteLine("Tarefa removida com sucesso!");
            }
            else
            {
                Console.WriteLine("Tarefa não encontrada.");
            }
        }

        static void MarcarTarefaComoConcluida()
        {
            ListarTarefasPendentes();
            Console.WriteLine("\nDigite o número da tarefa que deseja marcar como concluída:");
            if (int.TryParse(Console.ReadLine(), out int indice) && indice > 0 && indice <= tarefas.Count)
            {
                tarefas[indice - 1].Concluida = true;
                Console.WriteLine("Tarefa marcada como concluída!");
            }
            else
            {
                Console.WriteLine("Tarefa não encontrada.");
            }
        }

        static void FiltrarTarefasConcluidas()
        {
            Console.WriteLine("\nEssas são as tarefas concluídas:");
            for (int i = 0; i < tarefas.Count; i++)
            {
                if (tarefas[i].Concluida)
                {
                    Console.WriteLine($"{i + 1}- {tarefas[i].Titulo}: {tarefas[i].Descricao}");
                }
            }
        }
    }
}
