using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Order_CRUD.DTO;
using Order_CRUD.Reposatery.Repo;
using Order_CRUD.Services;

namespace Order_CRUD.Controllers
{
    [ApiController]
    [Route("unit")]
    public class UnitController : ControllerBase
    {
        private IUnitService _service;
        private IUnitRepo _repo;
        public UnitController(IUnitService service, IUnitRepo repo)
        {
            _service = service;
            _repo = repo;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            return Ok(_repo.GetAll());
        }

        [HttpGet("getById/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_repo.GetById(id));
        }

        [HttpPost("add")]
        public IActionResult Delete([FromBody] Unitdto unit)
        {
            _service.addUnit(unit);
            return Ok(true);
        }

        [HttpPost("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _service.deleteUnit(id);
            return Ok(true);
        }

        [HttpPost("update/{id}")]
        public IActionResult Delete([FromBody] Unitdto unit, int id)
        {
            _service.updateUnit(id, unit);
            return Ok(true);
        }
    }
}
