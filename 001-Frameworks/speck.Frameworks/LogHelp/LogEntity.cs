namespace speck.Frameworks.LogHelp
{
    /// <summary>
    /// 日志实体
    /// </summary>
    public class LogEntity
    {
        /// <summary>
        /// 日志级别
        /// </summary>
        public LogType LogType { get; set; }

        /// <summary>
        /// 日志类型
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///  日志内容
        /// </summary>
        public string Content { get; set; }

    }
}
