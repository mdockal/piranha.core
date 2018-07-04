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
using System;

namespace Piranha.AspNetCore.Api
{
    [ApiController]
    [Route("api/page")]
    public class PageApiController : ControllerBase
    {
        private readonly IApi _api;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="api">The current api</param>
        public PageApiController(IApi api)
        {
            _api = api;
        }

        /// <summary>
        /// Gets the page with the given id.
        /// </summary>
        /// <param name="id">The page id</param>
        [HttpGet("{id}")]
        public ActionResult<Models.PageBase> Get(Guid id)
        {
            var page = _api.Pages.GetById<Models.PageBase>(id);

            if (page != null && page.Published.HasValue && page.Published.Value <= DateTime.Now)
                return page;
            return NotFound();
        }
    }
}