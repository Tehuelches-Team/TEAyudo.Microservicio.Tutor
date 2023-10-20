using Application.Interface;
using Application.Model.Response;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;
using RestSharp;
using TEAyudo_Tutores;
using System.Text.Json;

namespace Infrastructure.Query
{
    public class TutorQuery : ITutorQuery
    {
        private readonly TEAyudoContext Context;

        public TutorQuery(TEAyudoContext Context)
        {
            this.Context = Context;
        }



        public async Task<Tutor?> GetTutorById(int Id)
        {
            Tutor? Tutor = await Context.Tutores.Include(f => f.Pacientes).FirstOrDefaultAsync(t => t.TutorId == Id);
            return Tutor;
        }


        public async Task<List<Tutor>> GetAllTutores()
        {
            List<Tutor> ListaTutor = await Context.Tutores.Include(f => f.Pacientes).ToListAsync();
            return ListaTutor;
        }

        public async Task<List<UsuarioResponse>> GetAllUsuarios()
        {
            var Client = new RestClient("https://localhost:7174");
            var Resquest = new RestRequest("/api/Usuario");
            RestResponse Response = await Client.ExecuteGetAsync(Resquest);
            //return await Client.GetJsonAsync<List<UsuarioResponse>>("/api/Usuario");
            if (Response.StatusCode == HttpStatusCode.NotFound) 
            {
                return null;
            }
            return JsonSerializer.Deserialize<List<UsuarioResponse>>(Response.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<UsuarioResponse> GetUsuarioById(int Id)
        {
            var Client = new RestClient("https://localhost:7174");
            return await Client.GetJsonAsync<UsuarioResponse>("/api/Usuario/" + Id);
        }
    }
}
