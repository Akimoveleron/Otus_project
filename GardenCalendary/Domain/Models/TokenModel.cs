namespace Domain.Models
{
    /// <summary>
    /// Модель токена
    /// </summary>
    public class TokenModel
    {
        /// <summary>
        /// Токен
        /// </summary>
        public string Token { get; set; } = string.Empty;
        
        /// <summary>
        /// Id пользователя
        /// </summary>
        public int UserId { get; set; }
    }
}
