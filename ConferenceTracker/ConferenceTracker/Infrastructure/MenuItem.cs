using ConferenceTracker.Data;
using System;

namespace ConferenceTracker.Infrastructure
{
    public class MenuItem : BaseObservableObject
    {
        public MenuItem(string displayName, Type target, MenuItemType type, string icon, bool isSelected = false)
        {
            DisplayName = displayName;
            TargetType = target;
            Type = type;
            IconSource = icon;
            IsSelected = isSelected;
        }

        public int Id { get { return (int)Type; } }

        public MenuItemType Type { get; set; }

        public string DisplayName { get; set; }

        public Type TargetType { get; set; }

        public string IconSource { get; set; }

        private bool isSelected;
        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                isSelected = value;
                RaiseOnPropertyChanged();
            }
        }
    }
}
