using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using ConfinApp.Helpers;
using ConfinApp.Models;
using ConfinApp.Services;
using Microcharts;
using SkiaSharp;
using Xamarin.Forms;

namespace ConfinApp.Views
{
    public partial class EvolucioPage : ContentPage
    {
        public EvolucioPage()
        {
            InitializeComponent();

            LoadChart();
        }

        private async void LoadChart()
        {
            try
            {
                Notify.ShowLoading();

                //await Task.Delay(1000);

                Microcharts.Entry entry;
                List<Microcharts.Entry> defuncionsEntries = new List<Microcharts.Entry>();
                List<Microcharts.Entry> altesEntries = new List<Microcharts.Entry>();
                List<Microcharts.Entry> nousCasosEntries = new List<Microcharts.Entry>();
                List<COVID19_Cat> covidCatData = await PandemicData.GetIncidenciaCatalunya();

                covidCatData = covidCatData.GetRange(0, 21);
                covidCatData.Sort((p, q) => p.Data.CompareTo(q.Data));

                foreach (COVID19_Cat data in covidCatData)
                {
                    entry = new Microcharts.Entry(Int32.Parse(data.Defuncions))
                    {
                        Color = SKColor.Parse("#000000")
                    };

                    defuncionsEntries.Add(entry);

                    entry = new Microcharts.Entry(Int32.Parse(data.Altes == null ? "0" : data.Altes))
                    {
                        Color = SKColor.Parse("#008000")
                    };

                    altesEntries.Add(entry);

                    entry = new Microcharts.Entry(Int32.Parse(data.Casos))
                    {
                        Color = SKColor.Parse("#FF0000")
                    };

                    nousCasosEntries.Add(entry);
                }

                this.chartViewAltes.Chart = new LineChart()
                {
                    Entries = altesEntries,
                    LineMode = LineMode.Straight,
                    LineSize = 8,
                    PointMode = PointMode.None,
                    PointSize = 20,
                };

                this.chartViewNousCasos.Chart = new LineChart()
                {
                    Entries = nousCasosEntries,
                    LineMode = LineMode.Straight,
                    LineSize = 8,
                    PointMode = PointMode.None,
                    PointSize = 20
                };

                this.chartViewDefuncions.Chart = new LineChart()
                {
                    Entries = defuncionsEntries,
                    LineMode = LineMode.Straight,
                    LineSize = 8,
                    PointMode = PointMode.None,
                    PointSize = 20
                };


                COVID19_Cat avui = covidCatData[covidCatData.Count - 1];
                dataActualitzacio.Text = avui.Data.ToShortDateString();
                List<Microcharts.Entry> avuiEntries = new List<Microcharts.Entry>
                {
                    new Microcharts.Entry(Int32.Parse(avui.Total_Defuncions == null ? "0" : avui.Total_Defuncions))
                    {
                        Color = SKColor.Parse("#000000"),
                    },
                    new Microcharts.Entry(Int32.Parse(avui.Total_Altes == null ? "0" : avui.Total_Altes))
                    {
                        Color = SKColor.Parse("#008000"),
                    },
                    new Microcharts.Entry(Int32.Parse(avui.Total_Casos == null ? "0" : avui.Total_Casos))
                    {
                        Color = SKColor.Parse("#FF0000"),
                    }
                };

                this.chartViewAvui.Chart = new DonutChart()
                {
                    Entries = avuiEntries
                };


                COVID19_Cat dosSetmanes = covidCatData[(covidCatData.Count / 2) - 1];
                List<Microcharts.Entry> dosSetmanesEntries = new List<Microcharts.Entry>
                {
                    new Microcharts.Entry(Int32.Parse(dosSetmanes.Total_Defuncions == null ? "0" : dosSetmanes.Total_Defuncions))
                    {
                        Color = SKColor.Parse("#000000"),
                    },
                    new Microcharts.Entry(Int32.Parse(dosSetmanes.Total_Altes == null ? "0" : dosSetmanes.Total_Altes))
                    {
                        Color = SKColor.Parse("#008000"),
                    },
                    new Microcharts.Entry(Int32.Parse(dosSetmanes.Total_Casos == null ? "0" : dosSetmanes.Total_Casos))
                    {
                        Color = SKColor.Parse("#FF0000"),
                    }
                };
                this.chartViewSetmana.Chart = new DonutChart()
                {
                    Entries = dosSetmanesEntries
                };
            }
            catch (Exception)
            {

            }
            finally
            {
                Notify.HideLoading();
            }
        }
    }
}
