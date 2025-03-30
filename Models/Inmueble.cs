using MongoDB.Bson.Serialization.Attributes;

public class Inmueble {
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("tipo")]
    public string Tipo { get; set; } = string.Empty;
    [BsonElement("operacion")]
    public string Operacion { get; set; } = string.Empty;
    [BsonElement("nombre_agente")]
    public string NombreAgente { get; set; } = string.Empty;
    [BsonElement("baños")]
    public int Banios { get; set; }
    [BsonElement("metros_terreno")]
    public int MetrosTerreno { get; set; }
    [BsonElement("metros_construccion")]
    public int MetrosConstruccion { get; set; }
    [BsonElement("tiene_patio")]
    public bool TienePatio { get; set; }
    [BsonElement("pisos")]
    public int Pisos { get; set; }
    [BsonElement("agencia")]
    public string Agencia { get; set; } = string.Empty; 
    [BsonElement("fecha_publicacion")]
    public string FechaPublicacion { get; set; } = string.Empty;  
    [BsonElement("costo")]
    public int Costo { get; set; }
}