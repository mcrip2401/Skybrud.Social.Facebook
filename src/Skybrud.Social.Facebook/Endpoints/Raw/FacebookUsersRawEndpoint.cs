﻿using System;
using Skybrud.Essentials.Common;
using Skybrud.Social.Facebook.Fields;
using Skybrud.Social.Facebook.OAuth;
using Skybrud.Social.Facebook.Options.User;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Endpoints.Raw {
    
    /// <summary>
    /// Class representing the raw implementation of the users endpoint.
    /// </summary>
    public class FacebookUsersRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth client.
        /// </summary>
        public FacebookOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal FacebookUsersRawEndpoint(FacebookOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the user with the specified <paramref name="identifier"/>.
        /// </summary>
        /// <param name="identifier">The identifier of the user.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetUser(string identifier) {
            if (String.IsNullOrWhiteSpace(identifier)) throw new ArgumentNullException("identifier", "A Facebook identifier (ID) must be specified.");
            return Client.DoHttpGetRequest("/" + identifier);
        }

        /// <summary>
        /// Gets information about the user with the specified <paramref name="identifier"/>.
        /// </summary>
        /// <param name="identifier">The identifier of the user.</param>
        /// <param name="fields">A collection of the fields that should be returned by the API.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetUser(string identifier, FacebookFieldsCollection fields) {
            if (String.IsNullOrWhiteSpace(identifier)) throw new ArgumentNullException("identifier", "A Facebook identifier (ID) must be specified.");
            return GetUser(new FacebookGetUserOptions(identifier, fields));
        }

        /// <summary>
        /// Gets information about the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetUser(FacebookGetUserOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            if (String.IsNullOrWhiteSpace(options.Identifier)) throw new PropertyNotSetException("options.Identifier", "A Facebook identifier (ID) must be specified.");
            return Client.DoHttpGetRequest("/" + options.Identifier, options);
        }

        #endregion

    }

}