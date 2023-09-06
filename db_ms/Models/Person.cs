using System;
using System.Collections.Generic;

namespace db_ms.Models;

public partial class Person
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
