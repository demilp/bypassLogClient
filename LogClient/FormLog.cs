using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogClient
{
    public partial class FormLog : Form
    {
        UdpClient client;
        IPEndPoint listenEndPoint;
        List<Data> dataList;
        bool realtime = true;
        public FormLog()
        {
            InitializeComponent();
            dataList = new List<Data>();
            clients.Items.Add("ALL");
            clients.SetSelected(0, true);
            listenEndPoint = new IPEndPoint(IPAddress.Any, int.Parse(ConfigurationManager.AppSettings["port"]));
            client = new UdpClient(int.Parse(ConfigurationManager.AppSettings["port"]));
            try
            {
                client.BeginReceive(new AsyncCallback(Receive), null);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        void Receive(IAsyncResult res)
        {
            byte[] receivedBytes = client.EndReceive(res, ref listenEndPoint);
            client.BeginReceive(new AsyncCallback(Receive), null);
            string s = Encoding.UTF8.GetString(receivedBytes);
            SimpleJSON.JSONNode node = SimpleJSON.JSON.Parse(s);
            Data data = new Data(node["date"].Value, node["message"].Value, node["sender"].Value, node["receiver"].Value);
            dataList.Add(data);
            if(realtime)
            if (MatchesSelectedCiteria(data))
            {
                dataGridView1.AllowUserToAddRows = true;
                Invoke((Action<Data>)((_data) =>{bindingList.Insert(0, data);}),new object[] { data });
            }
            if (!clients.Items.Contains(data.sender))
            {
                clients.Invoke(new MethodInvoker(delegate { clients.Items.Add(data.sender);}));
            }
            foreach (var r in data.receiver)
            {
                if(!clients.Items.Contains(r))
                    clients.Invoke(new MethodInvoker(delegate { clients.Items.Add(r); }));
            }

        }

        bool MatchesSelectedCiteria(Data data)
        {
            return (bool)Invoke((Func<bool>)delegate
            {
                if (clients.SelectedIndex == 0)
                {
                    return true;
                }
                switch (clients.SelectedItems.Count)
                {
                    case 1:
                        foreach (var re in data.receiver)
                        {
                            if (re == clients.SelectedItem.ToString())
                                return true;
                        }
                        if (data.sender == clients.SelectedItem.ToString())
                            return true;

                        break;
                    case 2:
                        foreach (var re in data.receiver)
                        {
                            if ((re == clients.SelectedItems[0].ToString() &&
                                 data.sender == clients.SelectedItems[1].ToString()) ||
                                (re == clients.SelectedItems[1].ToString() &&
                                 data.sender == clients.SelectedItems[0].ToString()))
                                return true;
                        }
                        break;
                    default:
                        foreach (var re in data.receiver)
                        {
                            foreach (var c in clients.SelectedItems)
                            {
                                if (re == c)
                                    return true;
                            }
                        }
                        foreach (var c in clients.SelectedItems)
                        {
                            if (data.sender == c)
                                return true;
                        }
                        break;
                }
                return false;
            });
        }

        private void clients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clients.SelectedIndex == 0)
            {
                var r = (
                    from d in dataList
                    orderby d.dateTime descending
                    select d).ToList();
                bindingList = new BindingList<Data>(r);
                dataGridView1.DataSource = bindingList;
            }
            else if (clients.SelectedItems.Count == 1)
            {    
                var r = (
                    from d in dataList
                    from re in d.receiver
                    where (d.sender == clients.SelectedItem.ToString() || re == clients.SelectedItem.ToString())
                    orderby d.dateTime descending
                    select d).ToList();
                bindingList = new BindingList<Data>(r);
                dataGridView1.DataSource = bindingList;
            }
            else if (clients.SelectedItems.Count == 2)
            {
                var r = (
                    from d in dataList
                    from re in d.receiver
                    where
                        (re == clients.SelectedItems[0].ToString() &&
                         d.sender == clients.SelectedItems[1].ToString()) ||
                        (re == clients.SelectedItems[1].ToString() &&
                         d.sender == clients.SelectedItems[0].ToString())
                    orderby d.dateTime descending 
                    select d).ToList();
                bindingList = new BindingList<Data>(r);
                dataGridView1.DataSource = bindingList;
            }
            else
            {
                string[] c = new string[clients.SelectedItems.Count];
                for (int i = 0; i < clients.SelectedItems.Count; i++)
                {
                    c[i] = clients.SelectedItems[i].ToString();
                }
                var r = (
                    from d in dataList
                    from re in d.receiver
                    where (c.Contains(re) || c.Contains(d.sender))
                    orderby d.dateTime descending
                    select d).ToList();
                bindingList = new BindingList<Data>(r);
                dataGridView1.DataSource = bindingList;
            }
        }

        BindingList<Data> bindingList;

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            realtime = !realtime;
            if (realtime)
            {
                btnPlayPause.Text = "▶";
                btnPlayPause.Font = new Font(FontFamily.GenericSansSerif, 30);
                clients_SelectedIndexChanged(null, null);
            }
            else
            {
                btnPlayPause.Text = "■";
                btnPlayPause.Font = new Font(FontFamily.GenericSansSerif, 20);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                textBoxDataPreview.Text = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
            }
        }
    }

    public struct Data
    {
        public string sender;
        public string[] receiver;
        public string message;
        public string dateTime;

        public Data(string dt, string m, string s, string r)
        {
            dateTime = dt;
            message = m;
            sender = s;
            receiver = r.Split(',').Select(p=>p.Trim()).Where(p => p != "").ToArray();
            
        }

        public string Sender {
            get { return sender; }
        }
        public string Receiver {
            get { return string.Join(", ", receiver); }
        }
        public string Message
        {
            get { return message; }
        }
        public string DateTime
        {
            get { return dateTime; }
        }
    }
}
