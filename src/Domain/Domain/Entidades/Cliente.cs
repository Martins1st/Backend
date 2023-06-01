namespace Domain.Entidades
{
    public class Cliente : CommonEntity
    {
        public string Nome { get; set; }
        public double OrcamentoInicial { get; set; }

    }
}


//Crie uma aplicação Web que forneça um cadastro de clientes com os campos: Id, Nome, DataCriacao e OrcamentoInicial.
//O Cadastro deve ter as opções de incluir, pesquisar, alterar e excluir. 
//Crie um botão para cada função acima.
//A aplicação deve utilizar um banco de dados para armazenar o cadastro (MySql, SQL Server, SQLite)