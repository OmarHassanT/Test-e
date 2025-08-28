namespace Test_e.Server.Helpers
{
    public class Helper(ILogger<Helper> logger)
    {
        private  readonly ILogger<Helper> _logger = logger;
        /// <summary>
        /// Validate value of keys in the appsettings file
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void ValidateConfig(string? value, string name)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                _logger.LogError("{ConfigName} is missing in configuration.", name);
                throw new InvalidOperationException($"{name} is missing in configuration.");
            }
        }
      
    }
}
