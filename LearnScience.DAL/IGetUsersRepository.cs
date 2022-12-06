using LS.Core;
using System.Collections.Generic;

namespace LS.DAL
{
    /// <summary>
    /// 员工后台数据操作接口
    /// </summary>
    interface IGetUsersRepository
    {
        #region 操作网站用户数据
        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        User GetUser(string userName);

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        IEnumerable<User> GetUsers(int pageIndex = D.Default_IndexPage, int pageSize = D.Default_PageSize);

        /// <summary>
        /// 搜索用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="isLike">要求是等于操作还是Like操作</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        IEnumerable<User> SearchUsers(string userName, bool isLike = false, int pageIndex = D.Default_IndexPage, int pageSize = D.Default_PageSize);

        /// <summary>
        /// 获取全部用户的统计
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="isLike">包含还是等于用户名</param>
        /// <param name="role">那种角色</param>
        /// <returns></returns>
        int GetUsersTotal(string userName = null, bool isLike = false, UserRoles? role = null);
        #endregion
    }
}
