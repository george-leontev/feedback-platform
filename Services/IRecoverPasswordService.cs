namespace CollegeFeedbackPlatform.Services;

public interface IRecoverPasswordService
{
    Task<bool> RecoverPasswordAsync(string email);
}