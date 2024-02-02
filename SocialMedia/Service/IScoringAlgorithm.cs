using SocialMedia.Models.BusinessModels;

namespace SocialMedia.Service;

public interface IScoringAlgorithm
{
    public int Score(User a, User b, int degree);
}