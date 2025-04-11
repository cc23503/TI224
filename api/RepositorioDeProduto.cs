// Estrutura de Armazenamento (substituindo database)
public static class RepositorioDeProduto
{
    public static List<Produto>? Produtos { get; set; } // Sendo estatico temos o acesso direto por 'RepositorioDeProduto'

    public static void Adicionar(Produto prod)
    {
        if (Produtos == null)
        {
            Produtos = new List<Produto>();
        }
        Produtos.Add(prod); // Uso do método 'Add' para adicionar 
    }

    public static Produto? PegarPorCodigo(string cod)
    {
        if (Produtos != null)
        {
            return Produtos.FirstOrDefault(p => p.Codigo == cod); // com o método 'FirstOrDefault' fazemos uma busca na list de tipo 'Produto'
        }
        return null;
    }

    public static void Remover(Produto prod)
    {
        if (Produtos != null)
        {
            Produtos.Remove(prod);
        }
    }
}