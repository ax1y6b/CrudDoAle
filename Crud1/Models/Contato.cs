using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using Crud1.Infra;

namespace Crud1.Models
{
    public class Contato
    {
        private SqlConnection connection;

        public List<ContatoModel> ListaContatos(ContatoModel model)
        {
            List<ContatoModel> lista = new List<ContatoModel>();

            DataSet ds = Database.ExecutarComandoSql("SELECT * FROM Contato");

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ContatoModel contatoModel = new ContatoModel();
                    contatoModel.IdContato = Convert.ToInt32(row["IdContato"]);
                    contatoModel.Nome = row["Nome"].ToString();
                    contatoModel.Email = row["Email"].ToString();
                    lista.Add(contatoModel);
                }
            }

            return lista;
        }

        public ContatoModel ConsultaContato(int IdContato)
        {
            ContatoModel contatoModel = new ContatoModel();
            DataSet ds = Database.ExecutarComandoSql("SELECT * FROM Contato WHERE IdContato = " + IdContato);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    contatoModel.IdContato = Convert.ToInt32(row["IdContato"]);
                    contatoModel.Nome = row["Nome"].ToString();
                    contatoModel.Email = row["Email"].ToString();
                }
            }

            return contatoModel;
        }

        public ContatoModel AdicionaContato(ContatoModel contatoModel)
        {
            DataSet ds = Database.ExecutarComandoSql("INSERT INTO Contato VALUES('" + contatoModel.Nome + "','" + contatoModel.Email + "')");
            return contatoModel;
        }

        public void AtualizaContato(ContatoModel contatoModel)
        {
            DataSet ds = Database.ExecutarComandoSql("UPDATE Contato SET Nome = '" + contatoModel.Nome + "', Email = '" + contatoModel.Email + "' WHERE IdContato = " + contatoModel.IdContato);
            return;
        }

        public void DeletaContato(ContatoModel model)
        {
            DataSet ds = Database.ExecutarComandoSql("DELETE FROM Contato WHERE IdContato = " + model.IdContato.ToString());
        }

    }
}
