﻿namespace TimelineManagement.DTOs.Account;

public class NewAccountDto
{
    public Guid Guid { get; set; }
    public string Password { get; set; }
    public int Otp { get; set; }
    public bool IsUsed { get; set; }
    public DateTime ExpiredDate { get; set; }
    
    public static implicit operator Models.Account(NewAccountDto newAccountDto)
    {
        return new Models.Account
        {
            Guid = newAccountDto.Guid,
            Password = newAccountDto.Password,
            Otp = newAccountDto.Otp,
            IsUsed = newAccountDto.IsUsed,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now,
            ExpiredDate = newAccountDto.ExpiredDate
        };
    }

    public static explicit operator NewAccountDto(Models.Account account)
    {
        return new NewAccountDto
        {
            Guid = account.Guid,
            Password = account.Password,
            Otp = account.Otp,
            IsUsed = account.IsUsed,
            ExpiredDate = account.ExpiredDate
        };
    }
}