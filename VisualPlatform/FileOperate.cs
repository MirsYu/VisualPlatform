using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace VisualPlatform
{
	class FileOperate
	{
		public struct ControlInfo
		{
			public string getClass;
			public string getName;
		}
		public List<ControlInfo> Arrcont = new List<ControlInfo>();
		public string ReadFile(string fileName,Control plane)
		{
			StreamReader strRead = new StreamReader(fileName,Encoding.Default);
			string line = "";
			string txt = "";
			int structlength = 0;
			while ((line=strRead.ReadLine())!=null)
			{
				txt += line;
				txt += "\r\n";
				// 解析脚本
				if(line.IndexOf("public") != -1)
				{
					string temp = "";
					string getName = "";
					string getClass = "";
					temp = line.Substring(line.IndexOf("public") + 7);
					getClass = temp.Substring(0, temp.IndexOf(" "));
					if (getClass == "struct")
					{
						structlength++;
						getName = temp.Substring(getClass.Length + 1, temp.Length - getClass.Length - 2);
						ControlInfo cont = new ControlInfo();
						cont.getClass = getClass;
						cont.getName = getName;
						Arrcont.Add(cont);
					}
					else if (line.IndexOf(";") != -1)
					{
						getName = temp.Substring(getClass.Length + 1, temp.Length - getClass.Length - 2);
						ControlInfo cont = new ControlInfo();
						cont.getClass = getClass;
						cont.getName = getName;
						Arrcont.Add(cont);
					}

				}
				if (structlength > 0 && line.IndexOf("}") != -1)
				{
					ControlInfo cont = new ControlInfo();
					cont.getClass = "End";
					cont.getName = "Endstruct";
					Arrcont.Add(cont);
					structlength--;
				}
			}
			strRead.Close();
			addControls(plane);
			return txt;
		}
		public static bool WriteFile(string fileName,string text)
		{
			FileStream fs = new FileStream(fileName, FileMode.Create);
			StreamWriter strWriter = new StreamWriter(fs);
			strWriter.Write(text);
			strWriter.Flush();
			strWriter.Close();
			fs.Close();
			return true;
		}
		public void addControls(Control plane)
		{
			Label lab = new Label();
			//Arrcont.OrderBy(a => a.getClass).ToList();
			for (int i = 0; i < Arrcont.Count; i++)
			{
				lab = new Label();
				lab.Name = "label" + i;
				lab.Text = Arrcont[i].getName;
				System.Drawing.Size size = new System.Drawing.Size();
				size = lab.ClientSize;
				size.Width = 100;
				lab.ClientSize = size;
				lab.TextAlign = System.Drawing.ContentAlignment.TopLeft;
				lab.Location = new System.Drawing.Point(0, i * 20);
				plane.Controls.Add(lab);

				TextBox tex = new TextBox();
				switch (Arrcont[i].getClass)
				{
					case "int":
						tex.Name = "int" + i;
						tex.Location = new System.Drawing.Point(100, i * 20);
						tex.Multiline = true;
						size = tex.ClientSize;
						size.Height = 15;
						tex.ClientSize = size;
						tex.KeyPress += new KeyPressEventHandler(textBox_int_KeyPress);
						plane.Controls.Add(tex);
						break;
					case "string":
						tex.Name = "string" + i;
						tex.Location = new System.Drawing.Point(100, i * 20);
						tex.Multiline = true;
						size = tex.ClientSize;
						size.Height = 15;
						tex.ClientSize = size;
						plane.Controls.Add(tex);
						break;
					case "float":
						tex.Name = "float" + i;
						tex.Location = new System.Drawing.Point(100, i * 20);
						tex.Multiline = true;
						size = tex.ClientSize;
						size.Height = 15;
						tex.ClientSize = size;
						tex.KeyPress += new KeyPressEventHandler(textBox_double_KeyPress);
						plane.Controls.Add(tex);
						break;
					case "double":
						tex.Name = "double" + i;
						tex.Location = new System.Drawing.Point(100, i * 20);
						tex.Multiline = true;
						size = tex.ClientSize;
						size.Height = 15;
						tex.ClientSize = size;
						tex.KeyPress += new KeyPressEventHandler(textBox_double_KeyPress);
						plane.Controls.Add(tex);
						break;
					default:
						break;
				}
			}
		}
		private void textBox_int_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 0x20|| (e.KeyChar == 46)) e.KeyChar = (char)0;  //禁止空格键 和小数点
			if (e.KeyChar > 0x20)
			{
				try
				{
					double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
				}
				catch
				{
					e.KeyChar = (char)0;   //处理非法字符
				}
			}
		}
		private void textBox_double_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键 和小数点
			if (e.KeyChar == 46&& ((TextBox)sender).Text.IndexOf(".") != -1)
			{
				e.KeyChar = (char)0;
			}
			if (e.KeyChar > 0x20)
			{
				try
				{
					double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
				}
				catch
				{
					e.KeyChar = (char)0;   //处理非法字符
				}
			}
		}
	}
}
