using UserWebAPI.Models;
using System.Threading;
using System.Linq;
using UserWebAPI.ViewModels;
using Microsoft.EntityFrameworkCore;
namespace UserWebAPI.Repository
{
    public class UserRepositorry:IUserRepositorry
    {
        private EMP_CURDContext emp_CurdContext;

        public UserRepositorry(EMP_CURDContext _EMP_CURDContext)
        {
            emp_CurdContext = _EMP_CURDContext;
        }



        public async Task<List<tbUserViewModels>> GetUsers()
        {
            if (emp_CurdContext != null)
            {
                return await (from u in emp_CurdContext.TblUsers
                              select new tbUserViewModels
                              {
                                  IUserId = u.IUserId,
                                  StrFirstName = u.StrFirstName,
                                  StrLastName = u.StrLastName,
                                  StrEmail = u.StrEmail,
                                  DtDateOfBirth = u.DtDateOfBirth,
                              }
                        ).ToListAsync();
            
            }
            return null;
        }

        public async Task<tbUserViewModels> GetUsers(int UserID)
        {
            if (emp_CurdContext != null)
            {
                return await(from u in emp_CurdContext.TblUsers where u.IUserId == UserID
                             select new tbUserViewModels
                             {
                                 IUserId = u.IUserId,
                                 StrFirstName = u.StrFirstName,
                                 StrLastName = u.StrLastName,
                                 StrEmail = u.StrEmail,
                                 DtDateOfBirth = u.DtDateOfBirth,
                             }
                        ).FirstOrDefaultAsync();

            }
            return null;
        }
        public async Task<bool> CheckUserExistByEmail(string email)
        {
            if (emp_CurdContext != null)
            {
                var user = await emp_CurdContext.TblUsers
                 .FirstOrDefaultAsync(e => e.StrEmail == email);
                if (user != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }

        }

        public async Task<int> AddUsers(tbUserViewModels User)
        {
            if (emp_CurdContext != null)
            {
                var _tblUser = new TblUser()
                {
                    IUserId = User.IUserId,
                    StrFirstName = User.StrFirstName,
                    StrLastName = User.StrLastName,
                    StrEmail = User.StrEmail,
                    DtDateOfBirth = User.DtDateOfBirth
                };
                emp_CurdContext.TblUsers.AddAsync(_tblUser);
               await emp_CurdContext.SaveChangesAsync();
                       return _tblUser.IUserId;

            }
            return 0;
        }

        public async Task<int> DeleteUsers(int UserID)
        {
            int result = 0;
            if (emp_CurdContext != null)
            {
                var _user = await emp_CurdContext.TblUsers.FindAsync(UserID);

                if (_user == null)
                {
                    return 0;
                }
                emp_CurdContext.TblUsers.Remove(_user);
                result = await emp_CurdContext.SaveChangesAsync();



          

            }
            return result;
        }

        public async Task<int> UpdateUsers(int UserID, tbUserViewModels User)
        {
            int result = 0;
            if (emp_CurdContext != null)
            {
                if (User != null)
                {
                    var _tblUser = new TblUser()
                    {
                        IUserId = User.IUserId,
                        StrFirstName = User.StrFirstName,
                        StrLastName = User.StrLastName,
                        StrEmail = User.StrEmail,
                        DtDateOfBirth = User.DtDateOfBirth
                    };
                    emp_CurdContext.TblUsers.Update(_tblUser);
                    result = await emp_CurdContext.SaveChangesAsync();

                }



            }
            return result;
        }
    }
}
