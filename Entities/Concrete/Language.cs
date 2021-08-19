using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Entities.Concrete
{
    public class Language : BaseEntity, IEntity
    {
        public int Id { get; set; }
        public string LangKey { get; set; }
        public string Name { get; set; }
        public string LocalName { get; set; }
    }
}