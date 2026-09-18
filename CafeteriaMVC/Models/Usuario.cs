using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CafeteriaMVC.Models;

[Index("Email", Name = "UQ__Usuario__A9D10534C7A82BC2", IsUnique = true)]
public partial class Usuario
{
    [Key]
    public int UsuarioID { get; set; }

    [StringLength(99)]
    public string NomeUsuario { get; set; } = null!;

    [StringLength(99)]
    public string Email { get; set; } = null!;

    [MaxLength(32)]
    public byte[] Senha { get; set; } = null!;

    [InverseProperty("Usuario")]
    public virtual ICollection<Inter_ItemUsuario> Inter_ItemUsuario { get; set; } = new List<Inter_ItemUsuario>();
}
