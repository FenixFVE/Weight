using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weight.Program.WeightDatabase;

public interface IInitializableCounter
{
    static abstract void InitializeCounter(int initialValue);
}
