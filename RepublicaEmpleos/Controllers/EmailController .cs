using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepublicaEmpleos.Services.Interfaces;
using RepublicaEmpleos.Infrastructure;

namespace RepublicaEmpleos.Controllers
{
    [IgnoreAntiforgeryToken]
    public class EmailController : BaseController
    {
        private readonly IEmailServices<Email> _EmailServices;

        public EmailController(IEmailServices<Email> emailServices)
        {
            _EmailServices= emailServices;
        }

        [HttpGet("id")]
        [Route("/GetEmails/{id}")]
        public async Task<IEnumerable<Email>> GetEmails(int id)
        {
            return await _EmailServices.GetAllByIdAsync(id);
        }

        // POST: Emails/Create
        [HttpPost]
        [Route("/AddEmails")]
        public async Task<IActionResult> Create([FromBody] Email Email)
        {
            Email.Id = 0;
            await _EmailServices.CreateAsync(Email);
            return new ObjectResult(
                $"<div class=\"alert alert - default alert - dismissible fade show\" role=\"alert\">" +
                $"<span class=\"alert - inner--icon\"><i class=\"ni ni - like - 2\"></i></span>" +
                $"< span class=\"alert-inner--text\"><strong>Susses! Telefono Cargado Con Exito</strong></span>" +
                $"<button type = \"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
                $"<span aria-hidden=\"true\">&times;</span></button>"+
                $"</div>");
        }

        // POST: Emails/Edit/5
        [HttpPut("id")]
        [Route("/EditEmail/{id}")]
        public async Task<IActionResult> Edit(int id,[FromBody]Email Email)
        {
            if (id != Email.Id)
            {
                return NotFound();
            }
            try
            {
                await _EmailServices.EditAsync(Email);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_EmailServices.EmailExists(Email.Id))
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
                $"< span class=\"alert-inner--text\"><strong>Susses! Telefono Cargado Con Exito</strong></span>" +
                $"<button type = \"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
                $"<span aria-hidden=\"true\">&times;</span></button>" +
                $"</div>");
        }

        [HttpDelete("id"), ActionName("Delete")]
        [Route("/DelectEmail/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Email = await _EmailServices.FindByIdAsync(id);
            await _EmailServices.DeletedConfirmed(Email);
            return new ObjectResult(
                $"<div class=\"alert alert - default alert - dismissible fade show\" role=\"alert\">" +
                $"<span class=\"alert - inner--icon\"><i class=\"ni ni - like - 2\"></i></span>" +
                $"< span class=\"alert-inner--text\"><strong>Susses! Telefono Cargado Con Exito</strong></span>" +
                $"<button type = \"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
                $"<span aria-hidden=\"true\">&times;</span></button>" +
                $"</div>");
        }
    }
}