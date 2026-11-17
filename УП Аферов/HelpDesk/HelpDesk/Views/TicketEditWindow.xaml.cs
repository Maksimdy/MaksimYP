using System.Windows;
using HelpDesk.Models;

namespace HelpDesk.Views
{
    public partial class TicketEditWindow : Window
    {
        public Ticket CurrentTicket { get; set; }

        public TicketEditWindow(Ticket ticket)
        {
            InitializeComponent();
            CurrentTicket = ticket;

            
            TicketIdTextBlock.Text = $"Заявка №: {CurrentTicket.Id}";
            DescriptionTextBox.Text = CurrentTicket.Description;

            
            foreach (var item in CategoryComboBox.Items)
            {
                if (item is System.Windows.Controls.ComboBoxItem cbItem && cbItem.Content.ToString() == CurrentTicket.Category)
                {
                    CategoryComboBox.SelectedItem = cbItem;
                    break;
                }
            }

            
            foreach (var item in PriorityComboBox.Items)
            {
                if (item is System.Windows.Controls.ComboBoxItem cbItem && cbItem.Content.ToString() == CurrentTicket.Priority)
                {
                    PriorityComboBox.SelectedItem = cbItem;
                    break;
                }
            }

            
            foreach (var item in StatusComboBox.Items)
            {
                if (item is System.Windows.Controls.ComboBoxItem cbItem && cbItem.Content.ToString() == CurrentTicket.Status)
                {
                    StatusComboBox.SelectedItem = cbItem;
                    break;
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (CategoryComboBox.SelectedItem is System.Windows.Controls.ComboBoxItem catItem)
                CurrentTicket.Category = catItem.Content.ToString();

            CurrentTicket.Description = DescriptionTextBox.Text;

            if (PriorityComboBox.SelectedItem is System.Windows.Controls.ComboBoxItem priItem)
                CurrentTicket.Priority = priItem.Content.ToString();

            if (StatusComboBox.SelectedItem is System.Windows.Controls.ComboBoxItem statItem)
                CurrentTicket.Status = statItem.Content.ToString();

            DialogResult = true; 
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}