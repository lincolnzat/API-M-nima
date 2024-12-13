namespace ApiLegal.DB;

public record Livro {
    public int Id { get; set; }
    public string ? Name { get; set; }

}

public class LivrosDB {

    private static List<Livro> _livros = new List<Livro>()
    {
        new Livro {Id=1, Name="Viagem ao Centro da Terra"},
        new Livro {Id=2, Name="Algoritmos e Lógica de Programação 1"},
        new Livro {Id=3, Name="Slam Dunk Vol. 30"}
    };

    public static List<Livro> GetLivros() {
        return _livros;
    }
    public static Livro ? GetLivro(int id) {
        return _livros.SingleOrDefault(livro => livro.Id == id);
    }

    public static Livro CreateLivro(Livro livro) 
    {
        _livros.Add(livro);
        return livro;
    }

    public static Livro UpdateLivro(Livro update)
    {
        _livros = _livros.Select(livro =>
        {
            if(livro.Id == update.Id)
            {
                livro.Name = update.Name;
            }
            return livro;
        }).ToList();
        return update;
    }

    public static void RemoveLivro(int id) 
    {
        _livros = _livros.FindAll(livro => livro.Id != id).ToList();
    }
}