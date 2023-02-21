using AutoMapper;
using CSharp_API_Newspaper.Data.Data;
using CSharp_API_Newspaper.Data.Data.Entities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TimekeeperAPI.Common.Utils;

namespace CSharp_API_Newspaper.Business.Services
{
    public class PostHanlder : IPostHanlder
    {
        private readonly NPDBContext _context;
        private readonly IMapper _mapper;

        public PostHanlder(NPDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response> CreatePost(PostCreateUpdateModel param)
        {
            try
            {
                var postToCreate = new NP_Post()
                {

                };

                await _context.AddAsync(postToCreate);

                var status = await _context.SaveChangesAsync();

                if (status <= 0)
                    return new ResponseError(HttpStatusCode.NotFound, "create save failed.");

                var data = _mapper.Map<MemberViewModel>(postToCreate);

                return new ResponseObject<MemberViewModel>(data, "create success.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, string.Empty);
                Log.Error("Param: {@Param}", param);
                return new Response<MemberViewModel>
                {
                    Data = null,
                    Message = ex.Message,
                    Code = HttpStatusCode.InternalServerError
                };
            }
        }

        public Task<Response> DeletePost(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> GetAllPost(PostQueryModel query)
        {
            throw new NotImplementedException();
        }

        public Task<Response> GetPostById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdatePost(Guid id, PostCreateUpdateModel param)
        {
            throw new NotImplementedException();
        }
    }
}
