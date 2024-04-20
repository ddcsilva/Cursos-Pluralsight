namespace BethanysPieShop.Models;

/*
    O operador ? é usado para declarar um tipo como nullable, ou seja, ele pode ser nulo.
    A propriedade CategoriaNome está sendo inicializada com uma string vazia.
    A propriedade Tortas é uma coleção de tortas, que é usada para navegar de uma categoria para várias tortas.
*/

public class Categoria
{
    public int CategoriaId { get; set; }
    public string CategoriaNome { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public List<Torta>? Tortas { get; set; }
}
