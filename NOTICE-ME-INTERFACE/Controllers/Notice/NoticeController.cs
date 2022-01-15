using Microsoft.AspNetCore.Mvc;
using NOTICE_ME_CROSSCUTING.DTO.Notice;
using NOTICE_ME_SERVICE.ApplicationService.Notice.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NOTICE_ME_INTERFACE.Controllers.Notice
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class NoticeController : ControllerBase
    {
        private readonly INoticeApplicationService NoticeApplicationService;

        public NoticeController(INoticeApplicationService noticeApplicationService)
        {
            NoticeApplicationService = noticeApplicationService;
        }


        [SwaggerResponse(statusCode: 200, description: "Added")]
        [SwaggerResponse(statusCode: 400, description: "Internal Server Error", Type = typeof(string))]
        [SwaggerResponse(statusCode: 409, description: "Conflict", Type = typeof(string))]
        [Produces("application/json")]
        [HttpPost("add")]
        public async Task<IActionResult> Register([FromBody] NoticePostDto dto)
        {
            await NoticeApplicationService.Post(dto);
            return Ok();
        }

        [SwaggerResponse(statusCode: 200, description: "Sucess" , Type = typeof(IEnumerable<NoticeSearchDto>))]
        [SwaggerResponse(statusCode: 400, description: "Internal Server Error", Type = typeof(string))]
        [SwaggerResponse(statusCode: 409, description: "Conflict", Type = typeof(string))]
        [Produces("application/json")]
        [HttpGet("search/{search}")]
        public async Task<IActionResult> Search([FromRoute] string search) => Ok(await NoticeApplicationService.Search(search));
    }
}
