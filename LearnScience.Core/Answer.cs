using System;

namespace LS.Core
{

    /// <summary>
    /// 试题组答题
    /// <para>记录用户答题信息的数据类型</para>
    /// </summary>
    public class TestPaperAnswer
    {
        /// <summary>
        /// 试题组回答Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 答题者Id
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 试题组Id
        /// </summary>
        public Guid TestPaperId { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 超期时间。默认24小时
        /// <para>单位是小时</para>
        /// </summary>
        public int ExpiredHours { get; set; } = 24;

        /// <summary>
        /// 超期时间
        /// </summary>
        public DateTime ExpiredTime { get { return StartTime.AddHours(ExpiredHours); } }

        /// <summary>
        /// 答题状态
        /// </summary>
        public AnswerStats Stat { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 完成日期
        /// </summary>
        public DateTime CompleteTime { get; set; }

        /// <summary>
        /// 保存到什么时候
        /// </summary>
        public DateTime SaveToTime { get; set; }
    }

    /// <summary>
    /// 问题答题
    /// </summary>
    public class QuestionAnswer
    {
        /// <summary>
        /// 每个问题回答的Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 试题组回答Id
        /// </summary>
        public Guid TestPaperAnswerId { get; set; }

        /// <summary>
        /// 试题回答Id
        /// </summary>
        public Guid SubjectAnswerId { get; set; }

        /// <summary>
        /// 问题回答Id
        /// </summary>
        public Guid QuestionId { get; set; }

        /// <summary>
        /// 我的回答
        /// </summary>
        public string Answer { get; set; }

        /// <summary>
        /// 是否正确
        /// </summary>
        public bool IsRight { get; set; }

        /// <summary>
        /// 我的得分
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// 批改者Id。客观题的Id是系统。
        /// </summary>
        public Guid CorrectId { get; set; }

        /// <summary>
        /// 教师评语。可空
        /// </summary>
        public string TeacherComment { get; set; }

        /// <summary>
        /// 我的评价。可空
        /// </summary>
        public string MyComment { get; set; }
    }

    /// <summary>
    /// 用户的知识目标
    /// </summary>
    public class UserKnowledgeTarget
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 哪一年
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// 哪个月
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// 一年内的第几周
        /// </summary>
        public int Week { get; set; }

        /// <summary>
        /// 知识编号
        /// </summary>
        public string KnowledgeCode { get; set; }

        /// <summary>
        /// 答题总数
        /// </summary>
        public int AnswerTotal { get; set; }

        /// <summary>
        /// 正确总数
        /// </summary>
        public int RightTotal { get; set; }

        /// <summary>
        /// 得分总数
        /// </summary>
        public int FullScoreTotal { get; set; }

        /// <summary>
        /// 回答正确得分总数
        /// </summary>
        public int ScoreRightTotal { get; set; }

        /// <summary>
        /// 能力总得分
        /// </summary>
        public int AbilityLevelTotal { get; set; }

        /// <summary>
        /// 能力水平
        /// </summary>
        public AbilityLeveles Level
        {
            get
            {
                int l = AnswerTotal == 0 ? 0 : (AbilityLevelTotal / AnswerTotal) + 1;
                return (AbilityLeveles)l;
            }
        }
    }
}
