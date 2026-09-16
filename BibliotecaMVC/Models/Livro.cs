using System;
using System.Collections.Generic;

namespace BibliotecaMVC.Models;

public partial class Livro
{
    public int LivroID { get; set; }

    public string NomeLivro { get; set; } = null!;

    public virtual ICollection<Inter_LivroUsuario> Inter_LivroUsuarios { get; set; } = new List<Inter_LivroUsuario>();
}
