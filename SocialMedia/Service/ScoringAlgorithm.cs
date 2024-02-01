using SocialMedia.Models.BusinessModels;

namespace SocialMedia.Service;

public class ScoringAlgorithm : IScoringAlgorithm
{
    private int propertyWeightTable(String property)
    {
        Dictionary<string, int> propertyWeights = new Dictionary<string, int>
        {
            { "DateOfBirth", 1 },
            { "UniversityLocation", 2 },
            { "Field", 6 },
            { "Workplace", 3 },
            { "Specialties", 5 },
        };
        if (propertyWeights.ContainsKey(property))
        {
            return propertyWeights[property];
        }
        else throw new InvalidDataException();
    }
    public int Score(User a, User b)
    {     
        int score = 0;
        score += calculateDateOfBirthScore(a, b);
        score += calculateUniversityLocationScore(a, b);
        score += calculateFieldScore(a, b);
        score += calculateWorkplaceScore(a, b);
        score += calculateSpecialtiesScore(a, b);
        return score;

    }
    private int calculateDateOfBirthScore(User a, User b)
    {
        if (a.DateOfBirth.Year == b.DateOfBirth.Year) return propertyWeightTable("DateOfBirth");
        else return 0;
    }
    private int calculateUniversityLocationScore(User a, User b)
    {
        if (a.UniversityLocation == b.UniversityLocation) return propertyWeightTable("UniversityLocation");
        else return 0;
    }
    private int calculateFieldScore(User a, User b)
    {
        if (a.Field == b.Field) return propertyWeightTable("Field");
        else return 0;
    }
    private int calculateWorkplaceScore(User a, User b)
    {
        if (a.Workplace == b.Workplace) return propertyWeightTable("Workplace");
        else return 0;
    }
    private int calculateSpecialtiesScore(User a, User b)
    {
        int common = a.Specialties.Intersect(b.Specialties).Count();
        return (common * propertyWeightTable("Specialties"));       
    }
}