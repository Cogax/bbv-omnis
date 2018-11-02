namespace Omnis
{
    using Omnis.Common;

    public class PerRequestFactory
    {
        private readonly IDbConnectionFactory connectionFactory;

        public PerRequestFactory(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }
    }
}