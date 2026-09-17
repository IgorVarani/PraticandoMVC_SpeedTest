using System;
using System.Collections.Generic;

namespace MVC_Mercado.Models;

public partial class Item
{
    public int ItemID { get; set; }

    public string NomeItem { get; set; } = null!;

    public virtual ICollection<Inter_ItemUsuario> Inter_ItemUsuario { get; set; } = new List<Inter_ItemUsuario>();
}
