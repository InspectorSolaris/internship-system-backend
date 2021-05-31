using Internship.BL.Interfaces.Common;
using Internship.BL.Interfaces.Data;
using Internship.BL.Interfaces.Identity;
using Internship.BL.Services;
using Internship.BL.Services.Data;
using Internship.BL.Services.Identity;
using Internship.Common.Dtos;
using Internship.Common.Dtos.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Internship.Web.Configuration
{
    public static class ConfigurationBL
    {
        public static void ConfigureBL(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IUserService<StudentDto>, StudentService>();
            serviceCollection.AddScoped<IUserService<HITsWorkerDto>, HITsWorkerService>();
            serviceCollection.AddScoped<IUserService<CompanyDto>, CompanyService>();
            serviceCollection.AddScoped<IFileService, FileService>();

            serviceCollection.AddScoped<IEntityService<DocumentDto>, DocumentService>();
            serviceCollection.AddScoped<IEntityService<InternshipAssessmentDto>, InternshipAssessmentService>();
            serviceCollection.AddScoped<IEntityService<InterviewDto>, InterviewService>();
            serviceCollection.AddScoped<IEntityService<PositionDto>, PositionService>();
            serviceCollection.AddScoped<IEntityService<PriorityCompanyDto>, PriorityCompanyService>();
            serviceCollection.AddScoped<IEntityService<PriorityStudentDto>, PriorityStudentService>();
            serviceCollection.AddScoped<IEntityService<SpecializationDto>, SpecializationService>();
            serviceCollection.AddScoped<IEntityService<SubjectAssessmentDto>, SubjectAssessmentService>();
            serviceCollection.AddScoped<IEntityService<SubjectInstanceDto>, SubjectInstanceService>();
            serviceCollection.AddScoped<IEntityService<SubjectDto>, SubjectService>();
            serviceCollection.AddScoped<IEntityService<TechnologyDto>, TechnologyService>();
        }
    }
}
