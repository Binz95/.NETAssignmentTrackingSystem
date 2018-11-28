using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentTrackingSystemLibrary
{
    public interface IAssignments
    {
        List<Assignments> GetAssignments();
        Assignments FindAssignments(int AssignmentId);
        void InsertAssignments(Assignments a);
        
    }
}
