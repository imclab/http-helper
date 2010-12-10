﻿namespace FluentHttp
{
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Net;

    [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1601:PartialElementsMustBeDocumented",
        Justification = "Reviewed. Suppression is OK here.")]
    public partial class FluentHttpRequest
    {
        /// <summary>
        /// The credentials to use for http web request.
        /// </summary>
        private ICredentials credentials;

        /// <summary>
        /// Sets the credentials.
        /// </summary>
        /// <param name="credentials">
        /// The credentials.
        /// </param>
        /// <returns>
        /// Returns <see cref="FluentHttpRequest"/>.
        /// </returns>
        [ContractVerification(true)]
        public FluentHttpRequest Credentials(ICredentials credentials)
        {
            Contract.Ensures(Contract.Result<FluentHttpRequest>() != null);

            this.credentials = credentials;

            return this;
        }

        /// <summary>
        /// Gets the Credentials
        /// </summary>
        /// <returns>
        /// Returns <see cref="ICredentials"/>.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ICredentials GetCredentials()
        {
            return credentials;
        }
    }
}