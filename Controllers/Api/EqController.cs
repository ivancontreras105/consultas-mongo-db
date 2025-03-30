using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/eq")]
public class EqController : Controller {
    [HttpGet("listar-agencias")]
    public IActionResult ListarAgencias(string agencia, string? agente){
        // Listar todos los registros de la agencia Torres Realty

        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        // Que la agencia sea Torres Realty
        var filtroAgencia = Builders<Inmueble>.Filter.Eq(x => x.Agencia, agencia);

        if(!string.IsNullOrWhiteSpace(agente)){
            var filtroAgente = Builders<Inmueble>.Filter.Eq(x => x.NombreAgente, agente);
            var filtroCompuesto = Builders<Inmueble>.Filter.And(filtroAgencia, filtroAgente);

            var lista = collection.Find(filtroCompuesto).ToList();
            return Ok(lista);
        }
        else {
            var lista = collection.Find(filtroAgencia).ToList();
            return Ok(lista);
        }
    }
}