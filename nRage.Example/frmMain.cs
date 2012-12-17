using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using nRage.Contract.TVRage;

namespace nRage.Example {
    public partial class frmMain : Form {
        public frmMain() {
            InitializeComponent();
        }

        internal class LoadingBar : IDisposable
        {
            private frmMain _form;

            public LoadingBar(frmMain form)
            {
                _form = form;
                _form.groupBox1.Enabled = false;
                _form.groupBox2.Enabled = false;
                _form.groupBox3.Enabled = false;
                _form.groupBox4.Enabled = false;
            }
            public void Dispose() { 
                _form.groupBox1.Enabled = true;
                _form.groupBox2.Enabled = true;
                _form.groupBox3.Enabled = true;
                _form.groupBox4.Enabled = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            using(new LoadingBar(this))
            {
                var db = new TVRageClient();
                var result = db.SearchByTitle(txtShowName.Text);
                DisplayResults(result);
            }
        }

        #region Display Results
        private void Write(string text){txtResult.Text += text + Environment.NewLine;}
        private void WriteHR(char character){Write("".PadRight(40,character));}

        private void DisplayResults(SearchResponse result)
        {
            txtResult.Clear();
            foreach(var show in result.Results)
            {
                Write("ID: " + show.ShowID);
                Write("Name: " + show.Name);
                Write("Seasons: " + show.Seasons);
                Write("TVRage URL: " + show.Link);
                Write("Status: " + show.Status);
                WriteHR('-');
            }
        }

        private void DisplayResults(FullSearchResponse result)
        {
            txtResult.Clear();
            foreach(var show in result.Results)
            {
                Write("ID: " + show.ShowID);
                Write("Name: " + show.Name);
                Write("Seasons: " + show.Seasons);
                Write("TVRage URL: " + show.Link);
                Write("Status: " + show.Status);
                Write("Network: " + show.Network);
                Write(txtResult.Text += "Run Time: " + show.RunTime);
                WriteHR('-');
            }
        }

        private void DisplayResults(EpisodeListResponse result)
        {
            txtResult.Clear();
            Write(result.Name + " (" + result.Seasons + " seasons)");
            WriteHR('*');

            foreach(var season in result.Seasons)
            {
                Write("SEASON " + season.Number);
                WriteHR('*');
                foreach(var episode in season.Episodes)
                {
                    Write(episode.EpNum + ": " + episode.Title);
                    Write("Aired: " + episode.AirDate);
                    WriteHR('-');
                }                
            }
        }

        private void DisplayResults(ShowInfoResponse result)
        {
            txtResult.Clear();
        }

        private void DisplayResults(FullShowInfoResponse result)
        {
            txtResult.Clear();
        }

        private void DisplayResults(LastUpdatesResponse result)
        {
            txtResult.Clear();
        }

        private void DisplayResults(ShowListResponse result)
        {
            txtResult.Clear();
        }
        #endregion
    }    
}
