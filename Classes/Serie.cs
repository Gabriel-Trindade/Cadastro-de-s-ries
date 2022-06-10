namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        private Genero Genero {get; set;}
        private string titulo {get; set;}
        private string descricao {get; set;}
        private int ano {get; set;}

        private bool Excluido {get; set;}

        public Serie(int id, Genero genero, string titulo, string descricao, int ano){

            this.id = id;
            this.Genero = genero;
            this.titulo = titulo;
            this.descricao = descricao;
            this.ano = ano;
            this.Excluido = false;

        }

        public override string ToString(){
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.titulo + Environment.NewLine;
            retorno += "Descrição: " + this.descricao + Environment.NewLine;
            retorno += "Ano: " + this.ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
            
        }

        public string retornaTitulo(){
            return this.titulo;
        }

        public int retornaId(){
            return this.id;
        }

        public void Exclui(){
            this.Excluido = true;
        }

        public bool retornaExcluido(){
            return this.Excluido;
        }

        
    }
}