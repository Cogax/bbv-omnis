namespace Omnis
{
    using Omnis.Common;

    public class RootFactory
    {
        private readonly IDbConnectionFactory connectionFactory;

        public RootFactory(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public virtual PerRequestFactory CreatePerRequestFactory()
        {
            return new PerRequestFactory(this.connectionFactory);
        }
    }
}