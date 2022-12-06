using System;

namespace LS.Core
{
    /// <summary>
    /// 知识文章
    /// </summary>
    public class Article
    {

        public Guid Id { get; set; }

        /// <summary>
        /// 文章作者Id
        /// </summary>
        public Guid AuthId { get; set; }

        /// <summary>
        /// 知识点Id
        /// </summary>
        public Guid KnowledgeId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 副标题
        /// </summary>
        public string SubTitle { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 发布日期
        /// </summary>
        public DateTime ReleaseTime { get; set; }
    }

    /// <summary>
    /// 知识文章审核
    /// </summary>
    public class ArticleReView : Article, IReView
    {
        public bool IsAccept { get; set; }
        public string Reason { get; set; }
        public DateTime ReViewTime { get; set; }
        public Guid ReViewerId { get; set; }
    }
}
