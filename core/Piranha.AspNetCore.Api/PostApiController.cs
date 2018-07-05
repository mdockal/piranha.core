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
    [Route("api/post")]
    public class PostApiController : ControllerBase
    {
        private readonly IApi _api;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="api">The current api</param>
        public PostApiController(IApi api)
        {
            _api = api;
        }

        /// <summary>
        /// Gets the post with the given id.
        /// </summary>
        /// <param name="id">The post id</param>
        [HttpGet("{id}")]
        public ActionResult<Models.PostBase> Get(Guid id)
        {
            var post = _api.Posts.GetById<Models.PostBase>(id);

            if (post != null && post.Published.HasValue && post.Published.Value <= DateTime.Now)
                return post;
            return NotFound();
        }
    }
}