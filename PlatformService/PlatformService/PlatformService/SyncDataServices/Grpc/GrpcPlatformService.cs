using AutoMapper;
using Grpc.Core;
using PlatformService.Data;
using System.Threading.Tasks;

namespace PlatformService.SyncDataServices.Grpc
{
    public class GrpcPlatformService : GrpcPlatform.GrpcPlatformBase
    {
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;

        public GrpcPlatformService(IPlatformRepo platoformRepo, IMapper mapper)
        {
            _repository = platoformRepo;
            _mapper = mapper;
        }

        public override Task<PlatformResponce> GetAllPlatforms(GetAllRequest request,
            ServerCallContext context)
        {
            var response = new PlatformResponce();
            var platforms = _repository.GetAllPlatforms();

            foreach(var plat in platforms)
            {
                response.Platform.Add(_mapper.Map<GrpcPlatformModel>(plat));
            }

            return Task.FromResult(response);
        }
    }
}
