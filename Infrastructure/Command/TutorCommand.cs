using Application.DTO;
using Application.Interface;
using Application.Model.DTO;
using Application.Model.Response;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using System.Text.Json;
using TEAyudo_Tutores;
using System.Net;
using Application.Exceptions;

namespace Infrastructure.Command
{
    public class TutorCommand : ITutorCommand
    {
        private readonly TEAyudoContext Context;

        public TutorCommand(TEAyudoContext Context)
        {
            this.Context = Context;
        }


        public async Task<bool> AddTutor(Tutor Tutor, UsuarioDTO UsuarioDTO)
        {
            var Client = new RestClient("https://localhost:7174");
            var Request = new RestRequest("/api/Usuario");
            Request.AddJsonBody(UsuarioDTO);
            var Result = await Client.ExecutePostAsync<UsuarioResponse>(Request);
            UsuarioResponse response = JsonSerializer.Deserialize<UsuarioResponse>(Result.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (Result.StatusCode == HttpStatusCode.Created)
            {
                Tutor.UsuarioId = response.UsuarioId;
                await Context.Tutores.AddAsync(Tutor);
                await Context.SaveChangesAsync();
                return true;
            };
            return false;
        }

        public async Task<Tutor?> PutTutor(int Id, TutorDTO TutorDTO)
        {
            Tutor? Tutor = await Context.Tutores.Include(p => p.Pacientes).FirstOrDefaultAsync(f => f.TutorId == Id);
            if (Tutor != null)
            {
                //Agregar los datos a actualizar   
                Context.Tutores.Update(Tutor);
                Context.SaveChanges();
                return Tutor;
            }
            return null;
        }

        public async Task<UsuarioResponse?> PutUsuario(int Id, UsuarioDTO UsuarioDTO)
        {
            var Client = new RestClient("https://localhost:7174");
            var Request = new RestRequest("/api/Usuario/" + Id);
            Request.AddJsonBody(UsuarioDTO);
            var Result = await Client.ExecutePutAsync<UsuarioResponse>(Request);
            if (Result.StatusCode == HttpStatusCode.Conflict)
            {
                throw new ConflictoException("El correo electronico ya se encuentra asociado a otra cuenta");
            }
            if (Result.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new FormatException("Ha ingresado un formato de fecha erronea");
            }
            UsuarioResponse Response = JsonSerializer.Deserialize<UsuarioResponse>(Result.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return Response;
        }

        public async Task<Tutor?> DeleteTutor(int Id)
        {
            Tutor? Tutor = await Context.Tutores.Include(p => p.Pacientes).FirstOrDefaultAsync(f => f.TutorId == Id);
            if (Tutor != null)
            {
                Context.Tutores.Remove(Tutor);
                await Context.SaveChangesAsync();
                return Tutor;
            }
            return null;
        }

        public async Task<UsuarioResponse?> DeleteUsuario(int Id)
        {
            var Client = new RestClient("https://localhost:7174");
            var Request = new RestRequest("/api/Usuario/" + Id, Method.Delete);
            var Result = await Client.ExecuteAsync(Request);
            UsuarioResponse Response = JsonSerializer.Deserialize<UsuarioResponse>(Result.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return Response;
        }
    }
}
