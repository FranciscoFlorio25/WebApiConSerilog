﻿namespace MyApp.Domian.Entities
{
    public class Product
    {
        public Product(string name, string? description, DateTime creationDate, bool isActive)
        {
            Name = name;
            Description = description;
            CreationDate = creationDate;
            IsActive = isActive;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
    }
}
