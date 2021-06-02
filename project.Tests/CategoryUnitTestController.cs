using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using project.Data;

namespace project.Tests
{
    class CategoryUnitTestController
    {
        public CategoryUnitTestController()
        {
            var context = new ApplicationDbContext(dbContextOptions);
            DummyDataDBInitializer db = new DummyDataDBInitializer();
            db.Seed(context);

            repository = new CategoryRepository(context);

        }
    }
}
