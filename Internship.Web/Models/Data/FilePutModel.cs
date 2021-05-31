using Microsoft.AspNetCore.Http;
using System;

namespace Internship.Web.Models.Data
{
    public class FilePutModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
    }
}
