using System.Collections.Generic;
using System.Linq;
using DTO;

public class RecommendationService : IRecommendationService {

    private readonly IRecommendationQueries queries;

    public RecommendationService(IRecommendationQueries queries) {
        this.queries = queries;
    }
    
    public List<Advertisement> GetAdvertisementsForStudent(int studentId) {
        // Get recommendation advertisements for a student
        List<Entity.Advertisement> advertisements = queries.GetAdvertisementsForStudent(studentId);
        
        // If no advertisements are found, return null
        if(advertisements == null) {
            return null;
        }
        
        // Convert Entity.Advertisement to Advertisement
        List<Advertisement> adv = advertisements.Select(adv => new Advertisement(adv)).ToList();
        
        return adv;
    }
    
    public List<Advertisement> GetAdvertisementsOfCompany(int companyId) {
        // Get advertisements of a company
        List<Entity.Advertisement> advertisements = queries.GetAdvertisementsOfCompany(companyId);
        
        // If no advertisements are found, return null
        if(advertisements == null) {
            return null;
        }
        
        // Convert Entity.Advertisement to Advertisement
        List<Advertisement> adv = advertisements.Select(adv => new Advertisement(adv)).ToList();
        
        return adv;
    }

    public bool CreateAdvertisement(int companyId, DTO.AdvertisementRegistration advertisement) {
        Advertisement adv = new Advertisement(advertisement);
        
        // Convert Skills to DTO.SkillRegistration
        List<DTO.SkillRegistration> skillsDto = advertisement.Skills
            .Select(skill => new DTO.SkillRegistration { Name = skill })
            .ToList();
        
        // Convert DTO.SkillRegistration to Skill
        List<Skill> skills = skillsDto
            .Select(skill => new Skill(skill))
            .ToList();
        
        // Convert Skill to Entity.Skill
        List<Entity.Skill> skillsEntity = skills
            .Select(skill => skill.ToEntity())
            .ToList();

        // Create advertisement
        int? advId = queries.CreateAdvertisement(companyId, adv.ToEntity(), skillsEntity);
        
        if (advId != null) {
            MatchAdvertisementToSkills(advId.Value); 
            return true;
        }

        return false;
    }
    
    private void MatchAdvertisementToSkills(int advertisementId) {
        queries.MatchAdvertisementForStudent(advertisementId);
        queries.MatchAdvertisementForCompany(advertisementId);
    }

}
