using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        // Padrão option injetanco configurações
        private readonly OpeningTimeOption _option;
        public ProjectsController(IOptions<OpeningTimeOption> option, ExampleClass exampleClass)
        {
            _option = option.Value;
            exampleClass.Name = "Update ate project controller";
        }


        //api/projects?query=netcore
        [HttpGet]
        public IActionResult Get(string query)
        {
            // Buscar Todos ou filtrar 
            return Ok();
        }

        //api/projects/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Buscar o projeto

            //return NotFound();

            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateProjectModel createProject)
        {
            if (createProject.Title.Length > 50)
            {
                return BadRequest();
            }
            
            // Cadastrar o projeto
            return CreatedAtAction(nameof(GetById), new { id = createProject.Id }, createProject);
        }

        //api/project/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectModel updateModel)
        {
            if(updateModel.Description.Length > 200)
            {
                return BadRequest();
            }

            //  Atualizo o objeto
            return NoContent();
        }

        //api/projetc/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Buscar, se não existir, retornar NotFound 

            //Remover  "Altera flag"
            return NoContent();
        }


        /***********************************************
         Outras ações para o projeto
         **********************************************/

        // api/projects/1/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, [FromBody] CreateCommentModel createComment)
        {
            return NoContent();
        }

        // api/1/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            return NoContent();
        }

        // api/1/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            return NoContent();
        }
    }
}
