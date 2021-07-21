using DIO.Series.Enums;
using System;
using System.Text;

namespace DIO.Series.Classes
{
    public class Serie : Entity
    {
        public Serie(Genero genero, string titulo, string descricao, int ano)
        {
            Id = Guid.NewGuid();
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excluido = false;
        }

        public Genero Genero { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Ano { get; set; }
        public bool Excluido { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Genero: {Genero}");
            sb.AppendLine($"Titulo: {Titulo}");
            sb.AppendLine($"Descricao: {Descricao}");
            sb.AppendLine($"Ano de Inicio: {Ano}");
            sb.AppendLine($"Excluido: {Excluido}");

            return sb.ToString();
        }

        public string RetornaTitulo()
        {
            return Titulo;
        }

        public Guid RetornaId()
        {
            return Id;
        }

        public void Exclui()
        {
            Excluido = true;
        }
    }
}
