using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepublicaEmpleos.Services.Interfaces;
using RepublicaEmpleos.Infrastructure;
using RepublicaEmpleos.Models;

namespace RepublicaEmpleos.Controllers
{
    [IgnoreAntiforgeryToken]
    public class LanguajeController : BaseController
    {
        private readonly ILanguajeServices<ProfileLanguage> _ProfileLanguageServices;

        public LanguajeController(ILanguajeServices<ProfileLanguage> ProfileLanguageServices)
        {
            _ProfileLanguageServices= ProfileLanguageServices;
        }

        [HttpGet("id")]
        [Route("/GetProfileLanguages/{ProfId}")]
        public async Task<IEnumerable<ProfileLanguage>> GetProfileLanguages(int ProfId)
        {
            return await _ProfileLanguageServices.GetAllById(ProfId);
        }

        // POST: ProfileLanguages/Create
        [HttpPost]
        [Route("/AddProfileLanguages")]
        public async Task<IActionResult> Create([FromBody] ProfileLanguage ProfileLanguage)
        {
            await _ProfileLanguageServices.CreateAsync(ProfileLanguage);
            return new ObjectResult(
                $"<div class=\"alert alert - default alert - dismissible fade show\" role=\"alert\">" +
                $"<span class=\"alert - inner--icon\"><i class=\"ni ni - like - 2\"></i></span>" +
                $"< span class=\"alert-inner--text\"><strong>Susses! Telefono Cargado Con Exito</strong></span>" +
                $"<button type = \"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">" +
                $"<span aria-hidden=\"true\">&times;</span></button>"+
                $"</div>");
        }

        // POST: ProfileLanguages/Edit/5
        [HttpPut("id")]
        [Route("/EditProfileLanguage/")]
        public async Task<IActionResult> Edit([FromBody]ProfileLanguage ProfileLanguage)
        {
            try
            {
                await _ProfileLanguageServices.EditAsync(ProfileLanguage);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_ProfileLanguageServices.Exists(ProfileLanguage.LanguageId, ProfileLanguage.ProfileId))
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
        [Route("/DelectProfileLanguage/{ProfId}/{langId}")]
        public async Task<IActionResult> Delete(int ProfId,int langId)
        {
            var ProfileLanguage = await _ProfileLanguageServices.FindByIdAsync(ProfId, langId);
            await _ProfileLanguageServices.DeletedConfirmed(ProfileLanguage);
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