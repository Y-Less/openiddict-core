/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/openiddict/openiddict-core for more information concerning
 * the license and the contributors participating to this project.
 */

using System;
using System.Collections.Generic;

namespace OpenIddict.Models
{
    /// <summary>
    /// Represents the underived base of all OpenIddict types that need an ID.
    /// </summary>
    public class OpenIddictBase<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Gets or sets the unique identifier
        /// associated with the current application.
        /// </summary>
        public virtual TKey Id { get; set; }
    }
}