using ImageReatedWork.Dto;
using ImageReatedWork.Helper;
using ImageReatedWork.Models;
using ImageReatedWork.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;

namespace ImageReatedWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService service;

        public ProfileController(IProfileService service)
        {
            this.service = service;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> UploadImage([FromForm]ProfileDto dto)
        {
           string name= ImageHelper.SaveImage(dto.Image);
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Image not Added");
            }
            Profile p = new Profile()
            {
                Bio = dto.Bio,
                Name = dto.Name,
                ImagePath = name
            };
           bool res=await service.Add(p);
            if (res)
            {
                return Ok( new {Message = "Data Added ", Data = p});
            }
            return BadRequest(new { Message = "Data not Added" });
           
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id , [FromForm] ProfileDto dto)
        {
            string imageName=ImageHelper.SaveImage(dto.Image);
            if (string.IsNullOrEmpty(imageName))
            {
                return BadRequest(new { Message = "Image invalid" });
            }
            Profile p = new Profile()
            {
                Bio = dto.Bio,
                Name = dto.Name,
                ImagePath = imageName
            };
         bool res= await  service.Update(id,p);
         return   res ?  
                    Ok("Data Updated"):
                    BadRequest("Data Not Update");
        }
    }
}





