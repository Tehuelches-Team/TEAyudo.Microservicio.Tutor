using Application.DTO;
using Application.Interface;
using Application.Model.Response;
using Azure.Core;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace TEAyudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorController : ControllerBase
    {
        private readonly ITutorService TutorService;
        private readonly IFiltrarUsuariosTutores FiltrarUsuariosTutores;

        public TutorController(ITutorService TutorService, IFiltrarUsuariosTutores FiltrarUsuariosTutores)
        {
            this.TutorService = TutorService;
            this.FiltrarUsuariosTutores= FiltrarUsuariosTutores;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTutor()
        {

            List<TutorResponse> ListaTutorResponse = await TutorService.GetAllTutor();
            if (ListaTutorResponse.Count == 0)
            {
                var ObjetoAnonimo = new
                {
                    Mensaje = "La lista esta vacia."
                };
                return Ok(ObjetoAnonimo);
            }

            //var Client = new RestClient("https://localhost:7174");
            List<UsuarioResponse> List = new List<UsuarioResponse>();
            foreach (var item in ListaTutorResponse)
            {
                var Client = new RestClient("https://localhost:7174");
                var Result = await Client.GetJsonAsync<UsuarioResponse>("/api/Usuario/" + item.UsuarioId);
                List.Add(Result);
            }
            //var Result = await Client.GetJsonAsync<List<UsuarioResponse>>("/api/Usuario");
            List = FiltrarUsuariosTutores.Filtrar(ListaTutorResponse,List);

            return Ok(List);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetTutorById(int Id)
        {
            TutorResponse? Tutor = await TutorService.GetTutorById(Id);

            if (Tutor == null)
            {
                var ObejetoAnonimo = new
                {
                    Mensaje = "No se encontro el tutor."
                };
                return NotFound(ObejetoAnonimo);
            }
            List<TutorResponse> ListTutor = new List<TutorResponse>();
            ListTutor.Add(Tutor);
            var Client = new RestClient("https://localhost:7174");
            var Result = await Client.GetJsonAsync<UsuarioResponse>("/api/Usuario/" + Tutor.UsuarioId);
            List<UsuarioResponse> List = new List<UsuarioResponse>();
            List.Add(Result);
            List = FiltrarUsuariosTutores.Filtrar(ListTutor,List);
            return Ok(List);
        }

        [HttpPost]
        public async Task<ActionResult> PostTutor(TutorDTO TutorDTO)
        {
            bool Resultado = await TutorService.AddTutor(TutorDTO);
            if (Resultado)
            {
                return new JsonResult("Tutor aniadido exitosamente") { StatusCode = 201 };
            }
            else
            {
                var ObjetoAnonimo = new
                {
                    Mensaje = "No se ha podido crear el tutor."
                };
                return BadRequest(ObjetoAnonimo);
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> PutTutor(int Id, TutorDTO TutorDTO)
        {
            TutorResponse? TutorResponse = await TutorService.PutTutor(Id, TutorDTO);
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

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteTutor(int Id)
        {
            TutorResponse? TutorResponse = await TutorService.DeleteTutor(Id);
            if (TutorResponse == null)
            {
                var ObjetoAnonimo = new
                {
                    Mensaje = "No se ha encontrado el tutor a eiminar."
                };
                return NotFound(ObjetoAnonimo);
            }
            return Ok(TutorResponse);
        }
    }
}
