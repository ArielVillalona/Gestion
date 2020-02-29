﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepublicaEmpleos.Services.Interfaces;
using RepublicaEmpleos.Infrastructure;
using System.Linq;

namespace RepublicaEmpleos.Controllers
{
    [IgnoreAntiforgeryToken]
    public class VehicleController : BaseController
    {
        private readonly IGenericInterface<Vehicle> _VehicleServices;
        public VehicleController(IGenericInterface<Vehicle> VehicleServices)
        {
            _VehicleServices = VehicleServices;
        }
        [HttpGet("id")]
        [Route("/GetVehicle/{id}")]
        public async Task<IEnumerable<Vehicle>> GetVehicle(int id)
        {
            return await _VehicleServices.GetAllById(id);
        }
        // POST: Phones/Create
        [HttpPost]
        [Route("/AddVehicle")]
        public async Task<IActionResult> Create([FromBody] Vehicle vehicle)
        {
            await _VehicleServices.CreateAsync(vehicle);
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
        [Route("/EditVehicle/{id}")]
        public async Task<IActionResult> Edit(int id,[FromBody]Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }
            try
            {
                await _VehicleServices.EditAsync(vehicle);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_VehicleServices.Exists(vehicle.Id))
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
        [Route("/DeleteVehicle/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Vehicles = _VehicleServices.FindByIdAsync(id).Result;
            await _VehicleServices.DeletedConfirmed(Vehicles);
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