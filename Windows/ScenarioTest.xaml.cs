using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.ComponentModel;
using System.Collections;
using System.Collections.ObjectModel;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SDKTemplate
{
    public class Song
    {
        public string ArticleName { get; set; }
        public string SongTitle { get; set; }
    }

    class SongViewModel: INotifyPropertyChanged
    {
        Song song;
        public SongViewModel(string name, string title)
        {
            song = new Song() { ArticleName = name, SongTitle = title };
        }
        public string ArticleName
        {
            get { return song.ArticleName; }
            set 
            { 
                song.ArticleName = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ArticleName"));
            }
        }
        public string SongTitle
        {
            get { return song.SongTitle;  }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    class SongsViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        ObservableCollection<SongViewModel> songViewModel = new ObservableCollection<SongViewModel>();
        public ObservableCollection<SongViewModel> Songs { get { return songViewModel; } }
        string titleErrorInfo;
        public string TitleErrorInfo
        {
            set
            {
                titleErrorInfo = value;
                PropertyChanged(this, new PropertyChangedEventArgs("TitleErrorInfo"));
            }
            get
            {
                return titleErrorInfo;
            }
        }
        string nameErrorInfo;
        public string NameErrorInfo {
            get
            {
                return nameErrorInfo;
            }
            set
            {
                this.nameErrorInfo = value;
                PropertyChanged(this, new PropertyChangedEventArgs("NameErrorInfo"));
            }
        }
    }
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ScenarioTest : Page
    {
        SongsViewModel viewModel = new SongsViewModel();
        public ScenarioTest()
        {
            this.InitializeComponent();
            ScenarioGrid.DataContext = viewModel;
        }

        private void AddSongButtonClick(object sender, RoutedEventArgs e)
        {
            viewModel.NameErrorInfo = NewNameText.Text == "" ? "Name cannot empty" : "";
            viewModel.TitleErrorInfo = NewTitleText.Text == ""? "Title cannot empty": "";
            if (NewTitleText.Text != "" && NewNameText.Text != "")
                viewModel.Songs.Add(new SongViewModel(NewNameText.Text, NewTitleText.Text));
        }
    }
}
