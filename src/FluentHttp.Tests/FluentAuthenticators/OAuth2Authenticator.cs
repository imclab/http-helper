﻿
namespace FluentHttp.Authenticators
{
    using System;
    using global::FluentHttp;

    /// <summary>
    /// Base class for OAuth2 Authenticators.
    /// </summary>
    abstract class OAuth2Authenticator : IFluentAuthenticator
    {
        /// <summary>
        /// Authenticates the fluent http request using OAuth2.
        /// </summary>
        /// <param name="fluentHttpRequest">The fluent http request.</param>
        public abstract void Authenticate(FluentHttpRequest fluentHttpRequest);
    }

    abstract class OAuth2BearerAuthenticator : OAuth2Authenticator
    {
        private readonly string _bearerToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="OAuth2BearerAuthenticator"/> class.
        /// </summary>
        /// <param name="bearerToken">The oauth 2 bearer_token.</param>
        protected OAuth2BearerAuthenticator(string bearerToken)
        {
            if (string.IsNullOrEmpty(bearerToken))
                throw new ArgumentNullException("bearerToken");
            _bearerToken = bearerToken;
        }

        /// <summary>
        /// Gets the bearer_token.
        /// </summary>
        public string BearerToken
        {
            get { return _bearerToken; }
        }
    }

    class OAuth2UriQueryParameterBearerAuthenticator : OAuth2BearerAuthenticator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OAuth2UriQueryParameterBearerAuthenticator"/> class.
        /// </summary>
        /// <param name="bearerToken">The oauth 2 bearer_token.</param>
        public OAuth2UriQueryParameterBearerAuthenticator(string bearerToken)
            : base(bearerToken)
        {
        }

        /// <summary>
        /// Authenticate the fluent http request using OAuth2 uri querystring parameter bearer_token.
        /// </summary>
        /// <param name="fluentHttpRequest">The fluent http request.</param>
        public override void Authenticate(FluentHttpRequest fluentHttpRequest)
        {
            fluentHttpRequest.QueryStrings(qs => qs.Add("bearer_token", BearerToken));
        }
    }
}