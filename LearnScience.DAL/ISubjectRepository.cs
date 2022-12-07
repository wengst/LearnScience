using LS.Core;
using System;
using System.Collections.Generic;

namespace LS.DAL
{
    /// <summary>
    /// 与试题、试题组有关的资料操作接口
    /// </summary>
    interface ISubjectRepository
    {
        #region 待审试题操作
        /// <summary>
        /// 保存试题
        /// <para>无论是保存编辑过的旧试题还是保存新试题，首先都要进入审核库，只有审核过之后，才能进入试题的发布库</para>
        /// <para>进入发布库的试题，作者可选择是上架还是下架试题</para>
        /// </summary>
        /// <param name="subject">试题</param>
        /// <param name="isToReView">是否提请审核</param>
        /// <returns></returns>
        bool SaveSubjectReView(SubjectReView subject, bool isToReView = false);

        /// <summary>
        /// 保存新的或编辑后的问题
        /// <para>问题的SubjectId必须被赋值</para>
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        bool SaveQuestionReView(QuestionReView question);

        /// <summary>
        /// 根据试题Id获取试题
        /// </summary>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        SubjectReView GetSubjectReView(Guid subjectId);

        /// <summary>
        /// 获取待审试题列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IEnumerable<SubjectReView> GetSubjectReViews(int pageIndex = D.Default_IndexPage, int pageSize = D.Default_PageSize);

        /// <summary>
        /// 根据待审试题Id获取问题列表
        /// </summary>
        /// <param name="sujectId"></param>
        /// <returns></returns>
        IEnumerable<QuestionReView> GetQuestionBySubjectReView(Guid sujectId);

        /// <summary>
        /// 根据待审试题组Id获取试题
        /// <para>待审试题组中的试题来自于审核过的试题</para>
        /// </summary>
        /// <param name="testPaperId"></param>
        /// <returns></returns>
        IEnumerable<Subject> GetSubjectsByTestPaperReView(Guid testPaperId);

        /// <summary>
        /// 审核试题
        /// <para>审核通过的试题将进入试题库。若未通过审核，请提供未通过的原因</para>
        /// </summary>
        /// <param name="subject">待审核的试题</param>
        /// <param name="isAccept">是否通过</param>
        /// <param name="reason">如果未通过，需要提供原因</param>
        /// <returns></returns>
        bool ReViewSubject(SubjectReView subject, bool isAccept, string reason = null);

        /// <summary>
        /// 保存新或正在编辑的试题组
        /// <para>新或编辑的试题组都进入待审试题组库。如果参数isToReView=true则表示进入审核程序，如果为false则表示不进入审核，可继续编辑</para>
        /// </summary>
        /// <param name="testPaper">待审试题组</param>
        /// <param name="isToReView">是否提请审核</param>
        /// <returns></returns>
        bool SaveTestPaperReView(TestPaperReView testPaper, bool isToReView = false);

        /// <summary>
        /// 获取待审试题组列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IEnumerable<TestPaperReView> GetTestPaperReView(int pageIndex = D.Default_IndexPage, int pageSize = D.Default_PageSize);

        /// <summary>
        /// 根据TestPaperReViewId获取待审试题组
        /// </summary>
        /// <param name="testPaperId"></param>
        /// <returns></returns>
        TestPaperReView GetTestPaperReView(Guid testPaperId);

        /// <summary>
        /// 审核试题组
        /// <para>审核通过的试题组将进入试题组库。未通过的试题组请提供原因</para>
        /// </summary>
        /// <param name="testPaper">试题组</param>
        /// <param name="isAccept">是否通过</param>
        /// <param name="reason">未通过审核的原因</param>
        /// <returns></returns>
        bool ReViewTestPaper(TestPaperReView testPaper, bool isAccept, string reason = null);
        #endregion

        #region 已审试题操作
        /// <summary>
        /// 上架或下架试题
        /// <para>如果试题处于上架状态，执行此方法将下架试题，反之就是上架</para>
        /// </summary>
        /// <param name="authId">作者Id</param>
        /// <param name="subjectId">试题Id</param>
        /// <returns></returns>
        bool PutonOrTakeOffSubject(Guid authId, Guid subjectId);

        /// <summary>
        /// 克隆试题
        /// <para>克隆试题的目的是为了创建相似题，比如修改下其中的一些数据后保存到表中，成为相似题</para>
        /// <para>新克隆出的试题处于草稿状态</para>
        /// </summary>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        SubjectReView CloneSubject(Guid subjectId);

        /// <summary>
        /// 上架或下架试题组
        /// <para>试题组作者自行决定是否上架或下架试题组</para>
        /// </summary>
        /// <param name="authId">作者Id</param>
        /// <param name="testPaperId">试题组Id</param>
        /// <returns></returns>
        bool PutonOrTakeOffTestPaper(Guid authId, Guid testPaperId);

        /// <summary>
        /// 分页获取试题组列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IEnumerable<TestPaper> GetTestPapers(Guid? authId = null, int pageIndex = D.Default_IndexPage, int pageSize = D.Default_PageSize);

        /// <summary>
        /// 根据试题组Id获取试题组
        /// </summary>
        /// <param name="testPaperId"></param>
        /// <returns></returns>
        TestPaper GetTestPaper(Guid testPaperId);

        /// <summary>
        /// 克隆试题组
        /// <para>克隆后的试题组，需要被克隆的试题组有不同但相似的试题组合</para>
        /// <para>克隆出的新试题组处于草稿状态</para>
        /// </summary>
        /// <param name="testPaperId"></param>
        /// <returns></returns>
        TestPaperReView CloneTestPaper(Guid testPaperId);

        /// <summary>
        /// 获取试题组的试题列表
        /// </summary>
        /// <param name="testPaperId"></param>
        /// <returns></returns>
        IEnumerable<Subject> GetSubjectsByTestPaper(Guid testPaperId);

        /// <summary>
        /// 根据试题Id获取问题列表
        /// </summary>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        IEnumerable<Question> GetQuestionsBySubject(Guid subjectId); 
        #endregion
    }
}
