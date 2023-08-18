using System.Security.Claims;
using TimelineManagement.Contracts;
using TimelineManagement.Data;
using TimelineManagement.DTOs.Account;
using TimelineManagement.DTOs.AccountRoles;
using TimelineManagement.Models;
using TimelineManagement.Utilities.Handlers;

namespace TimelineManagement.Services;

public class AccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IAccountRoleRepository _accountRoleRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IEmailHandler _emailHandler;
    private readonly ITokenHandler _tokenHandler;
    private readonly TimelineManagementDbContext _dbContext;

    public AccountService(IAccountRepository accountRepository, IRoleRepository roleRepository, IAccountRoleRepository accountRoleRepository, IEmployeeRepository employeeRepository, IEmailHandler emailHandler, ITokenHandler tokenHandler, TimelineManagementDbContext dbContext)
    {
        _accountRepository = accountRepository;
        _roleRepository = roleRepository;
        _accountRoleRepository = accountRoleRepository;
        _employeeRepository = employeeRepository;
        _emailHandler = emailHandler;
        _tokenHandler = tokenHandler;
        _dbContext = dbContext;
    }
    
    public string Login(LoginDto loginDto)
    {
        var getEmployee = _employeeRepository.GetByEmail(loginDto.Email);
        if (getEmployee is null)
        {
            return "0";
        }

        var getAccount = _accountRepository.GetByGuid(getEmployee.Guid);
        var handlerPassword = HashingHandler.ValidateHash(loginDto.Password, getAccount.Password);
        if (!handlerPassword)
        {
            return "0";
        }
        
        var claims = new List<Claim>
        {
            new Claim("Guid", getEmployee.Guid.ToString()),
            new Claim("FullName", $"{getEmployee.FirstName} {getEmployee.LastName}"),
            new Claim("Email", getEmployee.Email)
        };

        var employee = _employeeRepository.GetByEmail(loginDto.Email);
        var getRoles = _accountRoleRepository.GetRoleNamesByAccountGuid(employee.Guid);

        foreach (var getRole in getRoles)
        {
            claims.Add(new Claim(ClaimTypes.Role, getRole));
        }

        var generatedToken = _tokenHandler.GenerateToken(claims);
        if (generatedToken is null)
        {
            return "-1";
        }
        return generatedToken;
    }
    
    public RegisterDto? Register(RegisterDto registerDto)
    {
        using var transaction = _dbContext.Database.BeginTransaction();
        try
        {

            var employee = _employeeRepository.Create(new Employee
            {
                Guid = new Guid(),
                Nik = GenerateHandler.Nik(_employeeRepository.Getlastnik()),
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
                BirthDate = registerDto.BirthDate,
                HiringDate = registerDto.HiringDate,
                Gender = registerDto.Gender,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            });

            
            if (registerDto.Password != registerDto.ConfirmPassword)
            {
                return null;
            }
            var account = _accountRepository.Create(new Account
            {
                Guid = employee.Guid,
                Password = HashingHandler.GenerateHash(registerDto.Password),
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            });

            var getRole = _roleRepository.GetByName(registerDto.RoleName);
            if (getRole is null)
            {
                return null;
            }
            
            var accountRole = _accountRoleRepository.Create(new AccountRoleDto
            {
                AccountGuid = account.Guid,
                RoleGuid = getRole.Guid
            });
            
            var toDto = new RegisterDto
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                BirthDate = employee.BirthDate,
                Gender = employee.Gender,
                HiringDate = employee.HiringDate,
                RoleName = getRole.Name,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Password = account.Password,
            };
            
            transaction.Commit();
            return toDto;
        }
        catch 
        {
            transaction.Rollback();
            return null;
        }
    }
    
    public IEnumerable<AccountDto> GetAll()
    {
        var accounts = _accountRepository.GetAll();
        if (!accounts.Any())
        {
            return Enumerable.Empty<AccountDto>();
        }

        var accountDtos = new List<AccountDto>();
        foreach (var account in accounts)
        {
            accountDtos.Add((AccountDto)account);
        }

        return accountDtos;
    }
    
    public AccountDto? GetByGuid(Guid guid)
    {
        var account = _accountRepository.GetByGuid(guid);
        if (account is null)
        {
            return null;
        }

        return ((AccountDto)account);
    }

    public AccountDto? Create(NewAccountDto newAccountDto)
    {
        var account = _accountRepository.Create(newAccountDto);
        if (account is null)
        {
            return null;
        }

        return ((AccountDto)account);
    }
    
    public int Update(AccountDto accountDto)
    {
        var account = _accountRepository.GetByGuid(accountDto.Guid);
        if (account is null)
        {
            return -1;
        }

        Account toUpdate = accountDto;
        toUpdate.CreatedDate = account.CreatedDate;
        var result = _accountRepository.Update(toUpdate);
        return result ? 1 
            : 0;

    }

    public int Delete(Guid guid)
    {
        var account = _accountRepository.GetByGuid(guid);
        if (account is null)
        {
            return -1;
        }

        var result = _accountRepository.Delete(account);
        return result ? 1 
            : 0;
    }
    
    public int ForgotPassword(ForgotPasswordDto forgotPasswordDto)
    {
        //Mendapatkan Account Detail berdasarkan email
        var getAccountDetail = (from e in _employeeRepository.GetAll()
            join a in _accountRepository.GetAll() on e.Guid equals a.Guid
            where e.Email == forgotPasswordDto.Email
            select a).FirstOrDefault();
        
        _accountRepository.Clear();
        if (getAccountDetail is null)
        {
            return 0;
        }
        
        var otp = new Random().Next(111111, 999999);
        var account = new Account
        {
            Guid = getAccountDetail.Guid,   
            Password = getAccountDetail.Password,
            ExpiredDate = DateTime.Now.AddMinutes(5),
            Otp = otp,
            IsUsed = false,
            CreatedDate = getAccountDetail.CreatedDate,
            ModifiedDate = DateTime.Now
        };

        var isUpdate = _accountRepository.Update(account);

        if (!isUpdate)
        {
            return -1;
        }
        _emailHandler.SendEmail(forgotPasswordDto.Email, "Account - Forgot Password", $"Your otp is {otp}");
        
        return 1;
    }

    public int ChangePassword(ChangePasswordDto changePasswordDto)
    {
        var isExist = _employeeRepository.CheckEmail(changePasswordDto.Email);
        if (isExist is null)
        {
            return -1;
        }

        var getAccount = _accountRepository.GetByGuid(isExist.Guid);
        var account = new Account
        {
            Guid = getAccount.Guid,
            IsUsed = true,
            ModifiedDate = DateTime.Now,
            CreatedDate = getAccount.CreatedDate,
            Otp = getAccount.Otp,
            ExpiredDate = getAccount.ExpiredDate,
            Password = HashingHandler.GenerateHash(changePasswordDto.NewPassword)
        };

        if (getAccount.Otp != changePasswordDto.Otp)
        {
            return -2;
        }

        if (getAccount.IsUsed)
        {
            return -3;
        }

        if (getAccount.ExpiredDate < DateTime.Now)
        {
            return -4;
        }

        var isUpdate = _accountRepository.Update(account);
        if (!isUpdate)
        {
            return -2;
        }
        
        return 1;
    }
}