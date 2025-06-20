﻿using Core.Enums;
using Core.ValidateAttribute;
using Core.ValidateAttribute.Date;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Core.Model.DTO.User;

public class UserUpdateRequest
{
    [StringLengthIfNotNull(100)]
    [FullNameValidation]
    public string? FullName { get; set; } = null;
    
    [EmailAddress(ErrorMessage = "Invalid email format")]
    [StringLengthIfNotNull(100)]
    public string? Email { get; set; } = null;
    
    [RegularExpression(@"^\+?[0-9]{10,15}$", ErrorMessage = "Phone number must be in a valid format.")]
    [StringLengthIfNotNull(15)]
    public string? Phone { get; set; } = null;
    [EnumDataType(typeof(UserRoles))]
    public UserRoles? Role { get; set; } = null;

    [DataType(DataType.Date)]
    [MaxAge(100, ErrorMessage = "Возраст не должен превышать 100 лет")]
    [MinAge(18, ErrorMessage = "Возраст не должен быть меньше 18 лет")]
    public DateTime? BirthDate { get; set; } = null;

}
