using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using search.resultClass;

namespace search
{
    public partial class StartForm : Form
    {
        private const string URL = "http://192.168.3.68:10001/";

        private const string HOST = "192.168.3.226";

        private const string PORT = "27017";

        private const string DATABASENAME = "Unicom";

        IMongoDatabase database;

        private MongoClient client;

        AutoSizeFormClass asc = new AutoSizeFormClass();

        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public StartForm()
        {
            InitializeComponent();
            init();
        }
        delegate void SetTextCallback();

        private void SetText()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (query.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d);
            }
            else
            {
                if (query.Text == "")
                {
                    string msg = AsynchronousSocketListener.messages.Dequeue();
                    query.Text = msg;
                    search(msg);
                }
                else
                {
                    query.Text = "";
                }
            }
        }

        private void listen()
        {
            while (true)
            {
                if (AsynchronousSocketListener.messages.Count != 0)
                {
                    SetText();
                    if (AsynchronousSocketListener.messages.Count != 0)
                        SetText();
                }
            }
        }
        void init()
        {
            Thread thread = new Thread(AsynchronousSocketListener.StartListening);
            thread.Start();
            Thread watch = new Thread(listen);
            watch.Start();

            client = new MongoClient(string.Format("mongodb://{0}:{1}", HOST, PORT));
            database = client.GetDatabase(DATABASENAME);


            callerLabel2.Text = "111";
            callTimeLabel2.Text = DateTime.Now.ToString();
            durationLabel2.Text = "333";
            QCellCoreLabel2.Text = "444";

        }

        private string add_params(string url, Dictionary<string, string> parameters)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(URL + url);
            if (parameters.Count() > 0)
            {
                builder.Append("?");
                int i = 0;
                foreach (var item in parameters)
                {
                    if (i > 0)
                        builder.Append("&");
                    builder.AppendFormat("{0}={1}", item.Key, item.Value);
                    i++;
                }
            }
            return builder.ToString();

        }
        private Dictionary<string, string> get_segment(string dict, string text)
        {
            // 字典乱序
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(add_params(dict, new Dictionary<string, string> { { "text", text } }));
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";



            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return JsonConvert.DeserializeObject<Dictionary<string, string>>(retString);
        }


        private resultClass.allResult get_result(string text)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(add_params("search", new Dictionary<string, string> { { "text", text } }));
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";



            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return JsonConvert.DeserializeObject<resultClass.allResult>(retString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (query.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请输入查询内容！");
                return;
            }
            string text = clean_text(query.Text);
            var jieba = get_segment("jieba", text);
            var fool = get_segment("fool", text);
            jiebaSegText.Text = jieba["segment"];
            jiebaKeywordText.Text = jieba["keywords"];
            foolSegText.Text = fool["segment"];
            foolKeywordText.Text = fool["keywords"];
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            int sure = 0;
            if (successLabel.CheckState == CheckState.Checked) sure = 1;
            var collection = database.GetCollection<saveResult>("query");
            var updateDef = Builders<saveResult>.Update.Set(o => o.reason, reasonText.Text);
            collection.UpdateMany(o => o.question == query.Text, updateDef);
            updateDef = Builders<saveResult>.Update.Set(o => o.success, sure);
            collection.UpdateMany(o => o.question == query.Text, updateDef);
            MessageBox.Show("更新成功！");
            //query.Text = "";
            //jiebaKeywordText.Text = "";
            //jiebaSegText.Text = "";
            //foolKeywordText.Text = "";
            //foolSegText.Text = "";
            //jiebaGridview.DataSource = null;
            //foolGridview.DataSource = null;
        }

        private string clean_text(string text)
        {
            string[] sign = { ",", ".", "?", "!", "，", "。", "！", "？", "：", "；", ":", ";" };
            text = text.Trim();
            foreach (var s in sign)
            {
                text = text.Replace(s, " ");
            }
            return text;
        }

        private void search(string text)
        {
            var result = get_result(text);

            jiebaSegText.Text = result.jiebaSeg;
            foolSegText.Text = result.foolSeg;
            jiebaKeywordText.Text = result.jiebaKeywords;
            foolKeywordText.Text = result.foolKeywords;
            databind(result.jiebaSearchResult, result.foolSearchResult);

            string keyword = string.Empty;
            if (result.jiebaKeywords.Split(',').Count() > 0) keyword = result.jiebaKeywords.Split(',')[0];
            else if (result.foolKeywords.Split(',').Count() > 0) keyword = result.foolKeywords.Split(',')[0];
            else
            {
                QAGridView.DataSource = new List<test> { new test(text), new test("未找到关键词，无法提问。") };
                return;
            }

            QAGridView.DataSource = new List<test> { new test(text), new test(string.Format("请问您要查找的是 {0} 的电话吗？", keyword)) };
            return;

        }

        private void queryBtn_Click(object sender, EventArgs e)
        {
            string jieba_keyword = clean_text(jiebaKeywordText.Text);
            string fool_keyword = clean_text(foolKeywordText.Text);
            var result = get_result(query.Text);
            jiebaSegText.Text = result.jiebaSeg;
            foolSegText.Text = result.foolSeg;
            jiebaKeywordText.Text = result.jiebaKeywords;
            foolKeywordText.Text = result.foolKeywords;
            databind(result.jiebaSearchResult, result.foolSearchResult);
            //jiebaGridview.DataSource = result.jiebaSearchResult;
            //jiebaGridview.AutoResizeColumns();
            //foolGridview.DataSource = result.foolSearchResult;
            //foolGridview.AutoResizeColumns();
        }


        private void databind(List<searchResult> jieba, List<searchResult> fool)
        {
            Dictionary<string, string> title = new Dictionary<string, string> { { "phoneNum", "手机号码" }, { "allName", "全称" } };

            jiebaGridview.DataSource = jieba;
            foolGridview.DataSource = fool;

            jiebaGridview.AutoResizeColumns();
            foolGridview.AutoResizeColumns();
            foreach (var item in title)
            {
                jiebaGridview.Columns[item.Key].HeaderText = item.Value;
                foolGridview.Columns[item.Key].HeaderText = item.Value;
            }
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        private void StartForm_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void StartForm_MouseDown(object sender, MouseEventArgs e)
        {
            int x = e.X; //相对form窗口的坐标，客户区坐标  
            int y = e.Y;
            int x1 = Control.MousePosition.X;//相对显示器，屏幕的坐标  
            int y1 = Control.MousePosition.Y;
        }

        private void jiebaGridview_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void foolGridview_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void QAGridView_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            char show = e.Row.Index % 2 == 0 ? 'Q' : 'A';
            e.Row.HeaderCell.Value = string.Format("{0}", show);
        }

        private void autoTransfer_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomService customService = new CustomService(callerLabel2.Text, callTimeLabel2.Text, durationLabel2.Text, QCellCoreLabel2.Text, QAGridView.DataSource);

            customService.Show();

            //this.Close();
        }
    }
}
