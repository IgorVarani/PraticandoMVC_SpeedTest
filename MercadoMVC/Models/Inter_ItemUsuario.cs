using System;
using System.Collections.Generic;

namespace MVC_Mercado.Models;

public partial class Inter_ItemUsuario
{
    public int Inter_ItemUsuarioID { get; set; }

    public int ItemID { get; set; }

    public int UsuarioID { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
