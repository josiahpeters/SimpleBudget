using System;

namespace SimpleBudget
{
	public class CategoryResponse : Category
	{
		public CategoryResponse ()
		{
		}

        public CategoryResponse(Category category)
        {
            this.Id = category.Id;
            this.Name = category.Name;
            this.Frequency = category.Frequency;
        }
	}
}

