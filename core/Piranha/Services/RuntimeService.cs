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
    public class RuntimeService : IRuntimeService
    {
        private IEnumerable<Models.PageType> _pageTypes;
        private IEnumerable<Models.PostType> _postTypes;
        private IEnumerable<Data.Site> _sites;

        /// <summary>
        /// Gets all available page types.
        /// </summary>
        /// <param name="api">The current api</param>
        /// <returns>The page types</returns>
        public IEnumerable<Models.PageType> GetAllPageTypes(IApi api)
        {
            if (_pageTypes == null)
                LoadPageTypes(api);
            return _pageTypes;
        }

        /// <summary>
        /// Gets the page type with the given id.
        /// </summary>
        /// <param name="api">The current api</param>
        /// <param name="id">The unique id</param>
        /// <returns>The page type</returns>
        public Models.PageType GetPageTypeById(IApi api, string id)
        {
            if (_pageTypes == null)
                LoadPageTypes(api);
            return _pageTypes.FirstOrDefault(t => t.Id == id);
        }

        /// <summary>
        /// Gets all available post types.
        /// </summary>
        /// <param name="api">The current api</param>
        /// <returns>The post types</returns>
        public IEnumerable<Models.PostType> GetAllPostTypes(IApi api)
        {
            if (_postTypes == null)
                LoadPostTypes(api);
            return _postTypes;
        }

        /// <summary>
        /// Gets the post type with the given id.
        /// </summary>
        /// <param name="api">The current api</param>
        /// <param name="id">The unique id</param>
        /// <returns>The post type</returns>
        public Models.PostType GetPostTypeById(IApi api, string id)
        {
            if (_postTypes == null)
                LoadPostTypes(api);
            return _postTypes.FirstOrDefault(t => t.Id == id);
        }

        /// <summary>
        /// Gets the site that contains the given hostname.
        /// </summary>
        /// <param name="api">The current api</param>
        /// <param name="hostname">The hostname</param>
        /// <returns>The site</returns>
        public Data.Site GetSiteByHostname(IApi api, string hostname)
        {
            if (_sites == null)
                LoadSites(api);
            return _sites.FirstOrDefault(s => s.Hostnames != null && s.Hostnames.Contains(hostname));
        }

        /// <summary>
        /// Gets the default site.
        /// </summary>
        /// <param name="api">The current api</param>
        /// <returns>The site</returns>
        public Data.Site GetDefaultSite(IApi api)
        {
            if (_sites == null)
                LoadSites(api);
            return _sites.FirstOrDefault(s => s.IsDefault);
        }

        /// <summary>
        /// Loads the available page types from the api.
        /// </summary>
        /// <param name="api">The current api</param>
        private void LoadPageTypes(IApi api)
        {
            _pageTypes = api.PageTypes.GetAll();
        }

        /// <summary>
        /// Loads the available post types from the api.
        /// </summary>
        /// <param name="api">The current api</param>
        private void LoadPostTypes(IApi api)
        {
            _postTypes = api.PostTypes.GetAll();
        }

        /// <summary>
        /// Loads the available sites from the api.
        /// </summary>
        /// <param name="api">The current api.</param>
        private void LoadSites(IApi api)
        {
            _sites = api.Sites.GetAll();
        }
    }
}