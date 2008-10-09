﻿//-----------------------------------------------------------------------
// <copyright file="GetAccessTokenMessage.cs" company="Andrew Arnott">
//     Copyright (c) Andrew Arnott. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DotNetOAuth.Messages {
	using System;
	using DotNetOAuth.Messaging;

	/// <summary>
	/// A direct message sent by the Consumer to exchange an authorized Request Token
	/// for an Access Token and Token Secret.
	/// </summary>
	public class GetAccessTokenMessage : SignedMessageBase, ITokenContainingMessage {
		/// <summary>
		/// Initializes a new instance of the <see cref="GetAccessTokenMessage"/> class.
		/// </summary>
		/// <param name="serviceProvider">The URI of the Service Provider endpoint to send this message to.</param>
		protected internal GetAccessTokenMessage(MessageReceivingEndpoint serviceProvider)
			: base(MessageTransport.Direct, serviceProvider) {
		}

		/// <summary>
		/// Gets or sets the Token.
		/// </summary>
		string ITokenContainingMessage.Token {
			get { return this.RequestToken; }
			set { this.RequestToken = value; }
		}

		/// <summary>
		/// Gets or sets the Request Token.
		/// </summary>
		[MessagePart(Name = "oauth_token", IsRequired = true)]
		internal string RequestToken { get; set; }
	}
}