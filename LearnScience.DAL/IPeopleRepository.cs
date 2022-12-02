using System;
using System.Collections.Generic;
using System.Text;
using LS.Core;

namespace LS.DAL
{
    interface IPeopleRepository
    {
        /// <summary>
        /// 注册新用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="role">角色</param>
        /// <param name="email">油箱地址</param>
        /// <returns></returns>
        User RegisterUser(string userName,string pwd,UserRoles role,string email);

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        User LoginUser(string userName,string pwd);

        /// <summary>
        /// 忘记密码——发送修改密码链接
        /// </summary>
        /// <param name="userName"></param>
        bool ForgetPassword_SendMail(string userName);

        /// <summary>
        /// 忘记密码——重置密码
        /// </summary>
        bool ForgetPassword_ResetPassword();

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="oldpwd">旧密码</param>
        /// <param name="newpwd">新密码</param>
        /// <returns></returns>
        bool ChangePassword(string userName,string oldpwd,string newpwd);

        /// <summary>
        /// 改变头像
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="faceImageUrl">头像地址</param>
        /// <returns></returns>
        bool ChangeFaceImage(string userName, string faceImageUrl);

        /// <summary>
        /// 学生申请成为教师。
        /// <para>学生或家长能申请成为教师。要想成为教师的一个前提条件是至少提交三份高质量的试题组。</para>
        /// <para>学生或家长可创建试题、至少三份试题组，用于审核，审核通过后，可申请成为教师角色，通过审核的试题组可直接发布。</para>
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        bool ApplyForTeacher(string userName);

        /// <summary>
        /// 关联某用户
        /// <para>家长和学员的关联，同学和同学的关联，同学和教师的关联</para>
        /// <para>互关、关注、粉丝</para>
        /// </summary>
        /// <param name="userName">某用户的用户名</param>
        /// <param name="relation">关联关系</param>
        /// <returns></returns>
        bool FollowUser(string userName,UserRelations relation);

        /// <summary>
        /// 改变关注状态
        /// </summary>
        /// <param name="stat">关注状态</param>
        /// <returns></returns>
        bool ChangeFollow(RelationStats stat);
    }
}
