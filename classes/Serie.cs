namespace App.Series
{
    public class Serie : EntidadeBase
    {
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.id = id;
            this.genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.ano = ano;

        }
        private Genero genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int ano { get; set; }
    }

}