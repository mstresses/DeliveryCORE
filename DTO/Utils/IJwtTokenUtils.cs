namespace DTO.Utils
{
    public interface IJwtTokenUtils
    {
        string GenerateToken(int id, bool isAdmin);
    }

}