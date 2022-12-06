using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using LS.Core;

namespace LS.DAL
{
    /// <summary>
    /// 网站或软件的数据上下文
    /// </summary>
    public class LSAppDbContext : DbContext
    {
        private string _connectionString;

        #region DaSet
        public DbSet<User> Users { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserPair> UserPairs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PayLog> PayLogs { get; set; }
        public DbSet<Commodity> Commodities { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Purview> Purviews { get; set; }
        public DbSet<Verify> Verifies { get; set; }


        public DbSet<TestPaper> TestPapers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionReView> QuestionReViews { get; set; }
        public DbSet<SubjectReView> SubjectReViews { get; set; }
        public DbSet<TestPaperReView> TestPaperReViews { get; set; }

        public DbSet<Knowledge> Knowledges { get; set; }
        public DbSet<TestPaperAnswer> TestPaperAnswers { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
        public DbSet<UserKnowledgeTarget> UserKnowledgeTargets { get; set; }
        #endregion

        public LSAppDbContext(string ConnectionString)
        {
            _connectionString = ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //t1
            modelBuilder.Entity<User>(user =>
            {
                user.ToTable(D.t1);
                user.Property(p => p.Id).HasColumnType<Guid>(D.T_GUID).IsRequired().UseIdentityColumn().HasColumnName(D.f0);
                user.Property(p => p.UserName).HasMaxLength(32).IsRequired().HasColumnType(D.T_NVARCHAR32).HasColumnName(D.f1);
                user.Property(p => p.Password).HasMaxLength(32).IsRequired().HasColumnType(D.T_VARCHAR32).HasColumnName(D.f2);
                user.Property(p => p.EMail).HasColumnType(D.T_VARCHAR128).HasMaxLength(128).HasColumnName(D.f3);
                user.Property(p => p.FaceImageUrl).HasColumnType(D.T_VARCHAR128).HasColumnName(D.f4);
                user.Property(p => p.NikeName).HasColumnType(D.T_NVARCHAR8).HasMaxLength(8).HasColumnName(D.f5);
                user.Property(p => p.RegisterTime).HasColumnType<DateTime>(D.T_DATETIME).HasDefaultValue(DateTime.Now).HasColumnName(D.f6);
                user.Property(p => p.Role).HasColumnType(D.T_INT).HasDefaultValue(UserRoles.学生).HasColumnName(D.f7);
                user.Property(p => p.Sex).HasColumnType(D.T_INT).HasColumnName(D.f8).HasDefaultValue(Sexs.未设置);
                user.Property(p => p.VipStart).HasColumnType<DateTime>(D.T_DATETIME).HasColumnName(D.f9).IsRequired(false);
                user.Property(p => p.VipEnd).HasColumnType<DateTime>(D.T_DATETIME).HasColumnName(D.f10).IsRequired(false);
                user.Property(p => p.VipLevel).HasColumnType<int>(D.T_INT).HasColumnName(D.f11).IsRequired(false);
                user.Property(p => p.EMailConfirmed).HasColumnType(D.T_BIT).HasColumnName(D.f12).IsRequired().HasDefaultValue(false);
            });

            modelBuilder.Entity<User>().HasData(
                new User { Role = UserRoles.学生, EMail = "14140226@qq.com", NikeName = "零号学员", Password = LS.Core.F.MD5Encrypt("vtr97x7303"), RegisterTime = DateTime.Now, Sex = Sexs.未设置, UserName = "ZeroStudent", VipStart = DateTime.Now, VipEnd = DateTime.MaxValue, VipLevel = 1 },
                new User { UserName = "ZeroTeacher", NikeName = "零号教师", EMail = "wengst@126.com", Password = LS.Core.F.MD5Encrypt("vtr97x7303"), RegisterTime = DateTime.Now, Sex = Sexs.未设置, Role = UserRoles.教师, VipStart = DateTime.Now, VipEnd = DateTime.MaxValue, VipLevel = 1 },
                new User("Teacher", "vtr97x7303~123456", "wengshutang@126.com") { NikeName = "系统教师", Role = UserRoles.教师 },
                new User("Isaac Newton", "vtr97x7303~123456", "niudun@122.com") { NikeName = "艾萨克·牛顿", Role = UserRoles.教师 },
                new User("Albert Einstein", "vtr97x7303!", "einstein@122.com") { NikeName = "阿尔伯特·爱因斯坦", Role = UserRoles.教师 },
                User.VipTeacher("Robert Hooke", "vtr97x7303~123", "hooke@122.com", "罗伯特·虎克"),
                User.VipTeacher("Nikola Tesla", "vtr97x7303!123", "tesla@122.com", "尼古拉·特斯拉"),
                User.VipTeacher("James Watt", "vtr97x7303~123$", "watt@122.com", "詹姆斯·瓦特"),
                User.VipTeacher("James Prescott Joule", "vtr97x7303~234%44", "joule@122.com", "詹姆斯·普雷斯科特·焦耳"),
                User.VipTeacher("André-Marie Ampère", "André-Marie Ampère", "amp@122.com", "安德烈-马里·安培"),
                User.VipTeacher("Alessandro Giuseppe Antonio Anastasio Volta", "Alessandro Giuseppe Antonio Anastasio Volta", "volta@122.com", "阿纳斯塔西奥·伏特"),
                User.VipTeacher("menjieliefu", "vtr97x", "menjieliefu@122.com", "门捷列夫"),
                User.VipTeacher("jililue", "vtrjialijue", "jialijue@122.com", "伽利略"),
                User.VipTeacher("aidisheng", "aidisheng222@@33", "alidisheng@122.com", "爱迪生"),
                User.VipTeacher("faladi", "faladi~123", "faladi@122.com", "法拉第"),
                User.VipTeacher("kaipulei", "kaipulei@122.org", "kaipulei@122.com", "开普勒"),
                User.VipTeacher("daerwen", "daerwen@122.org", "daerwen@122.com", "达尔文"),
                User.VipTeacher("maikesiwei", "maikesiwei@122.org", "maikesiwei@122.com", "麦克斯韦"),
                User.VipTeacher("dafenqi", "dafenqi@122.org", "dafenqi@122.com", "达芬奇"),
                User.VipTeacher("nuobeier", "nuobeier@122.org", "nuobeier@122.com", "诺贝尔"),
                User.VipStudent("liubang", "刘邦"),
                User.VipStudent("liubei", "刘备"),
                User.VipStudent("zhangfen", "张飞"),
                User.VipStudent("libai", "李白"),
                User.VipStudent("lishimin", "李世民"),
                User.VipStudent("zhuchongba", "朱元璋"),
                User.VipStudent("zhaoyun", "赵云"),
                User.VipStudent("zhugeliang", "诸葛亮"),
                User.VipStudent("zhaokuo", "赵括"),
                User.VipStudent("guanyunchang", "关云长"),
                User.VipStudent("tangbohu", "唐伯虎"),
                User.VipStudent("chuanpu", "川普"),
                User.VipStudent("sunxingzhe", "孙悟空"),
                User.VipStudent("zhubajie", "猪八戒"),
                User.VipStudent("shasheng", "沙僧"),
                User.VipStudent("tangsanzang", "唐三藏"),
                User.VipStudent("guojing", "郭靖"),
                User.VipStudent("huangrong", "黄蓉"),
                User.VipStudent("qiuchuji", "丘处机"),
                User.VipStudent("chijiaodaxian", "赤脚大仙"),
                User.VipStudent("rulai", "我是如来"),
                User.VipStudent("guanyindashi", "观音大师"),
                User.VipUser("liyuan", "李渊", UserRoles.家长),
                User.VipUser("huangyaoshi", "黄药师", UserRoles.家长),
                User.VipUser("guoxiaotian", "郭啸天", UserRoles.家长)
            );

            //t2
            modelBuilder.Entity<UserAccount>(ua =>
            {
                ua.ToTable(D.t2);
                ua.Property(p => p.UserId).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f0);
                ua.Property(p => p.Balance).HasColumnType<int>(D.T_INT).HasColumnName(D.f1);
                ua.Property(p => p.Consumption).HasColumnType<int>(D.T_INT).HasColumnName(D.f2);
                ua.Property(p => p.PayAccount).HasColumnType<string>(D.T_VARCHAR64).HasColumnName(D.f3);
                ua.Property(p => p.Payway).HasColumnType<PayWays>(D.T_INT).HasColumnName(D.f4);
            });

            //t3
            modelBuilder.Entity<UserPair>(t =>
            {
                t.ToTable(D.t3);
                t.Property(p => p.UserId1).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f0);
                t.Property(p => p.UserId2).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f1);
                t.Property(p => p.LastStatTime).HasColumnType<DateTime>(D.T_DATETIME).HasColumnName(D.f2);
                t.Property(p => p.Relation).HasColumnType<UserRelations>(D.T_INT).HasColumnName(D.f3).IsRequired().HasDefaultValue(UserRelations.父母和子女);
                t.Property(p => p.Stat).HasColumnType<RelationStats>(D.T_INT).HasColumnName(D.f4).IsRequired().HasDefaultValue(ReleaseStats.草稿);
            });

            //t4
            modelBuilder.Entity<UserKnowledgeTarget>(t =>
            {
                t.ToTable(D.t4);
                t.Property(p => p.AbilityLevelTotal).HasColumnType(D.T_INT).HasColumnName(D.f1);
                t.Property(p => p.AnswerTotal).HasColumnName(D.f2).HasColumnType(D.T_INT);
                t.Property(p => p.FullScoreTotal).HasColumnType(D.T_INT).HasColumnName(D.f3);
                t.Property(p => p.KnowledgeCode).HasColumnType<string>(D.T_CHAR4).HasMaxLength(4).HasColumnName(D.f4);
                t.Property(p => p.Month).HasColumnType(D.T_INT).HasColumnName(D.f5);
                t.Property(p => p.Year).HasColumnName(D.f6).HasColumnType(D.T_INT);
                t.Property(p => p.Week).HasColumnType(D.T_INT).HasColumnName(D.f7);
                t.Property(p => p.RightTotal).HasColumnType(D.T_INT).HasColumnName(D.f8);
                t.Property(p => p.ScoreRightTotal).HasColumnType(D.T_INT).HasColumnName(D.f9);
                t.Property(p => p.UserId).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f10);
            });

            //t5
            modelBuilder.Entity<PayLog>(t =>
            {
                t.ToTable(D.t5);
                t.Property(p => p.PaymenterId).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f0);
                t.Property(p => p.PayTime).HasColumnType<DateTime>(D.T_DATETIME).HasColumnName(D.f1);
                t.Property(p => p.Payway).HasColumnType<PayWays>(D.T_INT).HasColumnName(D.f2);
                t.Property(p => p.Purpose).HasColumnType<PayPurposes>(D.T_INT).HasColumnName(D.f3);
                t.Property(p => p.Amount).HasColumnType(D.T_INT).HasColumnName(D.f4);
                t.Property(p => p.CollecterAccount).HasColumnType(D.T_NVARCHAR32).HasColumnName(D.f5);
                t.Property(p => p.CollecterId).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f6);
                t.Property(p => p.Comment).HasColumnName(D.f7).HasColumnType(D.T_NVARCHAR64).HasMaxLength(64);
                t.Property(p => p.ConfirmTime).HasColumnType<DateTime>(D.T_DATETIME).HasColumnName(D.f8);
                t.Property(p => p.IsConfirm).HasColumnType(D.T_BIT).HasColumnName(D.f9);
                t.Property(p => p.PayAccount).HasColumnType(D.T_NVARCHAR32).HasColumnName(D.f10);
                t.Property(p => p.PayImageUrl).HasColumnType(D.T_VARCHAR128).HasColumnName(D.f11);
                t.Property(P => P.UserId).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f12);
            });

            //t6
            modelBuilder.Entity<Commodity>(t =>
            {
                t.ToTable(D.t6);
                t.Property(p => p.VipLevel).HasColumnType(D.T_INT).HasColumnName(D.f0);
                t.Property(p => p.Amount).HasColumnType(D.T_INT).HasColumnName(D.f1);
                t.Property(p => p.Days).HasColumnType(D.T_INT).HasColumnName(D.f2);
                t.Property(p => p.Points).HasColumnType(D.T_INT).HasColumnName(D.f3);
                t.Property(p => p.VipDays).HasColumnType(D.T_INT).HasColumnName(D.f4);
            });

            //t7
            modelBuilder.Entity<Employee>(t =>
            {
                t.ToTable(D.t7);
                t.Property(p => p.Id).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f0);
                t.Property(p => p.CertCode).HasColumnType(D.T_VARCHAR20).HasColumnName(D.f1);
                t.Property(p => p.CertType).HasColumnType<CertTypes>(D.T_INT).HasColumnName(D.f2);
                t.Property(p => p.DepartmentId).HasColumnType(D.T_INT).HasColumnName(D.f3);
                t.Property(p => p.EndTime).HasColumnType<DateTime>(D.T_DATETIME).HasColumnName(D.f4);
                t.Property(p => p.FaceImageUrl).HasColumnType(D.T_VARCHAR128).HasColumnName(D.f5);
                t.Property(p => p.Name).HasColumnName(D.T_NVARCHAR16).HasMaxLength(16).HasColumnName(D.f6);
                t.Property(p => p.NikeName).HasColumnType(D.T_NVARCHAR8).HasMaxLength(8).HasColumnName(D.f7);
                t.Property(p => p.Password).HasColumnType(D.T_VARCHAR32).HasMaxLength(32).HasColumnName(D.f8);
                t.Property(p => p.RegisterTime).HasColumnType<DateTime>(D.T_DATETIME).HasColumnName(D.f9);
                t.Property(p => p.Sex).HasColumnType<Sexs>(D.T_INT).HasColumnName(D.f10);
                t.Property(p => p.StartTime).HasColumnType<DateTime>(D.T_DATETIME).HasColumnName(D.f11);
            });

            //t8
            modelBuilder.Entity<Department>(t =>
            {
                t.ToTable(D.t8);
                t.Property(p => p.Id).HasColumnType<int>(D.T_INT).HasColumnName(D.f0);
                t.Property(p => p.Name).HasColumnType(D.T_NVARCHAR8).HasColumnName(D.f1).HasMaxLength(8);
            });

            //t9
            modelBuilder.Entity<Purview>(t =>
            {
                t.ToTable(D.t9);
                t.Property(p => p.Code).HasColumnType(D.T_CHAR4).HasMaxLength(4).HasColumnName(D.f0);
                t.Property(p => p.Comment).HasColumnType(D.T_NVARCHAR64).HasMaxLength(64).HasColumnName(D.f1);
                t.Property(p => p.DepartmentId).HasColumnType(D.T_INT).HasColumnName(D.f2);
                t.Property(p => p.NeedRole).HasColumnType<UserRoles>(D.T_INT).HasColumnName(D.f3);
            });

            //t10
            modelBuilder.Entity<Question>(t =>
            {
                t.ToTable(D.t10);
                t.Property(p => p.SujectId).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f0);
                t.Property(p => p.Type).HasColumnType<QuestionType>(D.T_INT).HasColumnName(D.f1);
                t.Property(p => p.Number).HasColumnType(D.T_NVARCHAR8).HasColumnName(D.f2);
                t.Property(p => p.Knowledges).HasColumnType(D.T_VARCHAR128).HasColumnName(D.f3);
                t.Property(p => p.Score).HasColumnType(D.T_INT).HasColumnName(D.f4);
                t.Property(p => p.TextAnalyze).HasColumnType(D.T_NTEXT).HasColumnName(D.f5);
                t.Property(p => p.TextContent).HasColumnType(D.T_NTEXT).HasColumnName(D.f6);
                t.Property(p => p.Options).HasColumnType(D.T_NVARCHAR128).HasColumnName(D.f7);
                t.Property(p => p.Keys).HasColumnType(D.T_NVARCHAR128).HasColumnName(D.f8);
                t.Property(p => p.Difficulty).HasColumnType(D.T_INT).HasColumnName(D.f9);
            });

            //t11
            modelBuilder.Entity<QuestionReView>(t =>
            {
                t.ToTable(D.t11);
                t.Property(p => p.SujectId).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f0);
                t.Property(p => p.Type).HasColumnType<QuestionType>(D.T_INT).HasColumnName(D.f1);
                t.Property(p => p.Number).HasColumnType(D.T_NVARCHAR8).HasColumnName(D.f2);
                t.Property(p => p.Knowledges).HasColumnType(D.T_VARCHAR128).HasColumnName(D.f3);
                t.Property(p => p.Score).HasColumnType(D.T_INT).HasColumnName(D.f4);
                t.Property(p => p.TextAnalyze).HasColumnType(D.T_NTEXT).HasColumnName(D.f5);
                t.Property(p => p.TextContent).HasColumnType(D.T_NTEXT).HasColumnName(D.f6);
                t.Property(p => p.Options).HasColumnType(D.T_NVARCHAR128).HasColumnName(D.f7);
                t.Property(p => p.Keys).HasColumnType(D.T_NVARCHAR128).HasColumnName(D.f8);
                t.Property(p => p.Difficulty).HasColumnType(D.T_INT).HasColumnName(D.f9);
            });

            //t12
            modelBuilder.Entity<Subject>(t =>
            {
                t.ToTable(D.t12);
                t.Property(p => p.Id).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f0);
                t.Property(p => p.AuthId).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f1);
                t.Property(p => p.IsFree).HasColumnType(D.T_BIT).HasColumnName(D.f2);
                t.Property(p => p.Price).HasColumnType(D.T_INT).HasColumnName(D.f3);
                t.Property(p => p.ReleaseTime).HasColumnType(D.T_DATETIME).HasColumnName(D.f4);
                t.Property(p => p.Stat).HasColumnType<ReleaseStats>(D.T_INT).HasColumnName(D.f5);
                t.Property(p => p.TextAnalyze).HasColumnType(D.T_NTEXT).HasColumnName(D.f6);
                t.Property(p => p.TextContent).HasColumnType(D.T_NTEXT).HasColumnName(D.f7);
            });

            //t13
            modelBuilder.Entity<SubjectReView>(t =>
            {
                t.ToTable(D.t13);
                t.Property(p => p.Id).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f0);
                t.Property(p => p.AuthId).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f1);
                t.Property(p => p.IsFree).HasColumnType(D.T_BIT).HasColumnName(D.f2);
                t.Property(p => p.Price).HasColumnType(D.T_INT).HasColumnName(D.f3);
                t.Property(p => p.ReleaseTime).HasColumnType(D.T_DATETIME).HasColumnName(D.f4);
                t.Property(p => p.Stat).HasColumnType<ReleaseStats>(D.T_INT).HasColumnName(D.f5);
                t.Property(p => p.TextAnalyze).HasColumnType(D.T_NTEXT).HasColumnName(D.f6);
                t.Property(p => p.TextContent).HasColumnType(D.T_NTEXT).HasColumnName(D.f7);
                t.Property(p => p.IsAccept).HasColumnType(D.T_BIT).HasColumnName(D.f8);
                t.Property(p => p.ReViewerId).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f9);
                t.Property(p => p.ReViewTime).HasColumnType(D.T_DATETIME).HasColumnName(D.f10);
                t.Property(p => p.Reason).HasColumnType(D.T_NVARCHAR32).HasMaxLength(32).HasColumnName(D.f11);
            });

            //t14
            modelBuilder.Entity<TestPaper>(t =>
            {
                t.ToTable(D.t14);
                t.Property(p => p.Id).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f0);
                t.Property(p => p.Title).HasColumnType(D.T_NVARCHAR32).HasColumnName(D.f1);
                t.Property(p => p.IsFree).HasColumnType(D.T_BIT).HasColumnName(D.f2);
                t.Property(p => p.Price).HasColumnType(D.T_INT).HasColumnName(D.f3);
                t.Property(p => p.AuthId).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f4);
                t.Property(p => p.Comment).HasColumnType(D.T_NVARCHAR64).HasMaxLength(64).HasColumnName(D.f5);
                t.Property(p => p.ReleaseTime).HasColumnType<DateTime>(D.T_DATETIME).HasColumnName(D.f6);
                t.Property(p => p.Stat).HasColumnType<ReleaseStats>(D.T_INT).HasColumnName(D.f7);
            });

            //t15
            modelBuilder.Entity<TestPaperReView>(t =>
            {
                t.ToTable(D.t15);
                t.Property(p => p.Id).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f0);
                t.Property(p => p.Title).HasColumnType(D.T_NVARCHAR32).HasColumnName(D.f1);
                t.Property(p => p.IsFree).HasColumnType(D.T_BIT).HasColumnName(D.f2);
                t.Property(p => p.Price).HasColumnType(D.T_INT).HasColumnName(D.f3);
                t.Property(p => p.AuthId).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f4);
                t.Property(p => p.Comment).HasColumnType(D.T_NVARCHAR64).HasMaxLength(64).HasColumnName(D.f5);
                t.Property(p => p.ReleaseTime).HasColumnType<DateTime>(D.T_DATETIME).HasColumnName(D.f6);
                t.Property(p => p.Stat).HasColumnType<ReleaseStats>(D.T_INT).HasColumnName(D.f7);
                t.Property(p => p.IsAccept).HasColumnType(D.T_BIT).HasColumnName(D.f8);
                t.Property(p => p.Reason).HasColumnType(D.T_NVARCHAR64).HasMaxLength(64).HasColumnName(D.f9);
                t.Property(p => p.ReViewerId).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f10);
                t.Property(p => p.ReViewTime).HasColumnType(D.T_DATETIME).HasColumnName(D.f11);
            });

            //t16
            modelBuilder.Entity<Knowledge>(t =>
            {
                t.ToTable(D.t16);
                t.Property(p => p.Code).HasColumnType(D.T_CHAR4).HasColumnName(D.f0);
                t.Property(p => p.Comment).HasColumnType(D.T_NVARCHAR64).HasColumnName(D.f1);
                t.Property(p => p.EmployeeId).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f2);
                t.Property(p => p.IsExpired).HasColumnType(D.T_BIT).HasColumnName(D.f3);
                t.Property(p => p.Level).HasColumnType(D.T_INT).HasColumnName(D.f4);
                t.Property(p => p.ParentCode).HasColumnType(D.T_CHAR4).HasColumnName(D.f5);
                t.Property(p => p.ReleaseTime).HasColumnType(D.T_DATETIME).HasColumnName(D.f6);
                t.Property(p => p.Relies).HasColumnType(D.T_VARCHAR128).HasColumnName(D.f7);
            });

            modelBuilder.Entity<Knowledge>().HasData(
                Knowledge.Create("1000", "实验", "探究和实验", AbilityLeveles.未评估),
                Knowledge.Create("2000", "生物", "植物、动物、生理卫生", AbilityLeveles.未评估),
                Knowledge.Create("3000", "化学", "物质变化的科学，化学", AbilityLeveles.未评估),
                Knowledge.Create("4000", "物理", "机械运动、力、声、电、光、磁", AbilityLeveles.未评估),
                Knowledge.Create("5000", "地理", "自然地理", AbilityLeveles.未评估)
            );

            //t17
            modelBuilder.Entity<TestPaperAnswer>(t =>
            {
                t.ToTable(D.t17);
                t.Property(p => p.Id).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f0);
                t.Property(p => p.UserId).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f1);
                t.Property(p => p.TestPaperId).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f2);
                t.Property(p => p.Stat).HasColumnType<AnswerStats>(D.T_INT).HasColumnName(D.f3);
                t.Property(p => p.StartTime).HasColumnType<DateTime>(D.T_DATETIME).HasColumnName(D.f4);
                t.Property(p => p.SaveToTime).HasColumnType<DateTime>(D.T_DATETIME).HasColumnName(D.f5);
                t.Property(p => p.ExpiredHours).HasColumnType(D.T_INT).HasColumnName(D.f6);
                t.Property(p => p.CreateTime).HasColumnType<DateTime>(D.T_DATETIME).HasColumnName(D.f7);
                t.Property(p => p.CompleteTime).HasColumnType(D.T_DATETIME).HasColumnName(D.f8);
            });

            //t18
            modelBuilder.Entity<QuestionAnswer>(t =>
            {
                t.ToTable(D.t18);
                t.Property(p => p.Id).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f0);
                t.Property(p => p.Answer).HasColumnType(D.T_NVARCHAR128).HasColumnName(D.f1);
                t.Property(p => p.CorrectId).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f2);
                t.Property(p => p.IsRight).HasColumnType(D.T_BIT).HasColumnName(D.f3);
                t.Property(p => p.MyComment).HasColumnType(D.T_NVARCHAR128).HasColumnName(D.f4);
                t.Property(p => p.QuestionId).HasColumnType(D.T_GUID).HasColumnName(D.f5);
                t.Property(p => p.Score).HasColumnType(D.T_INT).HasColumnName(D.f6);
                t.Property(p => p.SubjectAnswerId).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f7);
                t.Property(p => p.TeacherComment).HasColumnType(D.T_NVARCHAR128).HasColumnName(D.f8);
                t.Property(p => p.TestPaperAnswerId).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f9);
            });

            //t19
            modelBuilder.Entity<Teacher>(t =>
            {
                t.ToTable(D.t19);
                t.Property(p => p.TeacherId).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f0);
                t.Property(p => p.Introduction).HasColumnType(D.T_NTEXT).HasColumnName(D.f1);
            });

            //t20
            modelBuilder.Entity<Article>(t =>
            {
                t.ToTable(D.t20);
                t.Property(p => p.Id).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f0);
                t.Property(p => p.AuthId).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f1);
                t.Property(p => p.KnowledgeId).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f2);
                t.Property(p => p.Title).HasColumnType(D.T_NVARCHAR64).HasMaxLength(64).HasColumnName(D.f3);
                t.Property(p => p.Content).HasColumnType(D.T_NTEXT).HasColumnName(D.f4);
                t.Property(p => p.ReleaseTime).HasColumnType(D.T_DATETIME).HasColumnName(D.f5);
                t.Property(p => p.SubTitle).HasColumnType(D.T_NVARCHAR64).HasColumnName(D.f6);
            });

            //t21
            modelBuilder.Entity<ArticleReView>(t =>
            {
                t.ToTable(D.t21);
                t.Property(p => p.Id).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f0);
                t.Property(p => p.AuthId).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f1);
                t.Property(p => p.KnowledgeId).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f2);
                t.Property(p => p.Title).HasColumnType(D.T_NVARCHAR64).HasMaxLength(64).HasColumnName(D.f3);
                t.Property(p => p.Content).HasColumnType(D.T_NTEXT).HasColumnName(D.f4);
                t.Property(p => p.ReleaseTime).HasColumnType(D.T_DATETIME).HasColumnName(D.f5);
                t.Property(p => p.SubTitle).HasColumnType(D.T_NVARCHAR64).HasColumnName(D.f6);
                t.Property(p => p.ReViewerId).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f7);
                t.Property(p => p.IsAccept).HasColumnType(D.T_BIT).HasColumnName(D.f8);
                t.Property(p => p.ReViewTime).HasColumnType(D.T_DATETIME).HasColumnName(D.f9);
                t.Property(p => p.Reason).HasColumnType(D.T_NVARCHAR64).HasMaxLength(64).HasColumnName(D.f10);
            });

            //t22
            modelBuilder.Entity<Verify>(t =>
            {
                t.ToTable(D.t22);
                t.Property(p => p.UserId).HasColumnType<Guid>(D.T_GUID).HasColumnName(D.f0);
                t.Property(p => p.Way).HasColumnType<VerifyWay>(D.T_TINYINT).HasColumnName(D.f1);
                t.Property(p => p.LimitMinutes).HasColumnType(D.T_SMALLINT).HasColumnName(D.f2);
                t.Property(p => p.Sendto).HasColumnType(D.T_NVARCHAR128).HasColumnName(D.f3);
                t.Property(p => p.md5).HasColumnType(D.T_VARCHAR32).HasColumnName(D.f4);
            });
        }
    }
}
