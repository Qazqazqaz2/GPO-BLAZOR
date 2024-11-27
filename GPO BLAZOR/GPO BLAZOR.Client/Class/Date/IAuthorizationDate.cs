namespace GPO_BLAZOR.Client.Class.Date
{
    public interface IAuthorizationDate
    {
        /// <summary>
        /// Есть ли соответствующая запись в хранилище
        /// </summary>
        bool IsCookies { get; }
        /// <summary>
        /// Сообщение пришедшее с сервера (на случай ошибки)
        /// </summary>
        string RequestMessage { get; }
        /// <summary>
        /// Поле заполненного логина
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Поле для хранения заполненного пароля
        /// </summary>
        string Password { get; set; }
        /// <summary>
        /// Поле хранящее делегат чтения
        /// </summary>
        public Reader _reader { get;}
        /// <summary>
        /// Поле хранящее делегат записи
        /// </summary>
        public Writer _writer { get;}
        /// <summary>
        /// Дополнительный асинхронный метод для инициализации
        /// </summary>
        /// <param name="reader"> Делегат для чтения из хранилища </param>
        /// <returns></returns>
        public Task GetValues(Reader reader, System.Timers.Timer timer);

        //public Task<string> SendLogin();
        /// <summary>
        /// Заглушка записи
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        Task Send(string value, System.Timers.Timer timer);
    }
    /// <summary>
    /// Делегат записи в хралище
    /// </summary>
    /// <param name="value"> Значение </param>
    /// <returns></returns>
    public delegate Task Writer(string key, string value);
    /// <summary>
    /// Делегат чтения их хранилища
    /// </summary>
    /// <returns>
    /// Значение
    /// </returns>
    public delegate Task<string> Reader(string key);
}
