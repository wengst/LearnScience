using System;
using System.Collections.Generic;

namespace LS.Core
{
    /// <summary>
    /// 试题组
    /// </summary>
    public class TestPaper
    {
        /// <summary>
        /// 试题组Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 试题组标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 试题集说明
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 试题集
        /// </summary>
        public List<Subject> Subjects { get; } = new List<Subject>();

        /// <summary>
        /// 发布者Id
        /// </summary>
        public Guid AuthId { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime ReleaseTime { get; set; }

        /// <summary>
        /// 试题集状态
        /// </summary>
        public ReleaseStats Stat { get; set; }

        /// <summary>
        /// 是否免费
        /// </summary>
        public bool IsFree
        {
            get
            {
                return TotalPrice == 0;
            }
        }

        /// <summary>
        /// 试题集的价格
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// 试题集总价
        /// </summary>
        public int TotalPrice
        {
            get
            {
                int p = Price;
                for (int i = 0; i < Subjects.Count; i++)
                {
                    p += Subjects[i].Price;
                }
                return p;
            }
        }
    }

    /// <summary>
    /// 试题
    /// </summary>
    public class Subject
    {
        /// <summary>
        /// 试题Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 试题内容
        /// <para>试题内容，很可能超过8096字节</para>
        /// </summary>
        public string TextContent { get; set; }

        /// <summary>
        /// 对整道试题的解析
        /// <para>富文本格式</para>
        /// </summary>
        public string TextAnalyze { get; set; }

        /// <summary>
        /// 人员Id
        /// <para>用户或员工的Id</para>
        /// </summary>
        public Guid AuthId { get; set; }

        /// <summary>
        /// 试题首次发布时间
        /// </summary>
        public DateTime ReleaseTime { get; set; }

        /// <summary>
        /// 发布状态
        /// </summary>
        public ReleaseStats Stat { get; set; } = ReleaseStats.草稿;

        /// <summary>
        /// 是否免费
        /// </summary>
        public bool IsFree { get; set; } = true;

        /// <summary>
        /// 价格
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// 试题的小题
        /// </summary>
        public List<Question> Questions { get; } = new List<Question>();
    }

    /// <summary>
    /// 试题中的问题
    /// </summary>
    public class Question
    {
        /// <summary>
        /// 试题Id
        /// </summary>
        public Guid SujectId { get; set; }

        /// <summary>
        /// 试题类型
        /// <para>单选题、选择题、判断题和简答计算题。其中前三项是客观题，可以自动批改</para>
        /// </summary>
        public QuestionType Type { get; set; } = QuestionType.单选题;

        /// <summary>
        /// 以竖线“|”分隔的知识Code编号和能力水平的集合。
        /// <para>形如："A0001,1|B0233,2"</para>
        /// </summary>
        public string Knowledges { get; set; }

        /// <summary>
        /// 问题内容。可空
        /// <para>RichText文本内容</para>
        /// </summary>
        public string TextContent { get; set; }

        /// <summary>
        /// 小题的题号
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 文本解析内容。可空
        /// <para>RichText格式，文本解析内容的长度很可能超过8096字节</para>
        /// </summary>
        public string TextAnalyze { get; set; }

        /// <summary>
        /// 难度系数
        /// <para>最小值是1，最大值是5。数字越大，难度越大</para>
        /// </summary>
        public int Difficulty { get; set; }

        /// <summary>
        /// 得分
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// 选项符号
        /// <para>选项之间用半角逗号分隔</para>
        /// </summary>
        public string Options { get; set; } = "A,B,C,D";

        /// <summary>
        /// 答案
        /// <para>各可能的答案之间用半角竖线“|”分隔</para>
        /// </summary>
        public string Keys { get; set; }
    }

    /// <summary>
    /// 试题中的问题审核
    /// </summary>
    public class QuestionReView : Question
    {

    }

    /// <summary>
    /// 试题审核
    /// </summary>
    public class SubjectReView : Subject
    {

        /// <summary>
        /// 是否通过审核
        /// </summary>
        public bool IsAccept { get; set; }

        /// <summary>
        /// 审核不通过的原因
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime ReViewTime { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public Guid ReViewer { get; set; }
    }

    /// <summary>
    /// 试题组的审核
    /// </summary>
    public class TestPaperReView : TestPaper
    {
        /// <summary>
        /// 是否通过审核
        /// </summary>
        public bool IsAccept { get; set; }

        /// <summary>
        /// 审核不通过的原因
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime ReViewTime { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public Guid ReViewer { get; set; }
    }
}
