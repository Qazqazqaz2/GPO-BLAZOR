using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBAgent.Models;

/// <summary>
/// Анкета
/// </summary>
[Table("Анкета")]
public partial class AskForm
{
    public int Id { get; set; }

    /// <summary>
    /// Имя студента
    /// </summary>
    [Column("Студент")]
    public int Student { get; set; }

    /// <summary>
    /// Группа
    /// </summary>
    [Column("Группа")]
    public string Group { get; set; } = null!;

    /// <summary>
    /// Вид и тип практики
    /// </summary>
    [Column("ВидИТипПрактики")]
    public int PracticeType { get; set; }

    /// <summary>
    /// Договор: номер
    /// </summary>
    [Column("Договор")]
    public int Contract { get; set; }

    /// <summary>
    /// Руководитель - консультант
    /// </summary>
    [Column("РуководительКонсультант")]
    public int ConsultantLeader { get; set; }

    /// <summary>
    /// Руководитель практики
    /// </summary>
    [Column("РуководительПрактики")]
    public int PracticeLeader { get; set; }

    /// <summary>
    /// Ответственные за заполнение
    /// </summary>
    [Column("ОтветственныеЗаЗаполнение")]
    public int AskFormResposeble { get; set; }

    /// <summary>
    /// Статус
    /// </summary>
    [Column("Статус")]
    public int Status { get; set; }

    /// <summary>
    /// Комментарий
    /// </summary>
    [Column("Комментарий")]
    public string? Commentary { get; set; }

    public virtual PracticeType PracticeTypeNavigation { get; set; } = null!;

    public virtual Group GroupNavigation { get; set; } = null!;

    public virtual Contract ContractNavigation { get; set; } = null!;

    public virtual User AskFormResposebleNavigation { get; set; } = null!;

    public virtual User ConsultantLeaderNavigation { get; set; } = null!;

    public virtual User PracticeLeaderNavigation { get; set; } = null!;

    public virtual Status StatusNavigation { get; set; } = null!;

    public virtual User StudentNavigation { get; set; } = null!;
}
