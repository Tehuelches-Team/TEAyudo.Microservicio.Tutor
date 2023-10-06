using Application.DTO;
using Application.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ITutorService
    {
        Task<TutorResponse?> GetTutorById(int Id);
        Task<bool> AddTutor(TutorDTO TutorDTO);
    }
}
