using System;
using System.Collections.Generic;
using System.Text;
using LS.Core;

namespace LS.DAL
{
    /// <summary>
    /// 用户/员工资料库数据操作接口
    /// </summary>
    interface IPeopleRepository
    {
        #region 登录/注册
        /// <summary>
        /// 注册新用户
        /// <para>表单项：用户名、角色(学员或家长)、密码、重复密码、邮箱地址、验证码</para>
        /// <para>用户提交表单，通过网页的基本验证后，保存注册信息到数据库，同时创建一封注册邮件到用户邮箱，返回需要用户确认邮箱的提示，以及登录链接</para>
        /// <para>本方法保存用户注册信息，且创建一份注册邮件(邮箱验证邮件)，保存到数据库，并发送邮箱验证邮件到用户邮箱</para>
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="pwd">密码</param>
        /// <param name="role">角色</param>
        /// <param name="email">油箱地址</param>
        /// <returns></returns>
        User RegisterUser(string userName, string pwd, UserRoles role, string email);

        /// <summary>
        /// 用户登录
        /// <para>表单项：用户名、密码、验证码</para>
        /// <para>用户提交表单项，经过后台服务器验证后，本方法负责进行数据库验证，如果用户存在则返回User实例，如果不存在则返回NULL</para>
        /// <para>本方法还会记录用户的登录信息(用户名、登录时间、客户端IP)</para>
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        User LoginUser(string userName, string pwd);

        /// <summary>
        /// 邮箱验证之邮箱确认
        /// <para>用户点击邮件内的链接地址链接到网站的邮件页面，输入用户自己的用户名。提交验证</para>
        /// <para>网站判断用户提交的用户名是否在邮箱确认表中存在，md5值是否与找到的记录一致，如果一致，则置用户表中的EMailConfirmed为true，从邮箱确认表中删除确认记录</para>
        /// <param name="userName"></param>
        /// <returns></returns>
        bool ConfirmEMail(string userName);
        #endregion

        #region 基本信息
        /// <summary>
        /// 修改基本信息
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="nikeName">昵称</param>
        /// <param name="sex">性别</param>
        /// <param name="faceImageUrl">头像文件地址</param>
        /// <returns></returns>
        bool ChangeProfiles(Guid userId, string nikeName, Sexs sex, string faceImageUrl = null);

        /// <summary>
        /// 改变头像
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="userName">用户名</param>
        /// <param name="faceImageUrl">头像地址</param>
        /// <returns></returns>
        bool ChangeFaceImage(Guid userId, string userName, string faceImageUrl);

        /// <summary>
        /// 学生申请成为教师。
        /// <para>学生或家长能申请成为教师。要想成为教师的一个前提条件是至少提交三份高质量的试题组。</para>
        /// <para>学生或家长可创建试题、至少三份试题组，用于审核，审核通过后，可申请成为教师角色，通过审核的试题组可直接发布。</para>
        /// </summary>
        /// <param name="userId">申请者的Id</param>
        /// <returns></returns>
        bool ApplyToTeacher(Guid userId);
        #endregion

        #region 账户安全
        /// <summary>
        /// 忘记密码——发送修改密码链接
        /// </summary>
        /// <param name="userName"></param>
        bool ForgetPassword_SendMail(string userName);

        /// <summary>
        /// 忘记密码——重置密码
        /// <para>充值密码需要提供用户名，防止用户输错邮箱导致密码被修改</para>
        /// </summary>
        bool ForgetPassword_ResetPassword(string userName);

        /// <summary>
        /// 修改密码
        /// <para>密码修改逻辑是先查找Id和旧密码相符的记录，如果不存在则不修改，返回false。如果存在则修改，并返回true</para>
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="oldpwd">旧密码</param>
        /// <param name="newpwd">新密码</param>
        /// <returns></returns>
        bool ChangePassword(Guid userId, string oldpwd, string newpwd);
        #endregion

        #region 资金往来
        /// <summary>
        /// 设置用户默认的收付款账户
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="payWay">收付款途径</param>
        /// <param name="payAccount">收付款账户</param>
        /// <returns></returns>
        bool ChangeAccount(Guid userId, PayWays payWay, string payAccount);

        /// <summary>
        /// 账户充值
        /// </summary>
        /// <param name="payLog">付款信息</param>
        /// <returns></returns>
        bool AccountCharge(PayLog payLog);

        /// <summary>
        /// 获取用户的充值记录
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<PayLog> GetMyPayLogs(Guid userId);

        /// <summary>
        /// 申请提现
        /// </summary>
        /// <param name="applyCash"></param>
        /// <returns></returns>
        bool ApplyCash(ApplyCash applyCash);

        /// <summary>
        /// 获取用户的提现记录
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IEnumerable<ApplyCash> GetMyApplyCash(Guid userId);

        /// <summary>
        /// 用户确认提现
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        bool ConfirmCash(Guid userid);
        #endregion

        #region 关系管理
        /// <summary>
        /// 关注用户
        /// <para>如果关注和被关注的双方在库中没有记录，则必须传递双方关系。反之则不用传递关系参数</para>
        /// </summary>
        /// <param name="meId">申请者Id</param>
        /// <param name="toId">对方的Id</param>
        /// <param name="relation">关联关系</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        bool SubscribeUser(Guid meId, Guid toId, UserRelations? relation = null, int pageIndex = D.Default_IndexPage, int pageSize = D.Default_PageSize);

        /// <summary>
        /// 获取我的关注者人数
        /// </summary>
        /// <param name="meId">我的用户ID</param>
        /// <returns></returns>
        int GetSubscribeTotal(Guid meId);

        /// <summary>
        /// 取消关注
        /// </summary>
        /// <param name="meId">申请者Id</param>
        /// <param name="toId">对方Id</param>
        /// <returns></returns>
        bool CancelSubscribe(Guid meId, Guid toId);

        /// <summary>
        /// 获取我的粉丝
        /// </summary>
        /// <param name="meId">我的Id</param>
        /// <param name="relation">关系</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        IEnumerable<User> GetMyFollows(Guid meId, UserRelations? relation = null, int pageIndex = D.Default_IndexPage, int pageSize = D.Default_PageSize);

        /// <summary>
        /// 获取我的粉丝数
        /// </summary>
        /// <param name="meId">我的用户Id</param>
        /// <param name="relation">配对关系</param>
        /// <returns></returns>
        int GetMyFollowTotal(Guid meId, UserRelations? relation = null);

        /// <summary>
        /// 获取我的关注
        /// </summary>
        /// <param name="meId">我的Id</param>
        /// <param name="relation">关系</param>
        /// <returns></returns>
        IEnumerable<User> GetMySubscribes(Guid meId, UserRelations? relation = null);

        /// <summary>
        /// 获取我的朋友
        /// </summary>
        /// <param name="meId">我的Id</param>
        /// <param name="relation">关系</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        IEnumerable<User> GetMyFriends(Guid meId, UserRelations? relation = null, int pageIndex = D.Default_IndexPage, int pageSize = D.Default_PageSize);

        /// <summary>
        /// 获取我的朋友总数
        /// </summary>
        /// <param name="meId">我的用户Id</param>
        /// <param name="relation">配对关系</param>
        /// <returns></returns>
        int GetMyFriendTotal(Guid meId, UserRelations? relation = null);
        #endregion
    }
}
