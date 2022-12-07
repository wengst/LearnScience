using System;

namespace LS.Core
{
    /// <summary>
    /// 用户角色
    /// </summary>
    [Flags]
    public enum UserRoles
    {
        /// <summary>
        /// 学生
        /// </summary>
        学生 = 1,
        /// <summary>
        /// 家长
        /// </summary>
        家长 = 2,
        /// <summary>
        /// 教师
        /// </summary>
        教师 = 4,
        /// <summary>
        /// 员工
        /// </summary>
        员工 = 8,
        /// <summary>
        /// 管理者
        /// </summary>
        管理 = 16
    }

    /// <summary>
    /// 证件类型
    /// </summary>
    public enum CertTypes
    {
        身份证,
        军官证,
        护照,
        驾驶证
    }

    /// <summary>
    /// 性别枚举
    /// </summary>
    public enum Sexs
    {
        未设置,
        男性,
        女性
    }

    /// <summary>
    /// 问题类型
    /// </summary>
    public enum QuestionType
    {
        单选题,
        选择题,
        判断题,
        简答计算题
    }

    /// <summary>
    /// 发布状态
    /// </summary>
    [Flags]
    public enum ReleaseStats
    {
        /// <summary>
        /// 刚创建的数据处于草稿状态。
        /// <para>草稿态的数据不能审核</para>
        /// </summary>
        草稿 = 1,
        /// <summary>
        /// 仓储中的数据对其他用户不可见
        /// </summary>
        仓储 = 2,
        /// <summary>
        /// 发布的数据对其他用户可见。
        /// </summary>
        发布 = 4,
        /// <summary>
        /// 被使用的数据会被锁定。锁定的数据不可编辑，但仓储或发布。
        /// </summary>
        锁定 = 8
    }

    /// <summary>
    /// 答题状态
    /// </summary>
    public enum AnswerStats
    {
        /// <summary>
        /// 选了答题后，一道题都没有做的情况。
        /// </summary>
        等待回答 = 1,
        /// <summary>
        /// 答了至少一道题，但是没有答完
        /// </summary>
        正在回答 = 10,
        /// <summary>
        /// 答完了所有题，但是老师还没有批改一道题。
        /// </summary>
        等待批改 = 20,
        /// <summary>
        /// 批改了至少一道题，但没有批改完。
        /// </summary>
        正在批改 = 100,
        /// <summary>
        /// 批改完成所有的题，但是没有完成评价/评分
        /// </summary>
        批改完成 = 1000,
        /// <summary>
        /// 批改完成了所有的题，而且完成了评价/评分
        /// </summary>
        答题完成 = 2000,
        /// <summary>
        /// 在规定时间内未完成答题，答题任务关闭。
        /// </summary>
        超期关闭 = 3000
    }

    /// <summary>
    /// 收付款途径
    /// </summary>
    public enum PayWays
    {
        支付宝,
        微信,
        PayPal
    }

    /// <summary>
    /// 支付用途
    /// </summary>
    public enum PayPurposes
    {
        /// <summary>
        /// 用户购买答题用的点数
        /// </summary>
        购买点数,
        /// <summary>
        /// 出题者获得的佣金
        /// </summary>
        出题佣金,
        /// <summary>
        /// 答题者答对题后获得的奖励
        /// </summary>
        答题奖励,
        /// <summary>
        /// 用户账户剩余点数的退款
        /// </summary>
        余额退款
    }

    /// <summary>
    /// 收付款状态
    /// </summary>
    public enum PayStats
    {
        未处理 = 1,
        正在处理 = 10,
        已支付 = 100,
        已收款 = 200
    }

    /// <summary>
    /// 配对关系
    /// </summary>
    public enum UserRelations
    {
        师生,
        父母和子女,
        同学,
        朋友
    }

    /// <summary>
    /// 关联状态
    /// </summary>
    [Flags]
    public enum RelationStats
    {
        /// <summary>
        /// 关注
        /// </summary>
        Follow = 2,
        /// <summary>
        /// 被关注
        /// </summary>
        BeFollow = 4
    }

    /// <summary>
    /// 能力级别
    /// </summary>
    public enum AbilityLeveles
    {
        未评估 = 0,
        了解 = 1,
        理解 = 2,
        掌握 = 3,
        应用 = 4
    }

    /// <summary>
    /// 验证途径
    /// </summary>
    public enum VerifyWay
    {
        /// <summary>
        /// 手机短信验证
        /// </summary>
        SMS,
        /// <summary>
        /// 邮箱验证
        /// </summary>
        Mail
    }
}
