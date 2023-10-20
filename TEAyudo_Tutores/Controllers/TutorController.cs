﻿using Application.DTO;
using Application.Exceptions;
using Application.Interface;
using Application.Model.DTO;
using Application.Model.Response;
using Microsoft.AspNetCore.Mvc;

namespace TEAyudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        private readonly ITutorService TutorService;

        public TutorController(ITutorService TutorService)
        {
            this.TutorService = TutorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTutor()
        {

            List<FullUsuarioResponse?> ListaTutorResponse = await TutorService.GetAllTutor();
            if (ListaTutorResponse == null)
            {
                var ObjetoAnonimo = new
                {
                    Mensaje = "La lista esta vacia."
                };
                return new JsonResult(ObjetoAnonimo) { StatusCode = 404 };
            }

            return Ok(ListaTutorResponse);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetTutorById(int Id)
        {
            FullUsuarioResponse? Tutor = await TutorService.GetTutorById(Id);

            if (Tutor == null)
            {
                var ObejetoAnonimo = new
                {
                    Mensaje = "No se encontro el tutor."
                };
                return NotFound(ObejetoAnonimo);
            }

            return Ok(Tutor);
        }

        [HttpPost]
        public async Task<ActionResult> PostTutor(TutorDTO TutorDTO)
        {
            bool Resultado = await TutorService.AddTutor(TutorDTO);
            //if (Resultado)
            //{
            return new JsonResult("Tutor aniadido exitosamente") { StatusCode = 201 };
            //}
            //else
            //{
            //    var ObjetoAnonimo = new
            //    {
            //        Mensaje = "No se ha podido crear el tutor debido a que ya existe una cuenta asociada al correo electronico ingresado."
            //    };
            //    return Conflict(ObjetoAnonimo);
            //}
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutTutor(int Id, FullUsuarioTutorDTO FullUsuarioTutorDTO)
        {
            try
            {
                FullUsuarioResponse? TutorResponse = await TutorService.PutTutor(Id, FullUsuarioTutorDTO);
                if (TutorResponse == null)
                {
                    var ObjetoAnonimo = new
                    {
                        Mensaje = "No se ha encontrado el tutor a actualizar."
                    };
                    return new JsonResult(ObjetoAnonimo) { StatusCode = 404 };
                }
                return new JsonResult(TutorResponse) { StatusCode = 201 };
            }
            catch (ConflictoException ex)
            {
                var ObjetoAnonimo = new
                {
                    Mensaje = ex.Message
                };
                return Conflict(ObjetoAnonimo);
            }
            catch (FormatException ex)
            {
                var ObjetoAnonimo = new
                {
                    Mensaje = ex.Message
                };
                return BadRequest(ObjetoAnonimo);
            }

        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteTutor(int Id)
        {
            FullUsuarioResponse? TutorResponse = await TutorService.DeleteTutor(Id);
            if (TutorResponse == null)
            {
                var ObjetoAnonimo = new
                {
                    Mensaje = "No se ha encontrado el tutor a eliminar."
                };
                return NotFound(ObjetoAnonimo);
            }
            return Ok(TutorResponse);
        }
    }
}
