﻿namespace App01.Domain.Entities.Common
{
    public interface IEntity
    {

    }
    public abstract class BaseEntity<TKey>: IEntity
    {
        public TKey ID { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<int>
    {
        
    }
}