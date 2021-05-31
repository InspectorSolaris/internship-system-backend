using Internship.DAL.Models;
using Internship.DAL.Models.Data;
using Internship.DAL.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Internship.DAL.Context
{
    public class InternshipDbContext : IdentityDbContext<User, Role, Guid>
    {
        public InternshipDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<HITsWorker> HITsWorkers { get; set; }

        public DbSet<File> Files { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Interview> Interviews { get; set; }

        public DbSet<InternshipAssessment> InternshipAssessments { get; set; }

        public DbSet<PriorityStudent> PriorityStudents { get; set; }

        public DbSet<PriorityCompany> PriorityCompanies { get; set; }

        public DbSet<Specialization> Specializations { get; set; }

        public DbSet<Technology> Technologies { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<SubjectInstance> SubjectInstances { get; set; }

        public DbSet<SubjectAssessment> SubjectAssessments { get; set; }

        public DbSet<Document> Documents { get; set; }
    }
}
