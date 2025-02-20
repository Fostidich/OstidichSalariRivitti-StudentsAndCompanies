using System.Collections.Generic;

public interface IInternshipService
{
    List<Internship> GetInternshipForStudent(int studentId);
    List<Internship> GetInternshipFromAdvertisement(int advertisementId, int companyId);
    bool CreateStudentFeedback(int internshipId, DTO.Feedback feedback, int studentId);
    bool CreateCompanyFeedback(int internshipId, DTO.Feedback feedback, int companyId);
    DTO.Feedback GetStudentFeedback(int internshipId, int userId, string role);
    DTO.Feedback GetCompanyFeedback(int internshipId, int userId, string role);
    bool DeleteInternship(int internshipId, int userId, string role);
    bool DeleteFeedback(int internshipId, int userId, string role);

}
