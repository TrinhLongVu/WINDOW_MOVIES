using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using WpfApp1.Database;
using WpfApp1.Models;
using WpfApp1.Views;

namespace WpfApp1.ViewModel
{
    class TicketView {
        public Ticket Ticket { get; set; }
        public TopRevenue Movie { get; set; }
    }
    class BookedTicketViewModel
    {
        public ObservableCollection<TicketView> Tickets { get; set; }
        public TicketView SelectedItem { get; set; }
        
        public BookedTicketViewModel() {
            if (!LoginViewModel.IsLogin()) {
                throw new Exception("Unexpected");
            }
            var movieDB = new MovieDB();
            List<Ticket> allTickets = new TicketDB().GetAllTickets(LoginViewModel.GetAccount().Id);
            Tickets = new ObservableCollection<TicketView>(allTickets.ConvertAll<TicketView>(tk => {
                return new TicketView {
                    Ticket = tk,
                    Movie = movieDB.GetMovieRaw(tk.MovieId)
                };
            }));
        }

        public void OpenMovieInfo(NavigationService navService) {
            navService.Navigate(new MovieInfo(SelectedItem.Ticket.MovieId));
        }
    }
}
