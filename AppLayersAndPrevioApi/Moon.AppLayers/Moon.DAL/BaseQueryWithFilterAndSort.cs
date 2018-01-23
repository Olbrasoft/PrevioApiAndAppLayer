using System;
using System.Linq;


namespace Moon.DAL
{
    public abstract class BaseQueryWithFilterAndSort<T> : BaseQuery<T>,ISimpleQuery<T>
    {
        protected abstract IQueryable<T> GetData();

        
        protected override IQueryable<T> GetNonPagedRecords()
        {
            var data = GetData();

            if (FilterAndSort != null)
            {
                data = FilterAndSort(data);
            }

            return data;
        }

        public Func<IQueryable<T>, IQueryable<T>> FilterAndSort { get; set; }
    }
}
