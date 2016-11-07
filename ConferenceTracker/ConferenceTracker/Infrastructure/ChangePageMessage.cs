namespace ConferenceTracker.Infrastructure
{
    public class ChangePageMessage
    {
        public MenuItem SelectedItem { get; set; }

        public ChangePageMessage(MenuItem selected)
        {
            SelectedItem = selected;
        }
    }
}
