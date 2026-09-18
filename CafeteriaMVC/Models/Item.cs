using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaMVC.Models;

public partial class Item
{
    [Key]
    public int ItemID { get; set; }

    [StringLength(99)]
    public string NomeItem { get; set; } = null!;

    [InverseProperty("Item")]
    public virtual ICollection<Inter_ItemUsuario> Inter_ItemUsuario { get; set; } = new List<Inter_ItemUsuario>();
}
