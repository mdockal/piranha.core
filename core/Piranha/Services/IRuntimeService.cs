/*
 * Copyright (c) 2018 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 * 
 * https://github.com/piranhacms/piranha.core
 * 
 */

using System.Collections.Generic;
using System.Linq;

namespace Piranha.Services
{
    /// <summary>
    /// The runtime service can be used as an extra level of caching
    /// for the middleware pipeline. It holds all of the sites, page types
    /// and post types in memory as these are the entities most unlikely
    /// to change in a running installation.
    /// 
    /// Please note that if a site, or content type is changed during runtime
    /// with this service active the web application needs to be recycled.
    /// </summary>
    public interface IRuntimeService
    {
        /// <summary>
        /// Gets all available page types.
        /// </summary>
        /// <param name="api">The current api</param>
        /// <returns>The page types</returns>
        IEnumerable<Models.PageType> GetAllPageTypes(IApi api);

        /// <summary>
        /// Gets the page type with the given id.
        /// </summary>
        /// <param name="api">The current api</param>
        /// <param name="id">The unique id</param>
        /// <returns>The page type</returns>
        Models.PageType GetPageTypeById(IApi api, string id);

        /// <summary>
        /// Gets all available post types.
        /// </summary>
        /// <param name="api">The current api</param>
        /// <returns>The post types</returns>
        IEnumerable<Models.PostType> GetAllPostTypes(IApi api);

        /// <summary>
        /// Gets the post type with the given id.
        /// </summary>
        /// <param name="api">The current api</param>
        /// <param name="id">The unique id</param>
        /// <returns>The post type</returns>
        Models.PostType GetPostTypeById(IApi api, string id);

        /// <summary>
        /// Gets the site that contains the given hostname.
        /// </summary>
        /// <param name="api">The current api</param>
        /// <param name="hostname">The hostname</param>
        /// <returns>The site</returns>
        Data.Site GetSiteByHostname(IApi api, string hostname);

        /// <summary>
        /// Gets the default site.
        /// </summary>
        /// <param name="api">The current api</param>
        /// <returns>The site</returns>
        Data.Site GetDefaultSite(IApi api);
    }
}