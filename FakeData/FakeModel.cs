using System;
using System.ComponentModel.DataAnnotations;

namespace FakeData
{
    public class FakeModel
    {
        [Key]
        public Guid FakeId { get; set; }

        public string FakeString { get; set; }
    }
}