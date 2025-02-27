using AutoMapper;
using Classifiers.Application.Classifiers.Commands.CreateClassifier;
using Classifiers.Application.Classifiers.Commands.DeleteClassifier;
using Classifiers.Application.Classifiers.Commands.Queries.GetClassifierDetails;
using Classifiers.Application.Classifiers.Commands.Queries.GetClassifierList;
using Classifiers.Application.Classifiers.Commands.Queries.GetClassifierSection;
using Classifiers.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Classifiers.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ClassifierController(IMapper mapper, IMediator mediator) : BaseController
    {
        private readonly IMapper _mapper = mapper;
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult<ClassifierListVm>> GetAll()
        {
            var query = new GetClassifierListQuery
            {

            };
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<ClassifierDetailsVm>> GetById(int id)
        {
            var query = new GetClassifierDetailsQuery
            {
                Id = id
            };
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet("by-parent/{parentId}")]
        public async Task<ActionResult<ClassifierSectionsVm>> GetByParentId(int parentId)
        {
            var query = new GetClassifierSectionQuery
            {
                ParentId = parentId
            };
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateClassifierDto createClassifierDto)
        {
            if (createClassifierDto == null)
            {
                return BadRequest("DTO is null");
            }
            var command = _mapper.Map<CreateClassifierCommand>(createClassifierDto);
            command.ParentId = createClassifierDto.ParentId;
            command.Name = createClassifierDto.Name;
            var clsId = await _mediator.Send(command);
            return Ok(clsId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateClassifierDto updateClassifierDto)
        {
            if (updateClassifierDto == null)
            {
                return BadRequest("DTO is null");
            }
            var command = _mapper.Map<UpdateClassifierDto>(updateClassifierDto);

            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteClassifierCommand
            {
                Id = id
            };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
