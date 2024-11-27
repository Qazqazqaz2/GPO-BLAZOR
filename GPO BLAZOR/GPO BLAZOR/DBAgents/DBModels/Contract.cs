using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBAgent.Models;

/// <summary>
/// Договор
/// </summary>
[Table("Договор")]
public partial class Contract
{
    public int Id { get; set; }

    /// <summary>
    /// Номер договора о практике
    /// </summary>
    [Column("НомерДоговораОПрактике")]
    public string Number { get; set; } = null!;

    /// <summary>
    /// Дата начала практики
    /// </summary>
    [Column("ДатаНачалаПрактики")]
    public DateOnly DateStart { get; set; }

    /// <summary>
    /// Дата окончания практики
    /// </summary>
    [Column("ДатаОкончанияПрактики")]
    public DateOnly DateEnd { get; set; }

    /// <summary>
    /// Организация
    /// </summary>
    [Column("Организация")]
    public int Organisation { get; set; }

    /// <summary>
    /// Помещение
    /// </summary>
    [Column("Помещение")]
    public string Room { get; set; } = null!;

    /// <summary>
    /// Материально техническое обеспече
    /// </summary>
    [Column("МатериальноТехническоеОбеспече")]
    public string Equipment { get; set; } = null!;


    public virtual ICollection<AskForm> AskForms { get; set; } = new List<AskForm>();

    public virtual Organization OrganizationNavigation { get; set; } = null!;
}
