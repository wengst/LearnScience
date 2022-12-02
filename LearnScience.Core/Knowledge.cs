using System;

namespace LS.Core
{
    /// <summary>
    /// 知识
    /// </summary>
    public class Knowledge
    {
        /// <summary>
        /// 父知识编码
        /// </summary>
        public string ParentCode { get; set; }

        /// <summary>
        /// 知识编码。
        /// <para>建议在4个字符以内，全大写</para>
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 知识标题。字符长度控制在8字符以内。
        /// <para>每个数字、字母和汉字算一个</para>
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 备注说明。可空
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 是否过期
        /// <para>已经过期的知识不呈现在用户端。</para>
        /// </summary>
        public bool IsExpired { get; set; }

        /// <summary>
        /// 发布该知识的员工Id。
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime ReleaseTime { get; set; }

        /// <summary>
        /// 需要达到的最高能力水平
        /// </summary>
        public AbilityLeveles Level { get; set; } = AbilityLeveles.了解;

        /// <summary>
        /// 知识的依赖项。
        /// <para>该值是以逗号“,”分隔的Code代码集合</para>
        /// </summary>
        public string Relies { get; set; }

        public static Knowledge Create(string c,string title,string comment,AbilityLeveles al) {
            Knowledge k = new Knowledge();
            k.Code = c;
            k.Title = title;
            k.Comment = comment;
            k.Level = AbilityLeveles.了解;
            k.Relies = "";
            k.ReleaseTime = DateTime.Now;
            k.IsExpired = false;
            k.ParentCode = "";
            return k;
        }
    }
}
