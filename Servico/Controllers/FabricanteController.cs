using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Servico.Controllers
{
    public class FabricanteController : ApiController
    {
        public IEnumerable<Models.Fabricante> Get()
        {
            Models.LojaDataContext dc = new Models.LojaDataContext();
            var r1 = from r in dc.Fabricantes orderby r.Descricao select r;
            return r1.ToList();
        }


        public void Post([FromBody] string value)
        {
            List<Models.Fabricante> r = JsonConvert.DeserializeObject<List<Models.Fabricante>>(value);
            Models.LojaDataContext dc = new Models.LojaDataContext();
            dc.Fabricantes.InsertAllOnSubmit(r);
            dc.SubmitChanges();
        }


    }
}
