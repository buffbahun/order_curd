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
    [Route("item")]
    public class ItemController : ControllerBase
    {
        private IItemService _service;
        private IItemRepo _repo;
        public ItemController(IItemService service, IItemRepo repo)
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
        public IActionResult Add([FromBody] Itemdto unit)
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
        public IActionResult Update([FromBody] Itemdto unit, int id)
        {
            _service.updateUnit(id, unit);
            return Ok(true);
        }
    }
}
