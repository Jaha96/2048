using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using System.Media;
namespace game2048
{
    public partial class Game2048 : Form
    {
        Random Rd = new Random();
        bool playing = true;
        static ArrayList mangChiSoRong = new ArrayList();
        public Game2048()
        {
            InitializeComponent();
        }
        public void CapNhatMau()
        {
            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {

                    if(Game[i,j].Text==""){
                        Game[i, j].BackColor = System.Drawing.Color.CadetBlue;
                    }
                    if (Game[i, j].Text == "2")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.Silver;
                        Game[i, j].ForeColor = System.Drawing.Color.White;

                    }
                    if (Game[i, j].Text == "4")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.Gray;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "8")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "16")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.Black;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "32")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.Yellow;
                        Game[i, j].ForeColor = System.Drawing.Color.Silver;
                    }
                    if (Game[i, j].Text == "64")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "128")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.Olive;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "256")
                    {
                        Game[i, j].BackColor = Color.Gold;
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "512")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "1024")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
                        Game[i, j].ForeColor = System.Drawing.Color.White;
                    }
                    if (Game[i, j].Text == "2048")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
                        Game[i, j].ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                    }
                    if (Game[i, j].Text == "4096")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                        Game[i, j].ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                    }
                    if (Game[i, j].Text == "8192")
                    {
                        Game[i, j].BackColor = System.Drawing.Color.Maroon;
                        Game[i, j].ForeColor = System.Drawing.Color.Yellow;
                    }
                }
            }
            
        }
        
        public void KhoiTaoManGame() {
            mangChiSoRong.Clear();

            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            for (int i = 0; i < 4;i++ )
            {
                for (int j = 0; j < 4;j++)
                {
                    if(Game[i,j].Text==""){
                        mangChiSoRong.Add(i*4+j+1);
                    }
                }
            }
            
            if(mangChiSoRong.Count>0){
               
                int chiSoHinh = int.Parse(mangChiSoRong[Rd.Next(0,mangChiSoRong.Count-1)].ToString());
                int i0 = (chiSoHinh - 1) / 4;
                int j0 = (chiSoHinh - 1) - i0 *4;
                int NgauNhien = Rd.Next(1,10);
                if (NgauNhien == 1 || NgauNhien == 2 || NgauNhien == 3 || NgauNhien == 4 || NgauNhien == 5||NgauNhien==6 )
                {
                    Game[i0, j0].Text = "2";
                }
                else { 
                    Game[i0,j0].Text="4";
                }

            }
            CapNhatMau();
        }
        public void LenTren() {
            bool khongLenDuoc = true;
            bool anDiem = false;
            bool kTraKhoiTao = false;
            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            for (int i = 0; i < 4;i++ )
            {
                int oRong = 0;
                for (int j = 0; j < 4;j++ )
                {
                    for (int k = j+1; k < 4;k++ )
                    {
                        if(Game[k,i].Text!=""){
                            if(Game[k,i].Text==Game[j,i].Text){
                                anDiem = true;
                            }
                            break;
                        }
                    }
                    if (Game[j, i].Text == "")
                    {
                        oRong++;
                    }
                    else {
                        for (int m = j; m >= 0;m-- )
                        {
                            if(Game[m,i].Text==""){
                                kTraKhoiTao = true;
                                break;
                            }
                        }
                        if (j + 1 < 4)
                        {
                            bool ktra = true;
                            
                            for (int k = j + 1; k < 4; k++)
                            {
                                if (Game[k, i].Text != "")
                                {
                                    if (Game[j, i].Text == Game[k, i].Text)
                                    {
                                        khongLenDuoc = false;
                                        lblScore.Text = (int.Parse(lblScore.Text) + int.Parse(Game[ j,i].Text) * 2).ToString();
                                        kTraKhoiTao = true;
                                        ktra = false;
                                        Game[j, i].Text = (int.Parse(Game[j, i].Text) * 2).ToString();
                                        if(oRong!=0){
                                            Game[j - oRong, i].Text = Game[j, i].Text;
                                            Game[j, i].Text = "";
                                            
                                        }
                                        Game[k, i].Text = "";
                                        break;
                                        
                                    }
                                    break;
                                }
                            }
                            if(ktra==true && oRong!=0){
                                khongLenDuoc = false;
                                Game[j - oRong, i].Text = Game[j, i].Text;
                                Game[j, i].Text = "";
                                
                            }
                        }
                        else {
                            if(oRong!=0){
                                khongLenDuoc = false;
                                Game[j - oRong, i].Text = Game[j, i].Text;
                                Game[j, i].Text = "";
                                
                            }
                        }
                        
                       
                    }
                }
            }
            if(kTraKhoiTao==true){
                KhoiTaoManGame();
            }
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            KhoiTaoManGame();
            KhoiTaoManGame();
            KhoiTaoManGame();
        }
        public void XuongDuoi()
        {
            bool khongXuongDuoc = true;
            bool anDiem = false;
            bool kTraKhoiTao = false;
            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            for (int i = 0; i < 4; i++)
            {
                int oRong = 0;
                for (int j = 3; j >=0; j--)
                {
                    for (int k = j - 1; k >= 0;k-- )
                    {
                        if(Game[k,i].Text!=""){
                            if(Game[k,i].Text==Game[j,i].Text){
                                anDiem = true;
                            }
                            break;
                        }
                    }
                    if (Game[j, i].Text == "")
                    {
                        oRong++;
                    }
                    else
                    {
                        for (int m = j+1; m <= 3; m++)
                        {
                            if (Game[m, i].Text == "")
                            {
                                kTraKhoiTao = true;
                                break;
                            }
                        }
                        if (j-1>=0)
                        {
                            bool ktra = true;
                            
                            for (int k = j -1 ; k >= 0; k--)
                            {
                                if (Game[k, i].Text != "")
                                {
                                    if (Game[j, i].Text == Game[k, i].Text)
                                    {
                                        khongXuongDuoc = false;
                                        lblScore.Text = (int.Parse(lblScore.Text) + int.Parse(Game[ j,i].Text) * 2).ToString();
                                        kTraKhoiTao = true;
                                        ktra = false;
                                        Game[j, i].Text = (int.Parse(Game[j, i].Text) * 2).ToString();
                                        if (oRong != 0)
                                        {
                                            Game[j + oRong, i].Text = Game[j, i].Text;
                                            Game[j, i].Text = "";
                                            
                                        }
                                        Game[k, i].Text = "";
                                        break;

                                    }
                                    break;
                                }
                            }
                            if (ktra == true && oRong != 0)
                            {
                                khongXuongDuoc = false;
                                Game[j + oRong, i].Text = Game[j, i].Text;
                                Game[j, i].Text = "";
                                
                            }
                        }
                        else
                        {
                            if (oRong != 0)
                            {
                                khongXuongDuoc = false;
                                Game[j + oRong, i].Text = Game[j, i].Text;
                                Game[j, i].Text = "";
                                
                            }
                        }


                    }
                }
            }
            if (kTraKhoiTao == true)
            {
                KhoiTaoManGame();
            }
        }
        public void SangTrai()
        {
            bool khongSangTraiDuoc=true;
            bool anDiem = false;
            bool kTraKhoiTao = false;
            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            for (int i = 0; i < 4; i++)
            {
                int oRong = 0;
                for (int j =0; j <4; j++)
                {

                    for (int k = j + 1; k < 4;k++ )
                    {
                        if(Game[i,k].Text!=""){
                            if(Game[i,j].Text==Game[i,k].Text){
                                anDiem = true;
                            }
                            break;
                        }
                    }
                    if (Game[i,j].Text == "")
                    {
                        oRong++;
                    }
                    else
                    {
                        for (int m = j-1; m >= 0; m--)
                        {
                            if (Game[i, m].Text == "")
                            {
                                kTraKhoiTao = true;
                                break;
                            }
                        }
                        if (j + 1 < 4)
                        {
                            bool ktra = true;
                            
                            for (int k = j + 1; k <4; k++)
                            {
                                if (Game[i,k].Text != "")
                                {
                                    
                                    if (Game[i,j].Text == Game[i,k].Text)
                                    {
                                        khongSangTraiDuoc = false;
                                        lblScore.Text = (int.Parse(lblScore.Text) + int.Parse(Game[i, j].Text) * 2).ToString();
                                        kTraKhoiTao = true;
                                        ktra = false;
                                        Game[i,j].Text = (int.Parse(Game[i,j].Text) * 2).ToString();
                                        if (oRong != 0)
                                        {
                                            Game[i,j - oRong].Text = Game[i,j].Text;
                                            Game[i,j].Text = "";
                                            
                                        }
                                        Game[i,k].Text = "";
                                        break;

                                    }
                                    break;
                                }
                            }
                            if (ktra == true && oRong != 0)
                            {
                                khongSangTraiDuoc = false;
                                Game[i,j - oRong].Text = Game[i,j].Text;
                                Game[i,j].Text = "";
                               
                            }
                        }
                        else
                        {
                            if (oRong != 0)
                            {
                                khongSangTraiDuoc = false;
                                Game[i,j - oRong].Text = Game[i, j].Text;
                                Game[i,j].Text = "";
                                
                            }
                        }


                    }
                }
            }
            if (kTraKhoiTao == true)
            {
                KhoiTaoManGame();
            }
        }
        public void SangPhai()
        {
            bool khongSangPhaiDuoc = true;
            bool anDiem=false;
            bool kTraKhoiTao = false;
            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            for (int i = 0; i < 4; i++)
            {
                int oRong = 0;
                for (int j = 3; j >= 0; j--)
                {
                    for (int k = j - 1; k >= 0;k-- )
                    {
                        if(Game[i,k].Text!=""){
                            if(Game[i,k].Text==Game[i,j].Text){
                                anDiem = true;
                            }
                            break;
                        }
                    }
                    if (Game[i,j].Text == "")
                    {
                        oRong++;
                    }
                    else
                    {
                        for (int m = j + 1; m < 4; m++)
                        {
                            if (Game[i,m].Text == "")
                            {
                                kTraKhoiTao = true;
                                break;
                            }
                        }
                        if (j - 1 >= 0)
                        {
                            bool ktra = true;
                            
                            for (int k = j - 1; k >= 0; k--)
                            {
                                if (Game[i,k].Text != "")
                                {
                                    
                                    
                                    if (Game[i,j].Text == Game[i,k].Text)
                                    {
                                        khongSangPhaiDuoc = false;
                                        lblScore.Text = (int.Parse(lblScore.Text) + int.Parse(Game[i, j].Text) * 2).ToString();
                                        kTraKhoiTao = true;
                                        ktra = false;
                                        Game[i,j].Text = (int.Parse(Game[i,j].Text) * 2).ToString();
                                        if (oRong != 0)
                                        {
                                            Game[i, j+oRong].Text = Game[ i,j].Text;
                                            Game[i,j].Text = "";
                                            
                                        }
                                        Game[i,k].Text = "";
                                        break;

                                    }
                                    break;
                                }
                            }
                            if (ktra == true && oRong != 0)
                            {
                                khongSangPhaiDuoc = false;
                                Game[i,j+ oRong].Text = Game[i,j].Text;
                                Game[ i,j].Text = "";
                                
                            }
                        }
                        else
                        {
                            if (oRong != 0)
                            {
                                khongSangPhaiDuoc = false;
                                Game[ i,j + oRong].Text = Game[ i,j].Text;
                                Game[ i,j].Text = "";
                                
                            }
                        }
                    }
                }
            }
            if (kTraKhoiTao == true)
            {
                KhoiTaoManGame();
            }
        }
        public bool KetThuc() {
            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            for (int i = 0; i < 4;i++ )
            {
                for (int j = 0; j < 4;j++ )
                {
                    if(Game[i,j].Text==""){
                        return false;
                    }
                    for (int k = j+1; k < 4;k++ )
                    {
                        if(Game[i,j].Text!=""){
                            if(Game[i,j].Text==Game[i,k].Text){
                                return false;
                            }
                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Game[j, i].Text == "")
                    {
                        return false;
                    }
                    for (int k = j + 1; k < 4; k++)
                    {
                        if (Game[k,i].Text != "")
                        {
                            if (Game[j,i].Text == Game[k,i].Text)
                            {
                                return false;
                            }
                            break;
                        }
                    }
                }
            }
            return true;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (KetThuc() == false)
            {
                if (e.KeyCode == Keys.Up)
                {
                    LenTren();

                }
                if (e.KeyCode == Keys.Down)
                {
                    XuongDuoi();
                }
                if (e.KeyCode == Keys.Left)
                {
                    SangTrai();
                }
                if (e.KeyCode == Keys.Right)
                {
                    SangPhai();
                }
            }
            else {
                continueToolStripMenuItem.Visible = false;
                lblGameOver.Text = "Game Over !!!!!!!!!!!!!!!!!";
                playing = false;
                lblGameOver.Visible = true;
                btnNewGame.Visible = true;
                btnExit.Visible = true;
                btnExit.Enabled = true;
                btnNewGame.Enabled = true;
                this.KeyDown -= new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            }
           
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            lblScore.Text = "0";
            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            lblGameOver.Visible = false;
            btnExit.Visible = false;
            playing = true;
            btnNewGame.Visible = false;
            btnNewGame.Enabled = false;
            btnExit.Enabled = false;
            for (int i = 0; i < 4;i++ )
            {
                for (int j = 0; j < 4;j++ )
                {
                    Game[i, j].Text = "";
                }
            }
            KhoiTaoManGame();
            KhoiTaoManGame();
            KhoiTaoManGame();
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            label1.Visible = true;
            pictureBox1.Visible = true;
            continueToolStripMenuItem.Visible = true;
            lblAbout.Visible = false;
            ptbImage.Visible = false;
            label2.Visible = true;
            lblScore.Visible = true;

            if(playing==false){
                this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            }
            playing = true;
            lblScore.Text = "0";
            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            lblGameOver.Visible = false;
            btnExit.Visible = false;
            btnNewGame.Visible = false;
            btnNewGame.Enabled = false;
            btnExit.Enabled = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Game[i, j].Visible = true;
                    Game[i, j].Text = "";
                }
            }
            KhoiTaoManGame();
            KhoiTaoManGame();
            KhoiTaoManGame();
        }

        private void continueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            pictureBox1.Visible = true;
                lblAbout.Visible = false;
                ptbImage.Visible = false;
                label2.Visible = true;
                lblScore.Visible = true;

                if (playing == false)
                {
                    this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
                }
                Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
                lblGameOver.Visible = false;
                btnExit.Visible = false;
                btnNewGame.Visible = false;
                btnNewGame.Enabled = false;
                btnExit.Enabled = false;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Game[i, j].Visible = true;
                    }
                }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            label1.Visible = false;
            lblGameOver.Visible = false;
            lblScore.Visible = false;
            label2.Visible = false;
            btnNewGame.Visible = false;
            btnExit.Visible = false;
            lblAbout.Visible = true;
            lblAbout.Location = new System.Drawing.Point(0,41);
            lblAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            lblAbout.Text = @"Code by phuchoa3t

                                  Facebook : facebook.com/hackermuxam

                Email : phuchoa3t@gmail.com
                                ";
            lblAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            ptbImage.Visible = true;
            Label[,] Game = { 
                                {lbl1,lbl2,lbl3,lbl4},
                                {lbl5,lbl6,lbl7,lbl8},
                                {lbl9,lbl10,lbl11,lbl12},
                                {lbl13,lbl14,lbl15,lbl16}
                              };
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Game[i, j].Visible = false;
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNewGame_MouseHover(object sender, EventArgs e)
        {
            btnNewGame.BackColor = System.Drawing.Color.Green;
        }

        private void btnNewGame_MouseLeave(object sender, EventArgs e)
        {
            btnNewGame.BackColor = System.Drawing.Color.Orange;
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            btnExit.BackColor = System.Drawing.Color.Green;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = System.Drawing.Color.Orange;
        }

        private void ptbImage_Click(object sender, EventArgs e)
        {

        }


    }
}
