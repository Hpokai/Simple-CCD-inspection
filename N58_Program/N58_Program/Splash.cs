//using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text;
using System.Threading;
using MySplashTestC;//login Splash

namespace JGP_Splash//class name
{
    public class Splasher
    {
        private frmSplash MySplashForm;//宣告一個Splash的Form

        private Thread MySplashThread;//宣告一個Thread
        private void ShowThread()//Thread執行程式
        {
            Application.Run(MySplashForm);//執行Splash
        }

        public string mStatus//狀態執行程式
        {
            get
            {
                if (MySplashForm == null)//如果暫存器裡面的值等於Null執行下面程式
                {
                    return "";//回傳空字串
                }
                else
                {
                    return MySplashForm.Status;//回傳Splash狀態
                }
            }
            set
            {
                if (MySplashForm == null)//如果值等於null執行下面程式
                {
                    return;
                }
                MySplashForm.Status = value;//回傳值給Splash狀態
            }
        }

        public void Show(string strName)
        {
            if (MySplashThread != null)//如果不等於null執行下面程式
            {
                return;
            }

            MySplashForm = new frmSplash();//宣告一個SplashFrom
            this.mStatus = strName;//將strName裡面的字串給mStatus

            MySplashThread = new Thread(new ThreadStart(ShowThread));
            MySplashThread.IsBackground = true;//將Background開啟
            MySplashThread.SetApartmentState(ApartmentState.STA);
            MySplashThread.Start();//啟動Thread
        }

        public void Close()
        {
            if (MySplashThread == null)
            {
                return;
            }
            if (MySplashForm == null)
            {
                return;
            }

            try
            {
                MySplashForm.Invoke(new MethodInvoker(MySplashForm.Close));

            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }

            MySplashForm = null;//關閉Form
            MySplashThread = null;//關閉Thread
        }
    }
}