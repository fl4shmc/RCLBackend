﻿namespace RCLBackend.DTO
{
    public class UserRegisterDTO
    {
        public string UserId { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }

    }
}
