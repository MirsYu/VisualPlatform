using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Diagnostics;
using System.IO;
using CSScriptLibrary;
using System.Reflection;
using ZXing;
using System.Threading;
using System.Net.Sockets;
using System.Net;

public interface ITextCapitalizer
{
	string ToUpper(string text);
	string ToLower(string text);
}

namespace VisualPlatform
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			#region 根据文件添加ListView项
			// 生成组件
			// 先遍历ico下所有图片 添加进imagelist
			// 创建listview 项 
			string Codename = "./Code";
			string Iconame = "./Ico";
			DirectoryInfo IcoDireInfo = new DirectoryInfo(Iconame);
			this.treeView_Components.Nodes.Clear();
			this.imageList1.Images.Clear();
			foreach (FileInfo NextFile in IcoDireInfo.GetFiles())
			{
				if (NextFile.Name.IndexOf(".ico") != -1)
				{
					Image img = Image.FromFile(NextFile.FullName);
					imageList1.Images.Add(NextFile.Name.Replace(".ico", ""), img);
				}
			}
			foreach (DirectoryInfo Nextdir in IcoDireInfo.GetDirectories())
			{
				foreach (FileInfo secondfile in Nextdir.GetFiles())
				{
					if (secondfile.Name.IndexOf(".ico") != -1)
					{
						Image img = Image.FromFile(secondfile.FullName);
						string nametemp = "./" + Nextdir.Name + "/" + secondfile.Name;
						imageList1.Images.Add(nametemp.Replace(".ico", ""), img);
					}
				}
			}

			treeView_Components.StateImageList = imageList1;
			DirectoryInfo CodeDireInfo = new DirectoryInfo(Codename);
			foreach (FileInfo NextFile in CodeDireInfo.GetFiles())
			{
				if (NextFile.Name.IndexOf(".cs") != -1)
				{
					TreeNode lvi = new TreeNode();
					lvi.ImageIndex = imageList1.Images.IndexOfKey(NextFile.Name.Replace(".cs", ""));
					lvi.SelectedImageIndex = lvi.ImageIndex;
					lvi.Text = NextFile.Name;
					treeView_Components.Nodes.Add(lvi);
				}
			}
			foreach (DirectoryInfo Nextdir in CodeDireInfo.GetDirectories())
			{
				TreeNode file = new TreeNode();
				file.ImageIndex = imageList1.Images.IndexOfKey("file");
				file.SelectedImageIndex = imageList1.Images.IndexOfKey("file");
				file.Text = Nextdir.Name;
				treeView_Components.Nodes.Add(file);
				foreach (FileInfo secondfile in Nextdir.GetFiles())
				{
					if (secondfile.Name.IndexOf(".cs") != -1)
					{
						TreeNode lvi = new TreeNode();
						string nametemp = "./" + Nextdir.Name + "/" + secondfile.Name;
						lvi.ImageIndex = imageList1.Images.IndexOfKey(nametemp.Replace(".cs", ""));
						lvi.SelectedImageIndex = lvi.ImageIndex;
						lvi.Text = secondfile.Name;
						file.Nodes.Add(lvi);
					}
				}
			}
			#endregion
		}

		void test()
		{
			string assembly = CSScript.CompileFile("script.cs", null);
			using (var script = new AsmHelper(assembly, null, true))
			{
				var capitalizer = (ITextCapitalizer)script.CreateObject("Script");
				string te = capitalizer.ToLower("HeLLo");
				MessageBox.Show(te);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			OpenFileDialog Openfile = new OpenFileDialog();
			if (Openfile.ShowDialog() == DialogResult.OK)
			{
				Image<Bgr, Byte> My_Image = new Image<Bgr, byte>(Openfile.FileName);
				//Mat My_Image = CvInvoke.Imread(Openfile.FileName, Emgu.CV.CvEnum.ImreadModes.Unchanged);
				// 高斯滤波
				CvInvoke.GaussianBlur(My_Image, My_Image, new Size(3, 3), 0, 0);
				CvInvoke.Imshow("GaussianBlur.", My_Image);
				// 转换灰度图 二值化
				CvInvoke.Threshold(My_Image, My_Image, 100, 255, Emgu.CV.CvEnum.ThresholdType.Binary);
				CvInvoke.Imshow("Gray.", My_Image);
				// 腐蚀 膨胀核
				Emgu.CV.Mat StructingElement = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Ellipse, new Size(7, 7), new Point(2, 2)); // 核
				CvInvoke.Erode(My_Image, My_Image, StructingElement, new Point(-1,-1),10,Emgu.CV.CvEnum.BorderType.Default, new MCvScalar(0));
				Image<Bgr, Byte> image1 = My_Image.Clone();
				
				CvInvoke.Erode(My_Image, image1, StructingElement, new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar(0));
				image1 = My_Image - image1;
				CvInvoke.Imshow("GetStructuringElement.", image1);

				CvInvoke.Canny(image1, image1, trackBar1.Value, trackBar1.Value * 3, 3);
				imageBox1.Image = image1;
				ScanBarCodeZbar(image1.ToBitmap());
			}
		}

		/// <summary>
		/// Zbar条码识别
		/// </summary>
		private void ScanBarCodeZbar(Image primaryImage)
		{
			using (ZBar.ImageScanner scanner = new ZBar.ImageScanner())
			{
				scanner.SetConfiguration(ZBar.SymbolType.EAN13, ZBar.Config.Enable, 1);
				List<ZBar.Symbol> symbols = new List<ZBar.Symbol>();
				System.Diagnostics.Stopwatch watch = new Stopwatch();
				watch.Start();
				symbols = scanner.Scan((Image)primaryImage);
				watch.Stop();
				TimeSpan timeSpan = watch.Elapsed;

				if (symbols != null && symbols.Count > 0)
				{
					string result = "扫描执行时间：" + timeSpan.TotalMilliseconds.ToString();
					symbols.ForEach(s => result += ",条码内容:" + s.Data + " 条码类型:" + s.Type + " 条码质量:" + s.Quality + Environment.NewLine);
					MessageBox.Show(result);
				}
			}
		}

		private void ScanBarCodeZxing(Image primaryImage)
		{
			IBarcodeReader reader = new BarcodeReader();
			System.Diagnostics.Stopwatch watch = new Stopwatch();
			watch.Start();
			Result result = reader.Decode((Bitmap)primaryImage); //通过reader解码
			watch.Stop();
			TimeSpan timeSpan = watch.Elapsed;
			MessageBox.Show("扫描执行时间：" + timeSpan.TotalMilliseconds.ToString()
							+ ",条码内容:" + result.Text
							+ ",条码类型" + result.BarcodeFormat.ToString()
							);
		}

		#region 拖拽相关

		//判断视图里是否存在相同项
		private bool FilterName(TreeNodeCollection treeView, string name)
		{
			for (int i = 0; i < treeView.Count; i++)
			{
				if (treeView[i].Nodes.Count > 0)
				{
					if (FilterName(treeView[i].Nodes, name))
						return true;
					else
						return false;
				}
				if (string.Equals(treeView[i].Text, name))
				{
					return true;
				}
			}
			return false;
		}
		//private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
		//{
		//	listView1.DoDragDrop(e.Item, DragDropEffects.Move);
		//}
		//private void listView1_DragEnter(object sender, DragEventArgs e)
		//{
		//	if (e.Data.GetDataPresent(typeof(ListViewItem)))//是否是真 
		//	{
		//		e.Effect = DragDropEffects.Move;
		//	}
		//	else
		//	{
		//		e.Effect = DragDropEffects.None;
		//	}
		//}
		//private void listView1_DragOver(object sender, DragEventArgs e)
		//{
		//	// 获得鼠标坐标
		//	Point point = listView1.PointToClient(new Point(e.X, e.Y));
		//	// 返回离鼠标最近的项目的索引
		//	int index = listView1.InsertionMark.NearestIndex(point);
		//	// 确定光标不在拖拽项目上
		//	if (index > -1)
		//	{
		//		Rectangle itemBounds = listView1.GetItemRect(index);
		//		if (point.X > itemBounds.Left + (itemBounds.Width / 2))
		//		{
		//			listView1.InsertionMark.AppearsAfterItem = true;
		//		}
		//		else
		//		{
		//			listView1.InsertionMark.AppearsAfterItem = false;
		//		}
		//	}
		//	listView1.InsertionMark.Index = index;
		//}
		//private void listView1_DragLeave(object sender, EventArgs e)
		//{
		//	listView1.InsertionMark.Index = -1;
		//}
		//private void listView1_DragDrop(object sender, DragEventArgs e)
		//{
		//	// 返回插入标记的索引值
		//	int index = listView1.InsertionMark.Index;
		//	// 返回拖拽项 
		//	ListViewItem item = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
		//	// 如果插入标记不可见，则退出.
		//	if (index == -1)
		//	{
		//		if (FilterName(listView2, item.Text))
		//		{
		//			ListViewItem itemTemp = (ListViewItem)item.Clone();
		//			int NameIndex = 1;
		//			for (int i = 0; i < listView1.Items.Count; i++)
		//			{
		//				if (listView1.Items[i].Text.IndexOf(item.Text) !=-1)
		//				{
		//					NameIndex++;
		//				}
		//			}
		//			itemTemp.Text += NameIndex;
		//			NameIndex = 1;
		//			listView1.Items.Insert(index + 1, itemTemp);
		//		}
		//		else//普通用户里的项拖拽到自己里的未知位置时，不发生移动！
		//		{
		//			//在目标索引位置插入一个拖拽项目的副本
		//			listView1.Items.Insert(index, (ListViewItem)item.Clone());
		//			//移除拖拽项目的原文件
		//			listView1.Items.Remove(item);
		//		}
		//		return;
		//	}
		//	// 如果插入标记在项目的右面，使目标索引值加一
		//	if (listView1.InsertionMark.AppearsAfterItem)
		//	{
		//		index++;
		//	}
		//	if (FilterName(listView2,item.Text))
		//	{
		//		//listView2.Items.Remove(item);
		//		//在目标索引位置插入一个拖拽项目的副本 
		//		ListViewItem itemTemp = (ListViewItem)item.Clone();
		//		int NameIndex = 1;
		//		for (int i = 0; i < listView1.Items.Count; i++)
		//		{
		//			if (listView1.Items[i].Text.IndexOf(item.Text) != -1)
		//			{
		//				NameIndex++;
		//			}
		//		}
		//		itemTemp.Text += NameIndex;
		//		NameIndex = 1;
		//		listView1.Items.Insert(index, itemTemp);
		//	}
		//	else
		//	{
		//		//在目标索引位置插入一个拖拽项目的副本
		//		listView1.Items.Insert(index, (ListViewItem)item.Clone());
		//		// 移除拖拽项目的原文件
		//		listView1.Items.Remove(item);
		//	}
		//}
		//// 对ListView里的各项根据索引进行排序
		//private class ListViewIndexComparer : System.Collections.IComparer
		//{
		//	public int Compare(object x, object y)
		//	{
		//		return ((ListViewItem)x).Index - ((ListViewItem)y).Index;
		//	}
		//}
		//private void listView1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		//{

		//}
		//private void listView2_ItemDrag(object sender, ItemDragEventArgs e)
		//{
		//	listView2.DoDragDrop(e.Item, DragDropEffects.Move);
		//}
		#endregion

		#region treeView_Hierachy
		private void treeView_Hierachy_DragDrop(object sender, DragEventArgs e)
		{
			TreeNode myNode = null;

			if (e.Data.GetDataPresent(typeof(TreeNode)))
			{
				myNode = (TreeNode)(e.Data.GetData(typeof(TreeNode)));
			}
			else
			{
				MessageBox.Show("error");
			}
			Point Position = new Point();
			Position.X = e.X;
			Position.Y = e.Y;
			Position = treeView_Hierachy.PointToClient(Position);
			TreeNode TargetNode = this.treeView_Hierachy.GetNodeAt(Position);
			// 如果是文件夹
			if (myNode.ImageIndex == imageList1.Images.IndexOfKey("file"))
			{
				return;
			}
			// 如果是从组件列表里面拖拽
			if (FilterName(treeView_Components.Nodes, myNode.Text))
			{
				TreeNode DragNode = (TreeNode)myNode.Clone();
				int NameIndex = 1;
				for (int i = 0; i < treeView_Hierachy.Nodes.Count; i++)
				{
					if (treeView_Hierachy.Nodes[i].Text.IndexOf(myNode.Text) != -1)
					{
						NameIndex++;
					}
				}
				DragNode.Text += NameIndex;
				treeView_Hierachy.Nodes.Add(DragNode);
			}
			// 本列表中拖拽
			else
			{
				//在目标索引位置插入一个拖拽项目的副本
				int index = treeView_Hierachy.Nodes.IndexOf(TargetNode);
				treeView_Hierachy.Nodes.Insert(index, (TreeNode)myNode.Clone());
				//移除拖拽项目的原文件
				treeView_Hierachy.Nodes.Remove(myNode);
			}
		}

		private void treeView_Hierachy_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(TreeNode)))
				e.Effect = DragDropEffects.Move;
			else
				e.Effect = DragDropEffects.None;
		}

		private void treeView_Hierachy_ItemDrag(object sender, ItemDragEventArgs e)
		{
			DoDragDrop(e.Item, DragDropEffects.Move);
		}
		#endregion

		private void treeView_Components_ItemDrag(object sender, ItemDragEventArgs e)
		{
			DoDragDrop(e.Item, DragDropEffects.Move);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			test();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			// 打开文件
			OpenFileDialog openfile = new OpenFileDialog();
			FileOperate oper = new FileOperate();
			if (openfile.ShowDialog() == DialogResult.OK)
			{
				textBox2.Text = openfile.FileName;
				textBox1.Text = oper.ReadFile(openfile.FileName, tabPage5);
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			// 保存文件
			if (textBox2.Text != null)
			{
				if (FileOperate.WriteFile(textBox2.Text, textBox1.Text))
				{
					MessageBox.Show("保存成功");
				}
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			OpenFileDialog Openfile = new OpenFileDialog();
			if (Openfile.ShowDialog() == DialogResult.OK)
			{
				Image<Bgr, Byte> My_Image = new Image<Bgr, byte>(Openfile.FileName);
				Image<Gray, byte> gray_image = My_Image.Convert<Gray, byte>();
				imageBox1.Image = gray_image;
				ScanBarCodeZxing(gray_image.ToBitmap());
			}
		}

		private Thread threadClient;
		private Socket socket;
		IPAddress ip = IPAddress.Parse("192.168.0.100");
		public byte[] MsgBuffer = new byte[0xa00000];
		private int length;
		public DynamicBufferManager recDynBuffer;
		private int lastEndPosition;
		private int lastStartPosition;
		private byte[] startCode;
		private byte[] endCode;
		private Stream recStream;

		private void btn_Connet_Click(object sender, EventArgs e)
		{
			recDynBuffer = new DynamicBufferManager(0xa00000);
			this.startCode = new byte[] { 0xff, 0xd8, 0xff };
			this.endCode = new byte[] { 0xff, 0xd9 };

			socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			socket.Connect(ip, 20000);
			threadClient = new Thread(new ParameterizedThreadStart(this.ReceiveData));
			threadClient.IsBackground = true;
			threadClient.Start(this.socket);
		}

		private void ReceiveData(object clienSocket)
		{
			byte[] buffMsgRec = new byte[0xa00000];
			Socket clien = clienSocket as Socket;
			while (true)
			{
				length = socket.Receive(buffMsgRec);
				this.recDynBuffer.WriteBuffer(buffMsgRec, 0, length);

				showData();
			}
		}

		private void showData()
		{
			int startIndex = -1;
			int num2 = -1;
			if ((this.lastStartPosition != -1) && (this.lastEndPosition != -1))
			{
				this.recDynBuffer.Clear(this.lastEndPosition);
				this.lastStartPosition = this.lastEndPosition = -1;
			}
			startIndex = this.IndexOf(this.recDynBuffer.Buffer, this.startCode, 0, this.recDynBuffer.DataCount);
			if (startIndex != -1)
			{
				this.lastStartPosition = startIndex;
				num2 = this.IndexOf(this.recDynBuffer.Buffer, this.endCode, startIndex, this.recDynBuffer.DataCount);
				if (num2 != -1)
				{
					this.lastEndPosition = num2;
					this.recStream = new MemoryStream(this.recDynBuffer.Buffer, startIndex, num2 - startIndex);
					Image image = Image.FromStream(recStream, true);
					Image<Bgr, Byte> My_Image = new Image<Bgr, byte>(new Bitmap(image));
					imageBox1.Image = My_Image;
				}
			}
		}

		internal int IndexOf(byte[] srcBytes, byte[] searchBytes, int startIndex, int srcLength)
		{
			if (srcBytes != null)
			{
				if (searchBytes == null)
				{
					return -1;
				}
				if ((srcLength == 0) || (srcLength > srcBytes.Length))
				{
					return -1;
				}
				if ((startIndex >= srcBytes.Length) || (startIndex < 0))
				{
					return -1;
				}
				if (searchBytes.Length != 0)
				{
					if (srcLength < searchBytes.Length)
					{
						return -1;
					}
					for (int i = startIndex; i < (srcLength - searchBytes.Length); i++)
					{
						if (srcBytes[i] != searchBytes[0])
						{
							continue;
						}
						if (searchBytes.Length == 1)
						{
							return i;
						}
						bool flag = true;
						for (int j = 1; j < searchBytes.Length; j++)
						{
							if (srcBytes[i + j] != searchBytes[j])
							{
								flag = false;
								break;
							}
						}
						if (flag)
						{
							return i;
						}
					}
				}
			}
			return -1;
		}
	}
}
