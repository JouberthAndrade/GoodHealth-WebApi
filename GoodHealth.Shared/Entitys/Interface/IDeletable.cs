using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHealth.Shared.Entitys.Interface
{
    public interface IDeletable
    {
        /// <summary>
        /// Indicate if a entity was deleted
        /// </summary>
        bool IsDeleted { get; }
        /// <summary>
        /// Moment when delete event ocurred
        /// </summary>
        DateTime? DeletedDate { get; }

        /// <summary>
        /// Flag entity as deleted
        /// </summary>
        void Delete();
    }
}
