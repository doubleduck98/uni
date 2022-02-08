﻿using System.Configuration;
using System.Linq;
using System.Web.Security;

namespace zad2
{
    public class CustomMembershipProvider : MembershipProvider
    {
        public override bool EnablePasswordRetrieval => throw new System.NotImplementedException();

        public override bool EnablePasswordReset => throw new System.NotImplementedException();

        public override bool RequiresQuestionAndAnswer => throw new System.NotImplementedException();

        public override string ApplicationName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public override int MaxInvalidPasswordAttempts => throw new System.NotImplementedException();

        public override int PasswordAttemptWindow => throw new System.NotImplementedException();

        public override bool RequiresUniqueEmail => throw new System.NotImplementedException();

        public override MembershipPasswordFormat PasswordFormat => throw new System.NotImplementedException();

        public override int MinRequiredPasswordLength => throw new System.NotImplementedException();

        public override int MinRequiredNonAlphanumericCharacters => throw new System.NotImplementedException();

        public override string PasswordStrengthRegularExpression => throw new System.NotImplementedException();

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new System.NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new System.NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new System.NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new System.NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new System.NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            var cs = ConfigurationManager.ConnectionStrings["aspdotnetConnectionString"].ConnectionString;
            using (var ctx = new UsersDataContext(cs))
            {
                var user = ctx.USER.Where(u => email == u.email).FirstOrDefault();
                if (user == null)
                {
                    return string.Empty;
                }
                return user.nazwa;
            }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new System.NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new System.NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new System.NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            var cs = ConfigurationManager.ConnectionStrings["aspdotnetConnectionString"].ConnectionString;
            using (var ctx = new UsersDataContext(cs))
            {
                var dbPassword = (from user in ctx.USER where user.email == username
                                 join pwd in ctx.PASSWORD on user.id equals pwd.userID
                                 select pwd.password1).FirstOrDefault();
                if (dbPassword == null)
                {
                    return false;
                }
                if (!BCrypt.Net.BCrypt.EnhancedVerify(password, dbPassword))
                {
                    return false;
                }
                ctx.Dispose();
            }
            return true;
        }
    }
}