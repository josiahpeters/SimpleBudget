using ServiceStack.ServiceHost;
using System;

namespace SimpleBudget
{
    [Route("/categories/{CategoryId}/delete", "GET")]
    public class CategoryDeleteCommand
	{
        public Guid CategoryId { get; set; }

        public CategoryDeleteCommand()
		{
		}
	}
}

