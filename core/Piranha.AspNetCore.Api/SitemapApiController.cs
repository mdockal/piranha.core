/*
 * Copyright (c) 2018 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 * 
 * https://github.com/piranhacms/piranha.core
 * 
 */

using Microsoft.AspNetCore.Mvc;

namespace Piranha.AspNetCore.Api
{
    [ApiController]
    [Route("api/sitemap")]
    public class SitemapApiController : ControllerBase
    {
        private readonly IApi _api;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="api">The current api</param>
        public SitemapApiController(IApi api)
        {
            _api = api;
        }

        /// <summary>
        /// Gets the sitemap for the default site.
        /// </summary>
        [HttpGet("")]
        public ActionResult<Models.Sitemap> Get()
        {
            return _api.Sites.GetSitemap();
        }
    }
}