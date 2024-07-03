using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace secDockerApp.Models
{
    [Table("Student")]
public class Student
{
    [Key]
public int ID { get; set; }
public string? LastName { get; set; }
public string? FirstMidName { get; set; }
public DateTime EnrollmentDate { get; set; }
}
}