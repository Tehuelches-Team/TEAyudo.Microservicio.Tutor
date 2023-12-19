using Application.Interface;
using Application.Model.Response;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using System.Net;
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

        public async Task<int?> GetTutorByUsuarioId(int Id)
        {
            Tutor? tutor = await Context.Tutores.FirstOrDefaultAsync(s => s.UsuarioId == Id);
            return tutor.TutorId;
        }
    }
}
