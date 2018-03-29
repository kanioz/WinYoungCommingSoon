using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WinYoungUI.Extensions
{
    public class Enums
    {
        public enum TransactionType
        {
            Capture = 1,
            Refund = 2,
            Void = 3,

        }
        public enum TransactionStatus
        {
            Paid = 1,
            Refunded = 2,
            Failed = 3,
            Void = 4,
            Pending = 5
        }
        public enum OrderStatus
        {
            Pending = 1,
            Accepted = 2,
            Rejected = 3,
            Cancelled = 4,
            Completed = 5
        }
        public enum AttachmentType
        {
            Site,
            UserAvatar,
            ContentCategory,
            Content,
            VideoCategory,
            Video,
            LibraryDocument,
            LibraryImage,
            SiteCategory
        }

        public enum RoleEnum
        {
            Admin = 1,
            Teacher = 2,
            TeacherCandidate = 3,
            Student = 4
        }
    }
}
