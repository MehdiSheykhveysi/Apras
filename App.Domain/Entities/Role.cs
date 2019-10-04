using App01.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;
using System;

namespace App01.Domain.Entities
{
    public class Role : IdentityRole<Guid>, IEntity
    {
    }
}