using Chloe.Entity;
namespace BossWellModel
{
    /// <summary>
    /// 文件上传记录表
    /// </summary>
    [Table("FileStorage")]
    public class FileStorageEntity : BaseEntity
    {
        /// <summary>
        /// 上传用户
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        public string FileType { get; set; }

        /// <summary>
        /// 文件大小Byte
        /// </summary>
        public int FileSize { get; set; }

        /// <summary>
        /// 存储路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

    }
}
