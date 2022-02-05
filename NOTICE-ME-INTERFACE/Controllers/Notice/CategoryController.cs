using Microsoft.AspNetCore.Mvc;
using NOTICE_ME_SERVICE.ApplicationService.Notice.Interfaces;

namespace NOTICE_ME_INTERFACE.Controllers.Notice
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryApplicationService _categoryApplicationService;

        public CategoryController(ICategoryApplicationService categoryApplicationservice)
        {
            _categoryApplicationService = categoryApplicationservice;
        }
    }
}
