using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using Microsoft.EntityFrameworkCore.Metadata;
namespace LS.Core
{
    /// <summary>
    /// 用户和员工的基类型，抽象类。
    /// </summary>
    public abstract class People
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NikeName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Sexs Sex { get; set; } = Sexs.未设置;

        /// <summary>
        /// 头像图片的Url地址，或者本地图片文件全名
        /// </summary>
        public string FaceImageUrl { get; set; }

        /// <summary>
        /// 注册日期和时间
        /// </summary>
        public DateTime RegisterTime { get; set; } = DateTime.Now;
    }

    /// <summary>
    /// 网站用户类型
    /// </summary>
    public class User : People
    {
        /// <summary>
        /// Vip开始时间
        /// </summary>
        public DateTime VipStart { get; set; }

        /// <summary>
        /// Vip结束时间
        /// </summary>
        public DateTime VipEnd { get; set; }

        /// <summary>
        /// Vip级别
        /// </summary>
        public int VipLevel { get; set; }

        /// <summary>
        /// 用户角色
        /// </summary>
        public UserRoles Role { get; set; }

        /// <summary>
        /// 用户电子邮件
        /// </summary>
        public string EMail { get; set; }

        /// <summary>
        /// 邮箱已验证
        /// </summary>
        public bool EMailConfirmed { get; set; }

        public User() { }

        public User(string userName, string password, string email)
        {
            UserName = userName;
            Password = F.MD5Encrypt(password);
            EMail = email;
        }

        public User(string userName, string password, string email, DateTime start, DateTime end, int level)
        {
            UserName = userName;
            Password = F.MD5Encrypt(password);
            EMail = email;
            VipStart = start;
            VipEnd = end;
            VipLevel = level;
        }

        public static User VipTeacher(string userName, string password, string email, string nikeName)
        {
            User u = new User(userName, password, email);
            u.VipStart = DateTime.Now;
            u.VipEnd = DateTime.MaxValue;
            u.VipLevel = 1;
            u.Role = UserRoles.教师;
            u.NikeName = nikeName;
            return u;
        }

        public static User VipStudent(string userName, string nikeName)
        {
            string password = userName + "@122.org";
            string email = userName + "@122.com";
            User u = new User(userName, password, email);
            u.VipStart = DateTime.Now;
            u.VipEnd = DateTime.MaxValue;
            u.VipLevel = 1;
            u.Role = UserRoles.学生;
            u.NikeName = nikeName;
            return u;
        }

        public static User VipUser(string userName, string nikeName, UserRoles role)
        {
            string password = userName + "@122.org";
            string email = userName + "@122.com";
            User u = new User(userName, password, email);
            u.VipStart = DateTime.Now;
            u.VipEnd = DateTime.MaxValue;
            u.VipLevel = 1;
            u.Role = role;
            u.NikeName = nikeName;
            return u;
        }
    }

    public class Teacher
    {
        public Guid TeacherId { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Introduction { get; set; }
    }

    /// <summary>
    /// 用户关联
    /// </summary>
    public class UserPair
    {
        /// <summary>
        /// 发起关联者Id
        /// </summary>
        public Guid UserId1 { get; set; }

        /// <summary>
        /// 接受关联者Id
        /// </summary>
        public Guid UserId2 { get; set; }

        /// <summary>
        /// 关联关系
        /// </summary>
        public UserRelations Relation { get; set; }

        /// <summary>
        /// 关联状态
        /// </summary>
        public RelationStats Stat { get; set; }

        /// <summary>
        /// 最近关联操作的日期
        /// </summary>
        public DateTime LastStatTime { get; set; }
    }

    /// <summary>
    /// 员工类型
    /// </summary>
    public class Employee : People
    {
        /// <summary>
        /// 员工姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        public CertTypes CertType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string CertCode { get; set; }

        /// <summary>
        /// 部门Id
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// 入职时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 离职时间
        /// </summary>
        public DateTime EndTime { get; set; }
    }

    /// <summary>
    /// 账户数据
    /// </summary>
    public class UserAccount
    {
        public Guid UserId { get; set; }

        /// <summary>
        /// 剩余点数
        /// </summary>
        public int Balance { get; set; }

        /// <summary>
        /// 消费点数
        /// </summary>
        public int Consumption { get; set; }

        /// <summary>
        /// 收付款途径
        /// </summary>
        public PayWays Payway { get; set; } = PayWays.微信;

        /// <summary>
        /// 收付款账号(支付宝账号/微信账号/PayPal账号)
        /// </summary>
        public string PayAccount { get; set; }
    }

    /// <summary>
    /// 支付记录
    /// <para>用户或经营者支付记录</para>
    /// </summary>
    public class PayLog
    {
        /// <summary>
        /// 付款者Id
        /// </summary>
        public Guid PaymenterId { get; set; }

        /// <summary>
        /// 使用者Id
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 收款者Id
        /// </summary>
        public Guid CollecterId { get; set; }

        /// <summary>
        /// 支付途径
        /// </summary>
        public PayWays Payway { get; set; }

        /// <summary>
        /// 付款账户
        /// </summary>
        public string PayAccount { get; set; }

        /// <summary>
        /// 收款账户
        /// </summary>
        public string CollecterAccount { get; set; }

        /// <summary>
        /// 付款金额
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 付款时间
        /// </summary>
        public DateTime PayTime { get; set; }

        /// <summary>
        /// 用途
        /// </summary>
        public PayPurposes Purpose { get; set; }

        /// <summary>
        /// 备注说明
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 收款者确认
        /// </summary>
        public bool IsConfirm { get; set; }

        /// <summary>
        /// 确认时间
        /// </summary>
        public DateTime ConfirmTime { get; set; }

        /// <summary>
        /// 付款截图地址
        /// </summary>
        public string PayImageUrl { get; set; }
    }

    /// <summary>
    /// 申请提现
    /// </summary>
    public class ApplyCash {
        /// <summary>
        /// 提现者Id
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 提现金额
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 收款途径
        /// </summary>
        public PayWays CollectWay { get; set; }

        /// <summary>
        /// 收款账户
        /// </summary>
        public string CollectAccount { get; set; }

        /// <summary>
        /// 联系方式。
        /// <para>申请者提供一个联系方式，当提现有问题时联系用。</para>
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// 申请创建日期
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 支付状态
        /// <para>对于已经打款的申请关键信息将被复制到PayLog表</para>
        /// </summary>
        public PayStats Stat { get; set; }

        /// <summary>
        /// 最后处理日期
        /// <para>对于已经提现的申请，关键信息将会被复制到PayLog表</para>
        /// </summary>
        public DateTime LastTime { get; set; }

        /// <summary>
        /// 备注信息。所有未能完备表达的信息都可以填写在这里。
        /// </summary>
        public string Comment { get; set; }
    }

    /// <summary>
    /// 商品
    /// </summary>
    public class Commodity
    {
        /// <summary>
        /// Vip级别
        /// </summary>
        public int VipLevel { get; set; }

        /// <summary>
        /// Vip时长
        /// </summary>
        public int VipDays { get; set; }

        /// <summary>
        /// 答题明细保存时间
        /// <para>在VIP有效期内，答题明细的保存时间。最短时间是7天</para>
        /// </summary>
        public int Days { get; set; } = 7;

        /// <summary>
        /// 金额
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// 充值点数
        /// </summary>
        public int Points { get; set; }
    }

    /// <summary>
    /// 部门
    /// </summary>
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// 权限
    /// <para>每页面都要有权限设置，如果这个值为NULL，表示不需要权限，任何人都能访问</para>
    /// </summary>
    public class Purview
    {
        /// <summary>
        /// 功能代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 功能说明
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 所需角色
        /// </summary>
        public UserRoles NeedRole { get; set; }

        /// <summary>
        /// 部门Id。Id=0表示不限部门
        /// </summary>
        public int DepartmentId { get; set; }
    }

    /// <summary>
    /// 验证记录
    /// </summary>
    public class Verify
    { 
        public Guid UserId { get; set; }

        public VerifyWay Way { get; set; } = VerifyWay.Mail;

        public string Sendto { get; set; }

        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 限制时长。单位分钟。邮箱验证默认2880分钟，既48小时
        /// </summary>
        public int LimitMinutes { get; set; } = 2880;

        /// <summary>
        /// 如果是邮箱验证，为防止篡改设置了此字段，加在邮件内容的链接中。用于比对用。
        /// </summary>
        public string md5 { get; set; }
    }
}
