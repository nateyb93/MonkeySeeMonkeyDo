using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MonkeySeeMonkeyDo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Activity_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Details.Items.Clear();
            List<Activity> activities = Activity.GetList();

            foreach(Activity a in activities)
            {
                //add new ListViewItem with listItem style and text matching the string applied in activity class.
                ListViewItem item = new ListViewItem
                {
                    Style = (Style)Application.Current.Resources["listItem"],
                    Content = new TextBlock
                    {
                        Style = (Style)Application.Current.Resources["listItemText"],
                        Text = a.ActivityName
                    }                                       
                };
                
                Details.Items.Add(item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //create new test user
            User user = new User("nateyb93");

            //add user to database on parallel thread
            IAsyncAction asyncAction = Windows.System.Threading.ThreadPool.RunAsync(
                (workItem) =>
                {
                    AddItem(user);
                }
            );
        }

        /// <summary>
        /// Adds a user to online database
        /// </summary>
        /// <param name="u">User to add to database</param>
        private async void AddItem(User u)
        {
            try
            {
                await App.MobileService.GetTable<User>().InsertAsync(u);
            }
            catch (MobileServiceInvalidOperationException e)
            {
                Debug.WriteLine(e.Message);
            }
        }


    }
}
