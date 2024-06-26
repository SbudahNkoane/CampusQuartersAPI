﻿using CampusQuartersAPI.Models;

namespace CampusQuartersAPI
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public int CellNumber { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }

    }
}
