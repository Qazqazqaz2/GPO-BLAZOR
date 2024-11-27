using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBAgent.Models;

/// <summary>
/// Группы
/// </summary>
[Table("Группы")]
public partial class Group
{
    /// <summary>
    /// Группа
    /// </summary>
    [Column("Группа")]
    public string Groups { get; set; } = null!;

    /// <summary>
    /// Направление
    /// </summary>
    [Column("Направление")]
    public int Direction { get; set; }

    /// <summary>
    /// Кафедра
    /// </summary>
    [Column("Кафедра")]
    public int Cafedral { get; set; }

    /// <summary>
    /// Курс
    /// </summary>
    [Column("Курс")]
    public int Cours { get; set; }

    /// <summary>
    /// Год поступления
    /// </summary>
    [Column("ГодПоступления")]
    public string Year { get; set; } = null!;

    public virtual ICollection<AskForm> AskFroms { get; set; } = new List<AskForm>();

    public virtual Cafedral CafedralNavigation { get; set; } = null!;

    public virtual Direction DirectionNavigation { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
