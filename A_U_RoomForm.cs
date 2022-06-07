using FlatUI.消息提示框;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HotelManageSystem
{
    public partial class A_U_RoomForm : Form
    {
        int mode = -1;
        string id;

        public A_U_RoomForm(int mode)
        {
            this.mode = mode;
            InitializeComponent();
            if (mode == 0)
                tipText.Text = "添加房型";
            else
                tipText.Text = "修改信息";
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // 用双缓冲绘制窗口的所有子控件
                return cp;
            }
        }

        public A_U_RoomForm(int mode, string id, string name, string bathroom, string nextwindow, string food, string ac, string computer, string area, string price, string count)
        {
            this.mode = mode;
            InitializeComponent();
            if (mode == 0)
                tipText.Text = "添加房型";
            else
                tipText.Text = "修改信息";
            this.id = id;
            this.nameText.TextContent = name;
            this.bathroomComb.Text = bathroom == "0"?"无":"有";
            this.windowComb.Text = nextwindow == "0" ? "无" : "有";
            this.foodComb.Text = food == "0" ? "无" : "有";
            this.acComb.Text = ac == "0" ? "无" : "有";
            this.computerComb.Text = computer == "0" ? "无" : "有";
            this.areaText.TextContent = area;
            this.priceText.TextContent = price;
            this.countText.TextContent = count;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool result = false;
            if (mode == 0)
                result = new DataBase().UpdateDB("insert into tb_room values('"+nameText.TextContent+"',"+(bathroomComb.Text=="无"?0:1)+","+ (windowComb.Text == "无" ? 0 : 1) + ","+ (foodComb.Text == "无" ? 0 : 1) + ","+ (acComb.Text == "无" ? 0 : 1) + ","+ (computerComb.Text == "无" ? 0 : 1) + ","+areaText.TextContent+","+priceText.TextContent+","+countText.TextContent+")");
            else
               result = new DataBase().UpdateDB("update tb_room set name='" + nameText.TextContent + "',bathroom=" + (bathroomComb.Text == "无" ? 0 : 1) + ",nextwindow=" + (windowComb.Text == "无" ? 0 : 1) + ",food=" + (foodComb.Text == "无" ? 0 : 1) + ",airconditioner=" + (acComb.Text == "无" ? 0 : 1) + ",computer=" + (computerComb.Text == "无" ? 0 : 1) + ",area=" + areaText.TextContent + ",price=" + priceText.TextContent + ",count=" + countText.TextContent+"where id="+id);
            if (result)
            {
                MessageV mv = new MessageV();
                mv.Str2 = "完成！";
                mv.ShowDialog();
                Close();
            }
            else
            {
                errorMessageBox error = new errorMessageBox();
                Service.setMessageForm(error, messagePanel);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            Service.setFormMini(this);
        }

        private void A_U_RoomForm_Load(object sender, EventArgs e)
        {
            windowsLeaveForMouseDown1.Add(TopPanel);
            windowsLeaveForMouseDown1.Form = this;
        }
    }
}
