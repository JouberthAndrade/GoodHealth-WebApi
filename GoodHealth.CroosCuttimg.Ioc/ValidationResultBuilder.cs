using GoodHealth.CroosCuttimg.Ioc.Localizations.Interface;
using GoodHealth.Domain.Result;
using GoodHealth.Shared.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodHealth.CroosCuttimg.Ioc
{
    public class ValidationResultBuilder : IValidationResultBuilder
    {
        private IDomainNotificationService _domainNotificationService;
        private IJsonLocalization _localization;

        public ValidationResultBuilder(IDomainNotificationService domainNotificationService,
            IJsonLocalization localization)
        {
            _domainNotificationService = domainNotificationService;
            _localization = localization;
        }

        public ValidationResultModel<TResult> Build<TResult>(TResult result)
        {
            if (_domainNotificationService.HasNotifications())
            {
                return ValidationResultModel<TResult>.Instantiate(_domainNotificationService
                    .GetNotifications()
                    .Select(n =>
                    {
                        var resource = _localization.GetResource(n.Key, n.Value);
                        if (!string.IsNullOrEmpty(resource))
                            return new NotificationModel(n.Key, resource, n.Type);
                        else
                            return new NotificationModel(n.Key, n.Value, n.Type);
                    }).ToList(), result);
            }


            return ValidationResultModel<TResult>.Instantiate(result);
        }

        public ValidationResultModel<Exception> Build(Exception ex)
        {
            return ValidationResultModel<Exception>.Instantiate(ex);
        }

        public Task<ValidationResultModel<TResult>> BuildAsync<TResult>(TResult result)
        {
            if (_domainNotificationService.HasNotifications())
            {
                return Task.FromResult(ValidationResultModel<TResult>.Instantiate(_domainNotificationService
                    .GetNotifications()
                    .Select(n =>
                    {
                        var resource = _localization.GetResource(n.Key, n.Value);
                        if (!string.IsNullOrEmpty(resource))
                            return new NotificationModel(n.Key, resource, n.Type);
                        else
                            return new NotificationModel(n.Key, n.Value, n.Type);
                    }).ToList(), result));
            }


            return Task.FromResult(ValidationResultModel<TResult>.Instantiate(result));
        }

        public Task<ValidationResultModel<Exception>> BuildAsync(Exception ex)
        {
            return Task.FromResult(ValidationResultModel<Exception>.Instantiate(ex));
        }

    }
}
