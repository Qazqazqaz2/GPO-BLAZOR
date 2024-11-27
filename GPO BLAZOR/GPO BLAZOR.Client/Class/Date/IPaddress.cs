namespace GPO_BLAZOR.Client.Class.Date
{
    /// <summary>
    /// Статический класс содержащий IP-адресса
    /// </summary>
    /// <remarks>
    /// Переделать на получение значений из XML-файла
    /// </remarks>
    public static class IPaddress
    {

        /// <summary>
        /// Адресс сервера с БД
        /// </summary>
#if IIS_DEBUG
        public const string IPAddress = "localhost:44338";
#else
        private static string _ipaddress = "localhost:3001";
        public static string helper;
        public static string IPAddress
        {
            get
            {
                return _ipaddress;
            }
            set
            {
                _ipaddress = value;
            }
        }
#endif
    }
}
