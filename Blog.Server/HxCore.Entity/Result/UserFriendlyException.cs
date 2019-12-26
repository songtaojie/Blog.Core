﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HxCore.Entity
{
    public class UserFriendlyException:Exception
    {
        public UserFriendlyException(string message)
       : base(message)
        {
        }
    }
    /// <summary>
    /// 没有被授权的异常
    /// </summary>
    public class NoAuthorizeException : Exception
    {
        public NoAuthorizeException(string message)
        : base(message)
        {
        }
    }
    public class NotFoundException : Exception
    {
        public NotFoundException(string message)
       : base(message)
        {
        }
    }
}
