using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YazılımMimarisi.Models.Common;
using YazılımMimarisi.Models.Common.Enums;
using YazılımMimarisi.Models.Entities.Diets;
using YazılımMimarisi.Services.DietMethods;
using YazılımMimarisi.Services.Foods;
using YazılımMimarisi.Services.Interfaces;

namespace YazılımMimarisi
{
    public partial class DiyetYöntemiEkle : Form
    {
        IDietMethodService _dietMethodService;
        IFoodService _foodService;

        public DiyetYöntemiEkle()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            HttpClient _client = new HttpClient();
            _foodService = new FoodService(_client);
            BaseResponse<Food> foodResponse = await _foodService.GetFoodByTag(txtbox_name.Text);
            if (foodResponse.Status.Value == ResponseStatus.Success.Value)
            {
                _client = new HttpClient();
                _dietMethodService = new DietMethodService(_client);
                DietMethod dietMethod = new DietMethod() { Name = txtbox_name.Text, Description = txtbox_description.Text,FoodIds= new List<string>() };
                foreach (var item in foodResponse.Content)
                {
                    dietMethod.FoodIds.Add(item.Id);
                }
                BaseResponse<DietMethod> response = await _dietMethodService.CreateDietMethod(dietMethod);
                if (response.Status.Value == ResponseStatus.Success.Value)
                {
                    MessageBox.Show("Diet yöntemi başarılı bir şekilde eklendi");
                }
                else
                {
                    MessageBox.Show("Diet yöntemi eklenemedi.");
                }
            }
            else
            {
                MessageBox.Show("Diet yöntemi eklenemedi.");
            }
          
        }

        private async void bttn_add_food_Click(object sender, EventArgs e)
        {
            HttpClient _client = new HttpClient();
            _foodService = new FoodService(_client);
            Food food = new Food() {Name=txtbox_food.Text,Tag=new List<string>() { txtbox_name.Text } };
            BaseResponse<Food> response = await _foodService.CreateFood(food);
            if (response.Status.Value == ResponseStatus.Success.Value)
            {
                lst_box_food.Items.Add(txtbox_food.Text);
            }
            else
            { 
                MessageBox.Show("Yemek eklenemedi.");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //KullaniciEkrani sayfasına git
            KullaniciEkrani frm = new KullaniciEkrani();
            frm.Show();
            this.Close();
        }

        private void DiyetYöntemiEkle_Load(object sender, EventArgs e)
        {
            GetAllFoods();
        }

        private async void GetAllFoods()
        {
            HttpClient _client = new HttpClient();
            _foodService = new FoodService(_client);
            BaseResponse<Food> foodResponse = await _foodService.GetFoodByTag(txtbox_name.Text);
            if (foodResponse.Status.Value == ResponseStatus.Success.Value)
            {
                if (foodResponse.Content.Count > 0)
                {
                    Dictionary<string, string> foods = new Dictionary<string, string>();
                    foreach (var item in foodResponse.Content)
                    {
                        foods.Add(item.Id, item.Name);
                    }
                    cmb_box_foods.DataSource = new BindingSource(foods, null);
                    cmb_box_foods.DisplayMember = "Value";
                    cmb_box_foods.ValueMember = "Key";
                }
            }
            else
            {
                MessageBox.Show("Yemekler çekilemedi.");
            }
        }
    }
}
