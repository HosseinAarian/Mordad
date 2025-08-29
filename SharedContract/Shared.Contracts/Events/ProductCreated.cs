using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Contracts.Events;

public record ProductCreated(int OrderId, string Name, string Description, decimal Price, int Quantity, DateTime OccurredAtUtc);
