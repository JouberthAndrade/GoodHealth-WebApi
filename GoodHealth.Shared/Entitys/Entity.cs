using Flunt.Notifications;
using GoodHealth.Shared.Entitys.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoodHealth.Shared.Entitys
{
    public abstract class Entity<TPrimaryKey> : Notifiable, IEntity<TPrimaryKey>
    {
        public virtual DateTime CreateDate { get; protected set; }
        public virtual DateTime? DeletedDate { get; protected set; }
        public virtual bool Ativo { get; protected set; }

        [JsonProperty("id")]
        public TPrimaryKey Id { get; protected set; }
    }
    public abstract class Entity : Entity<Guid>
    {
        protected Entity()
        {
            if (Id == Guid.Empty)
            {  // solution for use entity with base for document db entity
                this.Id = Guid.NewGuid();
                this.CreateDate = DateTime.Now;
                this.Ativo = true;
            }
        }

        public void Delete()
        {
            this.Ativo = false;
            this.DeletedDate = DateTime.Now;
        }

        public void SetId(Guid id)
        {
            if (id != Guid.Empty)
                this.Id = id;
        }
    }
}
