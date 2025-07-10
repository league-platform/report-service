using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

public class Report
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
