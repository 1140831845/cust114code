using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace search
{
    public partial class CustomService : Form
    {

        private const string HOST = "192.168.3.226";

        private const string PORT = "27017";

        private const string DATABASENAME = "Unicom";

        IMongoDatabase database;

        private MongoClient client;


        AutoSizeFormClass asc = new AutoSizeFormClass();

        private void StartForm_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            seachBtn.Height = searchText.Height;
        }

        private void StartForm_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
            seachBtn.Height = searchText.Height;
        }
        private void StartForm_MouseDown(object sender, MouseEventArgs e)
        {
            int x = e.X; //相对form窗口的坐标，客户区坐标  
            int y = e.Y;
            int x1 = Control.MousePosition.X;//相对显示器，屏幕的坐标  
            int y1 = Control.MousePosition.Y;
        }
        public CustomService()
        {
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;
            init();
        }
        public CustomService(String sfcallerLabel2, String sfcallTimeLabel2, String sfdurationLabel2, String sfQCellCoreLabel2, object sfDataSource)
        {

            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;
            callerLabel2.Text = sfcallerLabel2;
            callTimeLabel2.Text = sfcallTimeLabel2;
            durationLabel2.Text = sfdurationLabel2;
            QCellCoreLabel2.Text = sfQCellCoreLabel2;
            historyDataGridView.DataSource = sfDataSource;
            init();
        }

        void init()
        {
            List<string> search_type = new List<string> { "智能搜索", "拼音搜索" };
            searchTypeCombobox.DataSource = search_type;
            List<string> search_type2 = new List<string> { "请选择", "长春市", "吉林市", "四平市", "辽源市", "通化市", "白山市", "松原市", "白山市", "松原市", "白城市", "延边朝鲜自治州" };
            CityComboBox.DataSource = search_type2;
            client = new MongoClient(string.Format("mongodb://{0}:{1}", HOST, PORT));
            database = client.GetDatabase(DATABASENAME);


        }

        private void seachBtn_Click(object sender, EventArgs e)
        {
            IMongoCollection<SearchDB> collection;
            collection = database.GetCollection<SearchDB>("930u");

            if (searchTypeCombobox.Text == "智能搜索")
            {
                if (CityComboBox.Text == "请选择")
                {
                    var result = from xxx in collection.AsQueryable<SearchDB>()
                                 where xxx.UNITNAME.Contains(searchText.Text)
                                 select new display
                                 {
                                     UNITNAME = xxx.UNITNAME,
                                     TEL = xxx.TEL
                                 };
                    resultDataGridView.DataSource = result.ToList();
                }
                else
                {
                    var result = from xxx in collection.AsQueryable<SearchDB>()
                                 where xxx.UNITNAME.Contains(searchText.Text) && xxx.ADDRESS.Contains(CityComboBox.Text)
                                 select new display
                                 {
                                     UNITNAME = xxx.UNITNAME,
                                     TEL = xxx.TEL
                                 };
                    resultDataGridView.DataSource = result.ToList();
                }
            }
            else
            {
                if (CityComboBox.Text == "请选择")
                {
                    var result = from xxx in collection.AsQueryable<SearchDB>()
                                 where xxx.UNITCODE.Contains(searchText.Text.ToUpper())
                                 select new display
                                 {
                                     UNITNAME = xxx.UNITNAME,
                                     TEL = xxx.TEL
                                 };
                    resultDataGridView.DataSource = result.ToList();
                }
                else
                {
                    var result = from xxx in collection.AsQueryable<SearchDB>()
                                 where xxx.UNITCODE.Contains(searchText.Text.ToUpper()) && xxx.ADDRESS.Contains(CityComboBox.Text)
                                 select new display
                                 {
                                     UNITNAME = xxx.UNITNAME,
                                     TEL = xxx.TEL
                                 };
                    resultDataGridView.DataSource = result.ToList();
                }

            }
        }



    }
}
