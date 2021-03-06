﻿using System.Collections.Generic;
using Todo.Domain.TodoContext.Entities;
using Todo.Domain.UserContext.Entities.Enums;
using Todo.Shared.Entities;
using Todo.Shared.Util;
using Todo.Shared.ValuesObjects;

namespace Todo.Domain.UserContext.Entities
{
    public class User : Entity
    {
        public Email Email { get; private set; }
        public string Password { get; private set; }
        public ERole Role { get; private set; }
        public ICollection<TodoItem> TodoItems { get; set; }

        public User()
        {
        }

        public User(Email email, string password, ERole role)
        {
            Email = email;
            Password = password;
            Role = role;
        }
        
        
        public void ChooseRole(ERole role)
        {
            Role = role;
        }
        
        public void EncryptPassword()
        {
            Password = PasswordUtil.Hash(Password);
        }
    }
}