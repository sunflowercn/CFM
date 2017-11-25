using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace win.Inherit
{
    class ObjectPropertyCompare<T> : System.Collections.Generic.IComparer<T>
    {
        public PropertyDescriptor property { get; set; }
        public ListSortDirection direction { get; set; }
        public ObjectPropertyCompare() { }
        public ObjectPropertyCompare(PropertyDescriptor prop, ListSortDirection direction)
        {
            this.property = prop;
            this.direction = direction;
        }
        public int Compare(T x, T y)
        {
            object xValue = x.GetType().GetProperty(property.Name).GetValue(x, null);
            object yValue = y.GetType().GetProperty(property.Name).GetValue(y, null);

            int returnValue;

            if (xValue == null && yValue == null)
            {
                returnValue = 0;
            }
            else if (xValue == null)
            {
                returnValue = -1;
            }
            else if (yValue == null)
            {
                returnValue = 1;
            }
            else if (xValue is IComparable)
            {
                returnValue = ((IComparable)xValue).CompareTo(yValue);
            }
            else if (xValue.Equals(yValue))
            {
                returnValue = 0;
            }
            else
            {
                returnValue = xValue.ToString().CompareTo(yValue.ToString());
            }

            if (direction == ListSortDirection.Ascending)
            {
                return returnValue;
            }
            else
            {
                return returnValue * -1;
            }
        }
    }
    public class SortedBindingCollection<T> : BindingList<T>
    {
        protected override bool SupportsSortingCore
        {
            get { return true; }
        }
        protected override bool SupportsSearchingCore
        {
            get { return true; }
        }
        private bool isSortedCore = true;
        protected override bool IsSortedCore
        {
            get
            {
                return isSortedCore;
            }
        }
        private ListSortDirection sortDirectionCore = ListSortDirection.Ascending;
        protected override ListSortDirection SortDirectionCore
        {
            get
            {
                return sortDirectionCore;
            }
        }
        private PropertyDescriptor sortPropertyCore = null;
        protected override PropertyDescriptor SortPropertyCore
        {
            get
            {
                return sortPropertyCore;
            }
        }
        public SortedBindingCollection(IList<T> list)
            : base(list)
        {
        }
        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            List<T> items = this.Items as List<T>;

            if (items != null)
            {
                ObjectPropertyCompare<T> pc = new ObjectPropertyCompare<T>(prop, direction);
                items.Sort(pc);
                isSortedCore = true;
                sortDirectionCore = direction;
                sortPropertyCore = prop;
            }
            else
            {
                isSortedCore = false;
            }

            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
        protected override void RemoveSortCore()
        {
            isSortedCore = false;
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
    }
}
