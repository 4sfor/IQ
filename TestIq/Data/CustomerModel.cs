using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TestIq.Data;

public class CustomerModel
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
    [Required]
    [RegularExpression(@"^[а-яА-ЯёЁ]+$", ErrorMessage = "Только кириллица")]
    [StringLength(20, MinimumLength = 2)]
    public string Name { get; set; } = "";
    [Required]
    [RegularExpression(@"^[а-яА-ЯёЁ]+$", ErrorMessage = "Только кириллица")]
    [StringLength(20, MinimumLength = 2)]
    public string LastName { get; set; } = "";
    [Required]
    [RegularExpression(@"^[а-яА-ЯёЁ]+$", ErrorMessage = "Только кириллица")]
    [StringLength(25, MinimumLength = 3)]
    public string Country { get; set; } = "";
    [Required]
    [RegularExpression(@"^[а-яА-ЯёЁ]+$", ErrorMessage = "Только кириллица")]
    [StringLength(25, MinimumLength = 3)]
    public string City { get; set; } = "";
    
}