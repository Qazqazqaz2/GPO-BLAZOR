using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBAgent.Models;

/// <summary>
/// Студент
/// </summary>
[Table("Студент")]
public partial class Student
{
    /// <summary>
    /// Пользователь
    /// </summary>
    [Column("Пользователь")]
    public int User { get; set; }

    /// <summary>
    /// Группа
    /// </summary>
    [Column("Группа")]
    public string Group { get; set; } = null!;

    public virtual Group GroupNavigation { get; set; } = null!;

    public virtual User UserNavigation { get; set; } = null!;
}
