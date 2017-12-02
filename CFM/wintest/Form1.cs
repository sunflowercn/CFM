using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using win.form.CtrlExt;
using win.Inherit;
using win.Util;
using win;
using win.form.Inherit;
using System.Windows.Forms.DataVisualization.Charting;

namespace wintest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tt();
        }

        public void tt()
        {
            this.chart1.Series[0].Points.Clear();

            float[][] data = new float[6][];
            //5%
            data[5] = new float[19] { 2.2f, 4.1f, 5.8f, 7.2f, 11.1f, 15.4f, 19.3f, 21f, 25.5f, 33.2f, 39.6f, 39.6f, 47.2f, 47.4f, 53.7f, 57.1f, 56.9f, 57.3f, 56.6f };
            //10%
            data[4] = new float[19] { 2.7f, 4.8f, 6.7f, 8.4f, 12.6f, 17.1f, 21.2f, 23.5f, 28.7f, 35.9f, 41.7f, 42.2f, 48.8f, 49.2f, 54.4f, 57.2f, 57.1f, 57.5f, 56.9f };
            //25%
            data[3] = new float[19] { 3.6f, 6f, 8.2f, 10.4f, 15.1f, 20f, 24.6f, 27.7f, 33.9f, 40.5f, 45.3f, 46.5f, 51.6f, 52.2f, 55.6f, 57.3f, 57.4f, 57.7f, 57.3f };
            //50%
            data[2] = new float[19] { 4.5f, 7.3f, 9.8f, 12.6f, 17.9f, 23.2f, 28.3f, 32.3f, 39.8f, 45.5f, 49.3f, 51.3f, 54.6f, 55.6f, 56.9f, 57.8f, 57.8f, 57.9f, 57.7f };
            //75%
            data[1] = new float[19] { 5.4f, 8.6f, 11.4f, 14.8f, 20.7f, 26.4f, 32f, 36.9f, 45.7f, 50.5f, 53.3f, 56.1f, 57.6f, 58f, 58f, 58f, 58f, 58f, 58f };
            //90%
            data[0] = new float[19] { 6.3f, 9.8f, 12.9f, 16.8f, 23.2f, 29.3f, 35.4f, 41.1f, 50.9f, 55.1f, 56.9f, 58f, 58f, 58f, 58f, 58f, 58f, 58f, 58f };

            for (int i = 0; i < data.Length; i++)
            {
                Series ser = new Series();
                ser.ChartType = SeriesChartType.Spline;
               // ser.YValuesPerPoint =12;
                this.chart1.Series.Add(ser);
                //横坐标时间
                //DateTime dt = DateTime.Now.Date;
                //this.chart1.Series series = this.SetSeriesStyle(i);
                for (int j = 0; j < data[i].Length; j++)
                {
                    ser.Points.AddXY(j, data[i][j]);
                   
                }
              
            }

        }
    }
}
