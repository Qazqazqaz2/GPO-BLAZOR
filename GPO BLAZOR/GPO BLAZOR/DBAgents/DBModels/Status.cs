using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBAgent.Models;

/// <summary>
/// Статус
/// </summary>
[Table("Статус")]
public partial class Status
{
    public int Id { get; set; }

    /// <summary>
    /// Статус1
    /// </summary>
    [Column("Статус1")]
    public string StatusName { get; set; } = null!;

    public virtual ICollection<AskForm> AskForms { get; set; } = new List<AskForm>();
}
