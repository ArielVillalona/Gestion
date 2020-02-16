using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepublicaEmpleos.Data;
using RepublicaEmpleos.Services.Interfaces;
using RepublicaEmpleos.Infrastructure;

namespace RepublicaEmpleos.Controllers
{
    [IgnoreAntiforgeryToken]
    public class VehicleController : BaseController
    {
        private readonly IPhoneServices<Phone> _phoneServices;

        public VehicleController(IPhoneServices<Phone> phoneServices)
        {
            _phoneServices = phoneServices;
        }

        [HttpGet("id")]
      //  [Route("/GetPhones/{id}")]
        public async Task<IEnumerable<Phone>> GetPhones(int id)
        {
            return await _phoneServices.GetAllById(id);
        }

        // POST: Phones/Create
        [HttpPost]
      //  [Route("/AddPhones")]
        public async Task<IActionResult> Create([FromBody] Phone phone)
        {
            phone.Id = 0;
            await _phoneServices.CreateAsync(phone);
            return new ObjectResult(
                $"<div class=\"alert alert - default alert - dismissible fade show\" role=\"alert\">" +
                $"<span class=\"alert - inner--icon\"><i class=\"ni ni - like - 2\"></i></span>" +
                $"< span class=\"alert-inner--text\"><strong>Susses! Telefono Cargado Con Exito</strong></span>" +
                $"<button type = \"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
                $"<span aria-hidden=\"true\">&times;</span></button>"+
                $"</div>");
        }

        // POST: Phones/Edit/5
        [HttpPut("id")]
     //   [Route("/Editphone/{id}")]
        public async Task<IActionResult> Edit(int id,[FromBody]Phone phone)
        {
            if (id != phone.Id)
            {
                return NotFound();
            }
            try
            {
                await _phoneServices.EditAsync(phone);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_phoneServices.PhoneExists(phone.Id))
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
      //  [Route("/DelectPhone/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var phone = await _phoneServices.FindByIdAsync(id);
            await _phoneServices.DeletedConfirmed(phone);
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