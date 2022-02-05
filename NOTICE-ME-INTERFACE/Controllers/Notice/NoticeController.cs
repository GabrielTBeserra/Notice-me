using Microsoft.AspNetCore.Mvc;
using NOTICE_ME_CROSSCUTING.DTO.Notice;
using NOTICE_ME_CROSSCUTING.DTO.User;
using NOTICE_ME_SERVICE.ApplicationService.Notice.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NOTICE_ME_INTERFACE.Controllers.Notice
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class NoticeController : ControllerBase
    {
        private readonly INoticeApplicationService _noticeApplicationService;

        public NoticeController(INoticeApplicationService noticeApplicationService)
        {
            _noticeApplicationService = noticeApplicationService;
        }


        [SwaggerResponse(statusCode: 200, description: "Added")]
        [SwaggerResponse(statusCode: 400, description: "Internal Server Error", Type = typeof(string))]
        [SwaggerResponse(statusCode: 409, description: "Conflict", Type = typeof(string))]
        [Produces("application/json")]
        [HttpPost("add")]
        public async Task<IActionResult> Register([FromBody] NoticePostDto dto, CancellationToken ctToken)
        {
            await _noticeApplicationService.Post(dto, ctToken);
            return Ok();
        }

        [SwaggerResponse(statusCode: 200, description: "Success", Type = typeof(IEnumerable<NoticeSearchDto>))]
        [SwaggerResponse(statusCode: 400, description: "Internal Server Error", Type = typeof(string))]
        [SwaggerResponse(statusCode: 409, description: "Conflict", Type = typeof(string))]
        [Produces("application/json")]
        [HttpGet("search/{search}")]
        public async Task<IActionResult> Search([FromRoute] string search, CancellationToken ctToken) => Ok(await _noticeApplicationService.Search(search, ctToken));

        [SwaggerResponse(statusCode: 200, description: "Success", Type = typeof(IEnumerable<NoticeSearchDto>))]
        [SwaggerResponse(statusCode: 400, description: "Internal Server Error", Type = typeof(string))]
        [SwaggerResponse(statusCode: 409, description: "Conflict", Type = typeof(string))]
        [Produces("application/json")]
        [HttpGet("mynotices")]
        public async Task<IActionResult> MyNotices(CancellationToken ctToken) => Ok(await _noticeApplicationService.MyNotices(ctToken));

        [SwaggerResponse(statusCode: 200, description: "Success", Type = typeof(IEnumerable<NoticeSearchDto>))]
        [SwaggerResponse(statusCode: 400, description: "Internal Server Error", Type = typeof(string))]
        [SwaggerResponse(statusCode: 409, description: "Conflict", Type = typeof(string))]
        [Produces("application/json")]
        [HttpGet("getfeed")]
        public async Task<IActionResult> GetLatest(CancellationToken ctToken) => Ok(await _noticeApplicationService.GetFeed(ctToken));

        [SwaggerResponse(statusCode: 200, description: "Success", Type = typeof(IEnumerable<TopUserFeedDto>))]
        [SwaggerResponse(statusCode: 400, description: "Internal Server Error", Type = typeof(string))]
        [SwaggerResponse(statusCode: 409, description: "Conflict", Type = typeof(string))]
        [Produces("application/json")]
        [HttpGet("topusers")]
        public async Task<IActionResult> TopUsers(CancellationToken ctToken) => Ok(await _noticeApplicationService.GetTopUsers(ctToken));

        [SwaggerResponse(statusCode: 200, description: "Success")]
        [SwaggerResponse(statusCode: 400, description: "Internal Server Error", Type = typeof(string))]
        [SwaggerResponse(statusCode: 409, description: "Conflict", Type = typeof(string))]
        [Produces("application/json")]
        [HttpPost("changestatus")]
        public async Task<IActionResult> ChangeStatus([FromBody] NoticeChangeStatusDto dto, CancellationToken ctToken)
        {
            await _noticeApplicationService.ChangeStatus(dto, ctToken);
            return Ok();
        }

        [SwaggerResponse(statusCode: 200, description: "Success", Type = typeof(IEnumerable<NoticeWaitingAvaliationDto>))]
        [SwaggerResponse(statusCode: 400, description: "Internal Server Error", Type = typeof(string))]
        [SwaggerResponse(statusCode: 409, description: "Conflict", Type = typeof(string))]
        [Produces("application/json")]
        [HttpGet("waitingavaliation")]
        public async Task<IActionResult> GetWaitingAvaliation(CancellationToken ctToken) => Ok(await _noticeApplicationService.GetNoticeWaitingAvaliationDto(ctToken));
    }
}
