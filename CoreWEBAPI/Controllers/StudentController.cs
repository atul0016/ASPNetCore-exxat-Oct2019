using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreWEBAPI.Models;
using CoreWEBAPI.Services;

namespace CoreWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IService<Student, int> _service;

        /// <summary>
        /// Inject the StudentService from DI Container
        /// </summary>
        public StudentController(IService<Student, int> service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var res = _service.GetAsync().Result;
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var res = _service.GetAsync(id).Result;
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Student std)
        {
            try
            {
                // check for validation of Student Posted data
                if (ModelState.IsValid)
                {
                    var res = _service.CreateAsync(std).Result;
                    return Ok(res);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Student std)
        {
            try
            {
                if (id == std.StudentUniqueId)
                {
                    // check for validation of Student Posted data
                    if (ModelState.IsValid)
                    {
                        var res = _service.UpdateAsync(id,std).Result;
                        return Ok(res);
                    }
                    else
                    {
                        return BadRequest(ModelState);
                    }
                }
                else
                {
                    return BadRequest($"The {id} send in header does not match with id {std.StudentUniqueId} from body");
                }
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var res = _service.DeleteAsync(id).Result;
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}