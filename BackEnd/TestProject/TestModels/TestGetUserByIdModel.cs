using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.TestModels
{
    public class TestGetUserByIdModel
    {
        public Guid userId;
        
        public TestGetUserByIdModel(Guid userId)
        {
            this.userId = userId;
        }
    }
}
