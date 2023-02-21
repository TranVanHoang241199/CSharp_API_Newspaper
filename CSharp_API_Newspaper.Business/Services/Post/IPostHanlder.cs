using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimekeeperAPI.Common.Utils;

namespace CSharp_API_Newspaper.Business.Services
{
    public interface IPostHanlder
    {

        Task<Response> GetAllPost(PostQueryModel query);
        Task<Response> GetPostById(Guid id);
        Task<Response> CreatePost(PostCreateUpdateModel param);
        Task<Response> UpdatePost(Guid id, PostCreateUpdateModel param);
        Task<Response> DeletePost(Guid id);

        /*Task<Response> CreatePost(AdminCreateUpdateModel param);
        Task<Response> CreatePost(AdminCreateUpdateModel param);
        Task<Response> CreatePost(AdminCreateUpdateModel param);
        Task<Response> CreatePost(AdminCreateUpdateModel param);*/

    }
}
