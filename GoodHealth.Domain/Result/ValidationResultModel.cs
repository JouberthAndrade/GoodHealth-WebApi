using GoodHealth.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodHealth.Domain.Result
{
    public sealed class ValidationResultModel<TResult>
    {
        #region [ Constructor ]
        private ValidationResultModel(List<NotificationModel> notifications)
        {
            Notifications = notifications;
            HasNotifications = (notifications != null && notifications.Count > 0);
            HasException = false;
        }

        private ValidationResultModel(List<NotificationModel> notifications, TResult result)
            : this(notifications)
        {
            Result = result;
        }

        private ValidationResultModel(Exception ex)
        {
            Exception = new CustomException() { Message = ex.Message, StackTrace = ex.StackTrace };
            HasException = true;
            HasNotifications = false;
        }

        private ValidationResultModel(TResult result)
        {
            Result = result;
            HasException = false;
            HasNotifications = false;
        }
        #endregion

        #region [ Factory ]

        public static ValidationResultModel<TResult> Instantiate(List<NotificationModel> notifications, TResult result)
        {
            return new ValidationResultModel<TResult>(notifications, result);
        }

        public static ValidationResultModel<TResult> Instantiate(TResult result)
        {
            return new ValidationResultModel<TResult>(result);
        }

        public static ValidationResultModel<TResult> Instantiate(List<NotificationModel> notifications)
        {
            return new ValidationResultModel<TResult>(notifications);
        }

        public static ValidationResultModel<Exception> Instantiate(Exception ex)
        {
            return new ValidationResultModel<Exception>(ex);
        }

        #endregion

        #region [ Properties ]
        public CustomException Exception { get; private set; }
        public bool HasException { get; private set; }
        public bool HasNotifications { get; private set; }
        public List<NotificationModel> Notifications { get; private set; }
        public TResult Result { get; private set; }
        #endregion
    }

    public sealed class CustomException
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }

    public sealed class NotificationModel
    {
        public NotificationModel(string name, string message, NotificationType type)
        {
            Name = name;
            Message = message;
            Type = type;
        }

        public string Name { get; set; }
        public string Message { get; set; }
        public NotificationType Type { get; set; }
    }
}
