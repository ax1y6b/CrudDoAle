using Crud1.Models;
using System.Web.Mvc;

namespace Crud1.Controllers
{
    public class ContatoController : Controller
    {
        // GET: Contato

        public ActionResult Index(ContatoModel _contatoModel)
        {
            Contato _contato = new Contato();
            var lista = _contato.ListaContatos(_contatoModel);
            return View(lista);
        }

        public ActionResult AtualizaContato(int idContato)
        {
            Contato _contato = new Contato();
            var retorno = _contato.ConsultaContato(idContato);
            return View(retorno);
        }

        [HttpPost]
        public ActionResult AtualizaContato(ContatoModel _contatoModel)
        {
            Contato _contato = new Contato();
            _contato.AtualizaContato(_contatoModel);
            return base.RedirectToAction("Index", "Contato");
        }

        public ActionResult AdicionaContato()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionaContato(ContatoModel _contatoModel)
        {
            Contato _contato = new Contato();
            var novoContato = _contato.AdicionaContato(_contatoModel);
            return base.RedirectToAction("Index", "Contato");
        }

        [HttpDelete]
        public ActionResult DeletaContato(ContatoModel _contatoModel)
        {
            Contato _contato = new Contato();
            _contato.DeletaContato(_contatoModel);
            return new HttpStatusCodeResult(200);
        }
    }
}