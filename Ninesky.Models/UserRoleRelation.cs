﻿using System.ComponentModel.DataAnnotations;

namespace Ninesky.Models
{
    /// <summary>
    /// 用户角色关系
    /// </summary>
    public class UserRoleRelation
    {
        [Key]
        public int RelationID { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        [Required()]
        public int UserID { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        [Required()]
        public int RoleID { get; set; }
    }
}