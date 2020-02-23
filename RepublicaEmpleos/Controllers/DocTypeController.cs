using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepublicaEmpleos.Data;
using RepublicaEmpleos.Services.Interfaces;
using RepublicaEmpleos.Infrastructure;
using RepublicaEmpleos.Models;
using System.Linq;

namespace RepublicaEmpleos.Controllers
{
    [IgnoreAntiforgeryToken]
    public class DocTypeController : BaseController
    {
        private readonly IGenericInterface<ProfileDocType> _DoctypeServices;


        public DocTypeController(IGenericInterface<ProfileDocType> DoctypeServices)
        {
            _DoctypeServices = DoctypeServices;
        }

        [HttpGet("id")]
       [Route("/GetDocument/{id}")]
        public async Task<IEnumerable<ProfileDocType>> GetProfileDocType(int id)
        {
            return await _DoctypeServices.GetAllById(id);
        }

        // POST: Phones/Create
        [HttpPost]
        [Route("/AddDocument")]
        public async Task<IActionResult> Create([FromBody] ProfileDocType profileDocType)
        {
            await _DoctypeServices.CreateAsync(profileDocType);
            return new ObjectResult(
                $"<div class=\"alert alert - default alert - dismissible fade show\" role=\"alert\">" +
                $"<span class=\"alert - inner--icon\"><i class=\"ni ni - like - 2\"></i></span>" +
                $"< span class=\"alert-inner--text\"><strong>Susses! Cargado Con Exito</strong></span>" +
                $"<button type = \"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
                $"<span aria-hidden=\"true\">&times;</span></button>"+
                $"</div>");
        }

        // POST: Phones/Edit/5
        [HttpPut("id")]
       [Route("/EditDocument/{id}")]
        public async Task<IActionResult> Edit(int id,[FromBody]ProfileDocType profileDocType)
        {
            if (id != profileDocType.DocTypeID)
            {
                return NotFound();
            }
            try
            {
                await _DoctypeServices.EditAsync(profileDocType);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_DoctypeServices.Exists(profileDocType.DocTypeID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return new ObjectResult(
                $"<div class=\"alert alert - default alert - dismissible fade show\" role=\"alert\">" +
                $"<span class=\"alert - inner--icon\"><i class=\"ni ni - like - 2\"></i></span>" +
                $"< span class=\"alert-inner--text\"><strong>Susses! Cargado Con Exito</strong></span>" +
                $"<button type = \"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
                $"<span aria-hidden=\"true\">&times;</span></button>" +
                $"</div>");
        }

        [HttpDelete("id"), ActionName("Delete")]
      [Route("/DeleteDocument/{id}/{doctype}")]
        public async Task<IActionResult> Delete(int id,int doctype)
        {
            var profileDocType = _DoctypeServices.GetAllById(id).Result;
            var DelecteDoc = profileDocType.FirstOrDefault(x=> x.DocTypeID==doctype);
            await _DoctypeServices.DeletedConfirmed(DelecteDoc);
            return new ObjectResult(
                $"<div class=\"alert alert - default alert - dismissible fade show\" role=\"alert\">" +
                $"<span class=\"alert - inner--icon\"><i class=\"ni ni - like - 2\"></i></span>" +
                $"< span class=\"alert-inner--text\"><strong>Susses! Cargado Con Exito</strong></span>" +
                $"<button type = \"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
                $"<span aria-hidden=\"true\">&times;</span></button>" +
                $"</div>");
        }
    }
}