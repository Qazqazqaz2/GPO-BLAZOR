using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBAgent.Models;

/// <summary>
/// Вид и тип практики
/// </summary>
[Table("ВидИТипПрактики")]
public partial class PracticeType
{
    public int Id { get; set; }

    /// <summary>
    /// Название
    /// </summary>
    [Column("Название")]
    public string Name { get; set; } = null!;

    public virtual ICollection<AskForm> AskForms { get; set; } = new List<AskForm>();
}
