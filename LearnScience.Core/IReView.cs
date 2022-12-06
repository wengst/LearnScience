using System;
using System.Collections.Generic;
using System.Text;

namespace LS.Core
{
    /// <summary>
    /// 内容审核属性接口
    /// </summary>
    interface IReView
    {
        /// <summary>
        /// 是否通过审核
        /// </summary>
        public bool IsAccept { get; set; }

        /// <summary>
        /// 如果审核不通过，原因是什么
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime ReViewTime { get; set; }

        /// <summary>
        /// 审核者Id
        /// </summary>
        public Guid ReViewerId { get; set; }
    }
}
