using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/gt")]
public class GtController : Controller {
    [HttpGet("casas-venta-metros-terreno")]
    public IActionResult CasasEnVentaConMasDeXMetrosTerreno(int metrosConstruccion){
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");
        
        // Obtener todas las casas en venta con más de 500 metros de construcción
        var filtroCasas = Builders<Inmueble>.Filter.Eq(x => x.Tipo, "Casa");
        var filtroVenta = Builders<Inmueble>.Filter.Eq(x => x.Operacion, "Venta");
        var filtroMetros = Builders<Inmueble>.Filter.Gt(x => x.MetrosConstruccion, metrosConstruccion);

        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtroCasas, filtroVenta, filtroMetros);
        var list = collection.Find(filtroCompuesto).ToList();

        return Ok(list);
    }
}