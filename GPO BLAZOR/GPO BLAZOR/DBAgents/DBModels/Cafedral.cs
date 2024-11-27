using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBAgent.Models;

/// <summary>
/// Кафедра
/// </summary>
[Table("Кафедра")]
public partial class Cafedral
{
    public int Id { get; set; }
    /// <summary>
    /// Название полное
    /// </summary>
    [Column("НазваниеПолное")]
    public string FullName { get; set; } = null!;
    /// <summary>
    /// Название краткое
    /// </summary>
    [Column("НазваниеКраткое")]
    public string EncriptedName { get; set; } = null!;
    /// <summary>
    /// Заведующий
    /// </summary>
    [Column("Заведующий")]
    public int Leader { get; set; }

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual User LeaderNavigation { get; set; } = null!;
}
