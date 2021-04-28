using Internship.DAL.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace Internship.DAL.Context
{
    public class InternshipDbContext : IdentityDbContext<User, Role, Guid>
    {
    }
}
