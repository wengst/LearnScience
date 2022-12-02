using LS.Core;
using System.ComponentModel.DataAnnotations;

namespace LS.Web.Models
{
    /// <summary>
    /// 用户注册模型
    /// </summary>
    public class UserRegister : ViewModel
    {
        [Display(Name = C.UserName, Description = "汉字英文数字等的组合，字符个数在6~32之间"), Required()]
        public string UserName { get; set; }

        /// <summary>
        /// 注册时的用户角色只有学生和家长两种，教师角色是后申请的。角色有Flags标记，一个用户可以同时是学生/教师角色，也可以同时是家长/教师角色
        /// </summary>
        [Display(Name = C.Role, Description = "学生的监护人或学生本人"), Required()]
        public UserRoles Role { get; set; }

        [Display(Name = C.Password, Description = "汉字英文数字和符号的组合，字符个数在8~32之间"), Required()]
        public string Password { get; set; }

        [Display(Name = C.RePassword, Description = "要求与密码相同"), Required()]
        public string RePassword { get; set; }

        [Display(Name = C.EMail, Description = "请填写常用的油箱，用于激活账户、接收通知信息和修改密码等用"), Required()]
        public string EMail { get; set; }

        [Display(Name = C.VerificationCode, Description = "请输入图片中的字符"), Required()]
        public string VerificationCode { get; set; }
    }

    /// <summary>
    /// 用户登录模型
    /// </summary>
    public class UserLogin : ViewModel
    {
        [Display(Name = C.UserName), Required()]
        public string UserName { get; set; }

        [Display(Name = C.Password), Required()]
        public string Password { get; set; }

        [Display(Name = C.VerificationCode, Description = "请输入图片中的字符"), Required()]
        public string VerificationCode { get; set; }
    }

    /// <summary>
    /// 用户重置密码模型之提供用户名
    /// </summary>
    public class ResetPassword_SendEMail : ViewModel
    {
        [Display(Name = C.UserName), Required()]
        public string UserName { get; set; }

        [Display(Name = C.VerificationCode, Description = "请输入图片中的字符"), Required()]
        public string VerificationCode { get; set; }
    }

    /// <summary>
    /// 用户重置密码模型之更改密码
    /// </summary>
    public class ResetPassword_Change : ViewModel
    {
        [Display(Name = C.Password), Required()]
        public string Password { get; set; }

        [Display(Name = C.RePassword), Required()]
        public string RePassword { get; set; }
    }

    /// <summary>
    /// 登录后修改密码
    /// </summary>
    public class ChangePassword : ViewModel
    {
        [Display(Name = C.OldPassword), Required()]
        public string OldPassword { get; set; }

        [Display(Name = C.NewPassword), Required()]
        public string NewPassword { get; set; }

        [Display(Name = C.ReNewPassword), Required()]
        public string ReNewPassword { get; set; }
    }

    public class ChangeFaceImage : ViewModel
    {
        [Display(Name = C.FaceImageUrl)]
        public string FileName { get; set; }
    }

    /// <summary>
    /// 用户登录信息
    /// <para>用户登录后，用于显示在网页上的用户信息</para>
    /// </summary>
    public class UserLoginInfo : ViewModel
    {
        /// <summary>
        /// 用户名称。如果用户有昵称，则显示昵称，如果没有就显示用户名。
        /// </summary>
        [Display(Name = C.Name)]
        public string Name { get; set; }

        /// <summary>
        /// 用户角色字符串。如果同时具备多个角色，角色名之间用“/”分隔。
        /// </summary>
        [Display(Name = C.Role)]
        public string Role { get; set; }

        /// <summary>
        /// 用户头像的Url
        /// </summary>
        [Display(Name = C.FaceImageUrl)]
        public string FaceImgUrl { get; set; }
    }

    /// <summary>
    /// 用户自己的信息卡
    /// </summary>
    public class UserSelfCard : ViewModel
    {
        [Display(Name = C.UserName)]
        public string UserName { get; set; }

        [Display(Name = C.NikeName)]
        public string NikeName { get; set; }

        [Display(Name = C.EMail)]
        public string EMail { get; set; }

        [Display(Name = C.Vip)]
        public string IsVip { get; set; }

        [Display(Name = C.Role)]
        public string Role { get; set; }

        [Display(Name = C.FaceImageUrl)]
        public string FaceImageUrl { get; set; }

        [Display(Name = C.VipStartTime)]
        public string VipStarTime { get; set; }

        [Display(Name = C.VipEndTime)]
        public string VipEndTime { get; set; }

        [Display(Name = C.VipLength)]
        public string VipLength { get; set; }
    }
}
