using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBAgent.Models;

/// <summary>
/// Роль
/// </summary>
[Table("Роль")]
public partial class Role
{
    public int Id { get; set; }

    /// <summary>
    /// Название
    /// </summary>
    [Column("Название")]
    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
