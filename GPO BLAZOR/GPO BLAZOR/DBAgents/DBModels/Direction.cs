using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBAgent.Models;

/// <summary>
/// Направление
/// </summary>
[Table("Направление")]
public partial class Direction
{
    /// <summary>
    /// Код
    /// </summary>
    [Column("Код")]
    public int Code { get; set; }
    /// <summary>
    /// Название
    /// </summary>
    [Column("Название")]
    public string Name { get; set; } = null!;
    /// <summary>
    /// Профиль
    /// </summary>
    [Column("Профиль")]
    public string Profile { get; set; } = null!;
    /// <summary>
    /// Руководитель
    /// </summary>
    [Column("Руководитель")]
    public int LeaderName { get; set; }

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual User LeaderNavigation { get; set; } = null!;
}
