using Domain.BaseEntites;

namespace Domain.Models
{
    /// <summary>
    ///  Модель пользователя
    /// </summary>
    public class UserModel : BaseModel
    {
        /// <summary>
        /// PK
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; } = string.Empty;
        
        /// <summary>
        /// Отчество
        /// </summary>
        public string SecondName { get; set; } = string.Empty;

        /// <summary>
        /// Фамилия
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Адресс электронной почты
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string? PhoneNumber { get; set; }
    }
}
