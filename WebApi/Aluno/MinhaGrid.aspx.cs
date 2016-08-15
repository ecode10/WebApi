using Aluno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aluno
{
    public partial class MinhaGrid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //insert
            insert();

            //pega todo
            getAll();            
        }

        private void insert()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:1299");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var disciplinas = new Disciplina() { descricaoDisc = "Banco de dados V" };
            
            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/Disciplina").Result;
            response = client.PostAsJsonAsync("api/Disciplina", disciplinas).Result;

            if (response.IsSuccessStatusCode)
            {
                Uri disciplinaUri = response.Headers.Location;
                //Response.Redirect(disciplinaUri.ToString());
            }
            else
            {
                Response.Write(response.StatusCode.ToString() + " - " + response.ReasonPhrase.ToString());
            }
        }

        private void getAll()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:1299");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            Uri disciplinasURI;

            System.Net.Http.HttpResponseMessage response = client.GetAsync("api/Disciplina").Result;
            disciplinasURI = response.Headers.Location;

            if (response.IsSuccessStatusCode)
            {
                //var disciplinas = response.Content.ReadAsAsync<IEnumerable<Disciplina>>().Result;
                var disciplinas = response.Content.ReadAsAsync<IEnumerable<Object>>().Result;
                gridDisciplinas.DataSource = disciplinas;
                gridDisciplinas.DataBind();
            }
            else
                Response.Write(response.StatusCode.ToString() + " - " + response.ReasonPhrase);
        }
    }
}