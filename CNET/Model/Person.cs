﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Index(nameof(Email))]
    public class Person
    {
        #region konstruktory

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Person()
        {

        }
        #endregion

        #region vlastnosti
        public int Id { get; set; }
        [MaxLength(250)]
        public string FirstName { get; set; } = "John";

        [MaxLength(250)]
        public string LastName { get; set; } = "Doe";

        public string FullName
        {
            get
            {
                return GetFullName();
            }
        }

        public DateTime DateOfBirth { get; set; }

        [NotMapped] //neuklada do databaze
        public DateOnly DateOfBirthDateOnly
        {
            get { return DateOnly.FromDateTime(DateOfBirth); }
            set { DateOfBirth = value.ToDateTime(new TimeOnly(0)); }
        }
        public Address HomeAddress { get; set; } = new Address();
        
        [MaxLength(250)]
        public string Email { get; set; }

        public List<Contract> Contracts { get; set; }
                                    = new List<Contract>();
        #endregion

        #region metody
        public override string ToString()
            => $"{FirstName} {LastName}";


        public int Age()
        {
            DateTime today = DateTime.Today;

            int age = today.Year - DateOfBirth.Year;

            if (today.Month < DateOfBirth.Month ||
           ((today.Month == DateOfBirth.Month) && (today.Day < DateOfBirth.Day)))
            {
                age--;  //birthday in current year not yet reached, we are 1 year younger ;)
            }

            return age;
        }

        public string GetFullName()
            => $"{FirstName} {LastName}";

        #endregion

    }
}
