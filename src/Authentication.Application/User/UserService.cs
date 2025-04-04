using Authentication.Application.User.Create;
using Authentication.Application.User.TotalConsolidateUsers;
using Authentication.Domain.Abstractions;
using Authentication.Domain.Enums;
using Authentication.Domain.Repositories;

namespace Authentication.Application.User;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;

    }
    public async Task<Result<int>> CreteUserAsync(CreateUserCommand command)
    {
        var entity = new Domain.Entities.User(command.Name, command.Interests, command.Feelings, command.ValuesDescription)
            .SetAuthentication(command.Email, command.Password)
            .SetAge(command.Age)
            .SetOtherInfo(command.OtherInfo)
            .SetAddress(command.Address);

        switch (command.Status)
        {
            case EUserStatus.PENDING:
            entity.SetStatusPending();
                break;
            case EUserStatus.ACTIVE:
                entity.SetStatusActive();
                break;
            case EUserStatus.INACTIVE:
                entity.SetStatusInactive();
                break;
            default:
                entity.SetStatusPending();
                break;
        }
        
        if(await _userRepository.EmailExistsAsync(command.Email))
            return await Task.FromResult(Result.Error<int>("Este e-mail é invalido ou já está em uso."));
        
        var result = await _userRepository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return await Task.FromResult(Result.Ok(result.Id));
    }
    public async Task<Result<TotalConsolidateUsersResult>> GetTotalConsolidateUsers(int year)
    {
        var totalUsersConsolidated = await _userRepository.GetConsolidatedUsersAsync(year);
        
        var items = totalUsersConsolidated.Select(item => new TotalConsolidateUserItem().Map(item)).ToList();
        return Result.Ok(new TotalConsolidateUsersResult(items));
    }
}
