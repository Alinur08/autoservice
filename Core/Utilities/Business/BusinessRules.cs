using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core1.Utilities.Business
{
    public class BusinessRules
    {
        public static Result Run(params Result[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success) {
                    return logic;
                }
            }
            return null;
        }
    }
}
