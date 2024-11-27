using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBAgent.Models;

/// <summary>
/// Пользователь
/// </summary>
[Table("Пользователь")]
public partial class User
{
    public int Id { get; set; }

    /// <summary>
    /// Email
    /// </summary>
    [Column("Email")]
    public string Email { get; set; } = null!;

    /// <summary>
    /// Пароль
    /// </summary>
    [Column("Пароль")]
    public string Password { get; set; } = null!;

    /// <summary>
    /// Фамилия
    /// </summary>
    [Column("Фамилия")]
    public string LastName { get; set; } = null!;

    /// <summary>
    /// Имя
    /// </summary>
    [Column("Имя")]
    public string FirstName { get; set; } = null!;

    /// <summary>
    /// Отчество
    /// </summary>
    [Column("Отчество")]
    public string? MiddleName { get; set; }

    public virtual ICollection<AskForm> ResposebleAskFormNavigations { get; set; } = new List<AskForm>();

    public virtual ICollection<AskForm> ConsultantLeaderAskFormNavigations { get; set; } = new List<AskForm>();

    public virtual ICollection<AskForm> PracticeLeaderAskFormNavigations { get; set; } = new List<AskForm>();

    public virtual ICollection<AskForm> StudentAskFormNavigations { get; set; } = new List<AskForm>();

    public virtual ICollection<Cafedral> Cafedrals { get; set; } = new List<Cafedral>();

    public virtual ICollection<Direction> Directions { get; set; } = new List<Direction>();

    public virtual Student? Student { get; set; }

    public virtual ICollection<Organization> Organizations { get; set; } = new List<Organization>();

    public virtual ICollection<Role> Рольs { get; set; } = new List<Role>();
}
