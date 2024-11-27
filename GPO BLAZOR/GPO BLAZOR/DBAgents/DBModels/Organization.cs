using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBAgent.Models;

/// <summary>
/// Организация
/// </summary>
[Table("Организация")]
public partial class Organization
{
    public int Id { get; set; }

    /// <summary>
    /// Название
    /// </summary>
    [Column("Название")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Адрес
    /// </summary>
    [Column("Адрес")]
    public string Adress { get; set; } = null!;

    /// <summary>
    /// Руководитель организации
    /// </summary>
    [Column("РуководительОрганизации")]
    public string FactoryLeader { get; set; } = null!;

    /// <summary>
    /// Документ
    /// </summary>
    [Column("Документ")]
    public string Document { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
