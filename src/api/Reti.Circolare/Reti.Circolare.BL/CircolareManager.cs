using Reti.Circolare.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reti.Circolare.BL
{
    public class CircolareManager
    {
        private IUnitOfWork unitOfWork;
        public CircolareManager(IUnitOfWork iunitOfWork)
        {
            this.unitOfWork = iunitOfWork;
        }
    }
}
