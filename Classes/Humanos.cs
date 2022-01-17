namespace DIO.Humanos 
{
    public class Humano:EntidadesBase{

         // Atributos
		private string Nome { get; set; }
		private double Massa { get; set; }
        private Sexo Sexo{get; set;}
		private int Idade { get; set; }
        private bool Excluido {get; set;}

        // Métodos
		public Humano(int id, string nome, double massa, Sexo sexo, int idade)
		{
			this.Id = id;
            this.Nome = nome;
			this.Sexo = sexo;
			this.Massa = massa;
			this.Idade = idade;
            this.Excluido = false;
		}
        public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "Massa Corpórea: " + this.Massa + Environment.NewLine;
            retorno += "Sexo Biológico: " + this.Sexo + Environment.NewLine;
            retorno += "Idade: " + this.Idade + Environment.NewLine;
            retorno += "Morreu: " + this.Excluido;
			return retorno;
		}
        
        public string retornaNome()
		{
			return this.Nome;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    }


        
    
}