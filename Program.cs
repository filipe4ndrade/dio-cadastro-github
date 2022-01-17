using System;

namespace DIO.Humanos
{
    class Program{

          static HumanoRepositorio repositorio = new HumanoRepositorio();
        static void Main (string[] args){

             string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarHumanos();
						break;
					case "2":
						InserirHumano();
						break;
					case "3":
						AtualizarHumano();
						break;
					case "4":
						ExcluirHumano();
						break;
					case "5":
				    	VisualizarHumano();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }
		 private static void VisualizarHumano()
		{
			Console.Write("Digite o id do Humano: ");
			int indiceHumano = int.Parse(Console.ReadLine());

			var humano = repositorio.RetornaPorId(indiceHumano);

			Console.WriteLine(humano);
		}
        private static void ListarHumanos()
		{
			Console.WriteLine("Listar Humanos");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum Humano cadastrada.");
				return;
			}

			foreach (var humano in lista)
			{
                var excluido = humano.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", humano.retornaId(), humano.retornaNome(), (excluido ? "*Morreu*" : ""));
			}
		}
        
		private static void AtualizarHumano()
		{
			Console.Write("Digite o id do Humano: ");
			int indiceHumano = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Sexo)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Sexo), i));
			}
			Console.Write("Digite o sexo biológico entre as opções acima: ");
			int entradaSexo = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome do Humano: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite a Idade do Humano: ");
			int entradaIdade = int.Parse(Console.ReadLine());

            Console.Write("Digite a Massa Corporal do Humano: ");
			int entradaMassa = int.Parse(Console.ReadLine());

			Humano atualizaHumano = new Humano(id: indiceHumano,
										nome: entradaNome,
										sexo: (Sexo)entradaSexo,
										massa: entradaMassa,
										idade: entradaIdade);

			repositorio.Atualiza(indiceHumano, atualizaHumano);
		}
		    private static void ExcluirHumano()
		{
			Console.Write("Digite o id do Humano Morto: ");
			int indiceHumano = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceHumano);
		}
         private static void InserirHumano()
		{
			Console.WriteLine("Adicionar novo Humano");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Sexo)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Sexo), i));
			}
			Console.Write("Digite o sexo biológico entre as opções acima: ");
			int entradaSexo = int.Parse(Console.ReadLine());

			Console.Write("Digite o Nome do Humano: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite a Idade do Humano: ");
			int entradaIdade = int.Parse(Console.ReadLine());

            Console.Write("Digite a Massa Corporal do Humano: ");
			int entradaMassa = int.Parse(Console.ReadLine());

		

			Humano novaSerie = new Humano(id: repositorio.ProximoId(),
                                        nome: entradaNome,
										sexo: (Sexo)entradaSexo,
										massa: entradaMassa,
										idade: entradaIdade);

			repositorio.Insere(novaSerie);
		}
         private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Humanos a seu dispor!!!");
			Console.WriteLine("Cadastro Oficial de Humanos Abduzidos!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Humanos");
			Console.WriteLine("2- Inserir novo Humano");
			Console.WriteLine("3- Atualizar Humano");
			Console.WriteLine("4- Humano morreu");
			Console.WriteLine("5- Visualizar Humano");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
        
    }
    
}