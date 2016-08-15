using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi_Parte_1.Connect;
using WebApi_Parte_1.Models;

namespace WebApi_Parte_1.Controllers
{
    public class DisciplinasController : ApiController
    {
        private MinhaConexao db = new MinhaConexao();

        // GET: api/Disciplinas
        public IQueryable<Disciplinas> GetDisciplinas()
        {
            return db.Disciplinas;
        }

        //[Route("api/Disciplinas/byNome/{nome}")]
        //public IQueryable<Disciplinas> GetDisciplinas(string nome)
        //{
        //    return db.Disciplinas.Where(e => e.NomeDisc.Contains(nome));
        //}

        [Route("api/Disciplinas/Nome/{nome}")]
        public IHttpActionResult GetDisciplinas(string nome)
        {
            StringBuilder str = new StringBuilder();
            str.Append(@"SELECT IdDisc, NomeDisc FROM Disciplinas WHERE NomeDisc LIKE @nome ");

            IDataParameter parameter = new SqlParameter();
            parameter.DbType = DbType.String;
            parameter.ParameterName = "@nome";
            parameter.Value = '%' + nome + '%';

            var resultado = db.Database.SqlQuery<Disciplinas>(str.ToString(), parameter).ToList();

            if (resultado == null)
                return NotFound();

            return Ok(resultado);
        }


        // GET: api/Disciplinas/5
        [ResponseType(typeof(Disciplinas))]
        public IHttpActionResult GetDisciplinas(long id)
        {
            Disciplinas disciplinas = db.Disciplinas.Find(id);
            if (disciplinas == null)
            {
                return NotFound();
            }

            return Ok(disciplinas);
        }

        // PUT: api/Disciplinas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDisciplinas(long id, Disciplinas disciplinas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != disciplinas.IdDisc)
            {
                return BadRequest();
            }

            db.Entry(disciplinas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisciplinasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Disciplinas
        [ResponseType(typeof(Disciplinas))]
        public IHttpActionResult PostDisciplinas(Disciplinas disciplinas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Disciplinas.Add(disciplinas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = disciplinas.IdDisc }, disciplinas);
        }

        // DELETE: api/Disciplinas/5
        [ResponseType(typeof(Disciplinas))]
        public IHttpActionResult DeleteDisciplinas(long id)
        {
            Disciplinas disciplinas = db.Disciplinas.Find(id);
            if (disciplinas == null)
            {
                return NotFound();
            }

            db.Disciplinas.Remove(disciplinas);
            db.SaveChanges();

            return Ok(disciplinas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DisciplinasExists(long id)
        {
            return db.Disciplinas.Count(e => e.IdDisc == id) > 0;
        }
    }
}