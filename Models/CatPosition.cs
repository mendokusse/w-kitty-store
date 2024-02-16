namespace kitties.Models;

public class CatPosition
{
    public int Id { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime DateModified { get; set; }
    public decimal Price { get; set; }
    public int CatId { get; set; }
}