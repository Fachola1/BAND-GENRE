using System;
using System.Collections.Generic;
using System.Threading;

namespace Estudos_PraticaCSharp
{
    class Program
    {

        static void Main(string[] args)
        {
            #region VARIÁVEIS
            string nomeBanda;
            string bandaUsuario;
            int escolhaUsuario;
            int qtd = 0;
            int notaUsuario;

            Dictionary<string, List<int>> registroBandas = new Dictionary<string, List<int>>(); // Nome da banda, nota da banda
            #endregion

            Console.WriteLine(@"
                    ██████╗░░█████╗░███╗░░██╗██████╗░░█████╗░░██████╗
                    ██╔══██╗██╔══██╗████╗░██║██╔══██╗██╔══██╗██╔════╝
                    ██████╦╝███████║██╔██╗██║██║░░██║███████║╚█████╗░
                    ██╔══██╗██╔══██║██║╚████║██║░░██║██╔══██║░╚═══██╗
                    ██████╦╝██║░░██║██║░╚███║██████╔╝██║░░██║██████╔╝
                    ╚═════╝░╚═╝░░╚═╝╚═╝░░╚══╝╚═════╝░╚═╝░░╚═╝╚═════╝░
                                ");
            ExibirMensagemDeBoasVindas();
            Console.WriteLine();
            ExibirOpcoesDoMenu();

            Console.ReadLine();

            #region Funções

            void ExibirMensagemDeBoasVindas()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Seja bem-vindo(a)");
                Console.ResetColor();
            }

            void ExibirOpcoesDoMenu()
            {
                Console.WriteLine("\nDigite 1 para registrar uma banda");
                Console.WriteLine("Digite 2 para mostrar todas as bandas");
                Console.WriteLine("Digite 3 para avaliar uma banda");
                Console.WriteLine("Digite 4 para ver a média de das nota de uma banda");
                Console.WriteLine("Digite 9 para sair da aplicação");
                Console.WriteLine();

                Console.Write("Digite a sua opção: ");
                escolhaUsuario = Convert.ToInt32(Console.ReadLine());

                switch (escolhaUsuario)
                {
                    case 1:
                        Console.WriteLine();
                        ExibirTitulo("Registrando bandas");
                        RegistrarBandas();
                        break;
                    case 2:
                        Console.WriteLine();
                        if (registroBandas.Count == 0)
                        {
                            Console.WriteLine("Não há bandas cadastradas para serem mostradas! Por favor, cadastre-as teclando '1' no menu");
                            ExibirOpcoesDoMenu();
                            Thread.Sleep(1000);
                        }
                        else
                        {
                            ExibirTitulo("Mostrando bandas");
                            MostrarBandas();
                        }
                        break;
                    case 3:

                        if (registroBandas.Count == 0)
                        {
                            Console.WriteLine("Não há bandas cadastradas para serem avaliadas! Por favor, cadastre-as teclando '1' no menu");
                            Thread.Sleep(1000);
                            ExibirOpcoesDoMenu();
                        }
                        else
                        {
                            Console.WriteLine();
                            ExibirTitulo("Avaliando bandas");
                            AvaliarBandas();
                        }
                        break;
                    case 4:
                        if (registroBandas.Count == 0)
                        {
                            Console.WriteLine("Não há bandas cadastradas para calcular a média! Por favor, cadastre-as teclando '1' no menu");
                            Thread.Sleep(1000);
                            ExibirOpcoesDoMenu();
                        }
                        else
                        {
                            ExibirTitulo("Calculando a média: ");
                            CalcularMedia();
                        }
                        break;
                    case 9:
                        Console.WriteLine("Aplicação encerrada!");
                        Console.WriteLine("Finalizando...");
                        Thread.Sleep(3000);
                        break;
                    default:
                        Console.WriteLine($"O número {escolhaUsuario} não é válido. Tente novamente!");
                        ExibirOpcoesDoMenu();
                        break;
                }
            }

            void RegistrarBandas()
            {
                Console.WriteLine();

                Console.WriteLine("\nDigite o nome da banda que deseja adicionar: ");
                nomeBanda = Console.ReadLine();
                registroBandas.Add(nomeBanda, new List<int>()); // Adiciona o nome da banda, mas não adiciona nenhuma nota.

                Console.WriteLine("Deseja adicionar mais uma banda? Se sim, digite 1, se não, digite qualquer coisa: ");
                escolhaUsuario = Convert.ToInt32(Console.ReadLine());

                if (escolhaUsuario == 1)
                {
                    Console.Clear();
                    RegistrarBandas();
                }
                else
                {
                    Console.WriteLine("Registros feitos com sucesso!");
                    Console.WriteLine("Finalizando...");
                    Thread.Sleep(3000);
                    ExibirOpcoesDoMenu();
                }
            }

            void MostrarBandas()
            {
                Console.WriteLine();
                foreach (var banda in registroBandas.Keys)
                {
                    qtd++;
                    Console.WriteLine($"Banda {qtd} - {banda}");
                }

                Thread.Sleep(qtd * 500); // Cada banda equivalerá a meio segundo pra ser lido
                Console.Clear();
                ExibirOpcoesDoMenu();
            }


            void ExibirTitulo(string titulo)
            {
                foreach (var letra in titulo)
                {
                    Console.Write("*");
                }
                Console.WriteLine();

                Console.WriteLine(titulo);

                foreach (var letra in titulo)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            void AvaliarBandas()
            {
                Console.WriteLine("Deseja avaliar qual banda? ");
                bandaUsuario = Console.ReadLine();

                if (registroBandas.ContainsKey(bandaUsuario))
                {
                    Console.WriteLine($"Qual nota a banda {bandaUsuario} merece? ");
                    notaUsuario = Convert.ToInt32(Console.ReadLine());
                    registroBandas[bandaUsuario].Add(notaUsuario);

                    Console.WriteLine("Deseja adicionar mais uma nota? Se sim, tecle 1, se não, tecle qualquer coisa. ");
                    escolhaUsuario = Convert.ToInt32(Console.ReadLine());

                    if (escolhaUsuario == 1)
                    {
                        Console.WriteLine($"Qual nota a banda {bandaUsuario} merece? ");
                        notaUsuario = Convert.ToInt32(Console.ReadLine());
                        registroBandas[bandaUsuario].Add(notaUsuario);
                    }
                    else
                    {
                        Console.WriteLine("Finalizando avaliação.");
                        Thread.Sleep(2000);
                        ExibirOpcoesDoMenu();
                    }
                }
                else
                {
                    Console.WriteLine($"A banda {bandaUsuario} não foi encontrada");
                    Console.WriteLine("Aperte qualquer tecla para voltar ao menu!");
                    Console.ReadKey();
                    Console.Clear();
                    ExibirOpcoesDoMenu();
                }
            }

            void CalcularMedia()
            {
                Console.Clear();
                Console.WriteLine("Qual banda você deseja ver a média das notas? ");
                bandaUsuario = Console.ReadLine();

                if (registroBandas.ContainsKey(bandaUsuario))
                {
                    List<int> notas = registroBandas[bandaUsuario];

                    if (notas.Count > 0)
                    {
                        double somaNotas = 0;

                        foreach (int nota in notas)
                        {
                            somaNotas += nota;
                        }

                        double media = somaNotas / notas.Count;

                        Console.WriteLine($"A média das notas da banda {bandaUsuario} é: {media:F2}");
                    }
                    else
                    {
                        Console.WriteLine($"A banda {bandaUsuario} não possui notas cadastradas.");
                    }
                }
                else
                {
                    Console.WriteLine($"A banda {bandaUsuario} não foi encontrada");
                }

                Console.WriteLine("Pressione qualquer tecla para voltar ao menu!");
                Console.ReadKey();
                Console.Clear();
                ExibirOpcoesDoMenu();
            }

            #endregion
        }

    }
}
