using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Servico.Controllers
{
    public class VeiculoController : ApiController
    {

        public IEnumerable<Models.Veiculo> Get()
        {
            Models.LojaDataContext dc = new Models.LojaDataContext();
            var r1 = from r in dc.Veiculos orderby r.Modelo select r;
            return r1.ToList();
        }



        //O bom e velho update
        public void Put(int id, [FromBody] string value)
        {
            Models.Veiculo x = JsonConvert.DeserializeObject<Models.Veiculo>(value);
            Models.LojaDataContext dc = new Models.LojaDataContext();
            Models.Veiculo rest = (from f in dc.Veiculos where f.Id == x.Id select f).Single();
            rest.Vendido = x.Vendido;
            dc.SubmitChanges();
        }

        public void Post([FromBody] string value)
        {
            List<Models.Veiculo> r = JsonConvert.DeserializeObject<List<Models.Veiculo>>(value);
            Models.LojaDataContext dc = new Models.LojaDataContext();
            dc.Veiculos.InsertAllOnSubmit(r);
            dc.SubmitChanges();
        }
    }
}
