using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaMVC.Models;

public partial class Inter_ItemUsuario
{
    [Key]
    public int Inter_ItemUsuarioID { get; set; }

    public int ItemID { get; set; }

    public int UsuarioID { get; set; }

    [ForeignKey("ItemID")]
    [InverseProperty("Inter_ItemUsuario")]
    public virtual Item Item { get; set; } = null!;

    [ForeignKey("UsuarioID")]
    [InverseProperty("Inter_ItemUsuario")]
    public virtual Usuario Usuario { get; set; } = null!;
}
