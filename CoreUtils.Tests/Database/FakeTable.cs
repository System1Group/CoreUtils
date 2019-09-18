namespace System1Group.Lib.CoreUtils.Tests.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class FakeTable
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
