using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using YazılımMimarisi.Models.Common;
using YazılımMimarisi.Models.Common.Enums;
using YazılımMimarisi.Models.Entities.Persons;
using YazılımMimarisi.Services.Dieticians;
using YazılımMimarisi.Services.Interfaces;

namespace YazılımMimarisi
{
    public partial class AdminPaneli : Form
    {
        IDieticianService _dieticianService;
        public AdminPaneli()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
          //  DiyetisyenEkle sayfasına git
           DiyetisyenEkle frm = new DiyetisyenEkle();
           frm.Show();
           this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Login sayfasına git
            Login frm = new Login();
             frm.Show();
             this.Close();
        }

        private void AdminPaneli_LoadAsync(object sender, EventArgs e)
        {
            DieticiansLoadDataGrid();
        }

        private async void DieticiansLoadDataGrid()
        {
            HttpClient _client = new HttpClient();
            _dieticianService = new DieticianService(_client);
            BaseResponse<Dietician> response = await _dieticianService.GetAllDietician();
            if (response.Status.Value == ResponseStatus.Success.Value)
            {
                LoadDataGridView(response.Content);
            }
            else
            {
                MessageBox.Show("API da bi hata oluştu");
            }
        }
        private void LoadDataGridView(List<Dietician> content)
        {
            DataTable dt = new DataTable();
            //p
            dt.Columns.Add("IDNumber", typeof(string));
            dt.Columns.Add("Username", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("LastName", typeof(string));

            foreach (var item in content)
            { 
                dt.Rows.Add(item.IDNumber,item.Username, item.Name, item.LastName);
            }
            Dictionary<string, string> dictMapping = new Dictionary<string, string>();
            dictMapping.Add("IDNumber", "TC Numarası");
            dictMapping.Add("Username", "Kullanıcı Adı");
            dictMapping.Add("Name", "Adı");
            dictMapping.Add("LastName", "Soyadı");
            dataGridView1.DataSource = dt;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                string colheader = col.HeaderText;
                var key = dictMapping.Keys.FirstOrDefault(k => k == colheader);
                if (key != null)
                    col.HeaderText = dictMapping[key];
            }

        }
    }
}
