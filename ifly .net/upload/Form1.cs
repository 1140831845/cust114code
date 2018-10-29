using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using System.Net;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace upload
{
    public partial class form : Form
    {
        private const string URL = "http://192.168.3.68:10001/";
        private const string HOST = "192.168.3.226";

        private const string PORT = "27017";

        private const string DATABASENAME = "Unicom";

        IMongoDatabase database;

        private MongoClient client;

        private List<string> comboboxTitle = new List<string> { "请选择", "同义词", "停用词", "专有名词" };
        //指定collection的名称
        private readonly Dictionary<string, string> collectionDict = new Dictionary<string, string> { { "同义词", "synonym" }, { "停用词", "stopwords" }, { "专有名词", "propernouns" } };
        //表示每个collection中key的个数
        private readonly Dictionary<string, int> keyCount = new Dictionary<string, int> { { "同义词", 2 }, { "停用词", 2 }, { "专有名词", 2 } };
        //将csv中的字段对应到collection的key上
        private readonly Dictionary<string, string> field = new Dictionary<string, string> { { "同义词", "synonyms" }, { "停用词", "stopword" }, { "标准词", "standard" }, { "专有名词", "properNouns" } };
        //将查出来的数据的title转换为中文
        private readonly Dictionary<string, string> gridviewTitle = new Dictionary<string, string> { { "synonyms", "同义词" }, { "stopword", "停用词" }, { "standard", "标准词" }, { "properNouns", "专有名词" }, { "weight", "权重" } };

        private const string SELECT = "请选择";
        private const string SYNONYM = "同义词";
        private const string STOPWORD = "停用词";
        private const string PROPERNOUNS = "专有名词";


        public form()
        {
            InitializeComponent();
            init();
        }
        /// <summary>
        /// 程序启动时初始化
        /// </summary>
        protected void init()
        {
            client = new MongoClient(string.Format("mongodb://{0}:{1}", HOST, PORT));
            database = client.GetDatabase(DATABASENAME);
            //绑定下拉列表
            title.DataSource = comboboxTitle;
        }

        /// <summary>
        /// gridview 绑定数据库数据
        /// filterStop为停用词表查询过滤器
        /// filterSynonym为同义词表查询时过滤器
        /// 过滤器默认查询key根据第一个key查询,不算id
        /// </summary>
        /// <param name="name"></param>
        /// <param name="filterStop"></param>
        /// <param name="filterSynonym"></param>
        void databind(string name, FilterDefinition<Stopword> filterStop = null, FilterDefinition<Synonym> filterSynonym = null, FilterDefinition<Proper> filterProper = null)
        {
            if (name != SELECT)
            {
                string collectionName = collectionDict[name];

                //if (filter_ == null) filter = new BsonDocument();

                try
                {
                    switch (name)
                    {
                        case STOPWORD:
                            {
                                var collection = database.GetCollection<Stopword>(collectionName);
                                if (filterStop == null)//查询所有
                                {
                                    var results = collection.Find(new BsonDocument()).ToList();
                                    gridview.DataSource = results;
                                }
                                else//查询文本框输入的数据
                                {
                                    var results = collection.Find(filterStop).ToList();
                                    gridview.DataSource = results;
                                }
                            }
                            break;
                        case SYNONYM:
                            {
                                var collection = database.GetCollection<Synonym>(collectionName);
                                if (filterSynonym == null)//查询所有
                                {
                                    var results = collection.Find(new BsonDocument()).ToList();
                                    gridview.DataSource = results;
                                }
                                else//查询文本框输入的数据
                                {
                                    var results = collection.Find(filterSynonym).ToList();
                                    gridview.DataSource = results;
                                }
                            }
                            break;
                        case PROPERNOUNS:
                            {
                                var collection = database.GetCollection<Proper>(collectionName);
                                if (filterProper == null)//查询所有
                                {
                                    var results = collection.Find(new BsonDocument()).ToList();
                                    gridview.DataSource = results;
                                }
                                else//查询文本框输入的数据
                                {
                                    var results = collection.Find(filterProper).ToList();
                                    gridview.DataSource = results;
                                }
                            }
                            break;
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("数据库连接异常！");
                    return;
                }

                // 设置id 不可见
                gridview.Columns[0].Visible = false;

                for (int i = 0; i < gridview.Columns.Count; i++)
                {
                    //列宽度设置自适应
                    gridview.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                    //设置列标题将英文转为中文显示
                    if (gridviewTitle.Keys.Contains(gridview.Columns[i].HeaderCell.Value.ToString()))
                        gridview.Columns[i].HeaderCell.Value = gridviewTitle[gridview.Columns[i].HeaderCell.Value.ToString()];
                }

                statusLable.Text = "查询总数为:" + gridview.RowCount.ToString();
            }
        }
        /// <summary>
        /// 下拉框变化的时候触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void title_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = (sender as ComboBox).SelectedItem.ToString();
            databind(name);
        }

        /// <summary>
        /// 上传按钮点击时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uploadBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "csv 文件|*.csv";
            openFileDialog.Title = "选择上传的文件";

            openFileDialog.Multiselect = false;

            bool status = false;

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                status = importData(openFileDialog.FileName);
            }
            if (status)
            {
                string name = title.SelectedItem.ToString();
                databind(name);
            }
        }
        /// <summary>
        /// 导入数据
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        protected bool importData(string filePath)
        {
            string name = title.SelectedItem.ToString();

            if (name == SELECT)
            {
                MessageBox.Show("请先选择要上传的类型！");
                return false;
            }

            List<BsonDocument> docs = new List<BsonDocument>();//保存要插入的数据
            int duplicate = 0;//记录文件中包含的重复数据个数

            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs, Encoding.Default))
                    {
                        string[] csv_title = sr.ReadLine().Split(',');//设置列标题

                        switch (name)
                        {
                            case STOPWORD:
                                {
                                    csv_title = "停用词".Split(',');
                                }
                                break;
                            case SYNONYM:
                                {
                                    csv_title = "标准词,同义词".Split(',');

                                }
                                break;
                            case PROPERNOUNS:
                                {
                                    csv_title = "专有名词".Split(',');
                                }
                                break;
                        }


                        string row_text = "";
                        HashSet<string> unique = new HashSet<string>();

                        while ((row_text = sr.ReadLine()) != null)
                        {
                            BsonDocument doc = new BsonDocument();

                            string[] datas = null;

                            if (row_text.Contains(',')) datas = row_text.Split(',');
                            else if (row_text.Contains("\t")) datas = row_text.Split('\t');
                            else datas = row_text.Split();
                            //if(datas.Length > 1)
                            //{
                            //    MessageBox.Show("csv格式错误" + datas);
                            //    return false;
                            //}

                            if (datas.Length != keyCount[name])
                            {
                                MessageBox.Show("格式错误：" + datas);
                                return false;
                            }
                            if (unique.Contains(datas[0])) { duplicate += 1; continue; }
                            else if (string.IsNullOrEmpty(datas[0])) { duplicate += 1; continue; }

                            unique.Add(datas[0]);

                            switch (name)
                            {
                                case STOPWORD:
                                    {
                                        var col = database.GetCollection<Stopword>(collectionDict[name]);
                                        //首先查询是否有重复的value
                                        var result = col.AsQueryable<Stopword>().Count(e => e.stopword == datas[0]);

                                        if (result > 0)
                                        {
                                            duplicate += 1;
                                            continue;
                                        }
                                    }
                                    break;
                                case SYNONYM:
                                    {
                                        var col = database.GetCollection<Synonym>(collectionDict[name]);
                                        //首先查询是否有重复的value
                                        var result = col.AsQueryable<Synonym>().Count(e => e.standard == datas[0]);

                                        if (result > 0)
                                        {
                                            duplicate += 1;
                                            continue;
                                        }
                                    }
                                    break;
                                case PROPERNOUNS:
                                    {
                                        var col = database.GetCollection<Proper>(collectionDict[name]);
                                        //首先查询是否有重复的value
                                        var result = col.AsQueryable<Proper>().Count(e => e.properNouns == datas[0]);

                                        if (result > 0)
                                        {
                                            duplicate += 1;
                                            continue;
                                        }
                                    }
                                    break;
                            }

                            for (int i = 0; i < csv_title.Length; i++)
                            {
                                doc.Add(field[csv_title[i]], datas[i].Trim());
                            }
                            docs.Add(doc);
                        }

                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("打开文件失败！");
                return false;
            }

            try
            {
                ///插入数据库
                var collection = database.GetCollection<BsonDocument>(collectionDict[name]);
                collection.InsertMany(docs);
            }
            catch (Exception)
            {
                MessageBox.Show("数据库连接异常！");
                return false;
            }

            if (duplicate > 0) MessageBox.Show("数据全部导入成功！去除重复数据条数为：" + duplicate.ToString());
            else MessageBox.Show("数据全部导入成功！");

            return true;
        }
        /// <summary>
        /// 搜索按钮点击时触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchBtn_Click(object sender, EventArgs e)
        {
            string text = searchText.Text.Trim();

            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("请输入要查询的内容");
                return;
            }
            string name = title.SelectedItem.ToString();
            //将中文对应到数据库中的要查询的key
            Dictionary<string, string> searchKey = new Dictionary<string, string> { { "同义词", "standard" }, { "停用词", "stopword" }, { "专有名词", "properNouns" } };

            switch (name)
            {
                case STOPWORD:
                    {
                        //设置过滤器
                        FilterDefinitionBuilder<Stopword> builderFilter = new FilterDefinitionBuilder<Stopword>();
                        //使用正则表达式匹配所有包含text的value
                        BsonRegularExpression regex = new BsonRegularExpression(string.Format(".*{0}.*", text));
                        FilterDefinition<Stopword> filter = builderFilter.Regex(searchKey[name], regex);

                        databind(name, filterStop: filter);
                    }
                    break;
                case SYNONYM:
                    {
                        //设置过滤器
                        FilterDefinitionBuilder<Synonym> builderFilter = new FilterDefinitionBuilder<Synonym>();
                        //使用正则表达式匹配所有包含text的value
                        BsonRegularExpression regex = new BsonRegularExpression(string.Format(".*{0}.*", text));
                        FilterDefinition<Synonym> filter = builderFilter.Regex(searchKey[name], regex);

                        databind(name, filterSynonym: filter);
                    }
                    break;
                case PROPERNOUNS:
                    {
                        //设置过滤器
                        FilterDefinitionBuilder<Proper> builderFilter = new FilterDefinitionBuilder<Proper>();
                        //使用正则表达式匹配所有包含text的value
                        BsonRegularExpression regex = new BsonRegularExpression(string.Format(".*{0}.*", text));
                        FilterDefinition<Proper> filter = builderFilter.Regex(searchKey[name], regex);

                        databind(name, filterProper: filter);
                    }
                    break;
            }
        }
        /// <summary>
        /// 更新单元格出发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridview_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // 更新行号的时候不触发  columnIndex = -1 时表示行号 =0 时表示objectId
            if (e.ColumnIndex <= 0) return;
            if (e.RowIndex != -1)//列标题改变时不触发
            {
                int rowIndex = e.RowIndex;
                int colIndex = e.ColumnIndex;

                string name = title.SelectedItem.ToString();

                switch (name)
                {
                    case STOPWORD:
                        {
                            var collection = database.GetCollection<Stopword>(collectionDict[name]);
                            string word = gridview.Rows[rowIndex].Cells[1].Value.ToString();
                            int weight = Convert.ToInt32(gridview.Rows[rowIndex].Cells[2].Value.ToString());
                            if (weight == 0) return;
                            //当添加新数据的时候，第0个元素没有id值，为空， 对数据库进行插入操作
                            if (gridview.Rows[rowIndex].Cells[0].Value == null && word != "")
                            {

                                if (MessageBox.Show("是否添加" + word, "添加 ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    try
                                    {
                                        var result = collection.CountDocuments(o => o.stopword == word);
                                        if (result > 0)
                                        {
                                            MessageBox.Show("已存在！");
                                            return;
                                        }
                                        collection.InsertOne(new Stopword(word, weight));
                                        gridview.Rows[rowIndex].Cells[0].Value = collection.Find(o => o.stopword == word).ToList()[0]._id;
                                        add_word(word, weight.ToString());
                                        MessageBox.Show("添加成功！");

                                        return;
                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("添加失败！");
                                        return;
                                    }
                                }
                            }
                            try
                            {
                                if (colIndex == 1)
                                {
                                    var updateDef = Builders<Stopword>.Update.Set(o => o.stopword, gridview.Rows[rowIndex].Cells[colIndex].Value.ToString());

                                    collection.UpdateOne(o => o._id == (BsonObjectId)gridview.Rows[rowIndex].Cells[0].Value, updateDef);
                                    MessageBox.Show("更新成功！");
                                }
                                else if (colIndex == 2)
                                {
                                    var updateDef = Builders<Stopword>.Update.Set(o => o.weight, Convert.ToInt32(gridview.Rows[rowIndex].Cells[colIndex].Value.ToString()));
                                    collection.UpdateOne(o => o._id == (BsonObjectId)gridview.Rows[rowIndex].Cells[0].Value, updateDef);
                                    MessageBox.Show("更新成功！");
                                }
                                add_word(word, weight.ToString());
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("更新失败！");
                                databind(name);
                            }
                        }
                        break;
                    case SYNONYM:
                        {
                            var collection = database.GetCollection<Synonym>(collectionDict[name]);

                            string word = gridview.Rows[rowIndex].Cells[1].Value.ToString();
                            string synonym = gridview.Rows[rowIndex].Cells[2].Value.ToString();
                            if (word == "" || synonym == "") return;
                            //当添加新数据的时候，第0个元素没有id值，为空， 对数据库进行插入操作
                            if (gridview.Rows[rowIndex].Cells[0].Value == null && word != "" && synonym != "")
                            {
                                if (MessageBox.Show("是否添加" + word, "添加 ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    try
                                    {
                                        var result = collection.CountDocuments(o => o.standard == word);
                                        if (result > 0)
                                        {
                                            MessageBox.Show("已存在！");
                                            return;
                                        }
                                        collection.InsertOne(new Synonym(word, synonym));
                                        gridview.Rows[rowIndex].Cells[0].Value = collection.Find(o => o.standard == word).ToList()[0]._id;
                                        MessageBox.Show("添加成功！");
                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("添加失败！");
                                        return;
                                    }
                                    //add_word(word, synonym);
                                }
                                return;
                            }
                            else if (colIndex == 1)//更新标准词
                            {
                                try
                                {

                                    var updateDef = Builders<Synonym>.Update.Set(o => o.standard, gridview.Rows[rowIndex].Cells[colIndex].Value.ToString());

                                    collection.UpdateOne(o => o._id == (BsonObjectId)gridview.Rows[rowIndex].Cells[0].Value, updateDef);
                                    MessageBox.Show("更新成功！");
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("更新失败！");
                                    databind(name);
                                }
                            }
                            else if (colIndex == 2)//更新同义词
                            {
                                try
                                {
                                    var updateDef = Builders<Synonym>.Update.Set(o => o.synonyms, gridview.Rows[rowIndex].Cells[colIndex].Value.ToString());

                                    collection.UpdateOne(o => o._id == (BsonObjectId)gridview.Rows[rowIndex].Cells[0].Value, updateDef);
                                    MessageBox.Show("更新成功！");
                                }
                                catch (Exception err)
                                {
                                    MessageBox.Show("更新失败！");
                                    databind(name);
                                }
                            }
                            //add_word(word, synonym);
                        }
                        break;
                    case PROPERNOUNS:
                        {
                            var collection = database.GetCollection<Proper>(collectionDict[name]);

                            string word = gridview.Rows[rowIndex].Cells[1].Value.ToString();
                            int weight = Convert.ToInt32(gridview.Rows[rowIndex].Cells[2].Value.ToString());
                            if (weight == 0) return;
                            //当添加新数据的时候，第0个元素没有id值，为空， 对数据库进行插入操作
                            if (gridview.Rows[rowIndex].Cells[0].Value == null && word != "")
                            {
                                if (MessageBox.Show("是否添加" + word, "添加 ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    try
                                    {
                                        var result = collection.CountDocuments(o => o.properNouns == word);
                                        if (result > 0)
                                        {
                                            MessageBox.Show("已存在！");
                                            return;
                                        }
                                        collection.InsertOne(new Proper(word, weight));
                                        gridview.Rows[rowIndex].Cells[0].Value = collection.Find(o => o.properNouns == word).ToList()[0]._id;
                                        add_word(word, weight.ToString());
                                        MessageBox.Show("添加成功！");
                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("添加失败！");
                                        return;
                                    }
                                }
                                return;
                            }
                            try
                            {
                                if (colIndex == 1)
                                {
                                    var updateDef = Builders<Proper>.Update.Set(o => o.properNouns, gridview.Rows[rowIndex].Cells[colIndex].Value.ToString());

                                    collection.UpdateOne(o => o._id == (BsonObjectId)gridview.Rows[rowIndex].Cells[0].Value, updateDef);
                                    MessageBox.Show("更新成功！");
                                }
                                else if (colIndex == 2)
                                {
                                    var updateDef = Builders<Proper>.Update.Set(o => o.weight, Convert.ToInt32(gridview.Rows[rowIndex].Cells[colIndex].Value.ToString()));

                                    collection.UpdateOne(o => o._id == (BsonObjectId)gridview.Rows[rowIndex].Cells[0].Value, updateDef);
                                    MessageBox.Show("更新成功！");
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("更新失败！");
                                databind(name);
                            }
                            add_word(word, weight.ToString());
                        }
                        break;
                }
            }
        }
        /// <summary>
        /// 删除按钮触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = gridview.CurrentCell.RowIndex;

                int colIndex = gridview.CurrentCell.ColumnIndex;

                string content = gridview.Rows[rowIndex].Cells[colIndex].Value.ToString();

                if (MessageBox.Show("是否删除" + content, "删除 ", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string name = title.SelectedItem.ToString();

                    try
                    {
                        var collection = database.GetCollection<BsonDocument>(collectionDict[name]);
                        BsonObjectId id = gridview.Rows[rowIndex].Cells[0].Value as BsonObjectId;

                        var Deleteone = collection.DeleteOne(Builders<BsonDocument>.Filter.Eq("_id", id));
                        delete_word(gridview.Rows[rowIndex].Cells[1].Value.ToString());
                        
                        //databind(name);
                        MessageBox.Show("删除成功！");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("删除失败！");
                        return;
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("请选中要删除的内容！");
                return;
            }


        }

        private void gridview_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string name = title.SelectedItem.ToString();

            switch (name)
            {
                case STOPWORD:
                    {
                        Stopword adding = new Stopword("", 0);
                        List<Stopword> source = new List<Stopword>();
                        source.Add(adding);
                        gridview.DataSource = source;
                    }
                    break;
                case SYNONYM:
                    {
                        Synonym adding = new Synonym("", "");
                        List<Synonym> source = new List<Synonym>();
                        source.Add(adding);
                        gridview.DataSource = source;
                    }
                    break;
                case PROPERNOUNS:
                    {
                        Proper adding = new Proper("", 0);
                        List<Proper> source = new List<Proper>();
                        source.Add(adding);
                        gridview.DataSource = source;
                    }
                    break;
            }
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


        private void add_word(string word, string weight)
        {
            string name = title.SelectedItem.ToString();
            string type = "word";
            if (name == STOPWORD) type = "stopword";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(add_params("word", new Dictionary<string, string> { { type, word }, { "weight", weight } }));
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            try
            {

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
            }
            catch (Exception e)
            {

                throw;
            }
        }

        private void delete_word(string word)
        {
            string name = title.SelectedItem.ToString();
            string type = "word";
            if (name == STOPWORD) type = "stopword";
            else if (name == SYNONYM) return;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(add_params("word", new Dictionary<string, string> { { type, word } }));
            request.Method = "DELETE";
            request.ContentType = "text/html;charset=UTF-8";

            try
            {

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
