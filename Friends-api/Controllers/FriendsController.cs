using Friends_api.Data;
using Friends_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Friends_api.Controllers
{
    [ApiController]
    [Route("api/friends")]
    public class FriendsController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public ActionResult getAll()
        {
            var repository = new Repository();

            return new OkObjectResult(repository.GetAll());
        }

        [HttpGet]
        [Route("id")]
        public ActionResult GetById(int id)
        {
            var repository = new Repository();

            var friend = repository.GetById(id);

            if (friend == null)
                return new NotFoundObjectResult(new { message = "Não existe amigo com este Id" });

            return new OkObjectResult(friend);
        }

        [HttpPost]
        [Route("")]
        public ActionResult Create([FromBody] Friends req)
        {
            var repository = new Repository();

            Friends friend = req;

            if (friend == null)
                return new BadRequestObjectResult(new { message = "Dados para criação de um amigo é necessário" });

            repository.Save(friend);

            return new OkObjectResult(req);
        }

        [HttpDelete]
        [Route("")]
        public ActionResult Delete(int id)
        {
            var repository = new Repository();

            var friend = repository.GetById(id);

            if (friend == null)
                return new NotFoundObjectResult(new { message = "Não existe amigo com este Id" });

            repository.Delete(friend.Id);

            return Ok();
        }

        [HttpPut]
        [Route("")]
        public ActionResult Update([FromBody] Friends req)
        {
            var repository = new Repository();

            Friends friend = req;

            Friends friendInDataBase = repository.GetById(friend.Id);

            if(friendInDataBase == null)
                return new BadRequestObjectResult(new { message = "Não existe amigo registrado com este Id" });

            if (friend == null)
                return new BadRequestObjectResult(new { message = "Necessários dados para a edição de um amigo" });

            repository.Update(friend);

            return new OkObjectResult(req);
        }
    }
}
